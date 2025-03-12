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

        // navigazione
        [ForeignKey("IdBook")]
        public required Book Book { get; set; }

        [ForeignKey("IdUser")]
        public required User User { get; set; }
    }
}
