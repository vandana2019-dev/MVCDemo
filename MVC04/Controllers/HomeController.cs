using MVC04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC04.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();
        //public ActionResult Index()
        //{
        //    // Part 33 Html Helpers

        //    // Part 34 - Generating a dropdown list control
        //    // Populate a dropdown from a database
        //    //ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");

           
        
        //    return View();
        //}

        public ActionResult Index()
        {
            //   Part 35 select the Department with Id 1
            //   ViewBag.Departments = new SelectList(db.Departments, "Id", "Name","1");

            // Part 35 select the Department with IsSelected value in the DB
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach(Department department in db.Departments)
            {
                // Set the SelectListItem Text, Value and Selected from the DB
                // department.IsSelected.Value will be true, if in the DB it is set to 1
                // If Multiple rows are selected , then the latest is shown
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = department.Name,
                    Value = department.Id.ToString(),
                    Selected = department.IsSelected.HasValue ? department.IsSelected.Value : false
                };

                selectListItems.Add(selectListItem);
            }


            ViewBag.Departments = selectListItems;
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            // Part 36 - Difference between Html TextBox and HtmlTextBoxFor
            Company company = new Company("Pragim");

            // In the View give it as - @Html.DropDownList("Departments", "Select Department")
            ViewBag.Departments = new SelectList(company.Departments, "Id", "Name");
            ViewBag.CompanyName = company.CompanyName;
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            // strongly typed passing the Model to the View
            Company company = new Company("Pragim");
            return View(company);
        }

        [HttpPost]
        public string Contact(Company company)
        {
            // Part 37 - Generating a RadioButtonList control in MVC using HTML helpers
            // The value is set for selected Department (@Html.RadioButtonFor(m => m.SelectedDepartment
            // @department.Name is the text which is displayed
            if (string.IsNullOrEmpty(company.SelectedDepartment))
            {
                return "You did not select any department";
            }
            else
            {
                return "You selected department with Id =" + company.SelectedDepartment;
            }
        }
    }
}