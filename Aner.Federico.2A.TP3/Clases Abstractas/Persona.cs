using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad 
        { 
            Argentino, 
            Extranjero 
        }
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;


        #region Atributos

        /// <summary>
        /// Propiedad que retorna y setea con validacion el apellido
        /// </summary>
        public string Apellido
        {
            get 
            { 
                return this.apellido; 
            }
            set 
            { 
                this.apellido =validarNombreApellido(value); 
            }
        }
        /// <summary>
        /// Propiedad que retorna y setea con validacion el Nombre
        /// </summary>
        public string Nombre
        {
            get 
            {
                return this.nombre; 
            }
            set 
            { 
                this.nombre = validarNombreApellido(value); 
            }
        }

        /// <summary>
        /// Propiedad que retorna y setea la Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get 
            {
                return this.nacionalidad; 
            }
            set 
            { 
                this.nacionalidad = value; 
            }
        }

        /// <summary>
        /// Propiedad que retorna y setea con validacion el Dni
        /// </summary>
        public int DNI
        {
            get 
            { 
                return this.dni; 
            }

            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad que setea con validacion el Dni tipo string
        /// </summary>
        public string StringToDNi
        {
            set 
            {
                this.dni = ValidarDni(this.Nacionalidad,value);
                
            }
        }

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por Defecto
        /// </summary>
        public Persona()
        {
            this.apellido = "";
            this.dni = -1;
            this.nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
              
        }
        
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            
        {
            this.nombre = validarNombreApellido(nombre);
            this.apellido = validarNombreApellido (apellido);
            this.nacionalidad = nacionalidad;

        }


        /// <summary>
        /// Constructor parametrizado y q invoca otro constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor parametrizado y q invoca otro constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido,nacionalidad)
        {
            this.StringToDNi = dni;
        }

        #endregion


        #region Metodos

        /// <summary>
        ///  Valida que el dni concuerde con el rango q corresponde a su nacionalidad
        /// </summary>
        /// <param name="nacionalidad">NNacionalidad de una Persona</param>
        /// <param name="dato">Dni formato int</param>
        /// <returns>Dni Validado</returns>
        private int ValidarDni (ENacionalidad nacionalidad, int dato)
        {
             if ((nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
              || nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
           
            {
                return dato;
            }
            
            else
            {
                throw new NacionalidadInvalidaException("Nacionalidad no corresponde a su número de DNI");
            }

        }

        /// <summary>
        /// Valida formato del Dni y que la nacionalidad sea correcta
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Dni formato String</param>
        /// <returns>Dni Validado</returns>

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int rta = -1;

            if (dato.Length >= 1 && dato.Length <= 8 && (Int32.TryParse(dato, out dni)))
            {
                rta = ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException("Formato Invalido");
            }

            return rta;


        }

        /// <summary>
        /// Valida q el dato ingresado solo contenga letras 
        /// </summary>
        /// <param name="dato">Apellido o Nombre</param>
        /// <returns>cadena vacia si es incorrecto</returns>

        string validarNombreApellido(string dato)
        {
            bool flag = true;
            string rta = "";

            foreach (Char ch in dato)
            {
                if (!Char.IsLetter(ch) && ch != 32)
                {
                    flag = false;
                    break;
                }
            }

            if (flag == true)
            {
                rta = dato;
            }

            return rta;


        }

        /// <summary>
        /// Sobrecarga de toString
        /// </summary>
        /// <returns> devuelve cadena con la informacion de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0},{1}\n", this.apellido, this.nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.nacionalidad);

            return sb.ToString();
        }




        #endregion



    }
}
