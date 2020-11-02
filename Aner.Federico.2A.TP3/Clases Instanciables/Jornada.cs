using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {

        private List <Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;


        #region Propiedades

       /// <summary>
       /// Setea y devuelve el atributo alumnos
       /// </summary>
        public List<Alumno> Alumnos
        {
            get 
            { 
                return this.alumnos; 
            }
            set 
            { 
                this.alumnos = value; 
            }
        }

        /// <summary>
        /// Setea y devuelve el atributo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get 
            { 
                return this.clase; 
            }
            set 
            { 
                this.clase = value; 
            }
        }
        /// <summary>
        /// Setea y devuelve el atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get 
            { 
                return this.instructor; 
            }
            set 
            { 
                this.instructor = value; 
            }
        }

        #endregion


        #region Constructores
        /// <summary>
        /// Constructor por defecto privado, inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        
        
        /// <summary>
        /// Constructor patametrizado invoca otro constructor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;

        }

        #endregion


        #region Metodos

        /// <summary>
        /// Override de ToString 
        /// </summary>
        /// <returns>retorna cadena con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("JORNADA: ");
            sb.AppendFormat("CLASE DE: {0} POR  {1} \n\n", this.clase.ToString(), this.instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
               sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<--------------------------------------------------->");

            return sb.ToString();
        }

        /// <summary>
        /// Metodo estatico que guarda Archivos en formato .txt, en el directorio por default
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si pudo guardar, false caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            
            Texto nuevoTexto = new Texto();

            return nuevoTexto.Guardar("jornada.txt", jornada.ToString());
     
        }

        /// <summary>
        /// Metodo estatico que lee Archivos en formato .txt
        /// </summary>
        /// <returns>un string con los datos</returns>
        public static string Leer()
        {
            string rta;
            Texto nuevoTexto = new Texto();

            nuevoTexto.Leer("jornada.txt", out rta);

            return rta;
        }

        #endregion


        #region Sobrecarga Operadores

        /// <summary>
        /// Sobrecarga del ==, compara obj jornada con obj alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>TRUE si alumno pertenece a la clase, FALSE caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool rta = false;

            if (a == j.clase)
            {
                rta = true;
            }

            return rta;
        }

        /// <summary>
        /// Sobrecarga del !=
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }



        public static Jornada operator +(Jornada j, Alumno a) 
        {
            bool flag = false;
            foreach (Alumno item in j.alumnos)
            {

                if (item == a)
                {
                    flag = true;
                }

            }

            if (flag == false && a == j.clase)
            {
                j.alumnos.Add(a);
            }

            return j;


        }

        #endregion


    }
}
