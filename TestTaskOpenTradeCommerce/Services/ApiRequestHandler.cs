using Newtonsoft.Json;
using System.Net.Http.Headers;
using TestTaskOpenTradeCommerce.Entities;
using TestTaskOpenTradeCommerce.Interfaces;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace TestTaskOpenTradeCommerce.Services
{
    public class ApiRequestHandler : IApiRequestHandler
    {
        async public Task<List<TranslateJSONEntity>> SendRequestAndGetResponseAsync(
            List<TranslateJSONEntity> translationEntity)
        {
            var apiKey = ConfigurationManager.AppSettings.Get("ApiKey");

            var apiHost = ConfigurationManager.AppSettings.Get("ApiHost");

            var apiLink = ConfigurationManager.AppSettings.Get("ApiLink");

            var result = new List<TranslateJSONEntity>();

            foreach (var translate in translationEntity)
            {
                var jsonContent = JsonConvert.SerializeObject(translate);
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(apiLink),
                    Headers =
                    {
                        { "x-rapidapi-key", apiKey },
                        { "x-rapidapi-host", apiHost },
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

                var resultTranslation = await response.Content.ReadAsStringAsync();

                translate.OutputText = resultTranslation;
                result.Add(translate);
            }

            return result;
        }
    }
}