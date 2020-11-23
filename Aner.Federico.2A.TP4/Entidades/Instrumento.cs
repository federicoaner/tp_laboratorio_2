using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Guitarra))]
    [XmlInclude(typeof(Bajo))]
    [XmlInclude(typeof(Bateria))]
    [XmlInclude(typeof(Violin))]

    public abstract class Instrumento
    {
        private int id;
        private string tipo;
        private string marca;
        private string modelo;
        private string estado;
        private float precio;


        #region Propiedades
        public int ID
        {
            get
            {
                return this.id;
            }
        }

        public String Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }
        public String Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }


        public String Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                this.modelo = value;
            }
        }

        public string Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        #endregion



        #region Constructores
        /// <summary>
        /// Constructor por Default
        /// </summary>
        public Instrumento()
        {

        }


        /// <summary>
        /// Constructor Parametrizado
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="estado"></param>
        /// <param name="precio"></param>
        public Instrumento(string tipo, string marca,string modelo,string estado, float precio)
        {

            

            this.tipo = tipo;
            this.marca =  marca;
            this.modelo = modelo;
            this.estado = estado;
            this.precio = precio;
            
            
        }



        /// <summary>
        /// Constructor Parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="estado"></param>
        /// <param name="precio"></param>
        public Instrumento(int id, string tipo, string marca,string modelo, string estado, float precio)
            :this(tipo,marca,modelo,estado,precio)
        {
            this.id = id;
        }

        #endregion



        #region Metodos


        /// <summary>
        /// Muestra los Datos de los Instrumentos
        /// </summary>
        /// <returns></returns>

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--------------------------------------------------------");
            sb.AppendFormat("\nMARCA: {0}\nMODELO: {1}\nESTADO:{2}\nPRECIO:{3}", this.marca,this.modelo, this.estado, this.precio);
            sb.AppendLine();

            return sb.ToString();
        }


       
        /// <summary>
        /// Sobrecarga del ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        #endregion

    }
}
