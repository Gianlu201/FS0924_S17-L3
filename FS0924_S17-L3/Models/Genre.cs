using System.ComponentModel.DataAnnotations;

namespace FS0924_S17_L3.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }

        // proprietà di navigazione
        public ICollection<Book>? Books { get; set; }
    }
}
