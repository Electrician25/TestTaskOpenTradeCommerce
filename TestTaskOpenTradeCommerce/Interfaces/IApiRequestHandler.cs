using TestTaskOpenTradeCommerce.Entities;

namespace TestTaskOpenTradeCommerce.Interfaces
{
    public interface IApiRequestHandler
    {
        public Task<string> SendRequestAsync(TranslationEntity translationEntity);
    }
}
