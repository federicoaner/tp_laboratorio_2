using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    /// <summary>
    /// Clase publica hereda de vehiculo
    /// </summary>
    public class Ciclomotor : Vehiculo
    {
       
        
        /// <summary>
        /// Constructor reutiliza parametros de la clase base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        

        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio //es una sobrecarga, corregido Override y ETamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }


        /// <summary>
        /// Sobrecarga  publica y sellada de Mostrar
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar() 
                                                
        {
            StringBuilder sb = new StringBuilder(); //Append format corregidos 
                                                    //y ToString en el retorno

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
