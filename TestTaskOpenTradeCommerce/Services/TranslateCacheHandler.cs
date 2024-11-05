using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using TestTaskOpenTradeCommerce.Entities;
using TestTaskOpenTradeCommerce.Interfaces;

namespace TestTaskOpenTradeCommerce.Services
{
    public class TranslateCacheHandler(
        IDistributedCache distributedCache,
        IApiRequestHandler apiRequestSenderService)
        : ITranslateCacheHandler
    {
        public async Task<List<TranslateJSONEntity>> SetTransaltionCache(
            List<TranslateJSONEntity> translationEntity)
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
                }
            }

            var requestResult = await apiRequestSenderService.
                SendRequestAndGetResponseAsync(translationEntity);

            var serilazationObject = JsonConvert.SerializeObject(requestResult);

            await distributedCache.SetAsync("translation",
                Encoding.UTF8.GetBytes(serilazationObject));

            return requestResult;
        }
    }
}