using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class HiloAbortException :Exception
    {



        public HiloAbortException()
            : base("No se puede cerrar Hilo!")
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="mensaje"></param>
        public HiloAbortException(string mensaje)
            : base(mensaje)
        {

        }


        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="innerException"></param>
        public HiloAbortException(Exception innerException)

        {

        }







    }
}
