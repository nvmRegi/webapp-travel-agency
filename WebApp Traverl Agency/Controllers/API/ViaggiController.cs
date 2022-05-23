﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp_Traverl_Agency.Data;
using WebApp_Traverl_Agency.Models;

namespace WebApp_Traverl_Agency.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ViaggiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? cerca)
        {
            List<PacchettoViaggio> listaViaggi = new List<PacchettoViaggio>();

            using(TravelContext db = new TravelContext())
            {
                if(cerca != null)
                {
                    listaViaggi = db.Pacchetto_Viaggio
                        .Where(viaggio => viaggio.Nome.Contains(cerca) || viaggio.Descrizione.Contains(cerca))
                        .ToList();
                }
                else
                {
                    listaViaggi = db.Pacchetto_Viaggio.ToList();
                }
            }
            return Ok(listaViaggi);
        }
    }
}
