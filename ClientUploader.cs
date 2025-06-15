using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TitanApp.Models;

namespace TitanApp.Data
{
    public static class ClientUploader
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiUrl = "https://titanbot-ls2g.onrender.com/upload/clients";

        public static async Task UploadClientsAsync(IEnumerable<Client> clients)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync(apiUrl, clients);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Данные успешно отправлены на API:");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при отправке клиентов на API:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
