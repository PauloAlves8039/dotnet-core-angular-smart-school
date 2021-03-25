using Microsoft.AspNetCore.Mvc;

namespace src.SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Alunos: Marta, Paulo, Lucas, Rafa");
        }
    }
}
