using System.ComponentModel.DataAnnotations;

namespace FS0924_S17_L3.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }

        // navigazione
        public ICollection<Lending>? Lendings { get; set; }
    }
}
