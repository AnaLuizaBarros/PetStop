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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostSalvarAdotante([FromBody] Adotante adotante)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                Adotante adt = new Adotante(adotante.IdAdotante, adotante.Nome, adotante.Idade, adotante.Cpf, adotante.Dt_Nascimento, adotante.Email, adotante.Alergia, adotante.Endereco);

                //Implementar salvar no banco
                db.Set<Adotante>().Add(adt);
                db.SaveChanges();
                db.Set<Alergia>().Add(adt.Alergia);
                db.SaveChanges();
                db.Set<Endereco>().Add(adt.Endereco);
                db.SaveChanges();

                return Created("OK", adt);
            }
            catch { return BadRequest(); }
        }


       
        [HttpGet("{Nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBuscaAdotante(string Nome)
        {
            try
            {
                //Implementar busca do adotante
                using var db = new Data.ApplicationContext();

                var adotante = db.Adotante.Where(p => p.Nome == Nome).Take(1).ToList();

                if (adotante is not null && adotante.Count > 0)
                    return Ok(adotante);
                else
                    return NotFound();
            }
            catch { return BadRequest(); }
        }

        
        [HttpDelete("{idAdotante}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteAdotante(int idAdotante)
        {
            try
            {
                using var db = new Data.ApplicationContext();

                var adotante = db.Adotante.Find(idAdotante);

                if (adotante is not null)
                {
                    db.Adotante.Remove(adotante);
                    db.SaveChanges();

                    return Ok();
                }
                else
                    return NotFound();
            }
            catch { return BadRequest(); }
        }
    }
}
