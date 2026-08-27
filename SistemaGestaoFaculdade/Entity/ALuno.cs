using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SistemaGestaoFaculdade.Entity
{
    // o aluno é uma pessoa - então classe aluno base pessoa
    public class Aluno : Pessoa
    {
        // além do que foi herdado de pessoa , um aluno também tem um numero de matricula
        public string NumeroMatricula { get; set; }

        //o aluno pode se matricular em varios cursos
        public List<Matricula> Matriculas { get; set; } = new List<Matricula>();

        //Construtor de Aluno

        public Aluno(string nome, string cpf, string email, string numeroMatricula) : base(nome, cpf, email)
        {
            NumeroMatricula = numeroMatricula;
        }


    }
}
