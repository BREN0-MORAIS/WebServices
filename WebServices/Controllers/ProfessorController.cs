using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServices.Data;
using WebServices.Models;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRepository _repository;
        public ProfessorController(DataContext context, IRepository repository)
        {

            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int Id)
        {
            var aluno = _context.Professores.FirstOrDefault(a => a.Id == Id);
            if (aluno == null) return BadRequest("Aluno Não Encontrado");
            return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if (professor == null) return BadRequest("Professor Não encontrado");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repository.Add(professor);
            if (_repository.SaveChangs())
            {
                return Ok(professor);
            }
            return Ok("Professor Não Encintrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);


            _repository.Update(professor);
            if (_repository.SaveChangs())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não encontrado");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);

            _repository.Update(professor);
            if (_repository.SaveChangs())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não encontrado");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);

            _repository.Delete(professor);
            if (_repository.SaveChangs())
            {
                return Ok(professor);
            }
            return BadRequest("Não é possivel Deletar o Professor");

        }
    }
}
