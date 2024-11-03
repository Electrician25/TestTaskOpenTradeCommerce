using Newtonsoft.Json;

namespace TestTaskOpenTradeCommerce.Entities
{
    public class TranslationEntity
    {
        [JsonProperty("from")]
        public string? FromLanguage { get; set; }

        [JsonProperty("to")]
        public string? ToLanguage { get; set; }

        [JsonProperty("q")]
        public List<string>? InputText { get; set; }
    }
}