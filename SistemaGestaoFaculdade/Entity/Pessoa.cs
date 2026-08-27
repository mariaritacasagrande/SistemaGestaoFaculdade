using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoFaculdade.Entity
{

    //Maria Inicicando aqui o/ - Pessoa é a classe base abstrata para não repetirmos atributos comuns (Nome, CPF, E-mail)
    internal class Pessoa
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }


    //Agora um construtor - usei protected para que os filhos possam chamar o construtor e inicializar os dados herdados

    protected Pessoa(string nome, string cpf, string email)
        {
            Nome = nome;
            cpf = cpf;
            Email = email;
        }
    //Um método para permitir que alunos e professores recebem notificação
    
    public void ReceberNotificação(string mensagem)
        {
            Console.WriteLine($"Notificação para {Nome} :  {mensagem}");
        }

    }


}
