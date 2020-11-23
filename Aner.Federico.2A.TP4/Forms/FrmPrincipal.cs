using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;
using System.Threading;
//using EntidadesBD;

namespace BaseDatosStockConexion
{
    public partial class FrmPrincipal : Form
    {
        protected SqlDataAdapter da;
        protected DataTable dt;
        private Carrito carrito;
        
        public delegate void DelegadoFunda();  //Evento y delegado para informar q cliente con factura "x" se gano un funda gratis
        public event DelegadoFunda EventoFunda;


        Thread hilo; // se encarga de ir actualizando la barra de estado con la cantidad de ventas 
        Thread hilo2; //se encarga de actualizar el label Total de ventas, con las ventas realizadas

        delegate void delegado(int valor);



        /// <summary>
        /// Incicializa el form, y carga el dgv
        /// </summary>
        public FrmPrincipal()
        {
           
            InitializeComponent();
            if (!this.ConfigurarDataAdapter())
            {
                MessageBox.Show("ERROR AL CONFIGURAR EL DATAADAPTER!!!");
                this.Close();
            }
           
            this.ConfigurarDataTable();
            
            
            try
            {
                this.da.Fill(this.dt);

                this.ConfigurarGrilla();

                this.dgvGrilla.DataSource = this.dt;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            EventoFunda += MAnejador; // Agrego el metodo al Manejador

            this.StartPosition = FormStartPosition.CenterScreen;


        }

        //Se inician los 2 hilos q actualizan la cantidad de ventas, tanto para el label como para el la barra de estado
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.hilo = new Thread(new ThreadStart(Proceso1));
            if (!this.hilo.IsAlive)
            {
                this.hilo.Start();
            }

            hilo2 = new Thread(new ThreadStart(Proceso2));
            if (!this.hilo2.IsAlive)
            {  
                hilo2.Start();
            }


        }



        #region Hilos


        public void Proceso1()
        {
            try
            {

                do
                {
                    int cantidad = this.dt.Rows.Count;
                    delegado MD = new delegado(Actualizar1);
                    this.Invoke(MD, new object[] { cantidad });
                    Thread.Sleep(70);
                  
                }
                while (true);
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }     

        }



        public void Proceso2()
        {

            try
            {
                do
                {
                    int cantidad2 = this.dt.Rows.Count;
                    delegado MD = new delegado(Actualizar2);
                    this.Invoke(MD, new object[] { cantidad2 });
                    Thread.Sleep(70);

                }
                while (true);

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void Actualizar1(int valor)
        {
            p1.Value = valor;
            
        }


        public void Actualizar2(int valor)
        {

            this.label2.Text = valor.ToString();
        }




        #endregion




        #region Config del Dt y Da

        /// <summary>
        /// Configuracion del data Adapter y establezco la conexion con la base de datos
        /// </summary>
        /// <returns></returns>
        private bool ConfigurarDataAdapter()
        {
            bool rta = false;

            try
            {
                SqlConnection cn = new SqlConnection(Properties.Settings.Default.conexion);

                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT id, tipo, marca, modelo, estado, precio FROM tabla_Stock", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO tabla_Stock (tipo, marca, modelo, estado, precio) VALUES (@tipo, @marca, @modelo, @estado, @precio)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE tabla_Stock SET tipo=@tipo, marca=@marca, modelo=@modelo, estado=@estado, precio=@precio WHERE id=@id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM tabla_Stock WHERE id=@id", cn);

                this.da.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.InsertCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
                this.da.InsertCommand.Parameters.Add("@estado", SqlDbType.VarChar, 50, "estado");
                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");

                this.da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.UpdateCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
                this.da.UpdateCommand.Parameters.Add("@estado", SqlDbType.VarChar, 50, "estado");
                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                rta = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return rta;
        }


        /// <summary>
        /// Congif del data table
        /// </summary>
        private void ConfigurarDataTable()
        {
            this.dt = new DataTable("Ventas"); 
             
            this.dt.Columns.Add("id", typeof(int));  //Añado columnas segun la base de datos
            this.dt.Columns.Add("tipo", typeof(string));
            this.dt.Columns.Add("marca", typeof(string));
            this.dt.Columns.Add("modelo", typeof(string));
            this.dt.Columns.Add("estado", typeof(string));
            this.dt.Columns.Add("precio", typeof(string));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] }; //Primary key

            this.dt.Columns["id"].AutoIncrement = true; //Columna autoincremental
            this.dt.Columns["id"].AutoIncrementSeed = 1;//obtener el último id insertado en la tabla
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }




        private void ConfigurarGrilla()
        {
            //Config de diseño
            this.dgvGrilla.RowsDefaultCellStyle.BackColor = Color.LightSeaGreen;
            this.dgvGrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            this.dgvGrilla.BackgroundColor = Color.LightSeaGreen;        
            this.dgvGrilla.ColumnHeadersDefaultCellStyle.Font = new Font(dgvGrilla.Font, FontStyle.Bold);
            this.dgvGrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvGrilla.GridColor = Color.Black;

            // La grilla será de sólo lectura
            this.dgvGrilla.ReadOnly = false;

            // No permito la multiselección
            this.dgvGrilla.MultiSelect = false;

            // Selecciono toda la fila a la vez
            this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Hago que las columnas ocupen todo el ancho del 'DataGrid'
            this.dgvGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Indico el color de la fila seleccionada
            //this.dgvGrilla.RowsDefaultCellStyle.SelectionBackColor = Color.LightCyan;
            this.dgvGrilla.RowsDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            // No permito modificar desde la grilla
            this.dgvGrilla.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Saco los encabezados de las filas
            this.dgvGrilla.RowHeadersVisible = false;

        }

        #endregion





        /// <summary>
        /// Abre el Form secundario para realizar una Venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            frmInstrumentos frm = new frmInstrumentos(); //Nueva instacia del Form de Instrumentos
            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.dt.NewRow();

                // fila["id"] = frm.Instrumento.Id;
                fila["tipo"] = frm.Instrumento.Tipo;
                fila["marca"] = frm.Instrumento.Marca;
                fila["modelo"] = frm.Instrumento.Modelo;
                fila["estado"] = frm.Instrumento.Estado;
                fila["precio"] = frm.Instrumento.Precio;
                this.dt.Rows.Add(fila);    //agrego las filas al dt


            }  

        }

       

        /// <summary>
        /// Boton Guardar en BD, Sincroniza los datos de las ventas con la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.da.Update(this.dt);

                MessageBox.Show("Sincronizado!!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       


        /// <summary>
        /// Evento Click Guardar factura, uso la funcion cargar carrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarTxt_Click(object sender, EventArgs e)
        {

            try
            {
                CargarCarrito();
                if (Carrito.Guardar(this.carrito))
                {
                    MessageBox.Show("ARCHIVO GUARDADO CON EXITO");
                }

                else
                {
                    throw new ArchivosException();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        /// <summary>
        /// Evento Boton Leer Factura, se lee la factura en formato txt, ademas realiza el invoke del evento funda gratis...si realiza compra de guitarra nueva de mas de 150mil se lanza el evento q informa q el cliente con Factura nro "x" se gana una funda de regalo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerTxt_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show(Carrito.Leer());
            }
            catch (ArchivosException m)
            {
                MessageBox.Show(m.Message);
            }
            finally
            {
                
                EventoFunda.Invoke();
            }

        }



        /// <summary>
        /// Guarda los datos del dgv en archivo Xml, usando la funcion Cargarcarrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_GuardarXml_Click(object sender, EventArgs e)
        {
            try
            {
                CargarCarrito();
                if (Carrito.GuardarXml(this.carrito))
                {
                    MessageBox.Show("SERIALIZACION EXITOSA!!!");
                }
                else
                {
                    throw new ArchivosException("No se pudo guardar!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      

        }


       

        /// <summary>
        /// Manejador Evento Funda gratis...si se realiza la venta de una guitarra Nueva de mas de 150mil el cliente se lleva una funda gratis
        /// </summary>
        private void MAnejador()
        {
            

            foreach (DataRow fila in this.dt.Rows)
            {

                if (fila["tipo"].ToString() == "Guitarra Electrica" && float.Parse(fila["precio"].ToString()) >= 150000 && fila["estado"].ToString() == "nuevo")
                {
                    string nro = fila["id"].ToString();


                    MessageBox.Show("El cliente con factura nro: "+ nro + " se gano una funda Gratis");
                }


            }
        }




        /// <summary>
        /// Funcion para cargar la lista de la clase Carrito usando los datos de cada fila para cada tipo de instrumento, para luego usar en cuando guardo la factura en txt o para serializar
        /// </summary>

        private void CargarCarrito()
        {
            Instrumento i = default;
            this.carrito = new Carrito();

            try
            {
                foreach (DataRow fila in this.dt.Rows) // Recorro todos las filas, pasandole los valores a cada instrumento
                {
                    if (fila["tipo"].ToString() == "Guitarra Electrica")
                    {
                        i = new Guitarra(int.Parse(fila["id"].ToString()),
                                                        fila["tipo"].ToString(),
                                                        fila["marca"].ToString(),
                                                        fila["modelo"].ToString(),
                                                        fila["estado"].ToString(),
                                              float.Parse(fila["precio"].ToString()));

                    }
                    else if (fila["tipo"].ToString() == "Bajo")
                    {
                        i = new Bajo(int.Parse(fila["id"].ToString()),
                                                        fila["tipo"].ToString(),
                                                        fila["marca"].ToString(),
                                                        fila["modelo"].ToString(),
                                                        fila["estado"].ToString(),
                                              float.Parse(fila["precio"].ToString()));
                    }

                    else if (fila["tipo"].ToString() == "Bateria")
                    {
                        i = new Bajo(int.Parse(fila["id"].ToString()),
                                                        fila["tipo"].ToString(),
                                                        fila["marca"].ToString(),
                                                        fila["modelo"].ToString(),
                                                        fila["estado"].ToString(),
                                              float.Parse(fila["precio"].ToString()));
                    }

                    else if (fila["tipo"].ToString() == "Violin")
                    {
                        i = new Bajo(int.Parse(fila["id"].ToString()),
                                                        fila["tipo"].ToString(),
                                                        fila["marca"].ToString(),
                                                        fila["modelo"].ToString(),
                                                        fila["estado"].ToString(),
                                              float.Parse(fila["precio"].ToString()));
                    }


                    this.carrito += i; // agrego cada instrumento a la lista de la Clase Carrito con el operador +=
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }





        /// <summary>
        /// Form Closing... Aborto los 2 hilos q incicie al comienzo del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                this.hilo.Abort();
                this.hilo2.Abort();
                
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





       
    }
}
