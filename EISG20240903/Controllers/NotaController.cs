using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EISG20240903.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        static List<object> notas = new List<object>();

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return notas;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(int nota)
        {
            notas.Add(new {nota});
            return Ok();
        }
    }
}
