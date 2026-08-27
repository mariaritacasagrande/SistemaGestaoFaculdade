using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoFaculdade.Entity
{
    public class Disciplina
    {
        public string Codigo {  get; set; }
        public string Nome { get; set; }

        public int CargaHorária {  get; set; }

        //toda disciplina precisa ter um professor responsavel

        public Professor ProfessorResponsavel { get; set; }

        public Disciplina(string codigo, string nome, int cargaHoraria, Professor professorResponsavel)  
        {
            Codigo = codigo;
            Nome = nome;
            CargaHorária = cargaHoraria;
            ProfessorResponsavel = professorResponsavel;
        }
    }
}
