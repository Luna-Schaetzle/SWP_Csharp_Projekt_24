using Microsoft.AspNetCore.Mvc;

namespace DnD_Archive.Controllers
{
    public class StartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrieren()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
