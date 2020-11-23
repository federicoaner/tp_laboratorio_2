using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        /// <summary>
        /// Constructor inicializa el form
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
           
        }


        #region Botones

        /// <summary>
        /// Se llama el metodo limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }




        /// <summary>
        /// Realiza la operacion a partir de los nros q se ingresan en los textboxes y el operador elegido en el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Devuelve el resultado al Label de resultado</param>

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double res;

            res = Operar (txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = res.ToString();
        }


        /// <summary>
        /// Llama al metodo limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            Limpiar();
            
        }



        /// <summary>
        /// Convierte a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            string numero;

            if (this.lblResultado.Text != "")
            {
                Numero n1 = new Numero();
                numero = n1.DecimalBinario(this.lblResultado.Text);
                this.lblResultado.Text = numero;
            }
            else
            {
                this.lblResultado.Text = "Valor invalido";
            }

        }


        /// <summary>
        /// Convierte a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            string numero = this.lblResultado.Text;
            Numero n1 = new Numero();

            
            numero = n1.BinarioDecimal(numero);
            this.lblResultado.Text = numero;

        }


        /// <summary>
        /// Cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion




        #region Metodos

        /// <summary>
        /// Metodo que instancia los numeros y llama al metodo operar, para realizar la opeacion requerida
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>

        private static Double Operar(string num1, string num2, string operador)
        {
            double retorno;

            Numero n1 = new Numero(num1);
            Numero n2 = new Numero(num2);

            retorno = Calculadora.Operar(n1, n2, operador);
            return retorno;
        }

        /// <summary>
        /// Reiniciliza todos los campos
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "0";
            this.cmbOperador.Text = "+";
        }

        #endregion


        /// <summary>
        /// Se pregunta si quiere salir, con opciones SI/NO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }

        }



       
    }
}
