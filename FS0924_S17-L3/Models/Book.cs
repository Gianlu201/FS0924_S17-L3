using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS0924_S17_L3.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Title { get; set; }

        [Required]
        [StringLength(50)]
        public required string Author { get; set; }

        [Required]
        public required bool Available { get; set; }

        public string? Cover { get; set; }

        [Required]
        public Guid GenreId { get; set; }

        [ForeignKey("GenreId")]
        //proprietà di navigazione
        public Genre? Genre { get; set; }

        public ICollection<Lending>? Lendings { get; set; }
    }
}
