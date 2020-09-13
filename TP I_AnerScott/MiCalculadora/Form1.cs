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
        public FormCalculadora()
        {
            InitializeComponent();
        }

        

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double res;

            res = FormCalculadora.Operar (txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = res.ToString();
        }

       


        private static Double Operar(string num1, string num2, string operador)
        {
            double retorno;

            Numero n1 = new Numero(num1);
            Numero n2 = new Numero(num2);
            
            retorno = Calculadora.Operar(n1, n2, operador);
            return retorno;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
            
        }

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

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            string numero = this.lblResultado.Text;
            Numero n1 = new Numero();

            //string numero2 = n1.BinarioDecimal(numero);
            numero = n1.BinarioDecimal(numero);
            this.lblResultado.Text = numero;

        }




        #region Metodos no puedo borrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
