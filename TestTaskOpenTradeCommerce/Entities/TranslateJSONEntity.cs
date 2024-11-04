using System.Text.Json.Serialization;

namespace TestTaskOpenTradeCommerce.Entities
{
    public class TranslateJSONEntity
    {
        [JsonPropertyName("FromLanguage")]
        public string? from { get; set; }

        [JsonPropertyName("ToLanguage")]
        public string? to { get; set; }

        [JsonPropertyName("InputText")]
        public string? q { get; set; }

        [JsonPropertyName("OutputText")]
        public string? OutputText { get; set; }
    }
}