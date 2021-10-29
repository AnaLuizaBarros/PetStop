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
                return Ok(new Data.PetStopContext().Especie.ToList());
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
                return Ok(new Data.PetStopContext().Especie.FirstOrDefault(x => x.id_especie == id) ?? new Models.Especie());
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
                return Ok(new Data.PetStopContext().Especie.FirstOrDefault(x => x.nome == nome) ?? new Models.Especie());
            }
            catch { return BadRequest(); }
        }
    }
}