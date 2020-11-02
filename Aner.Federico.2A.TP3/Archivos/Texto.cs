using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        public bool Guardar(string archivo, string datos)
        {

            bool ok = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false))
                {

                    sw.WriteLine(datos);
                    ok = true;
                }
            }
            catch (Exception e)
            {
                
                throw new ArchivosException(e);

            }
            return ok;

        }


        public bool Leer(string archivo, out string datos)
        {
            bool ok = true;
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                ok = false;
                throw new ArchivosException(e);
            }
            return ok;

        }

    }

}
