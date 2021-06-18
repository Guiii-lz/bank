using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listConta = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "X":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = obterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma nova conta.");
            Console.WriteLine("Digite 1 para conta Física e 2 para conta Jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito disponível: ");
            double entradaCredito = double.Parse(Console.ReadLine());


            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, nome: entradaNome, saldo: entradaSaldo, credito: entradaCredito);

            listConta.Add(novaConta);

        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas:");
            if (listConta.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listConta.Count; i++)
            {
                Conta conta = listConta[i];
                Console.WriteLine("#{0} . ", i);
                Console.Write(conta);
            }
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            listConta[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listConta[indiceConta].Depositar(valorDeposito);
        }
        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listConta[indiceContaOrigem].Transferir(valorTransferencia, listConta[indiceContaDestino]);

        }


        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao novo conceito de Banco! The new Bank");
            Console.WriteLine("Selecione a Funcionalidade desejada");

            Console.WriteLine("1 - Listar Conta");
            Console.WriteLine("2 - Cadastrar nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("S - Sacar");
            Console.WriteLine("D - Depositar");
            Console.WriteLine("L - Limpar");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
