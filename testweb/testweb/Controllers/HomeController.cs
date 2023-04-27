using Microsoft.AspNetCore.Mvc;

namespace testweb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult blog()
        {
            return View();
        }
    }
}
