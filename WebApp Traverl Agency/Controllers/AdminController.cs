using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                        .Where(viaggio => viaggio.Id == id).Include(viaggio => viaggio.RichiesteInfo)
                        .FirstOrDefault();
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

        [HttpGet]
        public IActionResult Aggiorna(int id)
        {
            using(TravelContext db = new TravelContext())
            {
                try
                {
                    PacchettoViaggio pacchettoViaggio = db.Pacchetto_Viaggio
                        .Where(x => x.Id == id)
                        .First();
                        return View("Aggiorna", pacchettoViaggio);
                } catch (InvalidOperationException ex)
                {
                    return NotFound("Il pacchetto viaggio non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aggiorna(int id, PacchettoViaggio model)
        {
            if (!ModelState.IsValid)
            {
                return View("Aggiorna", model);
            }

            PacchettoViaggio viaggioToEdit = null;

            using(TravelContext db = new TravelContext())
            {
                viaggioToEdit = db.Pacchetto_Viaggio
                    .Where(viaggio => viaggio.Id == id)
                    .First();

                if (viaggioToEdit == null)
                {
                    return NotFound("Il pacchetto viaggio non è stato trovato");
                }
                else
                {
                    viaggioToEdit.Nome = model.Nome;
                    viaggioToEdit.Immagine = model.Immagine;
                    viaggioToEdit.Descrizione = model.Descrizione; 
                    viaggioToEdit.Durata = model.Durata;
                    viaggioToEdit.NumeroDestinazioni = model.NumeroDestinazioni;
                    viaggioToEdit.Prezzo = model.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Elimina(int id)
        {
            using(TravelContext db = new TravelContext())
            {
                PacchettoViaggio viaggioToDelete = db.Pacchetto_Viaggio
                    .Where(viaggio => viaggio.Id == id)
                    .First();

                if(viaggioToDelete != null)
                {
                    db.Pacchetto_Viaggio.Remove(viaggioToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il pacchetto viaggio non è stato trovato");
                }
            }
        }
    }
}
