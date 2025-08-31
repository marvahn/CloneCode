using Supabase.Postgrest.Attributes;
using System.Text.Json.Serialization;

namespace CloneCode.Application.DTOs.Response
{
    public class ResponseBook
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("Subtitle")]
        public string Subtitle { get; set; } = string.Empty;

        [JsonPropertyName("Description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("Author")]
        public string Author { get; set; } = string.Empty;

        [JsonPropertyName("Publisher")]
        public string Publisher { get; set; } = string.Empty;

        [JsonPropertyName("ConverImgUrl")]
        public string ConverImgUrl { get; set; } = string.Empty;
    }
}
