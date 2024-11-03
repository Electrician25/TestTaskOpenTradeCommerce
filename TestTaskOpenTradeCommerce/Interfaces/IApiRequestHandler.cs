using DatabaseCore.DAL.Entities;

namespace TestTaskOpenTradeCommerce.Interfaces
{
    public interface IApiRequestHandler
    {
        public Task<string> SendRequestAndGetResponseAsync(Translation translationEntity);
    }
}