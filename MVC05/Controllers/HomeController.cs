using MVC05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC05.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Part 52 – Partial Views in MVC
            var db = new SampleDBMVC();
            return View(db.Employees.ToList());
        }
        public ActionResult IndexPartial()
        {
            // Part 52 – Partial Views in MVC
            var db = new SampleDBMVC();
            return View(db.Employees.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            // Part 40 - Initialize based on the class created from edmx
            // public partial class SampleDBMVC : DbContext
            var db = new SampleDBMVC();
            Employee employees = db.Employees.Single(x => x.EmployeeId == id);
            return View(employees);
        }

        public ActionResult EmployeeDetails(int id)
        {
            // Part 43 - Opening a page in new browser window
            var db = new SampleDBMVC();
            Employee employees = db.Employees.Single(x => x.EmployeeId == id);
            return View(employees);
        }

        public ActionResult EmployeeDisplayDetails(int id)
        {
            //Part 44 - Display and Edit templated helpers in MVC
            // public partial class SampleDBMVC : DbContext
             var db = new SampleDBMVC();
            Employee employees = db.Employees.Single(x => x.EmployeeId == id);
            return View(employees);
        }

        public ActionResult EmployeeDisplayDetailsView(int id)
        {
            //Part 44 - Display and Edit templated helpers in MVC
            // public partial class SampleDBMVC : DbContext
            var db = new SampleDBMVC();
            Employee employees = db.Employees.Single(x => x.EmployeeId == id);
            // In the View , we use it as  @Html.Display("EmployeeData")
            ViewData["EmployeeData"] = employees;
            return View();
        }

        public ActionResult Edit(int id)
        {
            //Part 44 - Display and Edit templated helpers in MVC
            // public partial class SampleDBMVC : DbContext
            var db = new SampleDBMVC();
            Employee employees = db.Employees.Single(x => x.EmployeeId == id);
            return View(employees);
        }

        public ActionResult EmployeeDetailsImagesView(int id)
        {
           // Part 47 - Displaying Images in MVC
            var db = new SampleDBMVC();
            Employee employees = db.Employees.Single(x => x.EmployeeId == id);
            return View(employees);
        }
    }
}