using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebServices.Data;
using WebServices.Models;

namespace WebServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRepository _repository;

        public AlunoController(DataContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        //pega os dados
        //[HttpGet("getResposta")]
        //public IActionResult GetResposta()
        //{
        //    //return Ok(_repository.GetResposta());
        //}
        //[HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        //rota para o párametro utilizado no metodo
        //[HttpGet("{Id:int}")]
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno Não foi encontrado");
            return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno Não foi encontrado");
            return Ok(aluno);
        }
        //envia os dados
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repository.Add(aluno);
            if (_repository.SaveChangs())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno Não Cadastrado");
            //_context.Add(aluno);
            //_context.SaveChanges();
        }
        //atualiza os dados
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            //AsNoTracking() => Busca no banco de dados e verifica se existe mais não bloqueia a aplicação
            var al = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

            _repository.Update(aluno);
            if (_repository.SaveChangs())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno Não encontrado");
        }

        //ataualiza parcialmente os dados
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var al = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);


            _repository.Update(aluno);
            if (_repository.SaveChangs())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno Não encontrado");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            _repository.Delete(aluno);
            if (_repository.SaveChangs())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno Não encontrado");
        }
    }
}
