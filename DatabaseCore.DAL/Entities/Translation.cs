using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseCore.DAL.Entities
{
    public class Translation
    {
        [Key]
        public Guid Id { get; set; }

        [JsonPropertyName("from")]
        public string? FromLanguage { get; set; }

        [JsonPropertyName("to")]
        public string? ToLanguage { get; set; }

        [JsonPropertyName("q")]
        public string? InputText { get; set; }
        public string? OutputText { get; set; }
    }
}