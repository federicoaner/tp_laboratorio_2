using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carrito
    {
        public List<Instrumento> listaInstrumentos;
        private int capacidad;

        #region Constructores


        /// <summary>
        /// Constructor inicia la lista
        /// </summary>
        public Carrito()
        {
            this.listaInstrumentos = new List<Instrumento>();
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="capacidad"></param>
        public Carrito(int capacidad)
            : this()
        {
            this.capacidad = capacidad;
        }


        #endregion


        /// <summary>
        /// propiedad q calcula la facturacion total bruta
        /// </summary>

        #region Propiedades

        public float FacturacionTotal
        {
            get
            {
                float total = 0;

                foreach (Instrumento item in this.listaInstrumentos)
                {
                    total += item.Precio;
                }


                return total;
            }
        }
        #endregion



        #region Metodos



        /// <summary>
        /// Sobrecarga del ToString para mostrar todos los datos de la lista
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CASA DE MUSICA:");
            sb.AppendFormat("CANTIDAD DE VENTAS: {0}\n", this.listaInstrumentos.Count);
            sb.AppendFormat("TOTAL ACUMULADO ES: {0}", this.FacturacionTotal + " pesos. \n\n");
            foreach (Instrumento item in this.listaInstrumentos)
            {
                sb.Append(item.ToString());
              
            }

            return sb.ToString();
        }


        /// <summary>
        /// Guarda archivos en formato txt
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        public static bool Guardar(Carrito venta)
        {
            Texto txt = new Texto();
            return txt.Guardar("carrito.txt", venta.ToString());
        }

        /// <summary>
        /// Lee Archivos en formato Txt
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            txt.Leer("carrito.txt", out string datos);

            return datos;
        }

        /// <summary>
        /// Serializa los objetos
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        public static bool GuardarXml(Carrito venta)
        {
            Xml<Carrito> temp = new Xml<Carrito>();

            return temp.Guardar("carrito.xml", venta);
        }

        /// <summary>
        /// Deserializa
        /// </summary>
        /// <returns></returns>
        public static Carrito LeerXml()
        {

            Xml<Carrito> temp = new Xml<Carrito>();
            Carrito cTemp;
           // try
            //{
                temp.Leer("carrito.xml", out cTemp);
            //}
            //catch(Exception ex)
            //{
              //  throw new ArchivosException();
           // }
            return cTemp;
        }




        #endregion


        

        #region Sobrecargas
        /// <summary>
        /// Chequea  si los instrumentos se encuentran en la lista del Carrito 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Carrito car, Instrumento inst)
        {
            bool ok = false;

            if ((object)car != null && (object)inst != null)
            {
                foreach (Instrumento item in car.listaInstrumentos)
                {
                    if (item.Equals(inst))
                    {
                        ok = true;
                        break;
                    }
                }
            }

            return ok;
        }

        public static bool operator !=(Carrito car, Instrumento inst)
        {
            return !(car == inst);
        }


        /// <summary>
        /// Agrega un instrumento si este no se encuentra en la lista
        /// </summary>
        /// <param name="c"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Carrito operator +(Carrito car, Instrumento inst)
        {
            if (car != inst)
            {
                car.listaInstrumentos.Add(inst);
            }
            return car;
        }


        #endregion

    }

}


