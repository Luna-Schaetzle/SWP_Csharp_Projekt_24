using DnD_Archive.Models;
using DnD_Archive.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace DnD_Archive.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly DbManager _dbManager;


     /*   public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
     */
        public HomeController(DbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateSheet()
        {
            return View();
        }

        public IActionResult DeleteSheet()
        {
            return View();
        }

        public IActionResult OpenSheet()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult Edit(String UserName, String password)
        {
            //UserName Trimen Falls nicht null
            if (UserName != null)
            {
                UserName = UserName.Trim();
            }
            //Passwort & UserName schauen ob es null ist
            if (password == null)
            {
                ModelState.AddModelError("password", "Das Passwort darf nicht leer sein");
            }
            if (UserName == null)
            {
                ModelState.AddModelError("UserName", "Der Benutzername darf nicht leer sein");
            }

            //Schauen das der UserName 3 Zeichen hat
            if (UserName.Length < 3)
            {
                ModelState.AddModelError("UserName", "Der Benutzername ist mindestens 3 Zeichen lang");
            }


            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            var content = await _dbManager.CharacterSheets.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CharacterSheet content)
        {
            if (ModelState.IsValid)

            {
                _dbManager.CharacterSheets.Add(content);
                await _dbManager.SaveChangesAsync();
                return RedirectToAction(nameof(OpenSheet), new { id = content.SheetId });
            }
            return View(content);
        }
    }
}
