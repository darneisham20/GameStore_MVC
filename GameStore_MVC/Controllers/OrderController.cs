using Microsoft.AspNetCore.Mvc;

namespace GameStore_MVC.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
