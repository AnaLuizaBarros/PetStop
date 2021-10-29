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
        [Route("/api/animal")]
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
            catch (Exception) { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/animal/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarAnimalPorNome(string nome)
        {
            try
            {
                return Ok(new Data.PetStopContext().Animal.FirstOrDefault(x => x.nome == nome) ?? new Animal());
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/animal/especie/{id:int}")]
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
    }
}