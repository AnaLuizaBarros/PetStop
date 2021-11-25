using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStop_API.Controllers
{
    [ApiController]
    [Route("/api/animal")]
    public class AnimalController : ControllerBase
    {
        [HttpPost]
        [Route("/api/animal/SalvarAnimal")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarAnimal([FromBody] Animal animal)
        {
            try
            {
                using var db = new Data.PetStopContext();

                db.Set<Animal>().Add(animal);
                db.SaveChanges();

                return Created("OK", animal);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [HttpPut]
        [Route("/api/animal/EditarAnimal")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarAnimal([FromBody] Animal animal)
        {
            try
            {
                using var db = new Data.PetStopContext();

                db.Set<Animal>().Update(animal);
                db.SaveChanges();

                return Created("OK", animal);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [HttpGet]
        [Route("/api/animal/BuscarAnimalPorNome/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarAnimalPorNome(string nome)
        {
            try
            {
                var db = new Data.PetStopContext();

                var animal = (from a in db.Animal
                                where a.nome == nome
                                select new
                                {
                                    a.id_animal,
                                    a.nome,
                                    a.id_raca,
                                    imagens = (from im in db.Imagem where a.id_animal == im.id_animal select im).ToList(),
                                    a.id_doador,
                                    a.id_porte
                                }).FirstOrDefault();
                return Ok(animal);
            }
            catch(Exception e) { return BadRequest(e); }
        }

        [HttpGet]
        [Route("/api/animal/ListarPorEspecie/especie/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarPorEspecie(int id)
        {
            try
            {
                var db = new Data.PetStopContext();

                var animais = (from a in db.Animal
                              where a.Raca.id_especie == id
                              select new
                              {
                                  a.id_animal,
                                  a.nome,
                                  a.id_raca,
                                  imagens = (from im in db.Imagem where a.id_animal == im.id_animal select im).ToList(),
                                  a.id_doador,
                                  a.id_porte
                              });
                return Ok(animais);
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/animal/BuscarPorId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var db = new Data.PetStopContext();
                var animal = (from a in db.Animal
                               where a.id_animal == id
                               select new
                               {
                                   a.id_animal,
                                   a.nome,
                                   a.id_raca,
                                   imagens = (from im in db.Imagem where a.id_animal == im.id_animal select im).ToList(),
                                   a.id_doador,
                                   a.id_porte
                               }).FirstOrDefault();
                return Ok(animal);
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        [Route("/api/animal/AdicionarImagem/imagens")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AdicionarImagem([FromBody] Imagem imagem)
        {
            try
            {
                using var db = new Data.PetStopContext();
                db.Set<Imagem>().Add(imagem);
                db.SaveChanges();

                return Created("OK", imagem);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [HttpGet]
        [Route("/api/animal/ListarImagens/{id:int}/imagens")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarImagens(int id)
        {
            try
            {
                return Ok(new Data.PetStopContext().Imagem.Where(x => x.id_animal == id).Select(x => x.imagem));
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("/api/doador/FiltrarAnimais")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult FiltrarAnimais(int id_raca = 0, int id_porte = 0)
        {
            try
            {
                var db = new Data.PetStopContext();
                var animais = (from a in db.Animal
                               where 
                               (id_raca == 0 || a.id_raca == id_raca) &&
                               (id_porte == 0 || a.id_porte == id_porte)
                               select new
                               {
                                   a.id_animal,
                                   a.nome,
                                   a.id_raca,
                                   imagens = (from im in db.Imagem where a.id_animal == im.id_animal select im).ToList(),
                                   a.id_doador,
                                   a.id_porte
                               });

                if (animais != null && animais.Count() > 0)
                    return Ok(animais);
                else
                    return NotFound("Não foi encontrado nenhum animal vinculado a este doador.");
            }
            catch (Exception e) { return NotFound(e); }
        }

        [HttpDelete]
        [Route("/api/animal/DeletarAnimal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarAnimal(int id_animal)
        {
            try
            {
                var db = new Data.PetStopContext();

                var animal = db.Animal.FirstOrDefault(x => x.id_animal == id_animal);

                if (animal != null)
                {
                    db.Animal.Remove(animal);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception e) { return BadRequest(e); }
        }
    }
}