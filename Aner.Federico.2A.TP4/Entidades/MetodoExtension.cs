using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entidades
{
    public static class MetodoExtension
    {


        /// <summary>
        /// Metodo de Extension para usar en el test de consola, informa la ganancia sobre la Facturacion total bruta de ventas si son superados los costos de operacion q se pasan por parametro
        /// </summary>
        /// <param name="carrito"></param>
        /// <param name="montoCostos"></param>
        public static void GananciasSobreFacturacion(this Carrito carrito,float montoCostos)
        {
            
            if (carrito.FacturacionTotal > montoCostos)
            {
                float ganancia = carrito.FacturacionTotal - montoCostos;

                Console.WriteLine("Se superaron los costos, la ganancia es de: "+ganancia+" pesos.");
                

            }
            else
            {
                Console.WriteLine("Todavia no hay ganancias!");
            }
            

        }

       




    }
}
