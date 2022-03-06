using MVC10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC10.Controllers
{
    public class HomeController : Controller
    {
        SampleDBMVCEntities1 sampleDBMVCEntities1 = new SampleDBMVCEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult IndexSearch()
        {
           
            return View(sampleDBMVCEntities1.Students);
        }

        [HttpPost]
        public ActionResult IndexSearch(string searchTerm)
        {
            List<Student> students;
            if(string.IsNullOrEmpty(searchTerm))
            {
                students = sampleDBMVCEntities1.Students.ToList();
            }
            else
            {
                students = sampleDBMVCEntities1.Students.Where(x => x.Name.StartsWith(searchTerm)).ToList();
            }
            return View(students);
        }

        public JsonResult Getstudents(string searchTerm)
        {

            List<string> students;
            students = sampleDBMVCEntities1.
                        Students.Where(x => x.Name.StartsWith(searchTerm))
                        .Select(y => y.Name).ToList();

            return Json(students, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult All()
        {
            System.Threading.Thread.Sleep(4000);
            List<Student> model = sampleDBMVCEntities1.Students.ToList();
            return PartialView("_Student", model);
        }

        public PartialViewResult Top3()
        {
            System.Threading.Thread.Sleep(4000);
            List<Student> model = sampleDBMVCEntities1.
                                  Students.OrderByDescending(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }

        public PartialViewResult Bottom3()
        {
            System.Threading.Thread.Sleep(4000);
            List<Student> model = sampleDBMVCEntities1.
                                  Students.OrderBy(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }
    }
}