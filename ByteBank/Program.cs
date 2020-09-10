using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ContaCorrente conta = new ContaCorrente(50, 2981))
                {
                    conta.Sacar(1000);
                    // Precisa implementar IDisposable
                }
                    
            }
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch (SaldoInsuficienteException e)
            //{
            //    Console.WriteLine(e.Message);
            /*}*/ catch(Exception e)
            {
                Console.WriteLine(e.Message + " " + e.StackTrace + " " + e.InnerException);
            }
            Console.WriteLine(ContaCorrente.taxaOperacao);

            Console.WriteLine("Fim da aplicação. Tecle enter para sair...");
            Console.ReadLine();
        }
    }
}
