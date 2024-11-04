using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using TestTaskOpenTradeCommerce.Entities;
using TestTaskOpenTradeCommerce.Interfaces;
using WebCore.Exceptions;

namespace TestTaskOpenTradeCommerce.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class TranslationController(
        IDistributedCache distributedCache,
        IApiRequestHandler apiRequestSenderService,
        ILogger<TranslationController> logger) : ControllerBase
    {
        [HttpPost("Translate")]
        async public Task<List<TranslateJSONEntity>> GetNewTranslationAsync(
            [FromBody] List<TranslateJSONEntity> translationEntity)
        {
            var translationByteaArray = await distributedCache.GetAsync("translation");

            if (translationByteaArray != null)
            {
                var cahce = Encoding.UTF8.GetString(translationByteaArray);

                foreach (var entity in translationEntity)
                {
                    if (cahce.Contains(entity.from)
                        && cahce.Contains(entity.to)
                        && cahce.Contains(entity.q))
                    {
                        return JsonConvert.DeserializeObject<List<TranslateJSONEntity>>(cahce);
                    }

                    else
                        break;
                }
            }

            var requestResult = await apiRequestSenderService.
                SendRequestAndGetResponseAsync(translationEntity);

            var serilazationObject = JsonConvert.SerializeObject(requestResult);

            await distributedCache.SetAsync("translation",
                Encoding.UTF8.GetBytes(serilazationObject));

            return requestResult;
        }

        [HttpGet("AllTranslations")]
        async public Task<List<TranslateJSONEntity>> GetAllTranslationsAsync()
        {
            var translationByteaArray = await distributedCache.GetAsync("translation");

            if (translationByteaArray != null)
            {
                var cachedDataString = Encoding.UTF8.GetString(translationByteaArray);
                var productList = JsonConvert.DeserializeObject<List<TranslateJSONEntity>>(cachedDataString);
                return productList;
            }

            throw new WebCoreNoTranslationDataException();
        }
    }
}