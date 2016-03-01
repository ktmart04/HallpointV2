using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        //The question mark after the Grade type declaration indicates that the Grade property is nullable.
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        //property is a foreign key, and the corresponding navigation property
        public virtual Course Course { get; set; }

        //property is a foreign key, and the corresponding navigation property
        public virtual Student Student { get; set; }
    }
}