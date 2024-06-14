using System.Collections.Generic;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace BancoOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();

            while (true)
            {
                Console.WriteLine("1. Criar conta");
                Console.WriteLine("2. Listar contas");
                Console.WriteLine("3. Depositar");
                Console.WriteLine("4. Sacar");
                Console.WriteLine("5. Transferir");
                Console.WriteLine("6. Consultar saldo");
                Console.WriteLine("7. Sair");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CriarConta(banco);
                        break;
                    case 2:
                        banco.ListarContas();
                        break;
                    case 3:
                        Depositar(banco);
                        break;
                    case 4:
                        Sacar(banco);
                        break;
                    case 5:
                        Transferir(banco);
                        break;
                    case 6:
                        ConsultarSaldo(banco);
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }

            static void CriarConta(Banco banco)
            {
                Console.Write("Número da conta: ");
                string numero = Console.ReadLine();
                Console.Write("Titular: ");
                string titular = Console.ReadLine();
                Console.Write("Saldo inicial: ");
                double saldoInicial = double.Parse(Console.ReadLine());

                banco.CriarConta(numero, titular, saldoInicial);
            }

            static void Depositar(Banco banco)
            {
                Console.Write("Número da conta: ");
                string numero = Console.ReadLine();
                Console.Write("Saldo: ");
                double valor = double.Parse(Console.ReadLine());

                Conta conta = banco.BuscarContaPorNumero(numero); // Busca a conta pelo número

                if (numero != null)
                {
                    conta.Depositar(valor);
                } else
                {
                    Console.WriteLine("Conta não encontrada.");
                }
            }

            static void Sacar(Banco banco)
            {
                Console.Write("Número da conta: ");
                string numero = Console.ReadLine();
                Console.Write("Valor: ");
                double valor = double.Parse(Console.ReadLine());

                Conta conta = banco.BuscarContaPorNumero(numero);
                if (conta != null)
                {
                    conta.Sacar(valor);
                }
                else
                {
                    Console.WriteLine("Conta não encontrada.");
                }
            }

            static void Transferir(Banco banco)
            {
                Console.Write("Número da conta de origem: ");
                string numeroOrigem = Console.ReadLine();
                Console.Write("Número da conta de destino: ");
                string numeroDestino = Console.ReadLine();
                Console.Write("Valor: ");
                double valor = double.Parse(Console.ReadLine());

                Conta contaOrigem = banco.BuscarContaPorNumero(numeroOrigem);
                Conta contaDestino = banco.BuscarContaPorNumero(numeroDestino);

                if (contaOrigem != null && contaDestino != null)
                {
                    contaOrigem.Transferir(contaDestino, valor);
                }
                else
                {
                    Console.WriteLine("Conta de origem ou destino não encontrada.");
                }
            }

            static void ConsultarSaldo(Banco banco)
            {
                Console.Write("Número da conta: ");
                string numero = Console.ReadLine();

                Conta conta = banco.BuscarContaPorNumero(numero);
                if (conta != null)
                {
                    conta.ExibirDetalhes();
                }
                else
                {
                    Console.WriteLine("Conta não encontrada.");
                }
            }
        }
    }
}
