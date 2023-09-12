using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc7.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
