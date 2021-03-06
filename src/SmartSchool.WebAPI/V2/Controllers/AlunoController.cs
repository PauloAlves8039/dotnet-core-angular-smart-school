using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.SmartSchool.WebAPI.Data;
using src.SmartSchool.WebAPI.V1.Dtos;
using src.SmartSchool.WebAPI.Models;

namespace src.SmartSchool.WebAPI.V2.Controllers
{
    /// <summary>
    /// Versão 2: controlador responsável por funcionalidades relacionadas a entidade Aluno.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        /// <summary>
        /// Propriedade responsável por injetar repositório.
        /// </summary>
        public readonly IRepository _repo;

        /// <summary>
        /// Propriedade responsável por injetar mapeamento.
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// Construtor responsável por atribuir injecção de dependência do Repositório e Mapeamento. 
        /// </summary>
        /// <param name="repo">Parâmetro de definição do repositório.</param>
        /// <param name="mapper">Parâmetro de definição do mapeamento.</param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por obter registros de todos os alunos.
        /// </summary>
        /// <returns>Registros de todos os alunos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);

            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        /// <summary>
        /// Método responsável por obter registro de aluno(a) por Id.
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa do aluno(a).</param>
        /// <returns>Registro de um aluno(a) por Id.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null) return BadRequest("O Aluno(a) não foi encontrado!");

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(aluno);
        }

        /// <summary>
        /// Método responsável por adicionar registro de aluno(a).
        /// </summary>
        /// <param name="model">Instância da classe AlunoRegistrarDto.</param>
        /// <returns>Novo registro do aluno(a).</returns>
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);

            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno(a) não Cadastrado!");
        }

        /// <summary>
        /// Método responsável por atualizar todo o registro do aluno(a).
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa do aluno(a).</param>
        /// <param name="model">Instância da classe AlunoRegistrarDto.</param>
        /// <returns>Registro atualizado do aluno(a).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno(a) não Atualizado!");
        }

        /// <summary>
        /// Método responsável por excluir registro de aluno(a).
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa do aluno(a).</param>
        /// <returns>Confirmação da exclusão do registro de aluno(a).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno(a) não encontrado!");

            _repo.Delete(aluno);

            if (_repo.SaveChanges())
            {
                return Ok("Aluno(a) excluído!");
            }
            return BadRequest("Aluno(a) não excluído!");
        }
    }
}
