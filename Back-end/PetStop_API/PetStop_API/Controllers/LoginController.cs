using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStop_API.Models;
using System;
using System.Linq;

namespace PetStop_API.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("/api/login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login([FromBody] Login login)
        {
            try
            {
                using var db = new Data.PetStopContext();
                var usuario =
                    login.tipo == 0 ?
                        db.Doador.Where(p => p.email == login.email && p.senha == login.senha).Take(1).ToList<dynamic>() :
                        db.Adotante.Where(p => p.email == login.email && p.senha == login.senha).Take(1).ToList<dynamic>();
                if (usuario.Count > 0)
                    return Ok(usuario[0]);
                else
                    return NotFound();
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}