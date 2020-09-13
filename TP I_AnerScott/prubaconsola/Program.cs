using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace prubaconsola
{
    class Program
    {
        static void Main(string[] args)
        {

            // Console.WriteLine(Calculadora.ValidarOperador('a'));
            //

            Numero numero = new Numero(1);
            Numero numero2 = new Numero(2);

            Console.WriteLine( Calculadora.Operar(numero,numero2,"+"));

            Console.ReadKey(true);

             
        }
    }
}
