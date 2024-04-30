using DnD_Archive.Models;
using Microsoft.AspNetCore.Mvc;
using DnD_Archive.Models.DB;

namespace DnD_Archive.Controllers
{
    public class StartController : Controller
    {

        private readonly DbManager _dbManager;

        public StartController(DbManager dbManager)
        {
            _dbManager = dbManager;
        }
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
            //TODO: Feheler Beheben mit REgistrierung 
            //Schauen ob alles richtig ist 
            if (user.UserName != null)
            {
                user.UserName = user.UserName.Trim();
                if (user.UserName.Length < 3)
                {
                    ModelState.AddModelError("UserName", "Der Benutzername muss mindestens 3 Zeichen lang sein");
                }
            }
            if (user.email != null)
            {
                user.email = user.email.Trim();
                if (user.email.Length < 3)
                {
                    ModelState.AddModelError("email", "Die Email muss mindestens 3 Zeichen lang sein");
                }
            }
            if (user.password != null)
            {
                user.password = user.password.Trim();
                if (user.password.Length < 8)
                {
                    ModelState.AddModelError("password", "Das Passwort muss mindestens 8 Zeichen lang sein");
                }
            }
            if (ModelState.IsValid)
            {
                _dbManager.Users.Add(user);
                _dbManager.SaveChanges();
                return View("Message", new Message()
                {
                    Title = "Registrierung",
                    MessageText = "Sie haben sich erfolgreich registriert!"
                });
            }
            else
            {
                return View("Message", new Message()
                {
                    Title = "Registrierung",
                    MessageText = "Es ist ein Fehler aufgetreten!",
                    Solution = "Bitte Probieren Sie es erneut!"
                });
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
