using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]
        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}






/* When there is a one-to-zero-or-one relationship or a one-to-one relationship between 
 * two entities (such as between OfficeAssignment and Instructor), EF can't work out which 
 * end of the relationship is the principal and which end is dependent. One-to-one relationships 
 * have a reference navigation property in each class to the other class. The ForeignKey Attribute 
 * can be applied to the dependent class to establish the relationship. If you omit the ForeignKey 
 * Attribute, you get the following error when you try to create the migration: */