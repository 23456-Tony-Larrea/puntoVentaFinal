namespace POSales
{
    partial class Item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Item));
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.itemsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.itemsBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasIva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource3)).BeginInit();
            this.SuspendLayout();
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
            this.dgvItem.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.RowHeadersWidth = 51;
            this.dgvItem.Size = new System.Drawing.Size(765, 302);
            this.dgvItem.TabIndex = 7;
            this.dgvItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBodega_CellContentClick);
            this.dgvItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItem_CellFormatting);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(698, 21);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 26);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manejo Items";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 302);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 65);
            this.panel1.TabIndex = 6;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataSource = typeof(POSalesDb.Items);
            // 
            // comboBindingSource
            // 
            this.comboBindingSource.DataMember = "Combo";
            this.comboBindingSource.DataSource = this.itemsBindingSource;
            // 
            // itemsBindingSource1
            // 
            this.itemsBindingSource1.DataSource = typeof(POSalesDb.Items);
            // 
            // itemsBindingSource2
            // 
            this.itemsBindingSource2.DataSource = typeof(POSalesDb.Items);
            // 
            // itemsBindingSource3
            // 
            this.itemsBindingSource3.DataSource = typeof(POSalesDb.Items);
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // hasIva
            // 
            this.hasIva.DataPropertyName = "HasIva";
            this.hasIva.HeaderText = "HasIva";
            this.hasIva.Name = "hasIva";
            this.hasIva.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // codigoBarras
            // 
            this.codigoBarras.DataPropertyName = "codigoBarras";
            this.codigoBarras.HeaderText = "codigoBarras";
            this.codigoBarras.Name = "codigoBarras";
            this.codigoBarras.ReadOnly = true;
            // 
            // precioA
            // 
            this.precioA.DataPropertyName = "precioA";
            this.precioA.HeaderText = "precioA";
            this.precioA.Name = "precioA";
            this.precioA.ReadOnly = true;
            // 
            // precioB
            // 
            this.precioB.DataPropertyName = "precioB";
            this.precioB.HeaderText = "precioB";
            this.precioB.Name = "precioB";
            this.precioB.ReadOnly = true;
            // 
            // precioC
            // 
            this.precioC.DataPropertyName = "precioC";
            this.precioC.HeaderText = "precioC";
            this.precioC.Name = "precioC";
            this.precioC.ReadOnly = true;
            // 
            // precioD
            // 
            this.precioD.DataPropertyName = "precioD";
            this.precioD.HeaderText = "precioD";
            this.precioD.Name = "precioD";
            this.precioD.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // descMax
            // 
            this.descMax.DataPropertyName = "descMax";
            this.descMax.HeaderText = "descMax";
            this.descMax.Name = "descMax";
            this.descMax.ReadOnly = true;
            // 
            // stockMin
            // 
            this.stockMin.DataPropertyName = "stockMin";
            this.stockMin.HeaderText = "stockMin";
            this.stockMin.Name = "stockMin";
            this.stockMin.ReadOnly = true;
            // 
            // stock
            // 
            this.stock.DataPropertyName = "stock";
            this.stock.HeaderText = "stock";
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            // 
            // unidad
            // 
            this.unidad.DataPropertyName = "unidad";
            this.unidad.HeaderText = "unidad";
            this.unidad.Name = "unidad";
            this.unidad.ReadOnly = true;
            // 
            // bId
            // 
            this.bId.DataPropertyName = "bId";
            this.bId.HeaderText = "bId";
            this.bId.Name = "bId";
            this.bId.ReadOnly = true;
            // 
            // cId
            // 
            this.cId.DataPropertyName = "cId";
            this.cId.HeaderText = "cId";
            this.cId.Name = "cId";
            this.cId.ReadOnly = true;
            // 
            // gId
            // 
            this.gId.DataPropertyName = "gId";
            this.gId.HeaderText = "gId";
            this.gId.Name = "gId";
            this.gId.ReadOnly = true;
            // 
            // mId
            // 
            this.mId.DataPropertyName = "mId";
            this.mId.HeaderText = "mId";
            this.mId.Name = "mId";
            this.mId.ReadOnly = true;
            // 
            // servicio
            // 
            this.servicio.DataPropertyName = "servicio";
            this.servicio.HeaderText = "servicio";
            this.servicio.Name = "servicio";
            this.servicio.ReadOnly = true;
            // 
            // hascombo
            // 
            this.hascombo.DataPropertyName = "hascombo";
            this.hascombo.HeaderText = "hascombo";
            this.hascombo.Name = "hascombo";
            this.hascombo.ReadOnly = true;
            // 
            // aplicaSeries
            // 
            this.aplicaSeries.DataPropertyName = "aplicaSeries";
            this.aplicaSeries.HeaderText = "aplicaSeries";
            this.aplicaSeries.Name = "aplicaSeries";
            this.aplicaSeries.ReadOnly = true;
            // 
            // negativo
            // 
            this.negativo.DataPropertyName = "negativo";
            this.negativo.HeaderText = "negativo";
            this.negativo.Name = "negativo";
            this.negativo.ReadOnly = true;
            // 
            // ice
            // 
            this.ice.DataPropertyName = "ice";
            this.ice.HeaderText = "ice";
            this.ice.Name = "ice";
            this.ice.ReadOnly = true;
            // 
            // valorIce
            // 
            this.valorIce.DataPropertyName = "valorIce";
            this.valorIce.HeaderText = "valorIce";
            this.valorIce.Name = "valorIce";
            this.valorIce.ReadOnly = true;
            // 
            // imagen
            // 
            this.imagen.DataPropertyName = "imagen";
            this.imagen.HeaderText = "imagen";
            this.imagen.Name = "imagen";
            this.imagen.ReadOnly = true;
            this.imagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // imagenUrl
            // 
            this.imagenUrl.DataPropertyName = "imagenUrl";
            this.imagenUrl.HeaderText = "imagenUrl";
            this.imagenUrl.Name = "imagenUrl";
            this.imagenUrl.ReadOnly = true;
            // 
            // iva
            // 
            this.iva.DataPropertyName = "iva";
            this.iva.HeaderText = "iva";
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            // 
            // montoTotal
            // 
            this.montoTotal.DataPropertyName = "montoTotal";
            this.montoTotal.HeaderText = "montoTotal";
            this.montoTotal.Name = "montoTotal";
            this.montoTotal.ReadOnly = true;
            // 
            // costoTotal
            // 
            this.costoTotal.DataPropertyName = "CostoTotal";
            this.costoTotal.HeaderText = "Precio total";
            this.costoTotal.Name = "costoTotal";
            this.costoTotal.ReadOnly = true;
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
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 367);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Item";
            this.Text = "Item";
            this.Load += new System.EventHandler(this.Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoUnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoTresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoCuatroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadCajaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn comboDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gastoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaEDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource itemsBindingSource2;
        private System.Windows.Forms.BindingSource comboBindingSource;
        private System.Windows.Forms.BindingSource itemsBindingSource1;
        private System.Windows.Forms.BindingSource itemsBindingSource3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasIva;
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