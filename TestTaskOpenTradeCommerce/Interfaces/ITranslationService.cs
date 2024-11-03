using DatabaseCore.DAL.Entities;

namespace TestTaskOpenTradeCommerce.Interfaces
{
    public interface ITranslationService
    {
        public Task<Translation> GetAndSaveTranslationInfo(Translation translationEntity, string requestResult);
    }
}