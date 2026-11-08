using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services.Exceptions;
using System.Diagnostics;

namespace SalesWebMVC.Controllers
{
    public class SellerController : Controller
    {
        private readonly SellerService _selleService;
        private readonly DepartmentService _departmentService;
        public SellerController (SellerService selleService, DepartmentService departmentService)
        {
            _selleService = selleService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _selleService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            //_selleService!.Insert(seller);
            //  return RedirectToAction(nameof(Index));
            // Se alguma validação falhar (ex: data vazia), ele devolve a tela
            if (!ModelState.IsValid)
            {
                // TEM QUE BUSCAR OS DEPARTAMENTOS DE NOVO AQUI
                var departments = await _departmentService.FindAllAsync();
                // var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                var viewModel = new SellerFormViewModel { Seller = new Seller(), Departments = departments };
                return View(viewModel); // Devolve a tela com os erros e a lista preenchida
            }

            await _selleService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provide" });
            }
            var obj = await _selleService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _selleService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provide" });
            }
            var obj = await _selleService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) // teste se o id nao existe
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provide" });
            }
            var obj = await _selleService.FindByIdAsync(id.Value);
            if(obj == null) // teste se o id é nulo
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewmodel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if(id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _selleService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message});
            }
            
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel { Message =message,RequestId=Activity.Current?.Id ?? HttpContext.TraceIdentifier};
            return View(viewModel);

        }

    }
}
