using System.ComponentModel.DataAnnotations;

namespace UniConnect.Modals
{
    public class LostFoundItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a date")]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a type")]
        public string Type { get; set; } = string.Empty; 

        public string? ImageUrl { get; set; }

        public DateTime PostedAt { get; set; }
    }
}