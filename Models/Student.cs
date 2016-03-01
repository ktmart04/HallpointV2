using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContosoUniversity.Models
{
    public class Student : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public string ReportCardURL { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        public virtual ICollection<LOTPointTracker> Points { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}