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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntregasCajero));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuscarCodigo = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBucadorCodigo = new System.Windows.Forms.TextBox();
            this.enviarSolucionPorWhatsappToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOrdenes = new Zuby.ADGV.AdvancedDataGridView();
            this.IdOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ordenServicioModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noSeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenServicioModelBindingSource)).BeginInit();
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
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 86);
            this.panel2.TabIndex = 15;
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarCodigo.IconColor = System.Drawing.Color.Black;
            this.btnBuscarCodigo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarCodigo.IconSize = 15;
            this.btnBuscarCodigo.Location = new System.Drawing.Point(740, 29);
            this.btnBuscarCodigo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(25, 19);
            this.btnBuscarCodigo.TabIndex = 2;
            this.btnBuscarCodigo.UseVisualStyleBackColor = true;
            this.btnBuscarCodigo.Click += new System.EventHandler(this.btnBuscarCodigo_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(9, 7);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(258, 57);
            this.label9.TabIndex = 17;
            this.label9.Text = "Buscar Por Codigo,Falla,Solucion";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBucadorCodigo
            // 
            this.txtBucadorCodigo.Location = new System.Drawing.Point(456, 29);
            this.txtBucadorCodigo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBucadorCodigo.Multiline = true;
            this.txtBucadorCodigo.Name = "txtBucadorCodigo";
            this.txtBucadorCodigo.Size = new System.Drawing.Size(280, 19);
            this.txtBucadorCodigo.TabIndex = 1;
            // 
            // enviarSolucionPorWhatsappToolStripMenuItem
            // 
            this.enviarSolucionPorWhatsappToolStripMenuItem.Name = "enviarSolucionPorWhatsappToolStripMenuItem";
            this.enviarSolucionPorWhatsappToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enviarSolucionPorWhatsappToolStripMenuItem.Text = "Facturar";
            this.enviarSolucionPorWhatsappToolStripMenuItem.Click += new System.EventHandler(this.enviarSolucionPorWhatsappToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarSolucionPorWhatsappToolStripMenuItem,
            this.noSeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 566);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 56);
            this.panel1.TabIndex = 13;
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
            this.label1.Size = new System.Drawing.Size(194, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manejo de Entregas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOrden,
            this.IdCliente,
            this.NombreCliente,
            this.Total,
            this.estado});
            this.dgvOrdenes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvOrdenes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvOrdenes.FilterAndSortEnabled = true;
            this.dgvOrdenes.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvOrdenes.Location = new System.Drawing.Point(0, 83);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvOrdenes.RowHeadersVisible = false;
            this.dgvOrdenes.RowHeadersWidth = 51;
            this.dgvOrdenes.Size = new System.Drawing.Size(963, 483);
            this.dgvOrdenes.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvOrdenes.TabIndex = 16;
            // 
            // IdOrden
            // 
            this.IdOrden.HeaderText = "IdOrden";
            this.IdOrden.MinimumWidth = 22;
            this.IdOrden.Name = "IdOrden";
            this.IdOrden.ReadOnly = true;
            this.IdOrden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.IdOrden.Width = 125;
            // 
            // IdCliente
            // 
            this.IdCliente.HeaderText = "IdCliente";
            this.IdCliente.MinimumWidth = 22;
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            this.IdCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.IdCliente.Visible = false;
            this.IdCliente.Width = 125;
            // 
            // NombreCliente
            // 
            this.NombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreCliente.HeaderText = "Nombre del cliente";
            this.NombreCliente.MinimumWidth = 22;
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.ReadOnly = true;
            this.NombreCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 22;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Total.Width = 125;
            // 
            // estado
            // 
            this.estado.HeaderText = "estado";
            this.estado.MinimumWidth = 22;
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.estado.Width = 125;
            // 
            // ordenServicioModelBindingSource
            // 
            this.ordenServicioModelBindingSource.DataSource = typeof(POSalesDb.OrdenServicioModel);
            // 
            // noSeToolStripMenuItem
            // 
            this.noSeToolStripMenuItem.Name = "noSeToolStripMenuItem";
            this.noSeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.noSeToolStripMenuItem.Text = "No se";
            this.noSeToolStripMenuItem.Click += new System.EventHandler(this.noSeToolStripMenuItem_Click);
            // 
            // EntregasCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 622);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EntregasCajero";
            this.Text = "EntregasCajero";
            this.Load += new System.EventHandler(this.EntregasCajero_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenServicioModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnBuscarCodigo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBucadorCodigo;
        private System.Windows.Forms.ToolStripMenuItem enviarSolucionPorWhatsappToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Zuby.ADGV.AdvancedDataGridView dgvOrdenes;
        private System.Windows.Forms.BindingSource ordenServicioModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrdenDeServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estado;
        private System.Windows.Forms.ToolStripMenuItem noSeToolStripMenuItem;
    }
}