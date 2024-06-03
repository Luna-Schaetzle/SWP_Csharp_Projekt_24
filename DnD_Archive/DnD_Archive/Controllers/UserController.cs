using DnD_Archive.Models;
using Microsoft.AspNetCore.Mvc;
using DnD_Archive.Models.DB;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Markdig;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.InteropServices;
using Microsoft.DiaSymReader;

namespace DnD_Archive.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly DbManager _dbManager;

        public UserController(DbManager dbManager)
        {
            _dbManager = dbManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> edit()
        {
            var UserID = HttpContext.Session.GetString("UserID");
            var UserID2 = int.Parse(UserID);
            var user = await _dbManager.Users.FindAsync(UserID2);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> edit(String UserName, String email)
        {
            //Schauen ob der Benutzername schon vergeben ist
            var userCheck = _dbManager.Users.FirstOrDefault(u => u.UserName == UserName);
            if (userCheck != null && userCheck.UserName != HttpContext.Session.GetString("UserName"))
            {
                //Error View anzeigen
                return View("Message_2", new Message()
                {
                    Title = "Benutzername bereits vergeben",
                    MessageText = "Der Benutzername ist bereits vergeben. Bitte wählen Sie einen anderen Benutzernamen."

                });
            }
            //Schauen ob die Email schon vergeben ist
            var emailCheck = _dbManager.Users.FirstOrDefault(u => u.email == email);
            if (emailCheck != null && emailCheck.email != HttpContext.Session.GetString("email"))
            {
                //Error View anzeigen
                return View("Message_2", new Message()
                {
                    Title = "Email bereits vergeben",
                    MessageText = "Die Email ist bereits vergeben. Bitte wählen Sie eine andere Email."

                });
            }

            var UserID = HttpContext.Session.GetString("UserID");
            var UserID2 = int.Parse(UserID);
            var user = await _dbManager.Users.FindAsync(UserID2);
            if (user == null)
            {
                return NotFound();
            }
            user.UserName = UserName;
            user.email = email;
            _dbManager.Update(user);
            await _dbManager.SaveChangesAsync();
            //Session variable aktualisieren
            HttpContext.Session.SetString("UserName", UserName);
            HttpContext.Session.SetString("email", email);
            return RedirectToAction("overview");
        }



        public IActionResult overview()
        {
            //Aus Session den Benutzernamen holen
            var UserID = HttpContext.Session.GetString("UserID");
            var UserID2 = int.Parse(UserID); //String in Int umwandeln
            var user = _dbManager.Users.FirstOrDefault(u => u.UserID == UserID2); //Benutzer aus Datenbank holen
            return View(user);
        }



        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //change password
        [HttpPost]
        public async Task<IActionResult> ChangePassword(String password)
        {
            if (password.Length < 8){
                return View("Message_2", new Message()
                {
                    Title = "Passwort nicht sicher",
                    MessageText = "Das Passwort muss mindestens 8 Zeichen lang sein und Groß- und Kleinbuchstaben, Zahlen und Sonderzeichen enthalten."

                });
            }
            else{
            var UserID = HttpContext.Session.GetString("UserID");
            var UserID2 = int.Parse(UserID);
            var user = await _dbManager.Users.FindAsync(UserID2);
            if (user == null)
            {
                return NotFound();
            }
            user.password = Crypto.HashPassword(password);
            _dbManager.Update(user);
            await _dbManager.SaveChangesAsync();
            return RedirectToAction("overview");
            }
        }

        private bool HasSpecialChars(string password)
        {
            if (password.Any(c => !char.IsLetterOrDigit(c)))
            {
                return true;
            }
            return false;
        }

        private bool HasDigits(string password)
        {
            if (password.Any(c => char.IsDigit(c)))
            {
                return true;
            }
            return false;
        }

        private bool HasMixedCase(string password)
        {
            if (password.Any(c => char.IsUpper(c)) && password.Any(c => char.IsLower(c)))
            {
                return true;
            }
            return false;
        }

        public async Task<IActionResult> DeleteAsync()
        {
            var UserID = HttpContext.Session.GetString("UserID");
            var UserID2 = int.Parse(UserID);
            var user = await _dbManager.Users.FindAsync(UserID2);
            if (user == null)
            {
                return NotFound();
            }

            // Delete the user
            _dbManager.Users.Remove(user);
            await _dbManager.SaveChangesAsync();

            // Clear session variables
            HttpContext.Session.Clear();

            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Start");
        }

    }
}
