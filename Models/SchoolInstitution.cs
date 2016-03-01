using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class SchoolInstitution
    {      
        public string SchoolInstitutionID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolPhone { get; set; }

        public virtual ICollection<Department> Departments { get; set; }



    }
}