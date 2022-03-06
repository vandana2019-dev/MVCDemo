using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeneralClassLibrary47Framework;

namespace MVC03.Controllers
{
    public class EmployeeController : Controller
    {
         
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        //[HttpPost]
        // Below works using the form collection
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    // The values entered for the corresponding form element can be found
        //    foreach(string key in formCollection.AllKeys)
        //    {
        //        Response.Write("Key =" + key + " ");
        //        Response.Write(formCollection[key]);
        //        Response.Write("<br/>");
        //    }

        //    Employee employee = new Employee();
        //    employee.Name = formCollection["Name"];
        //    employee.Gender = formCollection["Gender"];
        //    employee.City = formCollection["City"];
        //    employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);

        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employeeBusinessLayer.AddEmployee(employee);

        //    return RedirectToAction("Index");
        //   // return View();
        //}


        // The above one is using the Form Collection, we can also pass the form name as each parameter
        // We can right click the form and see the name of each control
        // We pass each form element 
        //[HttpPost]
        //public ActionResult Create(string name, string gender, string city, DateTime dateofBirth)
        //{
        //    Employee employee = new Employee();
        //    employee.Name = name;
        //    employee.Gender = gender;
        //    employee.City = city;
        //    employee.DateOfBirth = dateofBirth;

        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employeeBusinessLayer.AddEmployee(employee);

        //    return RedirectToAction("Index");
        //    // return View();
        //}

        // Instead of passing each form element, we can just pass the Employee model

        //[HttpPost]
        //public ActionResult Create(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        // get the Latest data from the Form using UpdateModel
        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee employee = new Employee(); // Here the new object is created
        //         UpdateModel(employee); // UpdateModel gets the values from the form 
        //       // UpdateModel throws an exception if validation fails, that is required fields
        //       // set up in the Employee Model are not present

        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Employee employee = new Employee(); // Here the new object is created
            TryUpdateModel(employee);  // returns a Boolean and if not valid 

            if (ModelState.IsValid) // if the above TryUpdateModel returns false, that means Model State is not valid and returns false
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.ID == id);
            return View(employee);
        }

        //[HttpPost]
        //public ActionResult Edit(Employee employee)
        //{
        //    if (ModelState.IsValid) // If the Model State is not valid returns false
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        // Part 20 include properties in the Update Model
        //[HttpPost]
        //[ActionName("Edit")]
        //// To Prevent Unintended updates use id
        //public ActionResult Edit_Post(int id)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    Employee employee = employeeBusinessLayer.Employees.Single(x => x.ID == id);
        //    UpdateModel(employee, new string[] { "ID", "Gender", "City", "DateOfBirth" });
        //    // gets the posted form values automatically
        //    // Include only the mentioned properties

        //    if (ModelState.IsValid) // If the Model State is not valid returns false
        //    {
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        //// Part 21 include properties using the Bind
        //[HttpPost]
        //[ActionName("Edit")]
        //// To Prevent Unintended updates use id
        /// public ActionResult Edit_Post([Bind(Exclude ="Name")]Employee employee)
        //public ActionResult Edit_Post([Bind(Include ="Id, Gender, City, DateOfBirth")]Employee employee)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    // Get the Name of the Employee , just for checking and retreival
        //    employee.Name = employeeBusinessLayer.Employees.Single(x => x.ID == employee.ID).Name;

        //    // gets the posted form values automatically
        //    // Include only the mentioned properties

        //    if (ModelState.IsValid) // If the Model State is not valid returns false
        //    {
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        // Part 22 Include and Exclude propertires from Model
        [HttpPost]
        [ActionName("Edit")]
        // To Prevent Unintended updates use id
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            // Get the Name of the Employee , just for checking and retreival
            Employee employee = employeeBusinessLayer.Employees.Single(x => x.ID == id);
            UpdateModel<IEmployee>(employee); // Update the properties related to the interface
            // gets the posted form values automatically
            // Include only the mentioned properties

            if (ModelState.IsValid) // If the Model State is not valid returns false
            {
                employeeBusinessLayer.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}