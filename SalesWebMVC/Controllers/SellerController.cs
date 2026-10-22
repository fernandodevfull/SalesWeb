using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
