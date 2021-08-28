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
            Animal pet = new Animal(animal.Nome, animal.DataNascimento, animal.Email, animal.Cep, animal.Endereco, animal.Bairro, animal.Complemento, animal.Cidade);

            //Implementar salavr no banco

            return Created("OK", pet);

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
        public IActionResult GetPet()
        {
            //Implementar busca do animal

            return Ok("ok");

        }
    }
}
