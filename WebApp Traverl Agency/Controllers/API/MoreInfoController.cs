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
            using(TravelContext db = new TravelContext())
            {
                List<RichiestaInfo>  listaRichieste = db.Richiesta_Informazioni.ToList();
                return Ok(listaRichieste);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]RichiestaInfo model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            using (TravelContext db = new TravelContext())
            {
                db.Add(model);
                db.SaveChanges();
                return Ok();
            }
        }

    }
}
