using Microsoft.AspNetCore.Mvc;
using SalesWebMvc7.Data;
using SalesWebMvc7.Models.ViewModels;
using System.Diagnostics;

namespace SalesWebMvc7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SalesWebMvc7Context _ctx;

        public HomeController(ILogger<HomeController> logger, SalesWebMvc7Context ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IActionResult Index()
        {

            //var teste = _ctx.Sellers.Select(c => c.Name).ToList();   // mudei sellers

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Sales Web MVC App from C# Course";
            ViewData["Professor"] = "Nelio Alves";
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