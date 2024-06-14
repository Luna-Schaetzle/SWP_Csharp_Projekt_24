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
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Web;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Localization;


namespace DnD_Archive.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly DbManager _dbManager;

        private readonly MarkdownService _markdownService;


        /*   public HomeController(ILogger<HomeController> logger)
           {
               _logger = logger;
           }
        */
        public HomeController(DbManager dbManager, MarkdownService markdownService)
        {
            _dbManager = dbManager;
            _markdownService = markdownService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignalRChat()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OpenSheet()
        {
            /*string userId = HttpContext.Session.GetString("UserID");
            int UID = Int32.Parse(userId);

            //foreach

            var characterSheets = await _dbManager.CharacterSheets.ToListAsync();

            // foreach wo uid richtig is, neue liste
            return View(characterSheets); */

            //foreach
            var UserID = HttpContext.Session.GetString("UserID");
            var UserID2 = int.Parse(UserID); //String in Int umwandeln


            var characterSheets = _dbManager.CharacterSheets.Where(u => u.UserdId == UserID2).ToList(); //Benutzer aus Datenbank holen

            // foreach wo uid richtig is, neue liste
            return View(characterSheets);
        }


        [HttpPost]
        public async Task<IActionResult> OpenSheet(int id)
        {
            string userId = HttpContext.Session.GetString("UserID");
            int UID = Int32.Parse(userId);
            id = UID;

            var sheet = await _dbManager.CharacterSheets.FindAsync(id);
            if (sheet == null)
            {
                return NotFound();
            }
            return View(sheet);
        }


        public async Task<IActionResult> DeleteSheet(int id)
        {
            var characterSheet = _dbManager.CharacterSheets.FirstOrDefault(c => c.SheetId == id);

            if (characterSheet == null)
            {
                return NotFound("Character sheet not found for the given SheetID.");
            }
            else
            {
                _dbManager.CharacterSheets.Remove(characterSheet);
            }

            _dbManager.SaveChangesAsync();


            return View();
        }


        public IActionResult DisplayMarkdown(int id)
        {


            // Abrufen des CharacterSheet f�r die angegebene SheetID
            var characterSheet = _dbManager.CharacterSheets.FirstOrDefault(c => c.SheetId == id);
            if (characterSheet == null)
            {
                return NotFound("Character sheet not found for the given SheetID.");
            }

            // Den Markdown-Text aus dem CharContent-Feld des abgerufenen CharacterSheet-Objekts
            string markdownText = characterSheet.CharContent;

            // Markdown in HTML umwandeln
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var htmlContent = Markdown.ToHtml(markdownText, pipeline);

            // HTML-Inhalt an die View �bergeben
            ViewData["HtmlContent"] = htmlContent;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RollDice()
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
        public async Task<IActionResult> CreateSheet(string Name, string CharContent)
        {
            string userId = HttpContext.Session.GetString("UserID");
            //string userId = "1";
            int UID = Int32.Parse(userId);

            CharacterSheet newCharacter = new CharacterSheet(UID, CharContent, Name);

            if (ModelState.IsValid)

            {
                _dbManager.CharacterSheets.Add(newCharacter);
                _dbManager.SaveChanges();

            }
            return View();
        }


        //Sprache wechseln 

        public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return RedirectToAction(nameof(Index));
    }
    }
}
