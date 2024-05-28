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
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
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
        public  HomeController(DbManager dbManager)
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



        [HttpGet]
        public async Task<IActionResult> CreateSheet()
        {


            return View();
               
            }
           


        [HttpPost]
        public async Task<IActionResult> CreateSheet(string CharContent)
        {
            //string userId = HttpContext.Session.GetString("UserID");
            string userId = "1";
            int UID = Int32.Parse(userId);
                
            CharacterSheet newCharacter = new CharacterSheet(UID, CharContent);
            
            if (ModelState.IsValid)

            {
              _dbManager.CharacterSheets.Add(newCharacter);
              _dbManager.SaveChanges();

            }
            return View();
        }
    }
}
