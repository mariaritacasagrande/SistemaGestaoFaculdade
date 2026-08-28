using SistemaGestaoFaculdade.Entity;
using System.Text.RegularExpressions;

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
              
        case 1: CadastrarCurso(); break;
        case 2: CadastrarProfessor(); break;
        case 3: CadastrarAluno(); break;
        case 4: CadastrarDisciplina(); break;
        case 5: VincularDisciplinaCurso(); break;
        case 6: MatricularAlunoCurso(); break;
        case 7: LancarNota(); break;
        case 8: ConsultarPessoas(); break;
        case 9: ConsultarCursos(); break;
        case 10: ConsultarMatriculas(); break;
        //case 11: ConsultarBoletim(); break;
        case 12: EnviarNotificacao(); break;
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

void VincularDisciplinaCurso()
{
    Console.Clear();
    Console.WriteLine("--- VINCULAR DISCIPLINA AO CURSO ---");

    if (!cursos.Any())
    {
        Console.WriteLine("Erro: Nenhum curso cadastrado.");
        return;
    }

    if (!disciplinas.Any())
    {
        Console.WriteLine("Erro: Nenhuma disciplina cadastrada.");
        return;
    }

    Console.Write("Código do Curso: ");
    string codCurso = Console.ReadLine();

    // Busca o curso na lista
    Curso curso = cursos.FirstOrDefault(c => c.Codigo.Equals(codCurso, StringComparison.OrdinalIgnoreCase));
    if (curso == null)
    {
        Console.WriteLine("Erro: Curso não encontrado.");
        return;
    }

    Console.Write("Código da Disciplina: ");
    string codDisc = Console.ReadLine();

    // Busca a disciplina na lista
    Disciplina disciplina = disciplinas.FirstOrDefault(d => d.Codigo.Equals(codDisc, StringComparison.OrdinalIgnoreCase));
    if (disciplina == null)
    {
        Console.WriteLine("Erro: Disciplina não encontrada.");
        return;
    }

    // Verifica se a disciplina já está vinculada ao curso
    if (curso.Disciplinas != null && curso.Disciplinas.Any(d => d.Codigo.Equals(codDisc, StringComparison.OrdinalIgnoreCase)))
    {
        Console.WriteLine("Erro: Disciplina já está vinculada a este curso.");
        return;
    }

    // Adiciona a disciplina na lista de disciplinas do curso
    curso.Disciplinas.Add(disciplina);
    Console.WriteLine("Disciplina vinculada ao curso com sucesso!");
}


//--- Matricular aluno em curso
void MatricularAlunoCurso()
{
    Console.Clear(); 
    Console.WriteLine("--- Matrícula do Aluno em curso ---");
    
    Console.Write("Número de matrícula do aluno: "); 
    string numeroMatricula = Console.ReadLine();

    //Busca nos alunos se o número da matrícula é igual ao digitado
    Aluno aluno = alunos.FirstOrDefault(a => a.NumeroMatricula == numeroMatricula);

    //Se não encontra o aluno, para
    if (aluno == null)
    { 
        Console.WriteLine("Erro: Aluno não matriculado"); 
        return; 
    } 
    
    //Busca na lista de curso pelo código informado
    Console.Write("Código do curso: "); 
    string CodigoCurso = Console.ReadLine();
    
    Curso curso = cursos.FirstOrDefault(curso => curso.Codigo.Equals(CodigoCurso, StringComparison.OrdinalIgnoreCase)); 

    //Se não encontra o curso, para
    if (curso == null)
    {
        Console.WriteLine("Erro: Curso não encontrado."); 
        return;
    } 
    
    if (matriculas.Any(m => m.Aluno == aluno && m.Curso == curso))
    { 
        Console.WriteLine("Erro: Aluno já esta matriculado neste curso."); 
        return; 
    }

    Matricula novaMatricula = new Matricula(aluno, curso);
    matriculas.Add(novaMatricula);
    aluno.Matriculas.Add(novaMatricula);

    Console.WriteLine("Aluno matriculado com sucesso!");
}

//--- Consulta de pessoas
void ConsultarPessoas()
{
    int opcaoConsulta;

    do
    {
        Console.Clear();
        Console.WriteLine("--- Consulta de Pessoas ---");
        Console.WriteLine("1 - Aluno");
        Console.WriteLine("2 - Professor");
        Console.WriteLine("0 - Voltar");
        Console.WriteLine("---------------------------\n");
        Console.Write("Escolha uma opção: ");


        if (!int.TryParse(Console.ReadLine(), out opcaoConsulta))
        {
            Console.WriteLine("Opção inválida!");
            Console.ReadKey();
            continue;
        }

        switch (opcaoConsulta)
        {
            case 1:
                if (alunos.Count == 0)
                {
                    Console.WriteLine("Nenhum aluno cadastrado.");
                    Console.ReadKey();
                    break;
                }

                foreach (Aluno aluno in alunos)
                {
                    Console.WriteLine($"Nome: {aluno.Nome}");
                    Console.WriteLine($"CPF: {aluno.CPF}");
                    Console.WriteLine($"E-mail: {aluno.Email}");
                    Console.WriteLine($"Número de matrícula: {aluno.NumeroMatricula}");

                    Console.WriteLine("Curso(s) em que está matriculado: ");
                    foreach (Matricula matricula in aluno.Matriculas)
                        Console.WriteLine($"- {matricula.Curso.Nome}");
                }
                break;

            case 2:
                if (professores.Count == 0)
                {
                    Console.WriteLine("Nenhum professor cadastrado.");
                    Console.ReadKey();
                    break;
                }

                foreach (Professor professor in professores)
                {
                    Console.WriteLine($"Nome: {professor.Nome}");
                    Console.WriteLine($"CPF: {professor.CPF}");
                    Console.WriteLine($"E-mail: {professor.Email}");
                    Console.WriteLine($"Registro: {professor.Registro}");
                    Console.WriteLine($"Especialidade: {professor.Especialidade}");
                }
                break;

            case 0:
                break;

            default:
                Console.WriteLine("Opção inválida!");
                Console.ReadKey();
                break;
        }
    } while (opcaoConsulta != 0);
}

//--- Consulta de cursos
void ConsultarCursos()
{
    Console.Clear();
    Console.WriteLine("--- Consulta de Cursos ---\n");

    if (cursos.Count == 0)
    {
        Console.WriteLine("Nenhum curso cadastrado.");
        return;
    }

    //Lista cursos
    foreach (Curso curso in cursos)
    {
        Console.WriteLine($"Código: {curso.Codigo}");
        Console.WriteLine($"Nome: {curso.Nome}");
        Console.WriteLine($"Tipo: {curso.Tipo}");

        //Lista disciplinas de cada curso e o professor responsável
        Console.WriteLine("\nDisciplinas: ");
        foreach (Disciplina disciplina in curso.Disciplinas)
        {
            Console.WriteLine($"- {disciplina.Nome}");
            Console.WriteLine($"Professor: {disciplina.ProfessorResponsavel.Nome}");
        }

        //Lista alunos matriculados em cada curso
        Console.WriteLine("\nAlunos Matriculados:");
        foreach (Matricula matricula in matriculas)
        {
            if (matricula.Curso == curso)
                Console.WriteLine($"- {matricula.Aluno.Nome}");
        }

        Console.WriteLine("---------------------------\n");
    }
}

//Enviar Notificação

void EnviarNotificacao()
{
    Console.Clear();
    Console.WriteLine("--- Enviar Notificação ---");
    Console.WriteLine("1 - Aluno\n2 - Professor");
    string tipo = Console.ReadLine();
    Console.Write("Mensagem: ");
    string msg = Console.ReadLine();

    if (tipo == "1")
    {
        Console.Write("Matrícula do Aluno: ");
        string mat = Console.ReadLine();
        Aluno a = alunos.FirstOrDefault(x => x.NumeroMatricula == mat);
       // a?.ReceberNotificacao(msg);
    }
    else if (tipo == "2")
    {
        Console.Write("Registro do Professor: ");
        string reg = Console.ReadLine();
        Professor p = professores.FirstOrDefault(x => x.Registro == reg);
       // p?.ReceberNotificacao(msg);
    }
}

//Consulta de matrículas

void ConsultarMatriculas()
{
    Console.Clear();
    Console.WriteLine("--- Consulta de Matrículas ---");

    // Verifica se não existe nenhuma matrícula cadastrada
    if (!matriculas.Any())
    {
        Console.WriteLine("Não existem matrículas cadastradas.");
        return;
    }

    // Percorre todas as matrículas cadastradas
    foreach (Matricula matricula in matriculas)
    {
        Console.WriteLine($"Aluno: {matricula.Aluno.Nome}");
        Console.WriteLine($"Matrícula: {matricula.Aluno.NumeroMatricula}");
        Console.WriteLine($"Curso: {matricula.Curso.Nome}");
        Console.WriteLine($"Tipo: {matricula.Curso.Tipo}");
        Console.WriteLine("--------------------------------");
    }
}

void LancarNota()
{
    Console.Clear();
    Console.WriteLine("--- LANÇAR NOTA ---");

    if (!matriculas.Any())
    {
        Console.WriteLine("Erro: Nenhuma matrícula cadastrada no sistema.");
        return;
    }

    Console.Write("Digite a matricula do Aluno: ");
    string matricula = Console.ReadLine()?.Trim();

    // Busca todas as matrículas deste aluno (já que ele pode ter mais de um curso)
    var matriculasAluno = matriculas.Where(m => m.Aluno != null && m.Aluno.NumeroMatricula.Equals(matricula, StringComparison.OrdinalIgnoreCase)).ToList();

    if (!matriculasAluno.Any())
    {
        Console.WriteLine("Erro: Nenhuma matrícula encontrada para o CPF informado.");
        return;
    }

    // Se o aluno tiver apenas 1 matrícula, seleciona direto. Se tiver mais de uma, escolhe o curso.
    Matricula matriculaSelecionada = null;

    if (matriculasAluno.Count == 1)
    {
        matriculaSelecionada = matriculasAluno[0];
    }
    else
    {
        Console.WriteLine("\nEste aluno possui mais de uma matrícula. Escolha o curso:");
        for (int i = 0; i < matriculasAluno.Count; i++)
        {
            Console.WriteLine($"{i + 1} - Curso: {matriculasAluno[i].Curso.Nome} ({matriculasAluno[i].Curso.Codigo})");
        }
        Console.Write("Opção: ");
        if (!int.TryParse(Console.ReadLine(), out int opcaoMatricula) || opcaoMatricula < 1 || opcaoMatricula > matriculasAluno.Count)
        {
            Console.WriteLine("Opção de matrícula inválida.");
            return;
        }
        matriculaSelecionada = matriculasAluno[opcaoMatricula - 1];
    }

    // Verifica se o curso possui disciplinas vinculadas
    if (matriculaSelecionada.Curso.Disciplinas == null || !matriculaSelecionada.Curso.Disciplinas.Any())
    {
        Console.WriteLine("Erro: O curso desta matrícula não possui disciplinas vinculadas.");
        return;
    }

    // Lista as disciplinas do curso para seleção
    Console.WriteLine($"\nCurso: {matriculaSelecionada.Curso.Nome}");
    Console.WriteLine("Disciplinas disponíveis:");
    var disciplinasCurso = matriculaSelecionada.Curso.Disciplinas;

    for (int i = 0; i < disciplinasCurso.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {disciplinasCurso[i].Nome} (Código: {disciplinasCurso[i].Codigo})");
    }

    Console.Write("Escolha o número da disciplina: ");
    if (!int.TryParse(Console.ReadLine(), out int opcaoDisc) || opcaoDisc < 1 || opcaoDisc > disciplinasCurso.Count)
    {
        Console.WriteLine("Disciplina inválida.");
        return;
    }

    Disciplina disciplinaSelecionada = disciplinasCurso[opcaoDisc - 1];

    // Solicita e valida a nota
    Console.Write($"Digite a nota para a disciplina '{disciplinaSelecionada.Nome}' (0 a 10): ");
    if (!double.TryParse(Console.ReadLine(), out double nota) || nota < 0 || nota > 10)
    {
        Console.WriteLine("Erro: Nota inválida. Digite um número entre 0 e 10.");
        return;
    }

    // Salva ou atualiza a nota no dicionário do Boletim
    matriculaSelecionada.Boletim.NotaPorDisciplina[disciplinaSelecionada] = nota;

    string situacao = matriculaSelecionada.Boletim.ObterSituacao(nota, matriculaSelecionada.Curso.Tipo);
    Console.WriteLine($"\nNota {nota:F1} lançada com sucesso!");
    Console.WriteLine($"Situação na disciplina: {situacao}");
}

//parei aqui, o plano era criar Cadastrar Aluno, Cadastrar Disciplina, Vincular Disciplina Curso, Matricula Aluno Curso,
//Lançar Nota, Consultar Pessoa, Consultar Curso, Consultar Matricula, Consultar Boletim, ENviar Notificação