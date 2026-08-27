using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SistemaGestaoFaculdade.Entity
{
    // o professor é uma pessoa - então classe aluno base pessoa
    public class Professor : Pessoa
    {
        // além do que foi herdado de pessoa, um professor tem Registro e Especialidade
        public string Registro { get; set; }
        public string Especialidade { get; set; }

        //Construtor de Professor

        public Professor(string nome, string cpf, string email, string registro, string especialidade) : base(nome, cpf, email)
        {
            Registro = registro;
            Especialidade = especialidade;
        }


    }
}
