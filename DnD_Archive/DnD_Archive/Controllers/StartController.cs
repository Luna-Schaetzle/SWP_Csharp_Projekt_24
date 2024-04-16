using Microsoft.AspNetCore.Mvc;

namespace DnD_Archive.Controllers
{
    public class StartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
