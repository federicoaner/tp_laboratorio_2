﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Violin : Instrumento
    {


        private int id;
        private string tipo = "Violin";


        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Violin()
            :base()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="estado"></param>
        /// <param name="precio"></param>
        public Violin(string tipo, string marca, string modelo, string estado, float precio)
            : base(tipo, marca, modelo, estado, precio)
        {

            this.tipo = tipo;


        }


        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="estado"></param>
        /// <param name="precio"></param>

        public Violin(int id, string tipo, string marca, string modelo, string estado, float precio)
            : this(tipo, marca, modelo, estado, precio)
        {
            this.id = id;
        }


        #endregion


        #region Metodos


        /// <summary>
        /// Sobrecarga de MostrarDatos
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendFormat("TIPO: {0}\n", this.tipo);
            sb.AppendFormat("FACTURA NRO: {0}\n", this.id);
            return sb.ToString();
        }


        /// <summary>
        /// Sobrecarga de ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion




    }
}
