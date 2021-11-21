using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PetStop_API.Controllers
{
    public class RacaController : Controller
    {
        [HttpGet]
        [Route("/api/raca/BuscarTodasRacasPorEspeciePorId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarTodasRacasPorEspecie(int id_especie)
        {
            try
            {
                return Ok(new Data.PetStopContext().Raca.Where(x => x.id_especie == id_especie));
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/raca/BuscarRacaPorId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarRaca(int id)
        {
            try
            {
                return Ok(new Data.PetStopContext().Raca.FirstOrDefault(x => x.id_raca == id) ?? new Models.Raca());
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/raca/BuscarEspeciePorNome/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarEspecie(string nome)
        {
            try
            {
                return Ok(new Data.PetStopContext().Raca.FirstOrDefault(x => x.nome == nome) ?? new Models.Raca());
            }
            catch { return BadRequest(); }
        }
    }
}