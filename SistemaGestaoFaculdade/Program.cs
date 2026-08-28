using SistemaGestaoFaculdade.Entity;

// pega as listas que estão na memória pra simular o banco de dados

List<Curso> cursos = new List<Curso> ();
List<Professor> professores = new List<Professor>();
List<Aluno> alunos = new List<Aluno> ();
List<Disciplina> disciplinas = new List<Disciplina> ();
List<Matricula> matriculas = new List<Matricula> ();

//aqui começa o menu

int opcao;

do
{
    Console.Clear();
    Console.WriteLine("========= GESTÃO DA FACULDADE =========");
    Console.WriteLine("1 - Cadastrar curso");
    Console.WriteLine("2 - Cadastrar professor");
    Console.WriteLine("3 - Cadastrar aluno");
    Console.WriteLine("4 - Cadastrar disciplina");
    Console.WriteLine("5 - Vincular disciplina a um curso");
    Console.WriteLine("6 - Matricular aluno em curso");
    Console.WriteLine("7 - Lançar nota");
    Console.WriteLine("8 - Consultar pessoas");
    Console.WriteLine("9 - Consultar cursos");
    Console.WriteLine("10 - Consultar matrículas");
    Console.WriteLine("11 - Consultar boletim");
    Console.WriteLine("12 - Enviar notificação");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    if (!int.TryParse(Console.ReadLine(), out opcao)) //try parse caso o usuario digite uma letra ou caractere, verifica se é numero
    {
        Console.WriteLine("Opção inválida! Pressione Enter.");
        Console.ReadKey();
        continue;
    }

    switch (opcao)
    {
        //case 1: CadastrarCurso(); break;
        case 2:Console.WriteLine("=== Cadastrar Disciplina ===\n");
         CadastrarProfessor(); break;
        case 1: CadastrarCurso(); break;
        case 2: CadastrarProfessor(); break;
        //case 3: CadastrarAluno(); break;
        case 4:  Console.WriteLine("=== Cadastrar Disciplina ===\n");
         CadastrarDisciplina(); break;
        //case 5: VincularDisciplinaCurso(); break;
        //case 6: MatricularAlunoCurso(); break;
        //case 7: LancarNota(); break;
        //case 8: ConsultarPessoas(); break;
        //case 9: ConsultarCursos(); break;
        //case 10: ConsultarMatriculas(); break;
        //case 11: ConsultarBoletim(); break;
        //case 12: EnviarNotificacao(); break;
        case 0: Console.WriteLine("Saindo..."); break;
        default: Console.WriteLine("Opção inválida!"); break;
    }

    if (opcao != 0)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

} while (opcao != 0);

//Metodos

//Cadastrar Curso
   void CadastrarCurso()
    {
        Console.Clear();
        Console.WriteLine("--- Cadastro de Curso ---");
        Console.Write("Código: ");
        string codigo = Console.ReadLine();

        if (cursos.Any(c => c.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Erro: Já existe um curso com este código.");
            return;
        }

        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Tipo (1 - Graduação | 2 - Pós-graduação): ");
        int tipoOp = int.Parse(Console.ReadLine());

        TipoCurso tipo = (tipoOp == 2) ? TipoCurso.PosGraduacao : TipoCurso.Graduação;
        cursos.Add(new Curso(codigo, nome, tipo));
        Console.WriteLine("Curso cadastrado com sucesso!");
    }



//Cadastrar Professor

void CadastrarProfessor()
{
    Console.Clear();
    Console.WriteLine("--- Cadastro de Professor ---");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("CPF: ");
    string cpf = Console.ReadLine();

    if (professores.Any(p => p.CPF == cpf))
    {
        Console.WriteLine("Erro: CPF já cadastrado.");
        return;
    }

    Console.Write("E-mail: ");
    string email = Console.ReadLine();
    Console.Write("Registro: ");
    string registro = Console.ReadLine();

    if (professores.Any(p => p.Registro == registro))
    {
        Console.WriteLine("Erro: Registro já cadastrado.");
        return;
    }

    Console.Write("Especialidade: ");
    string especialidade = Console.ReadLine();

    professores.Add(new Professor(nome, cpf, email, registro, especialidade));
    Console.WriteLine("Professor cadastrado com sucesso!");
}

//Cadastrar Disciplina
void CadastrarDisciplina()
{
    Console.Clear();
    Console.WriteLine("--- Cadastro de Disciplina ---");

    Console.Write("Código: ");
    string codigo = Console.ReadLine();

    if (disciplinas.Any(d => d.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)))
    {
        Console.WriteLine("Erro: Já existe uma disciplina com este código.");
        Console.ReadKey();
        return;
    }

    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("Carga Horária: ");
    int cargaHoraria = int.Parse(Console.ReadLine());

    if (!professores.Any())
    {
        Console.WriteLine("Erro: Não existem professores cadastrados.");
        Console.ReadKey();
        return;
    }

    Console.Write("Digite o código do professor responsável: ");
    string codigoProfessor = Console.ReadLine();

    Console.Write("Professor responsável: ");
    string nomeProfessor = Console.ReadLine();

    Professor professorResponsavel = professores
    .FirstOrDefault(p => p.Nome.Equals(nomeProfessor, StringComparison.OrdinalIgnoreCase));

    if (professorResponsavel == null)
    {
        Console.WriteLine("Erro: Professor não encontrado.");
        Console.ReadKey();
        return;
    }

    disciplinas.Add(
        new Disciplina(
            codigo,
            nome,
            cargaHoraria,
            professorResponsavel
        )
    );

    Console.WriteLine("Disciplina cadastrada com sucesso!");
    Console.ReadKey();
}

// Cadastrar Aluno

void CadastrarAluno()
{
    Console.Clear();
    Console.WriteLine("--- Cadastro de Aluno ---");

    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    // Aceita somente letras e espaços
    while (!Regex.IsMatch(nome ?? "", @"^[a-zA-ZÀ-ÿ\s]+$"))
    {
        Console.Write("Nome inválido! Digite o nome novamente: ");
        nome = Console.ReadLine();
    }

    Console.Write("CPF: ");
    string cpf = Console.ReadLine();

    while (!Regex.IsMatch(cpf ?? "", @"^\d{11}$"))
    {
        Console.Write("CPF inválido! Digite o CPF com 11 digitos: ");
        cpf = Console.ReadLine();
    }

    if (alunos.Any(a => a.CPF == cpf))
    {
        Console.WriteLine("Erro: CPF já cadastrado.");
        return;
    }

    Console.Write("E-mail: ");
    string email = Console.ReadLine();

    Console.Write("Número de matrícula: ");
    string numeroMatricula = Console.ReadLine();

    if (alunos.Any(a => a.NumeroMatricula == numeroMatricula))
    {
        Console.WriteLine("Erro: Número de matrícula já cadastrada.");
        return;
    }

    alunos.Add(new Aluno(nome, cpf, email, numeroMatricula));

    Console.WriteLine("Aluno cadastrado com sucesso!");
}


//parei aqui, o plano era criar Cadastrar Aluno, Cadastrar Disciplina, Vincular Disciplina Curso, Matricula Aluno Curso,
//Lançar Nota, Consultar Pessoa, Consultar Curso, Consultar Matricula, Consultar Boletim, ENviar Notificação