using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TitanApp.Models;

namespace TitanApp.Services
{
    /// <summary>
    /// Сервис фоновой синхронизации списка клиентов с REST‑API.
    /// Делает первую попытку сразу, затем — повторные каждые 10 секунд,
    /// пока не получит успешный ответ. После успешной синхронизации
    /// останавливается до следующего InvalidateSync().
    /// </summary>
    public class ApiSyncService
    {
        private readonly string apiUrl = "https://titanbot-ls2g.onrender.com/upload/clients";
        private readonly HttpClient httpClient = new();

        private System.Threading.Timer? retryTimer;
        private bool isSyncInProgress;
        private bool syncSuccessful;

        private List<Client> clientsToSend = new();

        /// <summary>Сообщения общего статуса (отображаются в lblNotifications).</summary>
        public event Action<string>? StatusChanged;

        /// <summary>Статус связи с хостом (отображается в lblHostStatus).</summary>
        public event Action<string>? HostStatusChanged;

        /// <summary>Статус Telegram‑бота (отображается в lblTelegramStatus).</summary>
        public event Action<string>? TelegramStatusChanged;

        /// <summary>
        /// Запускает синхронизацию с заданным набором клиентов.
        /// </summary>
        public void TriggerSync(List<Client> clients)
        {
            clientsToSend = clients;
            StartSync();
        }

        /// <summary>
        /// Сбрасывает флаг успешной синхронизации, чтобы начать новую.
        /// </summary>
        public void InvalidateSync()
        {
            syncSuccessful = false;
            StartSync();
        }

        /// <summary>
        /// Позволяет внешнему коду сообщить о статусе Telegram‑бота.
        /// </summary>
        public void UpdateTelegramStatus(string message) => TelegramStatusChanged?.Invoke(message);

        // ----------------- приватная логика -----------------

        private void StartSync()
        {
            if (isSyncInProgress || syncSuccessful) return;

            isSyncInProgress = true;
            Task.Run(SendClientsAsync);
        }

        private async Task SendClientsAsync()
        {
            try
            {
                HostStatusChanged?.Invoke("Хост: отправка данных…");

                var json = JsonSerializer.Serialize(clientsToSend);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    syncSuccessful = true;
                    //HostStatusChanged?.Invoke("Хост: синхронизация успешна");
                    //StatusChanged?.Invoke($"Успешно отправлено {clientsToSend.Count} клиентов");
                    StopRetry();
                }
                else
                {
                    //HostStatusChanged?.Invoke($"Хост: ошибка {response.StatusCode}");
                    //StatusChanged?.Invoke("Синхронизация не удалась — повтор через 10 с");
                    StartRetry();
                }
            }
            catch (Exception ex)
            {
                //HostStatusChanged?.Invoke("Хост: ошибка соединения");
                //StatusChanged?.Invoke("Синхронизация не удалась: " + ex.Message);
                StartRetry();
            }
            finally
            {
                isSyncInProgress = false;
            }
        }

        private void StartRetry()
        {
            retryTimer ??= new System.Threading.Timer(_ => StartSync(), null, 10_000, 10_000);
        }

        private void StopRetry()
        {
            retryTimer?.Dispose();
            retryTimer = null;
        }
    }
}
