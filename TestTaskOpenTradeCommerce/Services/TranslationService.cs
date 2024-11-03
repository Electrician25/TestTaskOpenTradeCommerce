using TestTaskOpenTradeCommerce.Entities;
using TestTaskOpenTradeCommerce.Interfaces;

namespace TestTaskOpenTradeCommerce.Services
{
    public class TranslationService : ITranslationService
    {
        public async Task<TranslationEntity> GetTranslationServiceAsync(
            TranslationEntity translationEntity, string requestResult)
        {

            return translationEntity;
        }
    }
}