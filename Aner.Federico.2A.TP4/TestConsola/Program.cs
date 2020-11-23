using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            Carrito carritoUno = new Carrito(2);

            Guitarra g1 = new Guitarra(1,"Guitarra", "Gibson", "Les Paul", "usado", 10000);
            Violin v1 = new Violin(2,"Violin", "Stradivarius", "pepito", "usado", 10000);
            Bajo b1 = new Bajo(3, "Bajo", "Fender", "precision Bass", "nuevo", 10000);
            Bateria bat1 = new Bateria(4, "Bateria", "Tama", "Sx", "nuevo", 10000);
           


            carritoUno += g1; //agrego productos al carrito
            carritoUno += v1;
            carritoUno += b1;
            carritoUno += bat1;
            

            Console.WriteLine(carritoUno.ToString()); //Pruebo el ToString
            carritoUno.GananciasSobreFacturacion(25000); // Pruebo el Metodo de Extension, para calcular la ganancia real, al que le paso los costos por parametro




            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Presione Tecla Para Continuar!!!!!\n\n");

            Console.ReadKey();
            Console.Clear();


            try //Prueba de Archivos TXT/Xml... Guardar y Leer
            {

                Console.WriteLine("Chequeo guardar y abrir archivos.");
                
                if (Carrito.GuardarXml(carritoUno))
                {
                    Console.WriteLine("SERIALIZACION EXITOSA!!!");
                }
                
                
                if (Carrito.Guardar(carritoUno))
                {
                    Console.WriteLine("Archivo guardado con exito!!\n\n");
                }




                Console.WriteLine("LECTURA ARCHIVO EN FORMATO TXT");
                Console.WriteLine(Carrito.Leer());

            }
            catch(ArchivosException ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            Console.ReadLine();
        }
    }
}
