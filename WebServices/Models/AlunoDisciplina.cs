using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina()  { }
        public AlunoDisciplina(int alunoId,int disciplinaId)
        {
            this.AlunoId = AlunoId;
            this.DisciplinaId = disciplinaId;
        }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
