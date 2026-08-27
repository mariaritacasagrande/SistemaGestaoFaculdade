using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoFaculdade.Entity
{
    public class Boletim
    {

        // Usei um dicionário aquipra associar cada disciplina a uma nota
        public Dictionary<Disciplina, double> NotaPorDisciplina {  get; set; } = new Dictionary<Disciplina, double>();

        // Regra de aprovação baseada no tipo de curso ( graduação aprova com no minimo 7 e pós com 8)
        public string ObterSituacao(double nota, TipoCurso tipoCurso)
        {
            if (tipoCurso == TipoCurso.Graduação)
            {
                return nota >= 7.0 ? "Aprovado" : "Reprovado";
            }
            else
            {
                return nota >= 8.0 ? "Aprovado" : "Reprovado";
            }
        }
    }
}
