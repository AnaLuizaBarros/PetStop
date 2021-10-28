using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStop_API.Models;
using System;
using System.Linq;

namespace PetStop_API.Controllers
{
    [ApiController]
    [Route("/api/doador")]
    public class DoadorController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarDoador([FromBody] Doador doador)
        {
            try
            {
                using var db = new Data.PetStopContext();

                db.Set<Doador>().Add(doador);
                db.SaveChanges();

                return Created("OK", doador);
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/doador/BuscarDoador/{Nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarAdotante(string Nome)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var doador = db.Doador.Where(p => p.nome == Nome).Take(1).ToList();

                if (doador is not null && doador.Count > 0)
                    return Ok(doador);
                else
                    return NotFound();
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpDelete]
        [Route("/api/doador/ExcluirDoador/{idAdotante}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ExcluirAdotante(int idAdotante)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var doador = db.Adotante.Find(idAdotante);

                if (doador is not null)
                {
                    db.Adotante.Remove(doador);
                    db.SaveChanges();

                    return Ok();
                }
                else
                    return NotFound();
            }
            catch { return BadRequest(); }
        }
    }
}