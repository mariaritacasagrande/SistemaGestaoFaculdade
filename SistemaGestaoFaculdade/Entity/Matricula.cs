using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoFaculdade.Entity
{
    public class Matricula
    {

        public Aluno Aluno { get; set; }    
        public Curso Curso { get; set; }

        //o boletim pertence a matricula, . Se o aluno cursa dois cursos ele tem dois boletins separados e independentes - esta nas regras

        public Boletim Boletim { get; set; }

        public Matricula(Aluno aluno, Curso curso)
        {
            Aluno = aluno;
            Curso = curso;
            Boletim = new Boletim(); // cria o boletim
        }
    }
}
