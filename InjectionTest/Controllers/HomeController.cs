using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InjectionTest.Models;
using Unity.Attributes;

namespace InjectionTest.Controllers
{
    public class HomeController : Controller
    {
	    private IFirstService _firstService;

		[Dependency]
		public ISecondService SecondService { get; set; }

	    public HomeController(IFirstService firstService)
	    {
		    _firstService = firstService;
	    }

        public IActionResult Index()
        {
	        ViewData["CC"] = _firstService != null ? "yes" : "no";
	        ViewData["CA"] = SecondService != null ? "yes" : "no";
	        ViewData["SA"] = _firstService?.SecondService != null ? "yes" : "no";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
