using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo //tiene q ser abstracta
    {
       
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
       
        /// <summary>
        /// Constructor de vehiculo
        /// </summary>
        /// <param name="chasis">Chasis del vehiculo</param>
        /// <param name="marca">Marca del vehiculo</param>
        /// <param name="color">Color del vehiculo </param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }



        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio 
        {
            get;
        }

        
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }






        #region Sobrecarga de operadores



        /// <summary>
        /// Sobrecarga explicita, retorna un string con los datos de un vehiculo,recibe un vehiculo
        /// </summary>
        /// <param name="p"> vehiculo </param>


        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);  //Append format corregidos y to string en el retorno
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }



        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2) 
        {
            return !(v1 == v2); //Retorno no contenia negacion
        }

        #endregion


        #region Enumerados
        public enum EMarca //publicos
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion




        // invalido object y hashcode para eliminar los warning  pero lo dejo comentado
        // ya que no aparecen en el diagrama de clases

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        //public override bool Equals(object obj)
        //{
        //    bool rta = false;

        //    if (obj is Vehiculo)
        //    {
        //        rta = this == (Vehiculo)obj;
        //    }

        //    return rta;
        //}


    }
}
