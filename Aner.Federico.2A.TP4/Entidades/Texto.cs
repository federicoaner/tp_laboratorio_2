using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Texto : IArchivo<string>
    {



        /// <summary>
        ///  Guarda en un archivo  el string  pasado por parametro
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string path, string datos)
        {
            bool rta = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    if (sw != null)
                    {
                        sw.Write(datos);
                        rta = true;
                    }
                    else
                    {
                        throw new ArchivosException();
                    }
                }
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return rta;
        }

        /// <summary>
        /// Lee Archivos de Texto
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns></returns>

        public bool Leer(string path, out string datos)
        {
            bool rta = false;
            datos = default;

            try
            {
                using (StreamReader lector = new StreamReader(path))
                {
                    if (lector != null)
                    {
                        datos = lector.ReadToEnd();
                        rta = true;
                    }
                    else
                    {
                        throw new ArchivosException();
                    }
                }
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return rta;
        }
    }

}
