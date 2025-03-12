using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FS0924_S17_L3.Models;

namespace FS0924_S17_L3.ViewModels
{
    public class AddLendingViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Book")]
        public Guid IdBook { get; set; }

        [Required]
        [Display(Name = "User")]
        public Guid IdUser { get; set; }

        public DateTime LendingDate { get; set; }

        public DateTime LendingEnd { get; set; }
    }
}
