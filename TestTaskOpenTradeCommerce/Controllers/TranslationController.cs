using DatabaseCore.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
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
        async public Task<Translation> GetTranslationAsync(
            [FromBody] Translation translationEntity)
        {
            var requestResult = await apiRequestSenderService.SendRequestAndGetResponseAsync(translationEntity);
            return await translationService.GetAndSaveTranslationInfo(translationEntity, requestResult);
        }
    }
}