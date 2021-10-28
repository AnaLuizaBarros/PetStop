using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PetStop_API.Controllers
{
    [ApiController]
    [Route("/api/especie")]
    public class EspecieController : Controller
    {
        [HttpGet]
        [Route("/api/especie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarTodasEspecies()
        {
            try
            {
                using var db = new Data.PetStopContext();

                var resultado = db.Especie.ToList();

                if (resultado is not null && resultado.Count > 0) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/especie/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarEspecie(int id)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var resultado = db.Especie.FirstOrDefault(x => x.id_especie == id);

                if (resultado != null) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/especie/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarEspecie(string nome)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var resultado = db.Especie.FirstOrDefault(x => x.nome == nome);

                if (resultado != null) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }
    }
}