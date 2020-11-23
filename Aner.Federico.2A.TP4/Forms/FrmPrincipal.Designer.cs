namespace BaseDatosStockConexion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnGuardarTxt = new System.Windows.Forms.Button();
            this.btnLeerFactura = new System.Windows.Forms.Button();
            this.p1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_GuardarXml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(56, 21);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(535, 254);
            this.dgvGrilla.TabIndex = 10;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SpringGreen;
            this.btnGuardar.Location = new System.Drawing.Point(56, 363);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(141, 52);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "&Guardar en Base de Datos";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVenta
            // 
            this.btnVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnVenta.Location = new System.Drawing.Point(56, 293);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(141, 64);
            this.btnVenta.TabIndex = 12;
            this.btnVenta.Text = "Realizar Venta";
            this.btnVenta.UseVisualStyleBackColor = false;
            this.btnVenta.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnGuardarTxt
            // 
            this.btnGuardarTxt.BackColor = System.Drawing.Color.Lime;
            this.btnGuardarTxt.Location = new System.Drawing.Point(213, 293);
            this.btnGuardarTxt.Name = "btnGuardarTxt";
            this.btnGuardarTxt.Size = new System.Drawing.Size(122, 38);
            this.btnGuardarTxt.TabIndex = 17;
            this.btnGuardarTxt.Text = "Guardar Factura";
            this.btnGuardarTxt.UseVisualStyleBackColor = false;
            this.btnGuardarTxt.Click += new System.EventHandler(this.btnGuardarTxt_Click);
            // 
            // btnLeerFactura
            // 
            this.btnLeerFactura.BackColor = System.Drawing.SystemColors.Info;
            this.btnLeerFactura.Location = new System.Drawing.Point(213, 337);
            this.btnLeerFactura.Name = "btnLeerFactura";
            this.btnLeerFactura.Size = new System.Drawing.Size(122, 31);
            this.btnLeerFactura.TabIndex = 18;
            this.btnLeerFactura.Text = "Ver Factura";
            this.btnLeerFactura.UseVisualStyleBackColor = false;
            this.btnLeerFactura.Click += new System.EventHandler(this.btnLeerTxt_Click);
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(411, 308);
            this.p1.Maximum = 30;
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(153, 23);
            this.p1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(408, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Total de Ventas: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(530, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "0";
            // 
            // btn_GuardarXml
            // 
            this.btn_GuardarXml.Location = new System.Drawing.Point(213, 374);
            this.btn_GuardarXml.Name = "btn_GuardarXml";
            this.btn_GuardarXml.Size = new System.Drawing.Size(122, 41);
            this.btn_GuardarXml.TabIndex = 22;
            this.btn_GuardarXml.Text = "Guardar en Xml";
            this.btn_GuardarXml.UseVisualStyleBackColor = true;
            this.btn_GuardarXml.Click += new System.EventHandler(this.btn_GuardarXml_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(658, 428);
            this.Controls.Add(this.btn_GuardarXml);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.btnLeerFactura);
            this.Controls.Add(this.btnGuardarTxt);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvGrilla);
            this.Name = "FrmPrincipal";
            this.Text = "Aner Federico 2A";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnGuardarTxt;
        private System.Windows.Forms.Button btnLeerFactura;
        private System.Windows.Forms.ProgressBar p1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_GuardarXml;
    }
}

