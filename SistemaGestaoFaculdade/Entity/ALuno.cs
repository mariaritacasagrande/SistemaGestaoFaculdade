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
    public string NumeroMatricula {  get; set; }
        //um aluno pode estar matriculado em vários cursos por isso o List
        public List<Matricula> Matriculas { get; set; } = new List<Matricula>(List);

        //Construtor de Aluno

        public Aluno(string nome, string cpf, string email,string numeroMatricula) : base (nome,cpf,email)
        {
            NumeroMatricula = numeroMatricula;
        }


    }
}
