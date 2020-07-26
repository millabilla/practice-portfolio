using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeworkTracker.Models {
    public class Homework {

        [Key]
        public int ID { get; set; }

        //fill in necessary components of table

        [Required, DisplayName("Subject")]
        [StringLength(200)]
        public string Department { get; set; }

        [Required, DisplayName("Course Number")]
        public int SubjectNum { get; set; }

        [Required, DisplayName("Assignment")]
        [StringLength(200)]
        public string HomeworkTitle { get; set; }

        [Required, DisplayName("Due Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required, DisplayName("Time Due")]
        public TimeSpan DueTime { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

       
        [Required, DisplayName("Priority")]
        [RegularExpression("^[0-5]*$")]
        public int Importance { get; set; }

        public override string ToString() {
            return $"{base.ToString()}: {Department} {SubjectNum} {HomeworkTitle} {DueDate} {DueTime} {Notes} {Importance}";
        }
    }
}