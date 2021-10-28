using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PetStop_API.Controllers
{
    public class PorteController : Controller
    {
        [HttpGet]
        [Route("/api/porte")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarTodasRacasPorEspecie(int id_especie)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var resultado = db.Porte.ToList();

                if (resultado is not null && resultado.Count > 0) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/porte/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarRaca(int id)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var resultado = db.Porte.FirstOrDefault(x => x.id_porte == id);

                if (resultado != null) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/porte/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarEspecie(string nome)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var resultado = db.Porte.FirstOrDefault(x => x.nome == nome);

                if (resultado != null) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }
    }
}