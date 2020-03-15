namespace HW8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public Event() {
            //default constructor
        }
        public int ID { get; set; }

        public int LocationID { get; set; }

        [Required]
        [StringLength(5)]
        public string Distance { get; set; }

        public bool? Hurdles { get; set; }

        public int? AthleteID { get; set; }

        public float? RaceTimes { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Location Location { get; set; }
    }
}
