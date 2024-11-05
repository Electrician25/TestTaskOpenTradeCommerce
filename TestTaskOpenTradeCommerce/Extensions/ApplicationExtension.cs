using TestTaskOpenTradeCommerce.Interfaces;
using TestTaskOpenTradeCommerce.Services;

namespace TestTaskOpenTradeCommerce.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection serivce)
        {
            return serivce.AddTransient<IApiRequestHandler, ApiRequestHandler>()
                .AddTransient<ITranslateCacheHandler, TranslateCacheHandler>();
        }
    }
}