using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EISG20240903.Models;

namespace EISG20240903.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MatriculaController : ControllerBase
    {
        
        static List<Matricula> matriculas = new List<Matricula>();

       

        [HttpGet("{id}")]
        public Matricula Get(int id)
        {
            var matricula = matriculas.FirstOrDefault(c => c.Id == id);
            return matricula;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Matricula matricula)
        {
            matriculas.Add(matricula);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Matricula matricula)
        {
            var existingMatricula = matriculas.FirstOrDefault(c => c.Id == id);
            if (existingMatricula != null)
            {
                existingMatricula.Nombre = matricula.Nombre;
                existingMatricula.Curso = matricula.Curso;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
