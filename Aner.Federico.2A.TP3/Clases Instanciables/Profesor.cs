using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
       
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;


        #region Constructores


        /// <summary>
        /// Constructor por defecto estatico
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }


        /// <summary>
        /// Constructor por defecto de instancia, inicializa la cola de clases del dia
        /// </summary>
        public Profesor()
        {
            claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();

        }

        /// <summary>
        /// Constructor parametrizado, incializa nueva instancia de profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni,ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad )
        {
           
            Profesor temp = new Profesor();
            this.claseDelDia = temp.claseDelDia;

        }

        #endregion


        #region Metodos

        /// <summary>
        /// Metodo q asigna una clase aleatoria al enum de Eclases
        /// </summary>
        private void _randomClases()
        {
            
            this.claseDelDia.Enqueue((Universidad.EClases)Enum.Parse(typeof(Universidad.EClases), random.Next(0, 4).ToString()));
        }

        /// <summary>
        /// Override de MostrarDatos
        /// </summary>
        /// <returns>retorna los datos del profesor en un string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            
            return sb.ToString();
        }


        /// <summary>
        /// Retorna un string con las clases del dia
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in claseDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();

        }


        /// <summary>
        /// Override de ToString q reutiliza codigo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion


        #region Sobrecarga Operadores

        /// <summary>
        /// Sobrecarga del ==
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>TRUE si la clase del dia del prof pertenece a la Eclase </returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool rta = false;

            foreach (Universidad.EClases item in i.claseDelDia)
            {
                if (item == clase)
                {
                    rta = true;
                    break;
                }
            }

            return rta;

        }

        /// <summary>
        /// Sobrecarga del !=
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);

        }

        #endregion

    }
}
