using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConversioCore
{
    public class ConversioClient : IReceiptService
    {
        private readonly string _apiKey;
        public ConversioClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<bool> SendReceiptAsync(SendReceiptRequest receiptRequest)
        {
            var urlEndpoint = new Uri("https://app.conversio.com/api/v1/receipts");
            var settings = new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(receiptRequest, settings);
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-ApiKey", _apiKey);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(urlEndpoint, content);
                // var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    // Do something
                }
                return true;
            }
        }
    }
}