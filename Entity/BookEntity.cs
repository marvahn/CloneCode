
using System.ComponentModel.DataAnnotations.Schema;

namespace CloneCode.Entity
{
    [Table("Review")]
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "TIMESTAMP")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "TEXT")]
        public string Content { get; set; } = string.Empty;

        [Column(TypeName = "TEXT")]
        public string Author { get; set; } = string.Empty;

        [Column(TypeName = "INT4")]
        public int BookId { get; set; }

    }
}
