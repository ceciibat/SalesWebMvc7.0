using Microsoft.AspNetCore.Mvc;
using SalesWebMvc7.Models;
using SalesWebMvc7.Models.ViewModels;
using SalesWebMvc7.Services;
using SalesWebMvc7.Services.Exceptions;

namespace SalesWebMvc7.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        } // para aparecer todos os vendedores na tela

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellersFormViewModel { Departments = departments };
            return View(viewModel);
        } // para construir a caixinha com os departamentos

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sellers sellers)
        {
            _sellerService.Insert(sellers);
            return RedirectToAction(nameof(Index));
        } // para criar um novo vendedor

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            SellersFormViewModel viewModel = new SellersFormViewModel { Sellers = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Sellers sellers) 
        {
            if(id != sellers.Id)         // o id do vendedor que estou atualizando, não pode ser diferente do id da url da requisição
            {
                return BadRequest();
            }
            try
            {
                _sellerService.Update(sellers);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
