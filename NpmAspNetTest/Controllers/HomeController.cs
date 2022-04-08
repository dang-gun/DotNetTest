using Microsoft.AspNetCore.Mvc;

namespace NpmAspNetTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}