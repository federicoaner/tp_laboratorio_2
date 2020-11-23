using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ArchivosException()
            : base("Hubo un Error con los Archivos!")
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosException(string mensaje)
            : base(mensaje)
        {

        }


        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)

        {

        }

     

    }
}
