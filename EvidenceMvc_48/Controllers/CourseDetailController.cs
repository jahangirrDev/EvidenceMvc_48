using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidenceMvc_48.Controllers
{
    public class CourseDetailController : System.Web.Mvc.Controller
    {
        MvcCrudDbEntities dbContext = new MvcCrudDbEntities();

        public ActionResult Index()
        {
            List<Course_Subject> courses = dbContext.Course_Subject.ToList();

            return View(courses);
        }


        public ActionResult Create()
        {

            return View(dbContext.Courses.ToList());
        }

        [HttpPost]
        public ActionResult Create(  Course_Subject co_su    )
        {
            try
            {

                string fileName = System.IO.Path.GetFileName(co_su.Book_Image_Http.FileName);
                string savePath = Server.MapPath("~/Images/") + fileName;
                string databasePath = "Images/" + fileName;
                co_su.Book_Image_Http.SaveAs(savePath);
                co_su.Book_Image = databasePath;

                dbContext.Course_Subject.Add(co_su);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

           
           
          
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.CourseList = dbContext.Courses.ToList();
            return View(dbContext.Course_Subject.Where(w => w.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Course_Subject co_su)
        {
            try
            {

                string fileName = System.IO.Path.GetFileName(co_su.Book_Image_Http.FileName);
                string savePath = Server.MapPath("~/Images/") + fileName;
                string databasePath = "Images/" + fileName;
                co_su.Book_Image_Http.SaveAs(savePath);
                co_su.Book_Image = databasePath;

                var co_su_edit = dbContext.Course_Subject.Where(w => w.Id == co_su.Id).FirstOrDefault();
                co_su_edit.Id = co_su.Id;
                co_su_edit.Course_Id = co_su.Course_Id;
                co_su_edit.Is_Major = co_su.Is_Major;
                co_su_edit.Start_Date = co_su.Start_Date;
                co_su_edit.Subject_Name = co_su.Subject_Name;
                co_su_edit.Book_Image = co_su.Book_Image;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public ActionResult Delete(int id)
        {

            var course_subject = dbContext.Course_Subject.Where(w => w.Id == id).FirstOrDefault();
            dbContext.Course_Subject.Remove(course_subject);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}