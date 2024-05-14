using DnD_Archive.Models;
using Microsoft.AspNetCore.Mvc;
using DnD_Archive.Models.DB;
using System.Web.Helpers;


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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String UserName, String password)
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
            if (UserName?.Length < 3)
            {
                ModelState.AddModelError("UserName", "Der Benutzername ist mindestens 3 Zeichen lang");
            }


            return Login(new User()
            {
                UserName = UserName,
                password = password
            });
        }

        public IActionResult Login(User user)
        {


            //Die Daten aus der Datenbank holen
            var dbUser = _dbManager.Users.FirstOrDefault(u => u.UserName == user.UserName);
            //Wenn der User nicht existiert
            if (dbUser == null)
            {
                ModelState.AddModelError("UserName", "Der Benutzername existiert nicht");
            }
            //Überprüfen ob das Passwort stimmt
            else if (!Crypto.VerifyHashedPassword(dbUser.password, user.password))
            {
                ModelState.AddModelError("password", "Das Passwort ist falsch");
            }

            //Wenn es keine Fehler gibt
            if (ModelState.IsValid)
            {
                //Session erstellen und die Parameter speichern
                HttpContext.Session.SetString("UserName", dbUser.UserName);
                HttpContext.Session.SetInt32("UserID", dbUser.UserID);
                HttpContext.Session.SetString("email", dbUser.email);
                //TODO: Weiterleitung zur Home-Seite
                return View("Message", new Message()
                {
                    Title = "Login",
                    MessageText = "Sie haben sich erfolgreich eingeloggt!"
                });
            }
            else
            {
                return View("Message", new Message()
                {
                    Title = "Login",
                    MessageText = "Es ist ein Fehler aufgetreten!",
                    Solution = "Bitte Probieren Sie es erneut!"
                });
            }

        }



        [HttpGet]
        public IActionResult Registrieren()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrieren(String UserName, String email, String password)
        {
            var hashedPassword = Crypto.HashPassword(password);
            User user = new User()
            {
                UserName = UserName,
                email = email,
                password = hashedPassword
            };
            return Registrieren(user);
        }

        public IActionResult Registrieren(User user)
        {
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
                else
                {
                    // Beispiel für eine zusätzliche Passwortstärkenvalidierung (z.B. auf Zeichenvielfalt)
                    if (!HasMixedCase(user.password) || !HasDigits(user.password) || !HasSpecialChars(user.password))
                    {
                        ModelState.AddModelError("password", "Das Passwort muss Groß- und Kleinbuchstaben, Zahlen und Sonderzeichen enthalten");
                    }
                }
            }
            // Suchen ob der User schon mit dem Namen existiert
            if (_dbManager.Users.Any(u => u.UserName == user.UserName))
            {
                ModelState.AddModelError("UserName", "Der Benutzername existiert bereits");
            }
            // Suchen ob die Email schon existiert
            if (_dbManager.Users.Any(u => u.email == user.email))
            {
                ModelState.AddModelError("email", "Die Email existiert bereits");
            }
            if (ModelState.IsValid)
            {
                // TODO: weiterleitung zur Home-Seite
                _dbManager.Users.Add(user);
                _dbManager.SaveChanges();
                // Session erstellen und die Parameter speichern
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetInt32("UserID", user.UserID);
                HttpContext.Session.SetString("email", user.email);
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

        private bool HasMixedCase(string password)
        {
            return password.Any(char.IsLower) && password.Any(char.IsUpper);
        }

        private bool HasDigits(string password)
        {
            return password.Any(char.IsDigit);
        }

        private bool HasSpecialChars(string password)
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }



        public IActionResult Privacy()
        {
            return View();
        }
    }
}
