using Microsoft.AspNetCore.Mvc;
using TestTaskOpenTradeCommerce.Entities;
using TestTaskOpenTradeCommerce.Interfaces;

namespace TestTaskOpenTradeCommerce.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class TranslationController(
        ITranslateCacheHandler cacheHandler,
        ILogger<TranslationController> logger) : ControllerBase
    {
        [HttpPost("Translate")]
        async public Task<List<TranslateJSONEntity>> GetNewTranslationAsync(
            [FromBody] List<TranslateJSONEntity> translationEntity)
        {
            return await cacheHandler.SetTransaltionCache(translationEntity);
        }
    }
}