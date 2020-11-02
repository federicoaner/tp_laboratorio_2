using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
       
        /// <summary>
        /// Verifica q se lanze NacInvalidaExecption pasandole rangos invalidos al dni para cada nacionalidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void VerificarNacionalidadInvalida()
        {
            string dniExtIncorrecto = "30000000";
            string dniArgIncorrecto = "99999999";
            

           Alumno a1 = new Alumno(1,"asasada","ds", dniExtIncorrecto, Persona.ENacionalidad.Extranjero,Universidad.EClases.Laboratorio);
           Alumno a2 = new Alumno(2, "aasd", "fdgd",dniArgIncorrecto, Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);

        }


        /// <summary>
        /// Verifica q se lazce AlumnoRepetidoExecption agregando alumnos repetidos a un obj Universidad
        /// </summary>

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void VerificarAlumnoRepetido()
        {
            Universidad univ = new Universidad(); 

            Alumno a1 = new Alumno(1, "jose", "perez", "30000000", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Alumno a2 = new Alumno(1, "jose", "perez", "30000000", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);

            univ += a1;
            univ += a2;
        
        }

        [TestMethod]
        public void ListaJornadasCorrecta()
        {
            Universidad u1 = new Universidad();
            Assert.IsNotNull(u1.Jornadas);
        }

    }
}
