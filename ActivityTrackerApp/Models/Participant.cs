using System.ComponentModel.DataAnnotations;

namespace ActivityTrackerApp.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }

        [Required(ErrorMessage = "Jméno účastníka je povinné")]
        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "Podíl musí být mezi 0 a 100")]
        public double Share { get; set; }
    }
}
