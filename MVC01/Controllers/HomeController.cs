using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC01.Controllers
{
    public class HomeController : Controller
    {

        //public string Index()
        //{
        //    return "Hello from MVC Application";
        //}

        // If we want to pass a parameter, set pass as below
        // The https://localhost:44393/home/index/10, the id can be retrieved here
        //public string Index(string id)
        //{
        //    return "Id = " + id;
        //}

        /// <summary>
        /// If we want to include the Query String
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // https://localhost:44393/home/index/20?name=Test
        //public string Index(string id)
        //{
        //    return "Id = " + id + " Name = " + Request.QueryString["name"];
        //}

        public ActionResult Index()
        {
            ViewBag.Countries =  new List<string>()
            {
                "India",
                "US",
                "UK",
                "Canada"
            };
            ViewData["Countries"] = new List<string>()
            {
                "India",
                "US",
                "UK",
                "Canada"
            };
            return View();
        }

        public string GetDetails()
        {
            return "GetDetails Invoked";
        }
    }

}