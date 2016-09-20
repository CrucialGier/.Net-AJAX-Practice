using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AJAXFun.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AJAXFun.Controllers
{
    public class HomeController : Controller
    {
        private AjaxDemoContext db = new AjaxDemoContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HelloAjax()
        {
            return Content("Hello from the controller!", "text/plain");
        }
        public IActionResult Sum(int firstNumber, int secondNumber)
        {
            return Content((firstNumber + secondNumber).ToString(), "text/plain");
        }

        public IActionResult DisplayLocationWithAjax(string city, string country, int id)
        {
            Destination newDestination = new Destination(city, country, id);
            return View(newDestination);
        }

        public IActionResult RandomDestinationList(int destinationCount)
        {
            List<Destination> randomDestinationList = db.Destinations.OrderBy(r => Guid.NewGuid()).Take(destinationCount).ToList();
            return Json(randomDestinationList);
        }

        public IActionResult DisplayViewWithAjax()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewDestination(string newCity, string newCountry)
        {
            Destination newDestination = new Destination(newCity, newCountry);
            db.Destinations.Add(newDestination);
            db.SaveChanges();
            return Json(newDestination);
        }
    }
}
