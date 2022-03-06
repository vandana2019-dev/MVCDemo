using MVC04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using MVC04.ViewModel;

namespace MVC04.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        [HttpGet]
        // Part 38 Check Box List
        public ActionResult Index()
        {
            CityDbContext db = new CityDbContext();
            return View(db.Cities);
        }

        [HttpPost]
        public string Index(IEnumerable<City> cities)
        {
            if(cities.Count( x=> x.IsSelected) == 0)
            {
                return " You did not select any city";
            }
           else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected ");
                foreach(City city in cities)
                {
                    if(city.IsSelected)
                    {
                        sb.Append(city.Name + ", ");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                return sb.ToString();
            }

           
        }

        // Part 39 List Box List
        [HttpGet]
        public ActionResult IndexList()
        {
            CityDbContext db = new CityDbContext();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();

            foreach(City city in db.Cities)
            {
                // This is similar to the Drop down list
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = city.Name,
                    Value = city.Id.ToString(),
                    Selected = city.IsSelected
                };
                listSelectListItems.Add(selectListItem);
            }

            // In the View the data is set as 
            // @Html.ListBoxFor(x => x.SelectedCities, Model.Cities)
            CitiesViewModel citiesViewModel = new CitiesViewModel();
            citiesViewModel.Cities = listSelectListItems;

            return View(citiesViewModel);
        }

        [HttpPost]
        public string IndexList(IEnumerable<string> selectedCities)
        {
            if(selectedCities == null)
            {
                return "You did not select any city";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected " + string.Join(",", selectedCities));
                return sb.ToString();
            }
        }
    }
}