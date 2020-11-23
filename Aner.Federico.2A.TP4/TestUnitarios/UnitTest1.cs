using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Chequea si es correcto el valor de la propiedad FacturacionTotal de la clase Carrito
        /// </summary>
        [TestMethod]
        public void ChequearFacturacionTotal_OK()
        {

            Carrito car = new Carrito();
            Guitarra g1 = new Guitarra("fsda", "asdf", "fdf", "usado", 1000);
            Bateria b1 = new Bateria("fsda", "asdf", "fdf", "usado", 1000);
            Violin v1 = new Violin("aaa", "aaa", "ggg", "sfgd", 1000);
            Bateria bat1 = new Bateria("sad", "sad", "asdaf", "sad", 1000);

            car += g1;
            car += b1;
            car += v1;
            car += bat1;

            float totalVentas = car.FacturacionTotal;

            Assert.AreEqual(4000, totalVentas);


        }




        /// <summary>
        /// Chequea q la lista  ingrese productos correctamente
        /// </summary>
        [TestMethod]
        public void TotalElementosIngresadosLista_OK()
        {

            Carrito car = new Carrito();
            Guitarra g1 = new Guitarra("dsa","asdf","fdf","usado",1234);
            Bateria b1 = new Bateria("fsda", "asdf", "fdf", "usado", 1234);

            car += g1;
            car += b1;

            int totalElementos = car.listaInstrumentos.Count;

            Assert.AreEqual(2, totalElementos);


        }



        


        
        


    }
}
