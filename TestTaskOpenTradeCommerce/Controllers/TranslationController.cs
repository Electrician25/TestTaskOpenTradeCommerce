using Microsoft.AspNetCore.Mvc;
using TestTaskOpenTradeCommerce.Entities;
using TestTaskOpenTradeCommerce.Interfaces;

namespace TestTaskOpenTradeCommerce.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class TranslationController(
        ITranslationService translationService,
        IApiRequestHandler apiRequestSenderService) : ControllerBase
    {
        [HttpPost("TranslateText")]
        async public Task<TranslationEntity> GetTranslationAsync(
            [FromBody] TranslationEntity translationEntity)
        {
            var requestResult = await apiRequestSenderService.SendRequestAsync(translationEntity);
            return await translationService.GetTranslationServiceAsync(translationEntity, requestResult);
        }
    }
}