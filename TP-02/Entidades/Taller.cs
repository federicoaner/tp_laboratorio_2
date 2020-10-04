using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
     public sealed class Taller // estaba public
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
       

        #region "Constructores"
        
        /// <summary>
        /// Constructor inicializa la lista de vehiculos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
       
        /// <summary>
        /// Constructor publico reutiliza el constructur q inicializa la lista
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible)
            :this() 
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion



        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo) //agregados IF para forzar q entre a cada tipo en particular
                {

                    case ETipo.Suv:
                        if(v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        
                        break;
                   
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                       
                        break;
                   
                    case ETipo.Sedan:
                        if(v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                   
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            int esta = 0; // variable de control

            foreach (Vehiculo v in taller.vehiculos) //correcion talle.vehiculos
            {
                if (v == vehiculo) 
                {
                    esta = 1; //chequeo si un vehiculo esta en la lista
                    break;
                }     
                  
            }

            if (esta==0 && taller.espacioDisponible > taller.vehiculos.Count()) // si no esta en la lista y hay espacio lo agrago
            {
                taller.vehiculos.Add(vehiculo);
                return taller;
            }

            
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos) //correcion taller.vehiculos
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(v); //faltaba el remove, si el vehiculo se encuentra en la lista lo elimina
                    break;
                }
            }

            return taller;
        }
        #endregion


        /// <summary>
        /// Enumerados
        /// </summary>
        public enum ETipo
        {
            Ciclomotor, Sedan, Suv, Todos
        }
    }
}
