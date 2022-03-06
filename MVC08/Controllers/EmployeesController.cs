using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC08.Models;
using PagedList;
using PagedList.Mvc;

namespace MVC08.Controllers
{
    public class EmployeesController : Controller
    {
        private SampleDBMVCEntities db = new SampleDBMVCEntities();

        // GET: Employees
        // Part 62 - Implementing Search in MVC
        public ActionResult Index(string searchBy, string search2)
        {
            if (searchBy == "Gender")
            {
                return View(db.Employees.Where(x => x.Gender == search2 || search2 == null).ToList());
            }
            else
            {
                return View(db.Employees.Where(x => x.Name.StartsWith(search2) || search2 == null).ToList());
            }
        }

        // Part 63 - Implement Paging in MVC
        public ActionResult IndexPagedList(string searchBy, string search2, int? page)
        {
            if (searchBy == "Gender")
            {
                return View(db.Employees.Where(x => x.Gender == search2 || search2 == null)
                        .ToList().ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(db.Employees.Where(x => x.Name.StartsWith(search2) || search2 == null)
                      .ToList().ToPagedList(page ?? 1, 3));
            }
        }

        // Part 64 - Implement Sorting in MVC
        public ActionResult IndexPagedSortList(string searchBy, string search2, int? page, string sortBy)
        {
            ViewBag.SortNameParamter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.SortGenderParamter = sortBy == "Gender" ? "Gender desc" : "Gender";

            var employees = db.Employees.AsQueryable();

            if (searchBy == "Gender")
            {
                employees = employees.Where(x => x.Gender == search2 || search2 == null);
            }
            else
            {
                employees = employees.Where(x => x.Name.StartsWith(search2) || search2 == null);
            }

            switch(sortBy)
            {
                case "Name desc":
                    employees = employees.OrderByDescending(x => x.Name);
                    break;
                case "Gender desc":
                    employees = employees.OrderByDescending(x => x.Gender);
                    break;
                case "Gender":
                    employees = employees.OrderBy(x => x.Gender);
                    break;
                default:
                    employees = employees.OrderBy(x => x.Name);
                    break;
            }
           return View(employees.ToPagedList(page ?? 1, 3));
        }

        // Part 65 - Deleting multiple rows in MVC
        //[HttpPost]
        //public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        //{
        //    db.Employees.Where(x => employeeIdsToDelete.Contains(x.ID))
        //            .ToList().ForEach(db.Employees.DeleteObject);
        //    db.SaveChanges();
        // DeleteObject does not work here
        //}




        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Gender,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Gender,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
