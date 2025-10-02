using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CloneCode.Domains.Models
{
    public class Book : BaseModel
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("subTitle")] 
        public string Subtitle { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("author")]
        public string Author { get; set; } = string.Empty;

        [Column("publisher")]
        public string Publisher { get; set; } = string.Empty;
        [Column("coverImgUrl")]
        public string ConverImgUrl { get; set; } = string.Empty;


    }
}
