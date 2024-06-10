using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace DnD_Archive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiceController : ControllerBase
    {
        private readonly Random _random = new Random();

        [HttpGet("roll/{sides}")]
        public ActionResult<int> RollDice(int sides)
        {
            if (sides <= 0)
            {
                return BadRequest("Die Anzahl der Seiten muss größer als 0 sein.");
            }

            int result = _random.Next(1, sides + 1);
            return Ok(result);
        }


        /*  
        public IActionResult Index()
        {
            return Ok("Hello World");
        }
        */
    }
}
