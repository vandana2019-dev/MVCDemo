using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC01.Models;

namespace MVC01.Controllers
{
    public class EmployeeDBController : Controller
    {
        // GET: EmployeeDB
       
        public ActionResult Index()
        {
            EmployeeDBContext employeeContext = new EmployeeDBContext();
            List<EmployeeDB> employees = employeeContext.Employees.ToList();
            return View(employees);
        }

        // This refers to  @Html.ActionLink(employee.Name, "Details", new { id = employee.EmployeeId })
        public ActionResult Details(int id)
        {
            EmployeeDBContext employeeContext = new EmployeeDBContext();
            EmployeeDB employee = employeeContext.Employees.Single(emp => emp.EmployeeId == id);
            return View(employee);
        }
    }
}