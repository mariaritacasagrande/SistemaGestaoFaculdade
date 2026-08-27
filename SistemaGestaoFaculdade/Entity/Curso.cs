using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SistemaGestaoFaculdade.Entity
{
    public class Curso
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public TipoCurso Tipo { get; set; }

        //cada curso tem uma lista interna de disciplinas

        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public Curso(string codigo, string nome, TipoCurso tipo)
        {
            Codigo = codigo;
            Nome = nome;
            Tipo = tipo;
        }
    }
}
