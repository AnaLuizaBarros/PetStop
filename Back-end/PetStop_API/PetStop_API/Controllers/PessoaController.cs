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
            Pessoa pes = new Pessoa(pessoa.Nome, pessoa.CPF, pessoa.Nacionalidade);

            //Aqui salvar informações no banco de dados

            return Created("OK", pes);
        }
    }
}
