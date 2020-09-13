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



        public string SetNumero //unica lugar donde llamo a ValidarNumero
        {
            // get { return myVar; }
            set { this.numero = ValidarNumero(value); }
        }


        private double ValidarNumero(string strNumero)
        {
            double num = 0;

            double.TryParse(strNumero, out num);

            return num;
        }

        #region METODOS BINARIO/DECIMAL


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

        public string DecimalBinario(string numero)
        {

            return DecimalBinario(double.Parse(numero));

        }

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



        #endregion





        #region CONSTRUCTORES

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion






        #region SOBRECARGA DE OPERADORES

        public static double operator -(Numero n1, Numero n2)
        {

            double rta = n1.numero - n2.numero;

            return rta;
        }
        public static double operator +(Numero n1, Numero n2)
        {

            double rta = n1.numero + n2.numero;

            return rta;
        }

        public static double operator /(Numero n1, Numero n2)
        {

            double rta = double.MinValue;

            if (n2.numero != 0)
            {
                rta = n1.numero / n2.numero;
            }


            return rta;
        }

        public static double operator *(Numero n1, Numero n2)
        {

            double rta = n1.numero * n2.numero;

            return rta;
        }


        #endregion



    }// Numero
}
