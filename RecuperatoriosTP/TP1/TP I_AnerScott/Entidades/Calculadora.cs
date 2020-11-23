using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {



        /// <summary>
        /// Realiza el calculo segun el operador elegido
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Resultado de la operacion segun el case correspondiente</returns>
        public static double Operar(Numero num1, Numero num2,string operador)
        {
            double resultado=0;

            if (operador != "")
            {

                operador = ValidarOperador(Convert.ToChar(operador));

                
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


        /// <summary>
        /// Valida los operadores, caso contrario retorna +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Devuelve el operador en formato string</returns>
        private static string ValidarOperador (char operador)
        {
            


            string retorno = "+";

            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {

                return operador.ToString();
            }
            else {
                
                return retorno;

            }

        }

        


    }// Calculadora
}
