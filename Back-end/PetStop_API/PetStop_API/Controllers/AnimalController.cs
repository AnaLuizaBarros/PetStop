using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStop_API.Controllers
{
    [ApiController]
    [Route("/api/animal")]
    public class AnimalController : ControllerBase
    {
        [HttpPost]
        [Route("/api/animal/SalvarAnimal")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarAnimal([FromBody] Animal animal)
        {
            try
            {
                using var db = new Data.PetStopContext();

                db.Set<Animal>().Add(animal);
                db.SaveChanges();

                return Created("OK", animal);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [HttpPut]
        [Route("/api/animal/EditarAnimal")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarAnimal([FromBody] Animal animal)
        {
            try
            {
                using var db = new Data.PetStopContext();

                db.Set<Animal>().Update(animal);
                db.SaveChanges();

                return Created("OK", animal);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [HttpGet]
        [Route("/api/animal/BuscarAnimalPorNome/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarAnimalPorNome(string nome)
        {
            try
            {
                return Ok(new Data.PetStopContext().Animal.FirstOrDefault(x => x.nome == nome) ?? new Animal());
            }
            catch(Exception e) { return BadRequest(e); }
        }

        [HttpGet]
        [Route("/api/animal/ListarPorEspecie/especie/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarPorEspecie(int id)
        {
            try
            {
                return Ok(new Data.PetStopContext().Animal.Where(x => x.id_especie == id));
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        [Route("/api/animal/AdicionarImagem/imagens")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AdicionarImagem([FromBody] Imagem imagem)
        {
            try
            {
                using var db = new Data.PetStopContext();
                db.Set<Imagem>().Add(imagem);
                db.SaveChanges();

                return Created("OK", imagem);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [HttpGet]
        [Route("/api/animal/ListarImagens/{id:int}/imagens")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarImagens(int id)
        {
            try
            {
                return Ok(new Data.PetStopContext().Imagem.Where(x => x.id_animal == id).Select(x => x.imagem));
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/doador/FiltrarAnimais")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult FiltrarAnimais(int id_especie = 0, int id_porte = 0)
        {
            try
            {
                var lstAnimais =
                    new Data.PetStopContext().Animal.Where(p =>
                                                            (id_especie == 0 || p.id_especie == id_especie) &&
                                                            (id_porte == 0 || p.id_porte == id_porte));

                if (lstAnimais != null && lstAnimais.Count() > 0)
                    return Ok(lstAnimais);
                else
                    return NotFound("Não foi encontrado nenhum animal vinculado a este doador.");
            }
            catch (Exception) { return NotFound(); }
        }
    }
}