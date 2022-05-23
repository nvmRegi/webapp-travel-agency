using Microsoft.AspNetCore.Mvc;
using WebApp_Traverl_Agency.Data;
using WebApp_Traverl_Agency.Models;

namespace WebApp_Traverl_Agency.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<PacchettoViaggio> viaggi = new List<PacchettoViaggio>();

            using(TravelContext db = new TravelContext())
            {
                viaggi = db.Pacchetto_Viaggio.ToList<PacchettoViaggio>();
            }
            return View(viaggi);
        }

        [HttpGet]
        public IActionResult Dettagli(int id)
        {
            using(TravelContext db = new TravelContext())
            {
                try
                {
                    PacchettoViaggio viaggioFound = db.Pacchetto_Viaggio
                        .Where(x => x.Id == id)
                        .First();
                    return View("Dettagli", viaggioFound);
                } catch(InvalidOperationException ex)
                {
                    return NotFound("Il pacchetto viaggio non è stato trovato");
                } catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        public IActionResult CreaNuovo()
        {
            PacchettoViaggio model = new PacchettoViaggio();
            return View("CreaNuovo", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreaNuovo(PacchettoViaggio data)
        {
            if (!ModelState.IsValid)
            {
                return View("CreaNuovo", data);
            }

            using(TravelContext db = new TravelContext())
            {
                PacchettoViaggio nuovoViaggio = new PacchettoViaggio();
                nuovoViaggio.Nome = data.Nome;
                nuovoViaggio.Immagine = data.Immagine;
                nuovoViaggio.Descrizione = data.Descrizione;
                nuovoViaggio.Durata = data.Durata;
                nuovoViaggio.NumeroDestinazioni = data.NumeroDestinazioni;
                nuovoViaggio.Prezzo = data.Prezzo;

                db.Add(nuovoViaggio);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
