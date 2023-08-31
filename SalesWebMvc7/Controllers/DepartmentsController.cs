using Microsoft.AspNetCore.Mvc;
using SalesWebMvc7.Models;

namespace SalesWebMvc7.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>
            {
                new Department {Id = 1, Name = "Eletronics"},
                new Department {Id = 2, Name = "Fashion"}
            };

            return View(list);
        }
    }
}
