using Supabase.Postgrest.Attributes;

namespace CloneCode.Application.DTOs.Response
{
    public class ResponseBook
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Subtitle { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;
        public string ConverImgUrl { get; set; } = string.Empty;
    }
}
