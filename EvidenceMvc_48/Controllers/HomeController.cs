using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidenceMvc_48.Controllers
{
    public class HomeController : Controller
    {

        MvcCrudDbEntities dbContext = new MvcCrudDbEntities();
        // GET: Home
        public ActionResult Index()
        {
           List<Course> courses =   dbContext.Courses.ToList();

            return View(courses);
        }



        [HttpPost]
        public ActionResult Index(List<HttpPostedFileBase> files)
        {
            List<Course> courses = dbContext.Courses.ToList();

            return View(courses);
        }

        

        public ActionResult Edit(int id)
        {

            return View(dbContext.Courses.Where(w => w.Id == id).FirstOrDefault());
        }
    }
}