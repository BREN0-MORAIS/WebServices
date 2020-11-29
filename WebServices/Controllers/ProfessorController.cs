using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        public ProfessorController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: marta,Paula, lucas , Rafa");
        }
    }
}
