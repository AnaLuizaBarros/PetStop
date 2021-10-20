using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStop_API.Models;
using PetStop_API.Util;
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
        [Route("/api/adotante/BuscarAdotante/{Nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarAdotante(string Nome)
        {
            try
            {
                //Implementar busca do adotante
                using var db = new Data.PetStopContext();

                var adotante = db.Adotante.Where(p => p.nome == Nome).Take(1).ToList();

                if (adotante is not null && adotante.Count > 0)
                    return Ok(adotante);
                else
                    return NotFound();
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpDelete]
        [Route("/api/adotante/ExcluirAdotante/{idAdotante}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ExcluirAdotante(int idAdotante)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var adotante = db.Adotante.Find(idAdotante);

                if (adotante is not null)
                {
                    db.Adotante.Remove(adotante);
                    db.SaveChanges();

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
        public IActionResult AdotarAnimal(int id_animal, int id_adotante, int id_doador)
        {
            try
            {
                using var db = new Data.PetStopContext();

                Animal animal = (Animal)db.Animal.Where(p => p.id_animal == id_animal);
                Adotante adotante = (Adotante)db.Adotante.Where(p => p.id_adotante == id_adotante);
                Doador doador = (Doador)db.Doador.Where(p => p.id_doador == id_doador);

                Adocao adocao = new Adocao();
                adocao.dataAdocao = DateTime.Now;
                adocao.Adotante = adotante;
                adocao.Animal = animal;
                adocao.Doador = doador;

                db.Set<Adocao>().Add(adocao);
                db.SaveChanges();

                return Created("OK", adocao);
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}