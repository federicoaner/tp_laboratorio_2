using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml <T> : IArchivo<T>
    {


        public bool Guardar(string archivo, T datos)
        {
            bool ok = true;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, datos);
                }

            }
            catch (Exception e)
            {
                ok = false;
                throw new ArchivosException(e);
            }

            return ok;
        }


        public bool Leer(string archivo, out T datos)
        {
            bool ok = true;
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
                ok = false;
                Console.WriteLine(e.Message);
            }

            return ok;


        }


    }
}
