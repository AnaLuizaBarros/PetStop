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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostSalvarAnimal([FromBody] Animal animal)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                Animal pet = new Animal(animal.Id_Animal, animal.Nome, animal.Especie, animal.Pessoa);

                //Inserindo animal na base
                db.Set<Animal>().Add(pet);
                db.SaveChanges();

                return Created("OK", pet);
            }
            catch { return BadRequest(); }
        }

        /// <summary>
        /// Pesquisar um Pet por seu Nome
        /// </summary>
        /// <remarks>
        /// Requisição de exemplo:
        /// { 
        ///     Id = 1 
        /// }
        /// </remarks>
        /// <param name="string">Dados de um Pet</param>
        /// <returns>Objeto retornado com sucesso</returns>
        /// <response code="200">Objeto retornado com sucesso</response>
        /// /// <response code="400">Aconteceu um erro...</response>
        /// <response code="404">Objeto não encontrado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPet(string nome)
        {
            try
            {
                //Verificar se a busca se dará por algum parâmetro específico.

                //Implementar busca do animal
                using var db = new Data.ApplicationContext();

                var resultado = db.Animal.Where(p => p.Nome == nome).Take(1).ToList();

                if (resultado is not null) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }

        }


        [HttpGet("{idEspecie}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetListaPorEspecie(int idEspecie)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                List<Animal> resultado = db.Animal.Select(p => new Animal(p.Id_Animal, p.Nome, p.Especie, p.Pessoa)).ToList();
                resultado = resultado.FindAll(p => p.Especie.Id_Especie == idEspecie);

                if (resultado is not null && resultado.Count > 0) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }

    }
}
