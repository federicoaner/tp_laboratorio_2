﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {


        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ArchivosException()
            : base(" Ha ocurrido un error")
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
