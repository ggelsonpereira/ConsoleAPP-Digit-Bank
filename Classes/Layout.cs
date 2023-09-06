using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConsoleApp1.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>(); 
        private static int opcao = 0;
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            

            Console.Clear();

            Console.WriteLine("                                                                       ");
            Console.WriteLine("                     DIGITE A OPCAO DESEJADA:                          ");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                     1 - CRIAR CONTA                                   ");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                     2 - ENTRAR COM CPF E SENHA                        ");
            Console.WriteLine("=======================================================================");
            Console.Beep();

            DateTime DateTime = DateTime.Now;

            opcao = int.Parse(Console.ReadLine());
            Console.Beep();

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaLogin();
                    break;
                default:
                    Console.WriteLine("Opcao Invalida!");
                    break;
            }

        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("                                                                       ");
            Console.WriteLine("                     DIGITE SEU NOME:                                  ");
            string nome = Console.ReadLine();
            Console.Beep();
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                     DIGITE O CPF:                                     ");
            string cpf = Console.ReadLine();
            Console.Beep();
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                     DIGITE SUA SENHA:                                 ");
            string senha = Console.ReadLine();
            Console.Beep();
            Console.WriteLine("=======================================================================");
            Console.Beep();

            //Criar Conta

            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCpf(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("                       CONTA CADASTRADA COM SUCESSO.                    ");
            Console.WriteLine("========================================================================");

            // Espera 1 segundo para ir para a telalogada
            Thread.Sleep(1000);

            TelaContaLogada(pessoa);
        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                                       ");
            Console.WriteLine("                     DIGITE O CPF:                                     ");
            string cpf = Console.ReadLine();
            Console.Beep();
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                     DIGITE SUA SENHA:                                 ");
            string senha = Console.ReadLine();
            Console.Beep();
            Console.WriteLine("=======================================================================");
            Console.Beep();

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if(pessoa != null)
            {


                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();

                Console.WriteLine("                       PESSOA NAO CADASTRADA                            ");
                Console.WriteLine("========================================================================");

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgTelaBemVindo =
                $"{pessoa.Nome}    |  Banco: {pessoa.Conta.GetCodigoDoBanco()}     " +
                $"  | Agencia: {pessoa.Conta.GetNumeroAgencia()}    | Conta: {pessoa.Conta.GetNumeroDaConta()}";

            Console.WriteLine("");
            Console.WriteLine($"                  SEJA BEM-VINDO, {msgTelaBemVindo}"); 
            Console.WriteLine("");
                    DateTime Data = DateTime.Now;
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            DateTime DateTime = DateTime.Now;

            Console.WriteLine("                         DIGITE A OPCAO DESEJADA:                               ");
            Console.WriteLine("================================================================================");
            Console.WriteLine("                         1 - REALIZAR UM DEPOSITO                               ");
            Console.WriteLine("================================================================================");
            Console.WriteLine("                         2 - REALIZAR UM SAQUE                                  ");
            Console.WriteLine("================================================================================");
            Console.WriteLine("                         3 - CONSULTAR SALDO                                    ");
            Console.WriteLine("================================================================================");
            Console.WriteLine("                         4 - EXTRATO                                            ");
            Console.WriteLine("================================================================================");
            Console.WriteLine("                         5 - SAIR                                               ");
            Console.WriteLine("================================================================================");
            Console.Beep();

            opcao = int.Parse(Console.ReadLine());
            Console.Beep();

            switch(opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    TelaExtrato(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                         OPCAO INVALIDA!                                        ");
                    Console.WriteLine("================================================================================");
                    break;



            }
        }

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                      DIGITE O VALOR DO DEPOSITO:                        ");
            double valor = double.Parse(Console.ReadLine());
            Console.Beep();
            Console.WriteLine("                      ============================                       ");

            pessoa.Conta.Deposita(valor);

            Console.Clear() ;

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                    DEPOSITO REALIZADO COM SUCESSO                       ");
            Console.WriteLine("                    ==============================                        ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                      DIGITE O VALOR DO SAQUE:                           ");
            double valor = double.Parse(Console.ReadLine());
            Console.Beep();
            Console.WriteLine("                      ============================                       ");

            bool okSaque = pessoa.Conta.Saca(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            
            if(okSaque)
            {
                Console.WriteLine("                SAQUE FOI REALIZADO SUCESSO                           ");
                Console.WriteLine("======================================================================");
            }
            else
            {
                Console.WriteLine("                SALDO INSUFICIENTE!                                   ");
                Console.WriteLine("======================================================================");
            }

            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine($"                        SEU SALDO E: {pessoa.Conta.ConsultaSaldo()}   ");
            Console.WriteLine("========================================================================");
            Console.WriteLine("                                                                        ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

           if(pessoa.Conta.Extrato().Any())
            {
                // Mostrar extrato

                double total = pessoa.Conta.Extrato().Sum(x => x.valor);

                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("                                                                       ");
                    Console.WriteLine($"               Data: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}   ");
                    Console.WriteLine($"               Tipo de Movimentacao: {extrato.Descricao}              ");
                    Console.WriteLine($"               Valor: {extrato.valor}                                 ");
                    Console.WriteLine("                  =====================                                ");
                }

                Console.WriteLine("                                                             ");
                Console.WriteLine("                                                             ");
                Console.WriteLine($"                  SUB TOTAL: {total}                        ");
                Console.WriteLine("                   =====================                     ");
            }
            else
            {
                // Mostrar uma mensagem que nao ha extrato
                Console.WriteLine("                 NAO HA EXTRATO A SER EXIBIDO!                    ");
                Console.WriteLine("                 =============================                    ");
            }
            OpcaoVoltarLogado(pessoa);
        }

        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("                      ENTRE COM UMA OPCAO ABAIXO                         ");
            Console.WriteLine("                     =============================                       ");
            Console.WriteLine("                      1 - VOLTAR PARA MINHA CONTA                        ");
            Console.WriteLine("                     ============================                        ");
            Console.WriteLine("                      2 - SAIR                                           ");
            Console.WriteLine("                     ============================                        ");
            Console.Beep();

            opcao = int.Parse(Console.ReadLine());
            Console.Beep();

            if (opcao == 1)
                TelaContaLogada(pessoa);
            else
                TelaPrincipal();
        }

        private static void OpcaoVoltarDeslogado()
        {
            Console.WriteLine("                      ENTRE COM UMA OPCAO ABAIXO                         ");
            Console.WriteLine("                     ============================                        ");
            Console.WriteLine("                     1 - VOLTAR PARA MENU PRINCIPAL                      ");
            Console.WriteLine("                     ============================                        "); 
            Console.WriteLine("                     2 - SAIR                                            ");
            Console.WriteLine("                     ============================                        ");
            Console.Beep();

            opcao = int.Parse(Console.ReadLine());
            Console.Beep();

            if (opcao == 1)
                TelaPrincipal();
            else
            {
                Console.WriteLine("                          OPCAO INVALIDA!                             ");
                Console.WriteLine("                     ==========================                       ");
            }
        }
    }
}
