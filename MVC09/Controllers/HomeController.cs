using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC09.Models.Common;

namespace MVC09.Controllers
{
    // Part 70 - Authorize and AllowAnonymous action filters
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult SecureMethod()
        {
            return View();
        }

        public ActionResult NonSecureMethod()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Countries(List<string> countryNames)
        {
            return View(countryNames);
        }

        [HandleError]
        public ActionResult HandleError()
        {
            throw new Exception("Something went wrong");
        }

        // Part 75 Require Https attribute in MVC
        [RequireHttps]
        public string RequireHttps()
        {
            return "This method should be accessed only using HTTPS protocol";
        }
        
        // Part 76 ValidateInput attribute in MVC
        public ActionResult ValidateInput()
        {
            return View();
        }

        [HttpPost]
        public string ValidateInput(string comments)
        {
            return "Your comments:" + comments;
        }

        // Part 77 Custom Action Filters
        [TrackExecutionTime]
        public string IndexActionInvoked()
        {
            return "Index action invoked";
        }
    }
}