using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public AlumnoRepetidoException()
            : base ("ocurrio un error")
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException (string mensaje)
            : base(mensaje)
        {

        }

    }
}
