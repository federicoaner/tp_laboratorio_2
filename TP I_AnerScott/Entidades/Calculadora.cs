using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        public static double Operar(Numero num1, Numero num2,string operador)
        {
            double resultado=0;

            if (operador != "")
            {

                operador = ValidarOperador(Convert.ToChar(operador));

                //switch (ValidarOperador (Convert.ToChar(operador)))
                switch (operador)
                {

                    case "-":
                        resultado = num1 - num2;
                        break;

                    case "+":

                        resultado = num1 + num2;
                        break;

                    case "/":

                        resultado = num1 / num2;
                        break;

                    case "*":

                        resultado = num1 * num2;
                        break;
                }

            }

            return resultado;
        }

        private static string ValidarOperador (char operador)
        {
            //string retorno;

            //if (operador != '+' && operador != '-' && operador != '/' && operador != '*')
            //{

            //    retorno = "+";
            //}

            //retorno = (Convert.ToString(operador));
            //return retorno;


            

            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {

                return operador.ToString();
            }
            else {
                return "+";

            }

        }

        


    }// Calculadora
}
