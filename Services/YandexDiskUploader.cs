using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using dotenv.net;
using WebDav;

namespace TitanApp.Services
{
    public static class YandexDiskUploader
    {
        private static string? _token;
        private static WebDavClient? _client;

        static YandexDiskUploader()
        {
            try
            {
                DotEnv.Load();
                _token = Environment.GetEnvironmentVariable("YANDEX_TOKEN");

                if (string.IsNullOrWhiteSpace(_token))
                {
                    MessageBox.Show("⚠️ Переменная YANDEX_TOKEN не найдена в .env", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var paramsBuilder = new WebDavClientParams
                {
                    BaseAddress = new Uri("https://webdav.yandex.ru"),
                    Credentials = new NetworkCredential("webdav", _token)
                };

                _client = new WebDavClient(paramsBuilder);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ошибка инициализации загрузчика: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task<bool> UploadFileAsync(string localPath, string remoteFileName)
        {
            if (_client == null)
            {
                MessageBox.Show("❌ WebDav клиент не инициализирован", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string remotePath = "/titanbot/" + remoteFileName;

            try
            {
                // Проверка и создание папки
                var propResult = await _client.Propfind("/titanbot/");
                if (!propResult.IsSuccessful)
                {
                    var mkcolResult = await _client.Mkcol("/titanbot/");
                    if (!mkcolResult.IsSuccessful)
                        throw new Exception("Не удалось создать папку /titanbot/ на Яндекс.Диске");
                }

                // Загрузка файла
                using var fs = File.OpenRead(localPath);
                var uploadResult = await _client.PutFile(remotePath, fs);

                if (uploadResult.IsSuccessful)
                {
                    MessageBox.Show($"✅ Файл {remoteFileName} успешно загружен на Яндекс.Диск", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                MessageBox.Show($"❌ Ошибка загрузки: {uploadResult.StatusCode} {uploadResult.Description}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Исключение при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
