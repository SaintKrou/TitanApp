using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using dotenv.net;

namespace TitanApp.Services
{
    public static class YandexDiskUploader
    {
        private static readonly string RemoteFolder = "/titanbot/";
        private static string? _token;
        private static readonly HttpClient _httpClient = new();
        private static readonly SemaphoreSlim _uploadLock = new(1, 1);

        private static DateTime _lastUploadTime = DateTime.MinValue;
        private static string? _pendingFilePath;
        private static string? _pendingRemoteName;
        private static bool _uploadInProgress = false;

        public static Action<string>? ShowNotification;

        static YandexDiskUploader()
        {
            try
            {
                DotEnv.Load();
                _token = Environment.GetEnvironmentVariable("YANDEX_TOKEN");

                if (string.IsNullOrWhiteSpace(_token))
                {
                    ShowNotification?.Invoke("Переменная YANDEX_TOKEN не найдена в .env");
                }

                _httpClient.DefaultRequestHeaders.Add("Authorization", $"OAuth {_token}");
            }
            catch (Exception ex)
            {
                ShowNotification?.Invoke($"Ошибка инициализации: {ex.Message}");
            }
        }

        public static async Task<bool> UploadFileAsync(string localFilePath, string remoteFileName)
        {
            await _uploadLock.WaitAsync();

            try
            {
                if (_uploadInProgress)
                {
                    // Уже идёт процесс — сохраняем как ожидающее задание
                    _pendingFilePath = localFilePath;
                    _pendingRemoteName = remoteFileName;
                    return false;
                }

                _uploadInProgress = true;

                var now = DateTime.Now;
                var timeSinceLastUpload = now - _lastUploadTime;

                if (timeSinceLastUpload < TimeSpan.FromMinutes(1))
                {
                    _pendingFilePath = localFilePath;
                    _pendingRemoteName = remoteFileName;

                    var delay = TimeSpan.FromMinutes(1) - timeSinceLastUpload;
                    _ = Task.Run(async () =>
                    {
                        await Task.Delay(delay);
                        await TryUploadPendingAsync();
                    });

                    return false;
                }

                bool result = await InternalUploadAsync(localFilePath, remoteFileName);
                if (result)
                    _lastUploadTime = DateTime.Now;

                _uploadInProgress = false;

                return result;
            }
            finally
            {
                _uploadLock.Release();
            }
        }

        private static async Task TryUploadPendingAsync()
        {
            if (_pendingFilePath == null || _pendingRemoteName == null)
                return;

            await _uploadLock.WaitAsync();

            try
            {
                if (_uploadInProgress)
                    return;

                _uploadInProgress = true;

                bool result = await InternalUploadAsync(_pendingFilePath, _pendingRemoteName);
                if (result)
                {
                    _lastUploadTime = DateTime.Now;
                    _pendingFilePath = null;
                    _pendingRemoteName = null;
                }
                else
                {
                    // Пробуем снова через минуту
                    _ = Task.Run(async () =>
                    {
                        await Task.Delay(TimeSpan.FromMinutes(1));
                        await TryUploadPendingAsync();
                    });
                }

                _uploadInProgress = false;
            }
            finally
            {
                _uploadLock.Release();
            }
        }

        private static async Task<bool> InternalUploadAsync(string localFilePath, string remoteFileName)
        {
            try
            {
                var folderUri = $"https://cloud-api.yandex.net/v1/disk/resources?path={Uri.EscapeDataString(RemoteFolder)}";
                var createResp = await _httpClient.PutAsync(folderUri, null);
                if (!createResp.IsSuccessStatusCode && (int)createResp.StatusCode != 409)
                {
                    return false;
                }

                var uploadUrlReq = $"https://cloud-api.yandex.net/v1/disk/resources/upload?path={Uri.EscapeDataString(RemoteFolder + remoteFileName)}&overwrite=true";
                var uploadResp = await _httpClient.GetAsync(uploadUrlReq);
                if (!uploadResp.IsSuccessStatusCode)
                {
                    return false;
                }

                var json = await uploadResp.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<UploadLinkResponse>(json);

                if (result == null || string.IsNullOrEmpty(result.href))
                {
                    return false;
                }

                using var fileStream = File.OpenRead(localFilePath);
                var uploadContent = new StreamContent(fileStream);
                var finalResp = await _httpClient.PutAsync(result.href, uploadContent);

                if (finalResp.IsSuccessStatusCode)
                {
                    ShowNotification?.Invoke("Файл успешно загружен!");
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private class UploadLinkResponse
        {
            public string? href { get; set; }
            public string? method { get; set; }
            public bool templated { get; set; }
        }
    }
}
