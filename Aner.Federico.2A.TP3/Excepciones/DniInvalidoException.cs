using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {

        /// <summary>
        /// Constructor por defecto
        /// </summary>
       public DniInvalidoException()
            : base(" Ha ocurrido un error")
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="mensaje"></param>
        public DniInvalidoException(string mensaje)
            : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException (Exception e)
            : base (e.Message)
        {

        }
        public DniInvalidoException(string menesaje, Exception e) 
            : base (menesaje + e.Message)
        {

        }

    }
}
