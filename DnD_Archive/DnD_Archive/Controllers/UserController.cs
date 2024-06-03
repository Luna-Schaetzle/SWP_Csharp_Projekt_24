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
        public async Task<IActionResult> Edit()
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
