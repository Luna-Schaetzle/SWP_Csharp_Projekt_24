using Microsoft.AspNetCore.Mvc;
using DnD_Archive.Models;
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
using Microsoft.Extensions.Configuration.UserSecrets;


namespace DnD_Archive.Controllers
{
    [Authorize]
    public class SpellController : Controller
    {

        private readonly DbManager _dbManager;

        public SpellController(DbManager dbManager)
        {
            _dbManager = dbManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var UserID = HttpContext.Session.GetString("UserID");
            var UserID2 = int.Parse(UserID);
            var spell = new Spells();
            spell.UserID = UserID2;
            return View(spell);
        }

    }
}
