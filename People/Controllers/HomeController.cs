using Microsoft.AspNetCore.Mvc;
using People.Models;
using System.Diagnostics;

namespace People.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //GET: Employee - Add
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }


        //POST: Employee - Add
        [HttpPost]
        public IActionResult Add(MdlPeopleApp model)
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
