using System;

namespace POSales.Mantenimientos
{
    partial class Mantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mantenimiento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.aplicarCorreccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NoAplicarCorreccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enviarSolucionPorWhatsappToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuscarCodigo = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBucadorCodigo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEntregaBuscar = new FontAwesome.Sharp.IconButton();
            this.dtFechaEntregaMantenimientoHasta = new System.Windows.Forms.DateTimePicker();
            this.dtFechaEntregaDesde = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.btnIngresoBuscar = new FontAwesome.Sharp.IconButton();
            this.dtFechaIngresoHasta = new System.Windows.Forms.DateTimePicker();
            this.dtFechaIngresoDesde = new System.Windows.Forms.DateTimePicker();
            this.cambiarAPorEntregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 428);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 56);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manejo de Mantenimientos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvClients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClients.ColumnHeadersHeight = 40;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Fecha,
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
            this.aplicarCorreccion,
            this.NoAplicarCorreccion});
            this.dgvClients.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvClients.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvClients.EnableHeadersVisualStyles = false;
            this.dgvClients.Location = new System.Drawing.Point(0, 244);
            this.dgvClients.Margin = new System.Windows.Forms.Padding(2);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.RowHeadersWidth = 51;
            this.dgvClients.Size = new System.Drawing.Size(719, 184);
            this.dgvClients.TabIndex = 11;
            this.dgvClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellClick);
            
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Fecha.HeaderText = "Fecha In.";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.ToolTipText = "Fecha de Ingreso";
            // 
            // FechaEntrega
            // 
            this.FechaEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FechaEntrega.HeaderText = "Fecha En.";
            this.FechaEntrega.MinimumWidth = 6;
            this.FechaEntrega.Name = "FechaEntrega";
            this.FechaEntrega.ReadOnly = true;
            this.FechaEntrega.ToolTipText = "Fecha Entrega";
            this.FechaEntrega.Width = 103;
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
            this.idOrdenServicio.Width = 79;
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
            this.Codigo.HeaderText = "C.Equipo";
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
            this.descripcion.Width = 81;
            // 
            // aplicarCorreccion
            // 
            this.aplicarCorreccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.aplicarCorreccion.HeaderText = "Aplicar";
            this.aplicarCorreccion.MinimumWidth = 6;
            this.aplicarCorreccion.Name = "aplicarCorreccion";
            this.aplicarCorreccion.ReadOnly = true;
            this.aplicarCorreccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aplicarCorreccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aplicarCorreccion.Width = 84;
            // 
            // NoAplicarCorreccion
            // 
            this.NoAplicarCorreccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NoAplicarCorreccion.HeaderText = "No Aplicar";
            this.NoAplicarCorreccion.MinimumWidth = 6;
            this.NoAplicarCorreccion.Name = "NoAplicarCorreccion";
            this.NoAplicarCorreccion.ReadOnly = true;
            this.NoAplicarCorreccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NoAplicarCorreccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NoAplicarCorreccion.Width = 109;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarSolucionPorWhatsappToolStripMenuItem,
            this.agregarReservaToolStripMenuItem,
            this.cambiarAPorEntregarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(230, 92);
           
            // 
            // enviarSolucionPorWhatsappToolStripMenuItem
            // 
            this.enviarSolucionPorWhatsappToolStripMenuItem.Name = "enviarSolucionPorWhatsappToolStripMenuItem";
            this.enviarSolucionPorWhatsappToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.enviarSolucionPorWhatsappToolStripMenuItem.Text = "Enviar solucion por whatsapp";
            this.enviarSolucionPorWhatsappToolStripMenuItem.Click += new System.EventHandler(this.enviarSolucionPorWhatsappToolStripMenuItem_Click_1);
            // 
            // agregarReservaToolStripMenuItem
            // 
            this.agregarReservaToolStripMenuItem.Name = "agregarReservaToolStripMenuItem";
            this.agregarReservaToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.agregarReservaToolStripMenuItem.Text = "Agregar Reserva";
            this.agregarReservaToolStripMenuItem.Click += new System.EventHandler(this.agregarReservaToolStripMenuItem_Click);
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
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.btnIngresoBuscar);
            this.panel2.Controls.Add(this.dtFechaIngresoHasta);
            this.panel2.Controls.Add(this.dtFechaIngresoDesde);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 113);
            this.panel2.TabIndex = 12;
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarCodigo.IconColor = System.Drawing.Color.Black;
            this.btnBuscarCodigo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarCodigo.IconSize = 15;
            this.btnBuscarCodigo.Location = new System.Drawing.Point(691, 73);
            this.btnBuscarCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(25, 19);
            this.btnBuscarCodigo.TabIndex = 8;
            this.btnBuscarCodigo.UseVisualStyleBackColor = true;
            this.btnBuscarCodigo.Click += new System.EventHandler(this.btnBuscarCodigo_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(393, -1);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(284, 70);
            this.label9.TabIndex = 17;
            this.label9.Text = "Buscar Por Codigo,Falla,Solucion y Descripcion de Equipo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBucadorCodigo
            // 
            this.txtBucadorCodigo.Location = new System.Drawing.Point(407, 71);
            this.txtBucadorCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtBucadorCodigo.Multiline = true;
            this.txtBucadorCodigo.Name = "txtBucadorCodigo";
            this.txtBucadorCodigo.Size = new System.Drawing.Size(280, 19);
            this.txtBucadorCodigo.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Location = new System.Drawing.Point(206, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 26);
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
            this.btnEntregaBuscar.Location = new System.Drawing.Point(364, 74);
            this.btnEntregaBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEntregaBuscar.Name = "btnEntregaBuscar";
            this.btnEntregaBuscar.Size = new System.Drawing.Size(25, 19);
            this.btnEntregaBuscar.TabIndex = 6;
            this.btnEntregaBuscar.UseVisualStyleBackColor = true;
            this.btnEntregaBuscar.Click += new System.EventHandler(this.btnEntregaBuscar_Click);
            // 
            // dtFechaEntregaMantenimientoHasta
            // 
            this.dtFechaEntregaMantenimientoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEntregaMantenimientoHasta.Location = new System.Drawing.Point(282, 71);
            this.dtFechaEntregaMantenimientoHasta.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaEntregaMantenimientoHasta.Name = "dtFechaEntregaMantenimientoHasta";
            this.dtFechaEntregaMantenimientoHasta.Size = new System.Drawing.Size(78, 20);
            this.dtFechaEntregaMantenimientoHasta.TabIndex = 5;
            this.dtFechaEntregaMantenimientoHasta.ValueChanged += new System.EventHandler(this.dtFechaEntregaMantenimientoHasta_ValueChanged);
            // 
            // dtFechaEntregaDesde
            // 
            this.dtFechaEntregaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEntregaDesde.Location = new System.Drawing.Point(201, 71);
            this.dtFechaEntregaDesde.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaEntregaDesde.Name = "dtFechaEntregaDesde";
            this.dtFechaEntregaDesde.Size = new System.Drawing.Size(78, 20);
            this.dtFechaEntregaDesde.TabIndex = 4;
            this.dtFechaEntregaDesde.ValueChanged += new System.EventHandler(this.dtFechaEntregaDesde_ValueChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Location = new System.Drawing.Point(9, 13);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 26);
            this.label15.TabIndex = 7;
            this.label15.Text = "Fecha Ingreso";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnIngresoBuscar
            // 
            this.btnIngresoBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnIngresoBuscar.IconColor = System.Drawing.Color.Black;
            this.btnIngresoBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngresoBuscar.IconSize = 15;
            this.btnIngresoBuscar.Location = new System.Drawing.Point(168, 74);
            this.btnIngresoBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnIngresoBuscar.Name = "btnIngresoBuscar";
            this.btnIngresoBuscar.Size = new System.Drawing.Size(25, 19);
            this.btnIngresoBuscar.TabIndex = 3;
            this.btnIngresoBuscar.UseVisualStyleBackColor = true;
            this.btnIngresoBuscar.Click += new System.EventHandler(this.btnIngresoBuscar_Click);
            // 
            // dtFechaIngresoHasta
            // 
            this.dtFechaIngresoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIngresoHasta.Location = new System.Drawing.Point(86, 73);
            this.dtFechaIngresoHasta.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaIngresoHasta.Name = "dtFechaIngresoHasta";
            this.dtFechaIngresoHasta.Size = new System.Drawing.Size(78, 20);
            this.dtFechaIngresoHasta.TabIndex = 2;
            this.dtFechaIngresoHasta.ValueChanged += new System.EventHandler(this.dtFechaIngresoHasta_ValueChanged);
            // 
            // dtFechaIngresoDesde
            // 
            this.dtFechaIngresoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIngresoDesde.Location = new System.Drawing.Point(5, 73);
            this.dtFechaIngresoDesde.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaIngresoDesde.Name = "dtFechaIngresoDesde";
            this.dtFechaIngresoDesde.Size = new System.Drawing.Size(78, 20);
            this.dtFechaIngresoDesde.TabIndex = 1;
            this.dtFechaIngresoDesde.ValueChanged += new System.EventHandler(this.dtFechaIngresoDesde_ValueChanged);
            // 
            // cambiarAPorEntregarToolStripMenuItem
            // 
            this.cambiarAPorEntregarToolStripMenuItem.Name = "cambiarAPorEntregarToolStripMenuItem";
            this.cambiarAPorEntregarToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.cambiarAPorEntregarToolStripMenuItem.Text = "Cambiar a Por Entregar";
            this.cambiarAPorEntregarToolStripMenuItem.Click += new System.EventHandler(this.cambiarAPorEntregarToolStripMenuItem_Click);
            // 
            // Mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 484);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Mantenimiento";
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.Mantenimiento_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaMantenimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntregaEquipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadoAplicarCorreccionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadoNoAplicarCorreccionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enviarSolucionPorWhatsappToolStripMenuItem;
        private EventHandler enviarSolucionPorWhatsappToolStripMenuItem_Click;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnBuscarCodigo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBucadorCodigo;
        private System.Windows.Forms.Label label12;
        private FontAwesome.Sharp.IconButton btnEntregaBuscar;
        private System.Windows.Forms.DateTimePicker dtFechaEntregaMantenimientoHasta;
        private System.Windows.Forms.DateTimePicker dtFechaEntregaDesde;
        private System.Windows.Forms.Label label15;
        private FontAwesome.Sharp.IconButton btnIngresoBuscar;
        private System.Windows.Forms.DateTimePicker dtFechaIngresoHasta;
        private System.Windows.Forms.DateTimePicker dtFechaIngresoDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn aplicarCorreccion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NoAplicarCorreccion;
        private System.Windows.Forms.ToolStripMenuItem agregarReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarAPorEntregarToolStripMenuItem;
    }
}