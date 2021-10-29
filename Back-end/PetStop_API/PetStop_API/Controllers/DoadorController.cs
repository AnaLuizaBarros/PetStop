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
        [Route("/api/doador/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarDoador(int id)
        {
            try
            {
                return Ok(new Data.PetStopContext().Doador.FirstOrDefault(x => x.id_doador == id) ?? new Doador());
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/doador/{Nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarDoador(string Nome)
        {
            try
            {
                return Ok(new Data.PetStopContext().Doador.FirstOrDefault(x => x.nome == Nome) ?? new Doador());
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpDelete]
        [Route("/api/doador/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ExcluirDoador(int id)
        {
            try
            {
                using var db = new Data.PetStopContext();
                var doador = db.Doador.FirstOrDefault(x => x.id_doador == id);
                if (doador != null)
                {
                    db.Doador.Remove(doador);
                    return Ok();
                }
                else
                    return NotFound();
            }
            catch { return BadRequest(); }
        }
    }
}