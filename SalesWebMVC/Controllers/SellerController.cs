using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
namespace SalesWebMVC.Controllers
{
    public class SellerController : Controller
    {
        private readonly SellerService? _selleService;
        private readonly DepartmentService? _departmentService;
        public SellerController (SellerService selleService, DepartmentService departmentService)
        {
            _selleService = selleService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _selleService!.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService!.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            //_selleService!.Insert(seller);
            //  return RedirectToAction(nameof(Index));
            // Se alguma validação falhar (ex: data vazia), ele devolve a tela
            if (!ModelState.IsValid)
            {
                // TEM QUE BUSCAR OS DEPARTAMENTOS DE NOVO AQUI
                var departments = _departmentService!.FindAll();
                // var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                var viewModel = new SellerFormViewModel { Seller = new Seller(), Departments = departments };
                return View(viewModel); // Devolve a tela com os erros e a lista preenchida
            }

            _selleService!.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _selleService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _selleService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
