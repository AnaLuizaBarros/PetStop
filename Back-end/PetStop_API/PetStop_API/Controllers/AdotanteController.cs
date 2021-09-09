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
    [Route("/api/adotante")]
    public class AdotanteController : ControllerBase
    {
        //private readonly DevCarsDbContext _dbContext;
        //private readonly string _connectionstring;

        /// <response code="201">Adotante cadastrado com sucesso</response>
        /// <response code="400">Informação inválida</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Adotante adotante)
        {
            Adotante adt = new Adotante(adotante.Id, adotante.Nome, adotante.Idade, adotante.Cpf, adotante.Dt_Nascimento, adotante.Email, adotante.Animal, adotante.Alergia, adotante.Endereco);

            //Implementar salvar no banco

            return Created("OK", adt);

        }

        //api/adotante/1...
        /// <summary>
        /// Pesquisar um carro por seu identificador
        /// </summary>
        /// <remarks>
        /// Requisição de exemplo:
        /// { 
        ///     Id_Adotante = 1 
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
        public IActionResult GetAdotante()
        {
            //Implementar busca do adotante

            return Ok("ok");

        }
    }
}
