using DatabaseCore.DAL.Entities;
using DatabaseCore.DAL.EntityFramework.DatabaseContext;
using TestTaskOpenTradeCommerce.Interfaces;

namespace TestTaskOpenTradeCommerce.Services
{
    public class TranslationService(
        ApplicationDatabaseContext applicationDatabaseContext) : ITranslationService
    {
        public async Task<Translation> GetAndSaveTranslationInfo(
            Translation translationEntity, string requestResult)
        {
            translationEntity.OutputText = requestResult;
            var translationInfo = await applicationDatabaseContext.AddAsync(translationEntity);
            await applicationDatabaseContext.SaveChangesAsync();
            return translationEntity;
        }
    }
}