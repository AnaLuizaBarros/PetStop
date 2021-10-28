using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PetStop_API.Controllers
{
    public class RacaController : Controller
    {
        [HttpGet]
        [Route("/api/raca/RacasPorEspecie/{id_especie}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarTodasRacasPorEspecie(int id_especie)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var resultado = db.Raca.Where(x => x.id_especie == id_especie).ToList();

                if (resultado is not null && resultado.Count > 0) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/raca/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarRaca(int id)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var resultado = db.Raca.FirstOrDefault(x => x.id_raca == id);

                if (resultado != null) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/raca/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarEspecie(string nome)
        {
            try
            {
                using var db = new Data.PetStopContext();

                var resultado = db.Raca.FirstOrDefault(x => x.nome == nome);

                if (resultado != null) { return Ok(resultado); }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }
    }
}