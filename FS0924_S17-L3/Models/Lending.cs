using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS0924_S17_L3.Models
{
    public class Lending
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid IdBook { get; set; }

        [Required]
        public Guid IdUser { get; set; }

        public DateTime LendingDate { get; set; }

        public DateTime LendingEnd { get; set; }

        [Required]
        public bool Active { get; set; }

        // navigazione
        [ForeignKey("IdBook")]
        public Book Book { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
