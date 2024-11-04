using TestTaskOpenTradeCommerce.Entities;

namespace TestTaskOpenTradeCommerce.Interfaces
{
    public interface IApiRequestHandler
    {
        public Task<List<TranslateJSONEntity>> SendRequestAndGetResponseAsync(List<TranslateJSONEntity> translationEntity);
    }
}