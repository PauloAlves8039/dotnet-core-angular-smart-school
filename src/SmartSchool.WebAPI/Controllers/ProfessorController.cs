using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.SmartSchool.WebAPI.Data;
using src.SmartSchool.WebAPI.Dtos;
using src.SmartSchool.WebAPI.Models;

namespace src.SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;
        public readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);

            if (professor == null) return BadRequest("O Professor(a) não foi encontrado!");

            var professorDto = _mapper.Map<ProfessorDto>(professor);

            return Ok(professor);
        }

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
