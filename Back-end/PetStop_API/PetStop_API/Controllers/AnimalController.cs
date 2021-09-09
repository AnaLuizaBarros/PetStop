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
        public IActionResult Post([FromBody] Animal animal)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                Animal pet = new Animal(animal.Id_Animal, animal.Nome, animal.Especie, animal.Pessoa);

                //Inserindo animal na base
                db.Set<Animal>().Add(pet);

                return Created("OK", pet);
            }
            catch { return BadRequest(); }
        }


        //api/pessoa/1...
        /// <summary>
        /// Pesquisar um carro por seu identificador
        /// </summary>
        /// <remarks>
        /// Requisição de exemplo:
        /// { 
        ///     Id = 1 
        /// }
        /// </remarks>
        /// <param name="id">Dados de um Pet</param>
        /// <returns>Objeto retornado com sucesso</returns>
        /// <response code="200">Objeto retornado com sucesso</response>
        /// /// <response code="400">Aconteceu um erro...</response>
        /// <response code="404">Objeto não encontrado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPet([FromBody] Animal animal)
        {
            try
            {
                //Verificar se a busca se dará por algum parâmetro específico.

                //Implementar busca do animal
                using var db = new Data.ApplicationContext();

                var resultado = db.Animal.Where(p => p.Nome == animal.Nome).ToList();

                return Ok(resultado);
            }
            catch { return BadRequest(); }

        }
    }
}
