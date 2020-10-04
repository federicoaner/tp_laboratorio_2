using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// Clase publica hereda de Vehiculo
    /// </summary>
   public class Sedan : Vehiculo
    {
       
         private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas;
        }


        /// <summary>
        /// Constructor, reutiliza parametros del constructor por defecto agrega tipo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color,ETipo tipo)
            : this(marca,chasis,color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio //es una sobrecarga, corregido Override y ETamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }


        /// <summary>
        /// Sobreescribe el metodo mostrar de vehiculo, publica y sellada
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder(); //Append format corregidos 
                                                    //y ToString en el retorno

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        
        
        /// <summary>
        /// Enumerados
        /// </summary>
        public enum ETipo { CuatroPuertas, CincoPuertas }

    }
}
