namespace POSales.Mantenimientos
{
    partial class EntregasCajero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntregasCajero));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuscarCodigo = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBucadorCodigo = new System.Windows.Forms.TextBox();
            this.enviarSolucionPorWhatsappToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionFalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoMantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrdenServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel2.Controls.Add(this.btnBuscarCodigo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtBucadorCodigo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1624, 106);
            this.panel2.TabIndex = 15;
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarCodigo.IconColor = System.Drawing.Color.Black;
            this.btnBuscarCodigo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarCodigo.IconSize = 15;
            this.btnBuscarCodigo.Location = new System.Drawing.Point(986, 36);
            this.btnBuscarCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(33, 23);
            this.btnBuscarCodigo.TabIndex = 18;
            this.btnBuscarCodigo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(564, 70);
            this.label9.TabIndex = 17;
            this.label9.Text = "Buscar Por Codigo,Falla,Solucion, y fecha entrega ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBucadorCodigo
            // 
            this.txtBucadorCodigo.Location = new System.Drawing.Point(608, 36);
            this.txtBucadorCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBucadorCodigo.Multiline = true;
            this.txtBucadorCodigo.Name = "txtBucadorCodigo";
            this.txtBucadorCodigo.Size = new System.Drawing.Size(372, 23);
            this.txtBucadorCodigo.TabIndex = 16;
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
            this.dgvClients.ColumnHeadersHeight = 30;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Fecha,
            this.FechaEntrega,
            this.descripcionFalla,
            this.idEstadoMantenimiento,
            this.idUsuario,
            this.idOrdenServicio,
            this.IdEquipo,
            this.Codigo,
            this.descripcionEquipo,
            this.descripcion});
            this.dgvClients.EnableHeadersVisualStyles = false;
            this.dgvClients.Location = new System.Drawing.Point(0, 102);
            this.dgvClients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.RowHeadersWidth = 51;
            this.dgvClients.Size = new System.Drawing.Size(1623, 596);
            this.dgvClients.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 697);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1624, 69);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manejo de Entregas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.Fecha.Width = 122;
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
            // EntregasCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 766);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.panel1);
            this.Name = "EntregasCajero";
            this.Text = "EntregasCajero";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnBuscarCodigo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBucadorCodigo;
        private System.Windows.Forms.ToolStripMenuItem enviarSolucionPorWhatsappToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionFalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoMantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}