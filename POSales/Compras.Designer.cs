namespace POSales
{
    partial class Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compras));
            this.itemsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.itemsBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hascombo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aplicaSeries = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.negativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorIce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.imagenUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsBindingSource1
            // 
            this.itemsBindingSource1.DataSource = typeof(POSalesDb.Items);
            // 
            // itemsBindingSource3
            // 
            this.itemsBindingSource3.DataSource = typeof(POSalesDb.Items);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataSource = typeof(POSalesDb.Items);
            // 
            // itemsBindingSource2
            // 
            this.itemsBindingSource2.DataSource = typeof(POSalesDb.Items);
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.AutoGenerateColumns = false;
            this.dgvItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItem.ColumnHeadersHeight = 30;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.hasIva,
            this.nombre,
            this.codigoBarras,
            this.precioA,
            this.precioB,
            this.precioC,
            this.precioD,
            this.descripcion,
            this.descMax,
            this.stockMin,
            this.stock,
            this.unidad,
            this.bId,
            this.cId,
            this.gId,
            this.mId,
            this.servicio,
            this.hascombo,
            this.aplicaSeries,
            this.negativo,
            this.ice,
            this.valorIce,
            this.imagen,
            this.imagenUrl,
            this.iva,
            this.montoTotal,
            this.costoTotal,
            this.Edit,
            this.Delete});
            this.dgvItem.DataSource = this.itemsBindingSource3;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvItem.EnableHeadersVisualStyles = false;
            this.dgvItem.Location = new System.Drawing.Point(0, 0);
            this.dgvItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.RowHeadersWidth = 51;
            this.dgvItem.Size = new System.Drawing.Size(800, 372);
            this.dgvItem.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(931, 26);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manejo de compras";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 370);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 80);
            this.panel1.TabIndex = 8;
            // 
            // comboBindingSource
            // 
            this.comboBindingSource.DataMember = "Combo";
            this.comboBindingSource.DataSource = this.itemsBindingSource;
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 125;
            // 
            // hasIva
            // 
            this.hasIva.DataPropertyName = "HasIva";
            this.hasIva.HeaderText = "tipoCompra";
            this.hasIva.MinimumWidth = 6;
            this.hasIva.Name = "hasIva";
            this.hasIva.ReadOnly = true;
            this.hasIva.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hasIva.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.hasIva.Width = 125;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 125;
            // 
            // codigoBarras
            // 
            this.codigoBarras.DataPropertyName = "codigoBarras";
            this.codigoBarras.HeaderText = "codigoBarras";
            this.codigoBarras.MinimumWidth = 6;
            this.codigoBarras.Name = "codigoBarras";
            this.codigoBarras.ReadOnly = true;
            this.codigoBarras.Width = 125;
            // 
            // precioA
            // 
            this.precioA.DataPropertyName = "precioA";
            this.precioA.HeaderText = "precioA";
            this.precioA.MinimumWidth = 6;
            this.precioA.Name = "precioA";
            this.precioA.ReadOnly = true;
            this.precioA.Width = 125;
            // 
            // precioB
            // 
            this.precioB.DataPropertyName = "precioB";
            this.precioB.HeaderText = "precioB";
            this.precioB.MinimumWidth = 6;
            this.precioB.Name = "precioB";
            this.precioB.ReadOnly = true;
            this.precioB.Width = 125;
            // 
            // precioC
            // 
            this.precioC.DataPropertyName = "precioC";
            this.precioC.HeaderText = "precioC";
            this.precioC.MinimumWidth = 6;
            this.precioC.Name = "precioC";
            this.precioC.ReadOnly = true;
            this.precioC.Width = 125;
            // 
            // precioD
            // 
            this.precioD.DataPropertyName = "precioD";
            this.precioD.HeaderText = "precioD";
            this.precioD.MinimumWidth = 6;
            this.precioD.Name = "precioD";
            this.precioD.ReadOnly = true;
            this.precioD.Width = 125;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 125;
            // 
            // descMax
            // 
            this.descMax.DataPropertyName = "descMax";
            this.descMax.HeaderText = "descMax";
            this.descMax.MinimumWidth = 6;
            this.descMax.Name = "descMax";
            this.descMax.ReadOnly = true;
            this.descMax.Width = 125;
            // 
            // stockMin
            // 
            this.stockMin.DataPropertyName = "stockMin";
            this.stockMin.HeaderText = "stockMin";
            this.stockMin.MinimumWidth = 6;
            this.stockMin.Name = "stockMin";
            this.stockMin.ReadOnly = true;
            this.stockMin.Width = 125;
            // 
            // stock
            // 
            this.stock.DataPropertyName = "stock";
            this.stock.HeaderText = "stock";
            this.stock.MinimumWidth = 6;
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            this.stock.Width = 125;
            // 
            // unidad
            // 
            this.unidad.DataPropertyName = "unidad";
            this.unidad.HeaderText = "unidad";
            this.unidad.MinimumWidth = 6;
            this.unidad.Name = "unidad";
            this.unidad.ReadOnly = true;
            this.unidad.Width = 125;
            // 
            // bId
            // 
            this.bId.DataPropertyName = "bId";
            this.bId.HeaderText = "bId";
            this.bId.MinimumWidth = 6;
            this.bId.Name = "bId";
            this.bId.ReadOnly = true;
            this.bId.Width = 125;
            // 
            // cId
            // 
            this.cId.DataPropertyName = "cId";
            this.cId.HeaderText = "cId";
            this.cId.MinimumWidth = 6;
            this.cId.Name = "cId";
            this.cId.ReadOnly = true;
            this.cId.Width = 125;
            // 
            // gId
            // 
            this.gId.DataPropertyName = "gId";
            this.gId.HeaderText = "gId";
            this.gId.MinimumWidth = 6;
            this.gId.Name = "gId";
            this.gId.ReadOnly = true;
            this.gId.Width = 125;
            // 
            // mId
            // 
            this.mId.DataPropertyName = "mId";
            this.mId.HeaderText = "mId";
            this.mId.MinimumWidth = 6;
            this.mId.Name = "mId";
            this.mId.ReadOnly = true;
            this.mId.Width = 125;
            // 
            // servicio
            // 
            this.servicio.DataPropertyName = "servicio";
            this.servicio.HeaderText = "servicio";
            this.servicio.MinimumWidth = 6;
            this.servicio.Name = "servicio";
            this.servicio.ReadOnly = true;
            this.servicio.Width = 125;
            // 
            // hascombo
            // 
            this.hascombo.DataPropertyName = "hascombo";
            this.hascombo.HeaderText = "hascombo";
            this.hascombo.MinimumWidth = 6;
            this.hascombo.Name = "hascombo";
            this.hascombo.ReadOnly = true;
            this.hascombo.Width = 125;
            // 
            // aplicaSeries
            // 
            this.aplicaSeries.DataPropertyName = "aplicaSeries";
            this.aplicaSeries.HeaderText = "aplicaSeries";
            this.aplicaSeries.MinimumWidth = 6;
            this.aplicaSeries.Name = "aplicaSeries";
            this.aplicaSeries.ReadOnly = true;
            this.aplicaSeries.Width = 125;
            // 
            // negativo
            // 
            this.negativo.DataPropertyName = "negativo";
            this.negativo.HeaderText = "negativo";
            this.negativo.MinimumWidth = 6;
            this.negativo.Name = "negativo";
            this.negativo.ReadOnly = true;
            this.negativo.Width = 125;
            // 
            // ice
            // 
            this.ice.DataPropertyName = "ice";
            this.ice.HeaderText = "ice";
            this.ice.MinimumWidth = 6;
            this.ice.Name = "ice";
            this.ice.ReadOnly = true;
            this.ice.Width = 125;
            // 
            // valorIce
            // 
            this.valorIce.DataPropertyName = "valorIce";
            this.valorIce.HeaderText = "valorIce";
            this.valorIce.MinimumWidth = 6;
            this.valorIce.Name = "valorIce";
            this.valorIce.ReadOnly = true;
            this.valorIce.Width = 125;
            // 
            // imagen
            // 
            this.imagen.DataPropertyName = "imagen";
            this.imagen.HeaderText = "imagen";
            this.imagen.MinimumWidth = 6;
            this.imagen.Name = "imagen";
            this.imagen.ReadOnly = true;
            this.imagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.imagen.Width = 125;
            // 
            // imagenUrl
            // 
            this.imagenUrl.DataPropertyName = "imagenUrl";
            this.imagenUrl.HeaderText = "imagenUrl";
            this.imagenUrl.MinimumWidth = 6;
            this.imagenUrl.Name = "imagenUrl";
            this.imagenUrl.ReadOnly = true;
            this.imagenUrl.Width = 125;
            // 
            // iva
            // 
            this.iva.DataPropertyName = "iva";
            this.iva.HeaderText = "iva";
            this.iva.MinimumWidth = 6;
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            this.iva.Width = 125;
            // 
            // montoTotal
            // 
            this.montoTotal.DataPropertyName = "montoTotal";
            this.montoTotal.HeaderText = "montoTotal";
            this.montoTotal.MinimumWidth = 6;
            this.montoTotal.Name = "montoTotal";
            this.montoTotal.ReadOnly = true;
            this.montoTotal.Width = 125;
            // 
            // costoTotal
            // 
            this.costoTotal.DataPropertyName = "CostoTotal";
            this.costoTotal.HeaderText = "Precio total";
            this.costoTotal.MinimumWidth = 6;
            this.costoTotal.Name = "costoTotal";
            this.costoTotal.ReadOnly = true;
            this.costoTotal.Width = 125;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit.HeaderText = "";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.MinimumWidth = 6;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 6;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 6;
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.panel1);
            this.Name = "Compras";
            this.Text = "Compras";
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource itemsBindingSource1;
        private System.Windows.Forms.BindingSource itemsBindingSource3;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private System.Windows.Forms.BindingSource itemsBindingSource2;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource comboBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn hasIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioA;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioB;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioC;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioD;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn descMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn bId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn gId;
        private System.Windows.Forms.DataGridViewTextBoxColumn mId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn servicio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hascombo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aplicaSeries;
        private System.Windows.Forms.DataGridViewCheckBoxColumn negativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ice;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorIce;
        private System.Windows.Forms.DataGridViewImageColumn imagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagenUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoTotal;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}