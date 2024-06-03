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

       
    }
}
