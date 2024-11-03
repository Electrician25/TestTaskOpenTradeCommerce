using TestTaskOpenTradeCommerce.Entities;

namespace TestTaskOpenTradeCommerce.Interfaces
{
    public interface ITranslationService
    {
        public Task<TranslationEntity> GetTranslationServiceAsync(TranslationEntity translationEntity, string requestResult);
    }
}