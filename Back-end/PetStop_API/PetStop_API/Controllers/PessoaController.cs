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
        [HttpPost]
        [Route("/api/pessoa/CadastrarPessoa")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarPessoa([FromBody] Pessoa pessoa)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                db.Set<Pessoa>().Add(pessoa);
                db.SaveChanges();

                return Created("OK", pessoa);
            }
            catch(Exception ex) { return BadRequest(); }
        }
        [HttpGet]
        [Route("/api/pessoa/BuscarPessoa/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPessoa(string nome)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                var pessoa = db.Pessoa.Where(p => p.Nome.Equals(nome)).Take(1).ToList();

                if (pessoa != null && pessoa.Count > 0)
                    return Ok(pessoa);
                else
                    return NotFound();
            }
            catch { return BadRequest(); }
        }

        [HttpDelete]
        [Route("/api/pessoa/DeletarPessoa/{idPessoa}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarPessoa(int idPessoa)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                var pessoa = db.Pessoa.Find(idPessoa);

                if (pessoa != null && pessoa.Pessoa_ID > 0)
                {
                    db.Pessoa.Remove(pessoa);
                    db.SaveChanges();

                    return Ok();
                }
                else
                    return NotFound();
            }
            catch(Exception ex) { return BadRequest(); }
        }
    }
}
