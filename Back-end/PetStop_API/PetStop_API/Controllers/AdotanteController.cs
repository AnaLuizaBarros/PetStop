using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStop_API.Models;
using System;
using System.Linq;

namespace PetStop_API.Controllers
{
    [ApiController]
    [Route("/api/adotante")]
    public class AdotanteController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostSalvarAdotante([FromBody] Adotante adotante)
        {
            try
            {
                using var db = new Data.PetStopContext();

                db.Set<Adotante>().Add(adotante);
                db.SaveChanges();

                return Created("OK", adotante);
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/adotante/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarAdotante(int id)
        {
            try
            {
                return Ok(new Data.PetStopContext().Adotante.FirstOrDefault(x => x.id_adotante == id) ?? new Adotante());
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/adotante/{Nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarAdotante(string Nome)
        {
            try
            {
                return Ok(new Data.PetStopContext().Adotante.FirstOrDefault(x => x.nome == Nome) ?? new Adotante());
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpDelete]
        [Route("/api/adotante/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ExcluirAdotante(int id)
        {
            try
            {
                using var db = new Data.PetStopContext();
                var adotante = db.Adotante.FirstOrDefault(x => x.id_adotante == id);
                if (adotante != null)
                {
                    db.Adotante.Remove(adotante);
                    return Ok();
                }
                else
                    return NotFound();
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        [Route("/api/adotante/AdotarAnimal/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AdotarAnimal([FromForm] int id_animal, [FromForm] int id_adotante, [FromForm] int id_doador)
        {
            try
            {
                using var db = new Data.PetStopContext();
                Animal animal = db.Animal.FirstOrDefault(p => p.id_animal == id_animal);
                Adotante adotante = db.Adotante.FirstOrDefault(p => p.id_adotante == id_adotante);
                Doador doador = db.Doador.FirstOrDefault(p => p.id_doador == id_doador);

                if (animal != null && adotante != null && doador != null)
                {
                    Adocao adocao = new()
                    {
                        dataAdocao = DateTime.Now,
                        Adotante = adotante,
                        Animal = animal,
                        Doador = doador
                    };

                    db.Set<Adocao>().Add(adocao);
                    db.SaveChanges();

                    return Created("OK", adocao);
                }
                else
                    return Problem(detail: "Algum(ns) objetos não foram encontrados!", statusCode: 400);
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}