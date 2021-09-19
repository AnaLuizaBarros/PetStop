using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStop_API.Controllers
{
    [ApiController]
    [Route("/api/animal")]
    public class AnimalController : ControllerBase
    {
        /// <response code="201">Pet cadastrado com sucesso</response>
        /// <response code="400">Informação inválida</response>
        [HttpPost]
        [Route("/api/animal/CadastrarAnimal")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarAnimal([FromBody] Animal animal)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                db.Set<Animal>().Add(animal);
                db.SaveChanges();

                return Created("OK", animal);
            }
            catch(Exception ex) { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/animal/BuscarAnimalPorNome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarAnimalPorNome(string nome)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                var resultado = db.Animal.Where(p => p.Nome == nome).Take(1).ToList();

                if (resultado is not null && resultado.Count > 0) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }

        }

        [HttpGet]
        [Route("/api/animal/ListarPet/{idEspecie}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarPorEspecie(int idEspecie)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                List<Animal> resultado = db.Animal.Where(p => p.Especie.Especie_ID > 0).ToList();
                resultado = resultado.FindAll(p => p.Especie.Especie_ID == idEspecie);

                if (resultado is not null && resultado.Count > 0) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }

    }
}
