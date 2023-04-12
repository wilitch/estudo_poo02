using System.Security.Cryptography.X509Certificates;
using ProjetoAula02.Entities;
using ProjetoAula02.Repositories;

namespace ProjetoAula02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n *** CADASTRO DE FUNCIONÁRIOS *** \n");

            var funcionario = new Funcionario();
            funcionario.Funcao = new Funcao();

            try
            {
                funcionario.Id = Guid.NewGuid();
                funcionario.Funcao.Id = Guid.NewGuid();

                Console.Write("INFORME O NOME DO FUNCIONÁRIO....: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("INFORME O CPF....................: ");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("INFORME A MATRÍCULA..............: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("INFORME A DATA DE ADMISSÃO.......: ");
                funcionario.DataAdmissao = Convert.ToDateTime(Console.ReadLine());

                Console.Write("INFORME A DESCRIÇÃO DA FUNÇÃO....: ");
                funcionario.Funcao.Descricao = Console.ReadLine();

                Console.WriteLine("\nDADOS DO FUNCIONÁRIO:");
                Console.WriteLine($"\tID..................: {funcionario.Id}");
                Console.WriteLine($"\tNOME................: {funcionario.Nome}");
                Console.WriteLine($"\tCPF.................: {funcionario.Cpf}");
                Console.WriteLine($"\tMATRÍCULA...........: {funcionario.Matricula}");
                Console.WriteLine($"\tDATA DE ADMISSÃO....: {funcionario.DataAdmissao}");
                Console.WriteLine($"\tID DA FUNÇÃO........: {funcionario.Funcao.Id}");
                Console.WriteLine($"\tDESCRIÇÃO...........: {funcionario.Funcao.Descricao}");

                Console.Write("\nESCOLHA (1)JSON ou (2)XML....: ");
                var opcao = int.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();

                switch (opcao)
                {
                    case 1:
                        funcionarioRepository.ExportarJson(funcionario);
                        Console.WriteLine("\nARQUIVO JSON GRAVADO COM SUCESSO!");
                        break;

                    case 2:
                        funcionarioRepository.ExportarXml(funcionario);
                        Console.WriteLine("\nARQUIVO XML GRAVADO COM SUCESSO!");
                        break;

                    default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                        break;
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nERRO DE VALIDAÇÃO:");
                Console.WriteLine(e.Message);

                Console.Write("\nDESEJA TENTAR NOVAMENTE? (S/N)..: ");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Main(args);
                }
                else
                {
                    Console.WriteLine("\nFIM!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO EXECUTAR O PROGRAMA:");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}


