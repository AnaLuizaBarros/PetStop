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
    [Route("/api/pessoa")]
    public class PessoaController : ControllerBase
    {
        /// <response code="201">Pessoa cadastrado com sucesso</response>
        /// <response code="400">Informação inválida</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostPessoa([FromBody] Pessoa pessoa)
        {
            //int id, string nome, int idade, string cpf, DateTime dt_Nascimento, string email, Alergia alergia, Animal animal, Endereco endereco
            Pessoa pes = new Pessoa(pessoa.Id, pessoa.Nome, pessoa.Idade, pessoa.Cpf, pessoa.Dt_Nascimento, pessoa.Email, pessoa.Alergia, pessoa.Animal, pessoa.Endereco);

            //Aqui salvar informações no banco de dados

            return Created("OK", pes);
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
        /// <param name="id">Dados de uma Pessoa</param>
        /// <returns>Objeto retornado com sucesso</returns>
        /// <response code="200">Objeto retornado com sucesso</response>
        /// /// <response code="400">Aconteceu um erro...</response>
        /// <response code="404">Objeto não encontrado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPessoa()
        {
            //Implementar busca do adotante

            return Ok("ok");

        }
    }
}
