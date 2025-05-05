using System.ComponentModel.DataAnnotations;

namespace ActivityTrackerApp.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }

        [Required(ErrorMessage = "Text hlášky je povinný")]
        public string Text { get; set; }
    }
}
