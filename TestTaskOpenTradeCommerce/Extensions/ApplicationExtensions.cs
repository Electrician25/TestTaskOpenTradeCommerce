﻿using TestTaskOpenTradeCommerce.Interfaces;
using TestTaskOpenTradeCommerce.Services;

namespace TestTaskOpenTradeCommerce.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serivce)
        {
            return serivce.AddTransient<ITranslationService, TranslationService>()
                .AddTransient<IApiRequestHandler, ApiRequestHandler>();
        }
    }
}