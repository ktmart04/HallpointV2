using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            // Commenting out LINQ to show how to do the same thing in SQL. 
            //IQueryable<EnrollmentDateGroup> = from student in db.Students 
            // group student by student.EnrollmentDate into dateGroup 
            // select new EnrollmentDateGroup() 
            // { 
            // EnrollmentDate = dateGroup.Key, 
            // StudentCount = dateGroup.Count() 
            // };

            // SQL version of the above LINQ code. 
           //ApplicationConstants.EnrollmentCountSelectQuery

            IEnumerable<StudentPointStatusGroup> data = db.Database.SqlQuery<StudentPointStatusGroup>(ApplicationConstants.StudentCountStoredProc);


            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}