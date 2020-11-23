using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {

        private double numero;

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de solo escritura, setea el nro previa validacion mediante el metodo ValidarNumero
        /// </summary>
        private string SetNumero //unica lugar donde llamo a ValidarNumero
        {
            
            set { this.numero = ValidarNumero(value); }
        }
        #endregion



        #region CONSTRUCTORES


        /// <summary>
        /// Constructor Por defualt
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor con Parametros
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
            :this()
        {
            this.numero = numero;
        }


        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
            
        {
            this.SetNumero = strNumero;
        }

        #endregion




        #region METODOS 



        /// <summary>
        /// Convierte el nro recibido de Binario a Decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna el nro Decimal convertido en formato String, caso contrario mensaje de Error</returns>
        public string BinarioDecimal(string binario)
        {
            bool binarioOK;
            

            binarioOK = EsBinario(binario);

            char[] array = binario.ToCharArray();

            Array.Reverse(array);
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    if (i == 0)
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }
            }

            if (!EsBinario(binario))
            {
                return "valor invalido";
            }

            return Convert.ToString(sum);
        }

        /// <summary>
        /// Convierte Decimal a binario, el nro recibido
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el nro binario en formato String</returns>

        public string DecimalBinario(double numero)
        {
            string resul;
            long entero = (long)numero;
            

            if (entero < 0)
            {
                entero *= -1;
            }

            resul = Convert.ToString(entero, 2);
            return resul;

        }


        /// <summary>
        /// Convierte el Nro recibido a Binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Nro binario en formato String</returns>
        public string DecimalBinario(string numero)
        {
            double num;
            string resul;
            
            if (double.TryParse(numero, out num))
            {
                resul= DecimalBinario(num);
            }
           
            else
            {
                resul = "Error, Valor Invalido!!!";
            }

            return resul;

        }


        /// <summary>
        /// Valida si el nro recibido por parametro, es binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Booleano...true o false</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '1' || binario[i] == '0')
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }



        /// <summary>
        /// Valida q el nro ingresado sea un nro
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Numero Validado</returns>
        private double ValidarNumero(string strNumero)
        {
            double num = 0;

            double.TryParse(strNumero, out num);

            return num;
        }


        #endregion




        #region  OPERADORES



        /// <summary>
        /// Resta los nros recibidos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {

            double rta = n1.numero - n2.numero;

            return rta;
        }


        /// <summary>
        /// Suma los nros recibidos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {

            double rta = n1.numero + n2.numero;

            return rta;
        }


        /// <summary>
        /// Divide los nros recibidos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado division</returns>
        public static double operator /(Numero n1, Numero n2)
        {

            double rta = double.MinValue;

            if (n2.numero != 0)
            {
                rta = n1.numero / n2.numero;
            }


            return rta;
        }



        /// <summary>
        /// Multiplica los nros recibidos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado de la Multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {

            double rta = n1.numero * n2.numero;

            return rta;
        }


        #endregion






    }
}
