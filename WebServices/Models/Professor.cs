using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Models
{
    public class Professor
    {
        public Professor(){}
        public Professor(int id, string nome)
        {
            this.Id = id;
            this.Nome = this.Nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> disciplinas { get; set; }
    }
}
