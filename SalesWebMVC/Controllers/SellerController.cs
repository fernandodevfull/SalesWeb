using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

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
    }
}
