using Microsoft.AspNetCore.Mvc;
using src.SmartSchool.WebAPI.Data;
using src.SmartSchool.WebAPI.Models;

namespace src.SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null)
            {
                return BadRequest("O Aluno(a) não foi encontrado!");
            }
            else
            {
                return Ok(aluno);
            }
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno(a) não Cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno(a) não Atualizado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno(a) não encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno(a) não Atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno(a) não encontrado!");

            _repo.Delete(alu);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno(a) excluído!");
            }
            return BadRequest("Aluno(a) não excluído!");
        }
    }
}
