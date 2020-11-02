using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public NacionalidadInvalidaException()
            : base(" Ha ocurrido un error")
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje)
            :base (mensaje)
        {

        }

    }
}
