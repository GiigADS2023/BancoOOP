using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOOP
{
    public class Conta
    {
        public string Numero { get; set; }
        public string Titular { get; set; }
        public double Saldo { get; set; }

        public Conta(string numero, string titular, double saldoInicial)
        {
            Numero = numero;
            Titular = titular;
            Saldo = saldoInicial;
        }

        // Adiciona um valor ao saldo
        public void Depositar(double valor)
        {
            Saldo += valor;
            Console.WriteLine("Depósito realizado com sucesso.");
        }

        // Subtrai um valor do saldo, se houver saldo suficiente
        public bool Sacar(double valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                Console.WriteLine("Saque realizado com sucesso.");
                return true;
            } else
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
        }

        // Transfere um valor para outra conta, se houver saldo suficiente
        public bool Transferir(Conta destino, double valor)
        {
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                Console.WriteLine("Transferência realizada com sucesso!");
                return true;
            }
            else
            {
                return false;
            }
        }

        // Exibe as informações da conta(número, titular, saldo)
        public void ExibirDetalhes()
        {
            Console.WriteLine($"Número da conta: {Numero}, Titular: {Titular}, Saldo: {Saldo}");
        }
    }
}

