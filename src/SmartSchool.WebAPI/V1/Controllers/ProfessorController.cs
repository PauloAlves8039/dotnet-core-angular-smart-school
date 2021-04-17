using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.SmartSchool.WebAPI.Data;
using src.SmartSchool.WebAPI.V1.Dtos;
using src.SmartSchool.WebAPI.Models;

namespace src.SmartSchool.WebAPI.V1.Controllers
{
    /// <summary>
    /// Versão 1: controlador responsável por funcionalidades relacionadas a entidade Professor.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
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
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por obter registros de todos os professores.
        /// </summary>
        /// <returns>Registros de todos os professores.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        /// <summary>
        /// Método responsável por obter registro de professor(a) por Id.
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa do professor(a).</param>
        /// <returns>Registro de um professor(a) por Id.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, true);

            if (professor == null) return BadRequest("O Professor(a) não foi encontrado!");

            var professorDto = _mapper.Map<ProfessorDto>(professor);

            return Ok(professor);
        }

        /// <summary>
        /// Método responsável por obter registro de aluno(a) agregado ao professor(a) por Id.
        /// </summary>
        /// <param name="alunoId">Parâmetro de pesquisa do aluno(a).</param>
        /// <returns>Registro de um professor(a) agregado ao aluno(a) por Id.</returns>
        [HttpGet("byaluno/{alunoId}")]
        public IActionResult GetByAlunoId(int alunoId)
        {
            var professores = _repo.GetProfessoresByAlunoId(alunoId, true);

            if (professores == null) return BadRequest("Professores não encontradoa!");

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        /// <summary>
        /// Método responsável por adicionar registro de professor(a).
        /// </summary>
        /// <param name="model">Instância da classe ProfessorRegistrarDto.</param>
        /// <returns>Novo registro do professor(a).</returns>
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var prof = _mapper.Map<Professor>(model);

            _repo.Add(prof);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
            }

            return BadRequest("Professor(a) não Cadastrado!");
        }

        /// <summary>
        /// Método responsável por atualizar todo o registro do professor(a).
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa do professor(a).</param>
        /// <param name="model">Instância da classe ProfessorRegistrarDto.</param>
        /// <returns>Registro atualizado do professor(a).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var prof = _repo.GetProfessorById(id, false);

            if (prof == null) return BadRequest("Professor não encontrado!");

            _mapper.Map(model, prof);

            _repo.Update(prof);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
            }

            return BadRequest("Professor não Atualizado!");
        }

        /// <summary>
        /// Método responsável por atualizar parcialmente o registro do professor(a).
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa do professor(a).</param>
        /// <param name="model">Instância da classe ProfessorRegistrarDto.</param>
        /// <returns>Registro parcialmente atualizado do professor(a).</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var prof = _repo.GetProfessorById(id, false);

            if (prof == null) return BadRequest("Professor não encontrado!");

            _mapper.Map(model, prof);

            _repo.Update(prof);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
            }

            return BadRequest("Professor não Atualizado!");
        }

        /// <summary>
        /// Método responsável por excluir registro de professor(a).
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa do professor(a).</param>
        /// <returns>Confirmação da exclusão do registro de professor(a).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id, false);

            if (prof == null) return BadRequest("Professor não encontrado!");

            _repo.Delete(prof);

            if (_repo.SaveChanges())
            {
                return Ok("Professor Excluído!");
            }

            return BadRequest("Professor não Excluído!");
        }
    }
}
