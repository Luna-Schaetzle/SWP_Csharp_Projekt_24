using DnD_Archive.Models;
using Microsoft.AspNetCore.Mvc;
using DnD_Archive.Models.DB;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Login(string UserName, string password)
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                ModelState.AddModelError("UserName", "Der Benutzername darf nicht leer sein");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("password", "Das Passwort darf nicht leer sein");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var dbUser = _dbManager.Users.FirstOrDefault(u => u.UserName == UserName);
            if (dbUser == null || !Crypto.VerifyHashedPassword(dbUser.password, password))
            {
                ModelState.AddModelError(string.Empty, "Ungültiger Benutzername oder Passwort");
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, dbUser.UserName),
                new Claim(ClaimTypes.Email, dbUser.email),
                new Claim("UserID", dbUser.UserID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                // Optional: Authentifizierungs-Eigenschaften festlegen
            };

            //Daten in den Cookie schreiben
            HttpContext.Session.SetString("UserID", dbUser.UserID.ToString());
            HttpContext.Session.SetString("UserName", dbUser.UserName);
            HttpContext.Session.SetString("email", dbUser.email);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Start");
        }

        [HttpGet]
        public IActionResult Registrieren()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrieren(string UserName, string email, string password)
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
                    if (!HasMixedCase(user.password) || !HasDigits(user.password) || !HasSpecialChars(user.password))
                    {
                        ModelState.AddModelError("password", "Das Passwort muss Groß- und Kleinbuchstaben, Zahlen und Sonderzeichen enthalten");
                    }
                }
            }

            if (_dbManager.Users.Any(u => u.UserName == user.UserName))
            {
                ModelState.AddModelError("UserName", "Der Benutzername existiert bereits");
            }

            if (_dbManager.Users.Any(u => u.email == user.email))
            {
                ModelState.AddModelError("email", "Die Email existiert bereits");
            }

            if (ModelState.IsValid)
            {
                _dbManager.Users.Add(user);
                _dbManager.SaveChanges();

                return RedirectToAction("Login", "Start");
            }
            else
            {
                return View("Message", new Message()
                {
                    Title = "Registrierung",
                    MessageText = "Es ist ein Fehler aufgetreten!",
                    Solution = "Bitte probieren Sie es erneut!"
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
