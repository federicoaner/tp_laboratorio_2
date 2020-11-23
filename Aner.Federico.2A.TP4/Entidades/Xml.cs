using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Xml<T> : IArchivo<T>
    {


        /// <summary>
        /// Serializa  en xml el tipo de dato generico T 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool ok = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, datos);
                    ok = true;
                }

            }
            catch (Exception)
            {

                throw new ArchivosException();
            }

            return ok;
        }



        /// <summary>
        /// Deserializa  archivos xml el tipo de dato generico T 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool ok = false;
            datos = default(T);
            try
            {
                using (XmlTextReader read = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    datos = (T)ser.Deserialize(read);
                    ok = true;
                }

            }
            catch (Exception e)
            {
              
                Console.WriteLine(e.Message);
            }

            return ok;


        }









    }
}
