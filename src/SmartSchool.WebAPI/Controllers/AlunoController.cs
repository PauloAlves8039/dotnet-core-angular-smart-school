using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using src.SmartSchool.WebAPI.Models;

namespace src.SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "(81)99999-5555"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "(81)99999-6666"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Maria",
                Telefone = "(81)99999-7777"
            }
        };

        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("O Aluno(a) não foi encontrado!");
            }
            else
            {
                return Ok(aluno);
            }

        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome));
            if (aluno == null)
            {
                return BadRequest("O Aluno(a) não foi encontrado!");
            }
            else
            {
                return Ok(aluno);
            }

        }
    }
}
