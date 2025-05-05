using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActivityTrackerApp.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Datum je povinné")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Množství je povinné")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Doba trvání je povinná")]
        public string Duration { get; set; }

        public string WithWhom { get; set; }

        [Required(ErrorMessage = "Způsob provedení je povinný")]
        public string ActivityMethod { get; set; }

        public bool EnableGraphTracking { get; set; }

        [Range(1, 10, ErrorMessage = "Hodnocení musí být mezi 1 a 10")]
        public int OverallRating { get; set; }

        public string Feeling { get; set; }

        [Range(1, 10, ErrorMessage = "Síla musí být mezi 1 a 10")]
        public int Strength { get; set; }

        public string ExecutionWay { get; set; }
        public string Atmosphere { get; set; }
        public string Place { get; set; }
        public string SleepQuality { get; set; }
        public string FoodConsumed { get; set; }

        public List<Quote> Quotes { get; set; } = new List<Quote>();
        public List<Participant> Participants { get; set; } = new List<Participant>();
    }
}
