using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
namespace SalesWebMVC.Controllers
{
    public class SellerController : Controller
    {
        private readonly SellerService? _selleService;
        public SellerController (SellerService selleService)
        {
            _selleService = selleService;
        }

        public IActionResult Index()
        {
            var list = _selleService!.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
           _selleService!.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

    }
}
