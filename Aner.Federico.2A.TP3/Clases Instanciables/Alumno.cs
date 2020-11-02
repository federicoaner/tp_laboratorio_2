using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {

        public enum EEstadoCuenta 
        { 
            AlDia, 
            Deudor, 
            Becado 
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;


        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
            :base()
        {

        }

        /// <summary>
        /// Constructor parametrizado, invoca atributos de base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor parametrizado, invoca atributos de base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Override que muestra los datos del alumno
        /// </summary>
        /// <returns>Cadena con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendFormat("Estado de Cuenta: {0}\n", this.estadoCuenta);
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Override q muestra la clase que toma
        /// </summary>
        /// <returns>Cadena de la Clase q toma</returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASES DE: " + this.claseQueToma);
        }

        /// <summary>
        /// Override de ToSting q Reutuliza Mostrar datos
        /// </summary>
        /// <returns>cadena con los datos del alumno</returns>

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion


        #region Sobrecarga Operadores
       
        
        /// <summary>
        /// Sobrecarga del ==, Compara Alumno con clase q toma y si no es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>TRUE si tomo esa clase y no es deudor, False si no cumple las condiciones</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
           

            bool res = false;

            if (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
            {
                res = true;
            }

            return res;

        }


        /// <summary>
        /// Sobrecarga del !=,
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool rta = false;

            if (a.claseQueToma != clase)
            {
                rta = true;
            }

            return rta;
        }

        #endregion


    }
}
