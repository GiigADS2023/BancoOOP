using BancoOOP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOOP
{
    public class Banco
    {
        public List<Conta> Contas { get; private set; } = new List<Conta>();

        // Cria uma nova conta e adiciona à lista de contas.
        public void CriarConta(string numero, string titular, double saldoInicial)
        {
            Conta conta = new Conta(numero, titular, saldoInicial);
            Contas.Add(conta);
            Console.WriteLine("Conta criada com sucesso!");
        }

        // Busca uma conta pelo número e retorna a conta encontrada.
        public Conta BuscarContaPorNumero(string numero)
        {
            return Contas.Find(c => c.Numero == numero);
        }

        // Lista todas as contas do banco.
        public void ListarContas()
        {
            foreach (var conta in Contas)
            {
                conta.ExibirDetalhes();
            }
        }
    }
}