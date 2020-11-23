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

namespace BaseDatosStockConexion
{
    public partial class frmInstrumentos : Form
    {

        protected Instrumento inst;

        public Instrumento Instrumento
        {
            get { return this.inst;}
        }


        /// <summary>
        /// Const por defecto
        /// </summary>
        public frmInstrumentos()
        {
            InitializeComponent();
        }




        /// <summary>
        /// Constructor q recibe un instrumento y asigna los parametros de cada textbox
        /// </summary>
        /// <param name="inst"></param>
        public frmInstrumentos(Instrumento inst)
            :this()
        {
            this.inst = inst;

            this.cmbTipo.SelectedItem = inst.Tipo.ToString();
            this.textMarca.Text = inst.Marca.ToString();
            this.textModelo.Text = inst.Modelo.ToString();
            this.cboEstado.SelectedItem = inst.Estado.ToString();
            this.textPrecio.Text = inst.Precio.ToString();


        }




        /// <summary>
        /// agrega los productos al dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           

            try
            {


                string precio = this.textPrecio.Text;

                if (cmbTipo.SelectedIndex == 0)  //se instancia cada tipo de instrumento segun el indice del combobox
                {

                    this.inst = new Guitarra(this.cmbTipo.Text, this.textMarca.Text, this.textModelo.Text, this.cboEstado.Text, float.Parse(precio));


                }
                else if (cmbTipo.SelectedIndex == 1)
                {
                    this.inst = new Bajo(this.cmbTipo.Text, this.textMarca.Text, this.textModelo.Text, this.cboEstado.Text, float.Parse(precio));

                }
                else if (cmbTipo.SelectedIndex == 2)
                {
                    this.inst = new Bateria(this.cmbTipo.Text, this.textMarca.Text, this.textModelo.Text, this.cboEstado.Text, float.Parse(precio));

                }
                else if (cmbTipo.SelectedIndex == 3)
                {
                    this.inst = new Violin(this.cmbTipo.Text, this.textMarca.Text, this.textModelo.Text, this.cboEstado.Text, float.Parse(precio));

                }

                if (cmbTipo.SelectedIndex == 0 && this.textMarca.ToString() == "fender")
                {
                    this.DialogResult = MessageBox.Show("Se gano una funda Gratis");
                }
                else 
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }


            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

              
        }


        /// <summary>
        /// se cancela la venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }



        #region Validaciones


        /// <summary>
        /// Valida q se ingresen solo letras en el textbox atravez del Keypress
        /// </summary>
        /// <param name="v"></param>
        public void SoloLetras( KeyPressEventArgs v)
        {
            if (Char.IsLetter(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Por Favor Ingrese solo Letras");
            }
        }


        /// <summary>
        /// Valida q se ingresen solo nros en el textbox correspondiente atravez del Keypress
        /// </summary>
        /// <param name="v"></param>
        public void SoloNumeros(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Por Favor Ingrese solo Numeros");
            }
        }


        /// <summary>
        /// Llamo al metodo q valida q se ingresen solo letras o nros segun corresponda a cada Textbox especifico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloLetras(e);
        }

        private void textModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloLetras(e);
        }

        private void textPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SoloNumeros(e);
        }


        private void frmInstrumentos_Load(object sender, EventArgs e)
        {
            this.cboEstado.SelectedIndex = 0;
            this.cmbTipo.SelectedIndex = 0;
        }


        #endregion
    }
}
