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
        /// <summary>
        /// Cadastrar um Pet
        /// </summary>
        /// <remarks>
        /// Requisição de exemplo:
        /// {
        ///     "Nome": "Snoop",
        ///     "Data Nascimento": "01-01-2000",
        ///     "Email": "dono@gmail.com",
        ///     "CEP": "12345678",
        ///     "Endereco": "Rua Primeiro de Janeiro",
        ///     "Cidade": "Belo Horizonte",
        ///     "Bairro": "Centro",
        ///     "Complemento": "Casa"
        /// }
        /// </remarks>
        /// <param name="model">Dados de um novo Pet</param>
        /// <returns>Objeto recém criado</returns>
        /// <response code="201">Pet cadastrado com sucesso</response>
        /// <response code="400">Informação inválida</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Animal animal)
        {
            Animal pet = new Animal(animal.Nome, animal.DataNascimento, animal.Email, animal.Cep, animal.Endereco, animal.Bairro, animal.Complemento, animal.Cidade);

            //_dbContext.Carros.Add(carro);
            //_dbContext.SaveChanges();

            return Created("OK", pet);
        }
    }
}
