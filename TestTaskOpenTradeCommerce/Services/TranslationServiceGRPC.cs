//using Grpc.Core;

//namespace TestTaskOpenTradeCommerce.Services
//{
//    public class TranslationServiceGRPC : Translate.TranslationService.TranslationServiceBase
//    {
//        public override Task<TranslationServiceGRPC> TranslateText(TranslationRequest request, ServerCallContext context)
//        {
//            // Логика перевода
//            var result = new TranslationRequest
//            {
//                OutputText = $"Translated: {request.q}"  // Тут будет твоя логика перевода
//            };
//            return Task.FromResult(result);
//        }
//    }
//}