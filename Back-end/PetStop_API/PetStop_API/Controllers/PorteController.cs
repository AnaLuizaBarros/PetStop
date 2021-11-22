using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PetStop_API.Controllers
{
    public class PorteController : Controller
    {
        [HttpGet]
        [Route("/api/porte/BuscarTodosPortes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarTodosPortes()
        {
            try
            {
                return Ok(new Data.PetStopContext().Porte.ToList());
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/porte/BuscarPortePorId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPortePorId(int id)
        {
            try
            {
                return Ok(new Data.PetStopContext().Porte.FirstOrDefault(x => x.id_porte == id) ?? new Models.Porte());
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/porte/BuscarPortePorNome/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPortePorNome(string nome)
        {
            try
            {
                return Ok(new Data.PetStopContext().Porte.FirstOrDefault(x => x.nome == nome) ?? new Models.Porte());
            }
            catch { return BadRequest(); }
        }
    }
}