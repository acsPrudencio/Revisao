using System;

namespace Revisao{
    class program{
        static void Main(string[] args)
        {
            var indiceAluno = 0;
            Aluno[] alunos = new Aluno[5];
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");
       
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                            aluno.Nota = nota;
                        }else{
                            throw new ArgumentException("O valor da nota deve ser um decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach(var a in alunos){
                            if(a.Nome != null){
                                Console.WriteLine($"Aluno: {a.Nome}, nota: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaGeral = 0;
                        var quatidadeAlunos = 0;

                        for(int i=0; i<alunos.Length; i++){
                            if(alunos[i].Nome != null){
                                notaGeral += alunos[i].Nota;
                                quatidadeAlunos++;
                            }
                        }

                        Conceito conceitoGeral;
                        var mediaGeral = notaGeral/quatidadeAlunos;

                        int op = (int)mediaGeral;
                        Console.WriteLine(op);
                        switch(op){
                            case 0: case 1:
                                conceitoGeral = Conceito.E;
                                break;
                            case 2: case 3:
                                conceitoGeral = Conceito.D;
                                break;
                            case 4 : case 5 : case 6:
                                conceitoGeral = Conceito.C;
                                break;
                            case 7 : case 8:
                                conceitoGeral = Conceito.B;
                                break;
                            default:
                                conceitoGeral = Conceito.A;
                                break;
                        }

                        Console.WriteLine($"A media geral dos alunos foi {mediaGeral} - Conceito Geral: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine("");
            return opcaoUsuario;
        }
    }
}