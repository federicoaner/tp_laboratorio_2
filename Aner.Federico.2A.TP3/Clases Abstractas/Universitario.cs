using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {

        private int legajo;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario() 
            : base()
        {
            this.legajo = -1;
        }

        /// <summary>
        /// Constructor paremetrizado, invoca a base
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
         : base (nombre,apellido,dni,nacionalidad)
        {

            this.legajo=legajo;
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Muestra datos de los atributos de clase y los de la clase base
        /// </summary>
        /// <returns>devuelve cadena con los datos</returns>
        virtual protected string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);
            return sb.ToString();

        }

        /// <summary>
        /// Metodo abtracto
        /// </summary>
        /// <returns></returns>
        abstract protected string ParticiparEnClase();

        #endregion


        #region Sobrecargas
        /// <summary>
        /// Sobrecarga ==, comprara objetos por tipo, legajo y Dni
        /// </summary>
        /// <param name="pg1">universitario obj</param>
        /// <param name="pg2">universitario obj 2</param>
        /// <returns>TRUE si son iguales, FALSE si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool res = false;

            if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                res = true;
            }

            return res;

          

        }

        /// <summary>
        /// Sobrecarga !=, comprara objetos por tipo, legajo y Dni
        /// </summary>
        /// <param name="pg1">universitario obj/param>
        /// <param name="pg2">universitario obj 2</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

       
        /// <summary>
        /// Sobrecarga de Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
          

            bool res = false;

            if (obj is Universitario)
            {
                if ((Universitario)obj == this)
                {
                    res = true;
                }
            }

            return res;

        }


        #endregion


    }
}
