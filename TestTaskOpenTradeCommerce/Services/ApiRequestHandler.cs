using DatabaseCore.DAL.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TestTaskOpenTradeCommerce.Interfaces;

namespace TestTaskOpenTradeCommerce.Services
{
    public class ApiRequestHandler : IApiRequestHandler
    {
        private const string ApiKey = "fb24d672ebmsh17f3a5c9faa23b4p13710fjsn29986890dc78";
        private const string ApiHost = "rapid-translate-multi-traduction.p.rapidapi.com";
        private const string ApiLink = "https://rapid-translate-multi-traduction.p.rapidapi.com/t";

        async public Task<string> SendRequestAndGetResponseAsync(Translation translationEntity)
        {
            var jsonContent = JsonConvert.SerializeObject(translationEntity);
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(ApiLink),
                Headers =
                {
                    { "x-rapidapi-key", ApiKey },
                    { "x-rapidapi-host", ApiHost },
                },
                Content = new StringContent(jsonContent)
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}