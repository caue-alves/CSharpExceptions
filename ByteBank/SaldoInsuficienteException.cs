using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException(double saldo, double ValorSaque)
            : this("Tentativa de saque de " + ValorSaque + " excede seu saldo atual de " + saldo + " Favor inserir uma valor válido")
        {

        }
        public SaldoInsuficienteException(string message="")
            : base(message)
        {
        }
    }
}
