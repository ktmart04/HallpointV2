using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity
{
    public class ApplicationConstants
    {
        /// <summary>
        /// This constant refers to the stored procedure to retrieve the student count totals
        /// </summary>
        public const string StudentCountStoredProc = "EXEC dbo.GetStudentCount";

        /// <summary>
        /// This statement builds a query to get the enrollment count of all students
        /// </summary>
        public const string EnrollmentCountSelectQuery = "SELECT EnrollmentDate, COUNT(*) AS StudentCount " + "FROM Person " + "WHERE Discriminator = 'Student' " + "GROUP BY EnrollmentDate";
    }
}