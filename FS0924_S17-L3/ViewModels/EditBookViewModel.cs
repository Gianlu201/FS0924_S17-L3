using System.ComponentModel.DataAnnotations;

namespace FS0924_S17_L3.ViewModels
{
    public class EditBookViewModel
    {
        public Guid Id { get; set; }

        [StringLength(
            50,
            ErrorMessage = "Name must contain from 2 to 50 chars!",
            MinimumLength = 2
        )]
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [StringLength(
            50,
            ErrorMessage = "Author must contain from 2 to 50 chars!",
            MinimumLength = 2
        )]
        [Display(Name = "Author")]
        public string? Author { get; set; }

        [Display(Name = "Genre")]
        public Guid? GenreId { get; set; }

        [Display(Name = "Available")]
        public bool Available { get; set; }

        [Display(Name = "Cover")]
        public string? Cover { get; set; }
    }
}
