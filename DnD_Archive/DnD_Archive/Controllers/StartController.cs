using DnD_Archive.Models;
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

        [HttpGet]
        public IActionResult Registrieren()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrieren(User user)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
