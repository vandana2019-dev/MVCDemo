using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC04.ViewModel
{
    public class CitiesViewModel
    {
        public string Id { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<string> SelectedCities { get; set; }
    }
}