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
        [Route("/api/doador/CadastrarDoador/")]
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

        [HttpPut]
        [Route("/api/doador/EditarDoador/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarDoador([FromBody] Doador doador)
        {
            try
            {
                using var db = new Data.PetStopContext();

                db.Set<Doador>().Update(doador);
                db.SaveChanges();

                return Created("OK", doador);
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/doador/BuscarDoadorPorId/{id:int}")]
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
        [Route("/api/doador/BuscarDoadorPorNome/{Nome}")]
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

        [HttpGet]
        [Route("/api/doador/ListarAnimalPorDoador/{id_Doador:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarAnimalPorDoador(int id_Doador)
        {
            try
            {
                var db = new Data.PetStopContext();

                var animais = (from a in db.Animal
                               where
                               a.id_doador == id_Doador
                               select new
                               {
                                   a.id_animal,
                                   a.nome,
                                   a.id_raca,
                                   imagens = (from im in db.Imagem where a.id_animal == im.id_animal select im).ToList(),
                                   a.id_doador,
                                   a.id_porte,
                                   adotado = (from ad in db.Adocao where a.id_animal == ad.id_animal select ad).Any()
                               });
                if (animais != null && animais.Count() > 0)
                    return Ok(animais);
                else
                    return NotFound("Não foi encontrado nenhum animal vinculado a este doador.");
            }
            catch (Exception) { return NotFound(); }
        }

        [HttpDelete]
        [Route("/api/doador/ExcluirDoadorPorId/{id:int}")]
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