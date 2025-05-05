using System;
using System.ComponentModel.DataAnnotations;

namespace ActivityTrackerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Uživatelské jméno je povinné")]
        public string Username { get; set; }
    }
}
