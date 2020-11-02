using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
       public enum EClases 
        {
            Programacion, 
            Laboratorio, 
            Legislacion, 
            SPD 
        }
       private List<Alumno> alumnos;
       private  List<Jornada> jornadas;
       private List<Profesor> profesores;


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
        /// Setea y devuelve el atributo profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get 
            {
                return this.profesores; 
            }
            set 
            { 
                this.profesores = value; 
            }
        }

        /// <summary>
        /// Setea y devuelve el atributo jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get 
            {
                return this.jornadas; 
            }
            set 
            { 
                this.jornadas = value;
            }
        }


        /// <summary>
        /// Setea y devuelve el atributo jornadas mediante indexadordx
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get 
            { 
                return jornadas[i]; 
            }
            set 
            { 
                jornadas[i] = value; 
            }
        }

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion


        #region Metodos
        /// <summary>
        /// Metodo q muestra los datos de la clase
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>String con la informacion</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada item in uni.jornadas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }


        /// <summary>
        /// Override de ToString q reutiliza MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }


        /// <summary>
        /// Guarda archivos en formato .xml en el directorio por defualt
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>True si pudo guardar</returns>
        public static bool Guardar(Universidad uni)
        {

            Xml<Universidad> temp = new Xml<Universidad>();
            return temp.Guardar("Universidad.xml", uni);

        }

        /// <summary>
        /// Lee archivos en formato .xml
        /// </summary>
        /// <returns>datos del archivo</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> temp = new Xml<Universidad>();
            Universidad uTemp;
            try
            {
                temp.Leer("Universidad.xml", out uTemp);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e.InnerException);
            }
            return uTemp;
        }

        #endregion



        #region Sobrecarga Operadores

        /// <summary>
        /// Sobrecarga del operador == Compara obj Universidad con Obj Alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>TRUE si el alumno pertenece a la lista de alumnos de la universidad,FALSE caso contrario</returns>
        public static bool operator == (Universidad g, Alumno a)
        {
            bool rta = false;

            foreach (Alumno item in g.alumnos)
            {
                if(a == item)
                {
                    rta = true;
                    break;
                }
            }

            return rta;
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }



        /// <summary>
        /// Sobrecarga del operador == Compara obj Universidad, obj Profesor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si el profesor da clases en la universidad, FALSE caso contrario </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool rta = false;

            foreach (Profesor item in g.profesores)
            {
                if (i == item)
                {
                    rta = true;
                    break;
                }
            }

            return rta;
        }



        /// <summary>
        /// Sobrecarga del operador != Compara obj Universidad, obj Profesor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        /// <summary>
        /// Sobrecarga del operador == Compara obj Universidad, con un enum Eclases
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Devuelve el primer prof q puede dar la clase, caso contrario lanza excepcion</returns>

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            //if (g == clase)
            //{
            //    return Profesor
            //}
            Profesor prof = null;

            foreach (Profesor item in u.profesores)
            {
                if(item == clase)
                {
                    prof = item;
                    break;

                }
                
            }

            if (prof is null)
            {
                throw new SinProfesorException("No hay un profesor para esta clase");
            }

            return prof;
        }



        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor prof = null;

            foreach (Jornada item in u.jornadas)
            {
                if (item.Clase != clase)
                {
                    prof = item.Instructor;
                    break;
                }

            }
            if (prof is null)
            {

                throw new SinProfesorException();

            }
            return prof;
        }



        /// <summary>
        ///  Sobrecarga operador +, 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g,EClases clase)
        {
            Profesor prof = (g == clase);
            Jornada jor = new Jornada(clase, prof);

            foreach (Alumno item in g.alumnos)
            {
                jor = jor + item;
            }

            g.jornadas.Add(jor);
            return g;
        }


        /// <summary>
        /// Sobrecarga operador +,
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Devuelve obj Universidad si el alumno no esta repetido, caso contrario lanza excepcion</returns>

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno Repetido");
            }
          
            return u;
        }



        /// <summary>
        /// Sobrecarga operador +,
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>Devuelve obj Universidad si el profesor no esta repetido</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        #endregion

  
    }
}
