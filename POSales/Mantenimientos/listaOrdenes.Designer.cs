namespace POSales.Mantenimientos
{
    partial class listaOrdenes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listaOrdenes));
            this.btnBuscarCodigo = new FontAwesome.Sharp.IconButton();
            this.txtBucadorCodigo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEntregaBuscar = new FontAwesome.Sharp.IconButton();
            this.dtFechaEntregaMantenimientoHasta = new System.Windows.Forms.DateTimePicker();
            this.dtFechaEntregaDesde = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.enviarSolucionPorWhatsappToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgvListaOrdenes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionFalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoMantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrdenServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOrdenes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarCodigo.IconColor = System.Drawing.Color.Black;
            this.btnBuscarCodigo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarCodigo.IconSize = 15;
            this.btnBuscarCodigo.Location = new System.Drawing.Point(974, 45);
            this.btnBuscarCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(33, 23);
            this.btnBuscarCodigo.TabIndex = 8;
            this.btnBuscarCodigo.UseVisualStyleBackColor = true;
            // 
            // txtBucadorCodigo
            // 
            this.txtBucadorCodigo.Location = new System.Drawing.Point(576, 46);
            this.txtBucadorCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBucadorCodigo.Multiline = true;
            this.txtBucadorCodigo.Name = "txtBucadorCodigo";
            this.txtBucadorCodigo.Size = new System.Drawing.Size(372, 22);
            this.txtBucadorCodigo.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Location = new System.Drawing.Point(53, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(171, 32);
            this.label12.TabIndex = 13;
            this.label12.Text = "Fecha Entrega";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEntregaBuscar
            // 
            this.btnEntregaBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnEntregaBuscar.IconColor = System.Drawing.Color.Black;
            this.btnEntregaBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEntregaBuscar.IconSize = 15;
            this.btnEntregaBuscar.Location = new System.Drawing.Point(248, 52);
            this.btnEntregaBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEntregaBuscar.Name = "btnEntregaBuscar";
            this.btnEntregaBuscar.Size = new System.Drawing.Size(33, 23);
            this.btnEntregaBuscar.TabIndex = 6;
            this.btnEntregaBuscar.UseVisualStyleBackColor = true;
            // 
            // dtFechaEntregaMantenimientoHasta
            // 
            this.dtFechaEntregaMantenimientoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEntregaMantenimientoHasta.Location = new System.Drawing.Point(138, 52);
            this.dtFechaEntregaMantenimientoHasta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFechaEntregaMantenimientoHasta.Name = "dtFechaEntregaMantenimientoHasta";
            this.dtFechaEntregaMantenimientoHasta.Size = new System.Drawing.Size(103, 22);
            this.dtFechaEntregaMantenimientoHasta.TabIndex = 5;
            // 
            // dtFechaEntregaDesde
            // 
            this.dtFechaEntregaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEntregaDesde.Location = new System.Drawing.Point(29, 52);
            this.dtFechaEntregaDesde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFechaEntregaDesde.Name = "dtFechaEntregaDesde";
            this.dtFechaEntregaDesde.Size = new System.Drawing.Size(103, 22);
            this.dtFechaEntregaDesde.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel2.Controls.Add(this.btnBuscarCodigo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtBucadorCodigo);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnEntregaBuscar);
            this.panel2.Controls.Add(this.dtFechaEntregaMantenimientoHasta);
            this.panel2.Controls.Add(this.dtFechaEntregaDesde);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1599, 106);
            this.panel2.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(325, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(211, 41);
            this.label9.TabIndex = 17;
            this.label9.Text = "Buscar Por Codigo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // enviarSolucionPorWhatsappToolStripMenuItem
            // 
            this.enviarSolucionPorWhatsappToolStripMenuItem.Name = "enviarSolucionPorWhatsappToolStripMenuItem";
            this.enviarSolucionPorWhatsappToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.enviarSolucionPorWhatsappToolStripMenuItem.Text = "Enviar solucion por whatsapp";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarSolucionPorWhatsappToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(273, 28);
            // 
            // dgvListaOrdenes
            // 
            this.dgvListaOrdenes.AllowUserToAddRows = false;
            this.dgvListaOrdenes.AllowUserToDeleteRows = false;
            this.dgvListaOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaOrdenes.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaOrdenes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaOrdenes.ColumnHeadersHeight = 30;
            this.dgvListaOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListaOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FechaEntrega,
            this.descripcionFalla,
            this.solucion,
            this.idEstadoMantenimiento,
            this.idUsuario,
            this.idOrdenServicio,
            this.IdEquipo,
            this.Codigo,
            this.descripcionEquipo,
            this.descripcion,
            this.Imprimir});
            this.dgvListaOrdenes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvListaOrdenes.EnableHeadersVisualStyles = false;
            this.dgvListaOrdenes.Location = new System.Drawing.Point(-10, 110);
            this.dgvListaOrdenes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListaOrdenes.Name = "dgvListaOrdenes";
            this.dgvListaOrdenes.ReadOnly = true;
            this.dgvListaOrdenes.RowHeadersVisible = false;
            this.dgvListaOrdenes.RowHeadersWidth = 51;
            this.dgvListaOrdenes.Size = new System.Drawing.Size(1597, 596);
            this.dgvListaOrdenes.TabIndex = 14;
            this.dgvListaOrdenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellContentClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manejo de Mantenimientos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 693);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1599, 69);
            this.panel1.TabIndex = 13;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // FechaEntrega
            // 
            this.FechaEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FechaEntrega.HeaderText = "Fecha En.";
            this.FechaEntrega.MinimumWidth = 6;
            this.FechaEntrega.Name = "FechaEntrega";
            this.FechaEntrega.ReadOnly = true;
            this.FechaEntrega.ToolTipText = "Fecha Entrega";
            this.FechaEntrega.Width = 127;
            // 
            // descripcionFalla
            // 
            this.descripcionFalla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionFalla.HeaderText = "Falla";
            this.descripcionFalla.MinimumWidth = 6;
            this.descripcionFalla.Name = "descripcionFalla";
            this.descripcionFalla.ReadOnly = true;
            // 
            // solucion
            // 
            this.solucion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.solucion.HeaderText = "solucion";
            this.solucion.MinimumWidth = 6;
            this.solucion.Name = "solucion";
            this.solucion.ReadOnly = true;
            // 
            // idEstadoMantenimiento
            // 
            this.idEstadoMantenimiento.HeaderText = "idEstadoMantenimiento";
            this.idEstadoMantenimiento.MinimumWidth = 6;
            this.idEstadoMantenimiento.Name = "idEstadoMantenimiento";
            this.idEstadoMantenimiento.ReadOnly = true;
            this.idEstadoMantenimiento.Visible = false;
            // 
            // idUsuario
            // 
            this.idUsuario.HeaderText = "idUsuario";
            this.idUsuario.MinimumWidth = 6;
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Visible = false;
            // 
            // idOrdenServicio
            // 
            this.idOrdenServicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idOrdenServicio.HeaderText = "Orden";
            this.idOrdenServicio.MinimumWidth = 6;
            this.idOrdenServicio.Name = "idOrdenServicio";
            this.idOrdenServicio.ReadOnly = true;
            this.idOrdenServicio.Width = 97;
            // 
            // IdEquipo
            // 
            this.IdEquipo.HeaderText = "IdEquipo";
            this.IdEquipo.MinimumWidth = 6;
            this.IdEquipo.Name = "IdEquipo";
            this.IdEquipo.ReadOnly = true;
            this.IdEquipo.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo Equipo";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // descripcionEquipo
            // 
            this.descripcionEquipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionEquipo.HeaderText = "Equipo";
            this.descripcionEquipo.MinimumWidth = 6;
            this.descripcionEquipo.Name = "descripcionEquipo";
            this.descripcionEquipo.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.descripcion.HeaderText = "Estado";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 99;
            // 
            // Imprimir
            // 
            this.Imprimir.HeaderText = "Imprimir";
            this.Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Imprimir.Image")));
            this.Imprimir.MinimumWidth = 6;
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.ReadOnly = true;
            // 
            // listaOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 762);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvListaOrdenes);
            this.Controls.Add(this.panel1);
            this.Name = "listaOrdenes";
            this.Text = "listaOrdenes";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOrdenes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnBuscarCodigo;
        private System.Windows.Forms.TextBox txtBucadorCodigo;
        private System.Windows.Forms.Label label12;
        private FontAwesome.Sharp.IconButton btnEntregaBuscar;
        private System.Windows.Forms.DateTimePicker dtFechaEntregaMantenimientoHasta;
        private System.Windows.Forms.DateTimePicker dtFechaEntregaDesde;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem enviarSolucionPorWhatsappToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dgvListaOrdenes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionFalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn solucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoMantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewImageColumn Imprimir;
    }
}