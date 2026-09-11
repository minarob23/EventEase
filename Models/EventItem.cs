using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class EventItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}