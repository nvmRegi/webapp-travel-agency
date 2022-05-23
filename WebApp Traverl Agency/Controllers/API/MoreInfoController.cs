using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp_Traverl_Agency.Data;
using WebApp_Traverl_Agency.Models;

namespace WebApp_Traverl_Agency.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoreInfoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<RichiestaInfo> listaRichieste = new List<RichiestaInfo>();
            if(listaRichieste.Count == 0)
            {
                return Ok(listaRichieste); 
            }

            using(TravelContext db = new TravelContext())
            {
                listaRichieste = db.Richiesta_Informazioni.ToList();
                return Ok(listaRichieste);
            }
        }

        [HttpPost]
        public IActionResult AggiungiRichiesta([FromBody]RichiestaInfo data)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            using(TravelContext db = new TravelContext())
            {
                List<RichiestaInfo> listaRichieste = db.Richiesta_Informazioni.ToList();
                listaRichieste.Add(data);

                return Ok(listaRichieste);
            }
        }

    }
}
