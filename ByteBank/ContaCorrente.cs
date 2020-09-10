// using _05_ByteBank;

using Exceptions;
using System;

namespace ByteBank
{
    public class ContaCorrente : IDisposable
    {
        public static double taxaOperacao { get; private set; }

        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }
        public static int TotalSaqueSemSaldo { get; private set; }

        private int _agencia;
        public int Agencia
        {
            get
            {
                return _agencia;
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }

                _agencia = value;
            }
        }
        public int Numero { get;}

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numero)
        {
            if(agencia <= 0)
            {
                throw new ArgumentException("O seguinte argumento está inválido, favor inserir um valor válido", nameof(agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O seguinte argumento está inválido, favor inserir um valor válido", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
            try 
            {
                taxaOperacao = 30 / TotalDeContasCriadas;
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                // throw;
            }
            finally
            {
                Console.WriteLine("Ação executada");
            }
        }


        public void Sacar(double valor)
        {
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(_saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                throw new ArgumentException("Valor inválido para a transferência ", nameof(valor));
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
        }

           public void Dispose()
        {
            Console.WriteLine("Fechando...");
        }
    }
}
