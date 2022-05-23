using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_Traverl_Agency.Data;
using WebApp_Traverl_Agency.Models;

namespace WebApp_Traverl_Agency.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Homepage");
        }

        [HttpGet]
        public IActionResult Dettagli(int id)
        {
            using (TravelContext db = new TravelContext())
            {
                try
                {
                    PacchettoViaggio viaggioFound = db.Pacchetto_Viaggio
                        .Where(x => x.Id == id)
                        .First();
                    return View("Dettagli", viaggioFound);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Il pacchetto viaggio non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

    }
}