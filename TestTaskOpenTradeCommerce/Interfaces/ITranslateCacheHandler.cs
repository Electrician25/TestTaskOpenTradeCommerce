using TestTaskOpenTradeCommerce.Entities;

namespace TestTaskOpenTradeCommerce.Interfaces
{
    public interface ITranslateCacheHandler
    {
        public Task<List<TranslateJSONEntity>> SetTransaltionCache(List<TranslateJSONEntity> translationEntity);
    }
}