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
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasIvaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoUnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoTresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoCuatroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoBarrasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadCajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicioDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aplicaSeriesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.negativoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.comboDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gastoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorIceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImagenBitmap = new System.Windows.Forms.DataGridViewImageColumn();
            this.imagenDataGridViewImageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagenUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.idDataGridViewTextBoxColumn,
            this.hasIvaDataGridViewCheckBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.codigoUnoDataGridViewTextBoxColumn,
            this.codigoDosDataGridViewTextBoxColumn,
            this.codigoTresDataGridViewTextBoxColumn,
            this.codigoCuatroDataGridViewTextBoxColumn,
            this.codigoBarrasDataGridViewTextBoxColumn,
            this.precioADataGridViewTextBoxColumn,
            this.precioBDataGridViewTextBoxColumn,
            this.precioCDataGridViewTextBoxColumn,
            this.precioDDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.unidadCajaDataGridViewTextBoxColumn,
            this.pesoDataGridViewTextBoxColumn,
            this.comisionDataGridViewTextBoxColumn,
            this.descMaxDataGridViewTextBoxColumn,
            this.stockMinDataGridViewTextBoxColumn,
            this.stockMaxDataGridViewTextBoxColumn,
            this.costoDataGridViewTextBoxColumn,
            this.unidadDataGridViewTextBoxColumn,
            this.bIdDataGridViewTextBoxColumn,
            this.cIdDataGridViewTextBoxColumn,
            this.gIdDataGridViewTextBoxColumn,
            this.mIdDataGridViewTextBoxColumn,
            this.servicioDataGridViewCheckBoxColumn,
            this.aplicaSeriesDataGridViewCheckBoxColumn,
            this.negativoDataGridViewCheckBoxColumn,
            this.comboDataGridViewCheckBoxColumn,
            this.gastoDataGridViewCheckBoxColumn,
            this.iceDataGridViewTextBoxColumn,
            this.valorIceDataGridViewTextBoxColumn,
            this.ImagenBitmap,
            this.imagenDataGridViewImageColumn,
            this.imagenUrlDataGridViewTextBoxColumn,
            this.ivaDataGridViewTextBoxColumn,
            this.montoTotalDataGridViewTextBoxColumn,
            this.categoriaADataGridViewTextBoxColumn,
            this.categoriaBDataGridViewTextBoxColumn,
            this.categoriaCDataGridViewTextBoxColumn,
            this.categoriaDDataGridViewTextBoxColumn,
            this.categoriaEDataGridViewTextBoxColumn,
            this.costoTotalDataGridViewTextBoxColumn,
            this.Edit,
            this.Delete});
            this.dgvItem.DataSource = this.itemsBindingSource;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItem.EnableHeadersVisualStyles = false;
            this.dgvItem.Location = new System.Drawing.Point(0, 0);
            this.dgvItem.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.RowHeadersWidth = 51;
            this.dgvItem.Size = new System.Drawing.Size(1284, 302);
            this.dgvItem.TabIndex = 7;
            this.dgvItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBodega_CellContentClick);
            this.dgvItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItem_CellFormatting);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataSource = typeof(POSalesDb.Items);
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
            this.panel1.Size = new System.Drawing.Size(1284, 65);
            this.panel1.TabIndex = 6;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hasIvaDataGridViewCheckBoxColumn
            // 
            this.hasIvaDataGridViewCheckBoxColumn.DataPropertyName = "HasIva";
            this.hasIvaDataGridViewCheckBoxColumn.HeaderText = "HasIva";
            this.hasIvaDataGridViewCheckBoxColumn.Name = "hasIvaDataGridViewCheckBoxColumn";
            this.hasIvaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoUnoDataGridViewTextBoxColumn
            // 
            this.codigoUnoDataGridViewTextBoxColumn.DataPropertyName = "codigoUno";
            this.codigoUnoDataGridViewTextBoxColumn.HeaderText = "codigoUno";
            this.codigoUnoDataGridViewTextBoxColumn.Name = "codigoUnoDataGridViewTextBoxColumn";
            this.codigoUnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoDosDataGridViewTextBoxColumn
            // 
            this.codigoDosDataGridViewTextBoxColumn.DataPropertyName = "codigoDos";
            this.codigoDosDataGridViewTextBoxColumn.HeaderText = "codigoDos";
            this.codigoDosDataGridViewTextBoxColumn.Name = "codigoDosDataGridViewTextBoxColumn";
            this.codigoDosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoTresDataGridViewTextBoxColumn
            // 
            this.codigoTresDataGridViewTextBoxColumn.DataPropertyName = "codigoTres";
            this.codigoTresDataGridViewTextBoxColumn.HeaderText = "codigoTres";
            this.codigoTresDataGridViewTextBoxColumn.Name = "codigoTresDataGridViewTextBoxColumn";
            this.codigoTresDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoCuatroDataGridViewTextBoxColumn
            // 
            this.codigoCuatroDataGridViewTextBoxColumn.DataPropertyName = "codigoCuatro";
            this.codigoCuatroDataGridViewTextBoxColumn.HeaderText = "codigoCuatro";
            this.codigoCuatroDataGridViewTextBoxColumn.Name = "codigoCuatroDataGridViewTextBoxColumn";
            this.codigoCuatroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoBarrasDataGridViewTextBoxColumn
            // 
            this.codigoBarrasDataGridViewTextBoxColumn.DataPropertyName = "codigoBarras";
            this.codigoBarrasDataGridViewTextBoxColumn.HeaderText = "codigoBarras";
            this.codigoBarrasDataGridViewTextBoxColumn.Name = "codigoBarrasDataGridViewTextBoxColumn";
            this.codigoBarrasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioADataGridViewTextBoxColumn
            // 
            this.precioADataGridViewTextBoxColumn.DataPropertyName = "precioA";
            this.precioADataGridViewTextBoxColumn.HeaderText = "precioA";
            this.precioADataGridViewTextBoxColumn.Name = "precioADataGridViewTextBoxColumn";
            this.precioADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioBDataGridViewTextBoxColumn
            // 
            this.precioBDataGridViewTextBoxColumn.DataPropertyName = "precioB";
            this.precioBDataGridViewTextBoxColumn.HeaderText = "precioB";
            this.precioBDataGridViewTextBoxColumn.Name = "precioBDataGridViewTextBoxColumn";
            this.precioBDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioCDataGridViewTextBoxColumn
            // 
            this.precioCDataGridViewTextBoxColumn.DataPropertyName = "precioC";
            this.precioCDataGridViewTextBoxColumn.HeaderText = "precioC";
            this.precioCDataGridViewTextBoxColumn.Name = "precioCDataGridViewTextBoxColumn";
            this.precioCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioDDataGridViewTextBoxColumn
            // 
            this.precioDDataGridViewTextBoxColumn.DataPropertyName = "precioD";
            this.precioDDataGridViewTextBoxColumn.HeaderText = "precioD";
            this.precioDDataGridViewTextBoxColumn.Name = "precioDDataGridViewTextBoxColumn";
            this.precioDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unidadCajaDataGridViewTextBoxColumn
            // 
            this.unidadCajaDataGridViewTextBoxColumn.DataPropertyName = "unidadCaja";
            this.unidadCajaDataGridViewTextBoxColumn.HeaderText = "unidadCaja";
            this.unidadCajaDataGridViewTextBoxColumn.Name = "unidadCajaDataGridViewTextBoxColumn";
            this.unidadCajaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pesoDataGridViewTextBoxColumn
            // 
            this.pesoDataGridViewTextBoxColumn.DataPropertyName = "peso";
            this.pesoDataGridViewTextBoxColumn.HeaderText = "peso";
            this.pesoDataGridViewTextBoxColumn.Name = "pesoDataGridViewTextBoxColumn";
            this.pesoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comisionDataGridViewTextBoxColumn
            // 
            this.comisionDataGridViewTextBoxColumn.DataPropertyName = "comision";
            this.comisionDataGridViewTextBoxColumn.HeaderText = "comision";
            this.comisionDataGridViewTextBoxColumn.Name = "comisionDataGridViewTextBoxColumn";
            this.comisionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descMaxDataGridViewTextBoxColumn
            // 
            this.descMaxDataGridViewTextBoxColumn.DataPropertyName = "descMax";
            this.descMaxDataGridViewTextBoxColumn.HeaderText = "descMax";
            this.descMaxDataGridViewTextBoxColumn.Name = "descMaxDataGridViewTextBoxColumn";
            this.descMaxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockMinDataGridViewTextBoxColumn
            // 
            this.stockMinDataGridViewTextBoxColumn.DataPropertyName = "stockMin";
            this.stockMinDataGridViewTextBoxColumn.HeaderText = "stockMin";
            this.stockMinDataGridViewTextBoxColumn.Name = "stockMinDataGridViewTextBoxColumn";
            this.stockMinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockMaxDataGridViewTextBoxColumn
            // 
            this.stockMaxDataGridViewTextBoxColumn.DataPropertyName = "stockMax";
            this.stockMaxDataGridViewTextBoxColumn.HeaderText = "stockMax";
            this.stockMaxDataGridViewTextBoxColumn.Name = "stockMaxDataGridViewTextBoxColumn";
            this.stockMaxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoDataGridViewTextBoxColumn
            // 
            this.costoDataGridViewTextBoxColumn.DataPropertyName = "costo";
            this.costoDataGridViewTextBoxColumn.HeaderText = "costo";
            this.costoDataGridViewTextBoxColumn.Name = "costoDataGridViewTextBoxColumn";
            this.costoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unidadDataGridViewTextBoxColumn
            // 
            this.unidadDataGridViewTextBoxColumn.DataPropertyName = "unidad";
            this.unidadDataGridViewTextBoxColumn.HeaderText = "unidad";
            this.unidadDataGridViewTextBoxColumn.Name = "unidadDataGridViewTextBoxColumn";
            this.unidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bIdDataGridViewTextBoxColumn
            // 
            this.bIdDataGridViewTextBoxColumn.DataPropertyName = "bId";
            this.bIdDataGridViewTextBoxColumn.HeaderText = "bId";
            this.bIdDataGridViewTextBoxColumn.Name = "bIdDataGridViewTextBoxColumn";
            this.bIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cIdDataGridViewTextBoxColumn
            // 
            this.cIdDataGridViewTextBoxColumn.DataPropertyName = "cId";
            this.cIdDataGridViewTextBoxColumn.HeaderText = "cId";
            this.cIdDataGridViewTextBoxColumn.Name = "cIdDataGridViewTextBoxColumn";
            this.cIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gIdDataGridViewTextBoxColumn
            // 
            this.gIdDataGridViewTextBoxColumn.DataPropertyName = "gId";
            this.gIdDataGridViewTextBoxColumn.HeaderText = "gId";
            this.gIdDataGridViewTextBoxColumn.Name = "gIdDataGridViewTextBoxColumn";
            this.gIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mIdDataGridViewTextBoxColumn
            // 
            this.mIdDataGridViewTextBoxColumn.DataPropertyName = "mId";
            this.mIdDataGridViewTextBoxColumn.HeaderText = "mId";
            this.mIdDataGridViewTextBoxColumn.Name = "mIdDataGridViewTextBoxColumn";
            this.mIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // servicioDataGridViewCheckBoxColumn
            // 
            this.servicioDataGridViewCheckBoxColumn.DataPropertyName = "servicio";
            this.servicioDataGridViewCheckBoxColumn.HeaderText = "servicio";
            this.servicioDataGridViewCheckBoxColumn.Name = "servicioDataGridViewCheckBoxColumn";
            this.servicioDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // aplicaSeriesDataGridViewCheckBoxColumn
            // 
            this.aplicaSeriesDataGridViewCheckBoxColumn.DataPropertyName = "aplicaSeries";
            this.aplicaSeriesDataGridViewCheckBoxColumn.HeaderText = "aplicaSeries";
            this.aplicaSeriesDataGridViewCheckBoxColumn.Name = "aplicaSeriesDataGridViewCheckBoxColumn";
            this.aplicaSeriesDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // negativoDataGridViewCheckBoxColumn
            // 
            this.negativoDataGridViewCheckBoxColumn.DataPropertyName = "negativo";
            this.negativoDataGridViewCheckBoxColumn.HeaderText = "negativo";
            this.negativoDataGridViewCheckBoxColumn.Name = "negativoDataGridViewCheckBoxColumn";
            this.negativoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // comboDataGridViewCheckBoxColumn
            // 
            this.comboDataGridViewCheckBoxColumn.DataPropertyName = "combo";
            this.comboDataGridViewCheckBoxColumn.HeaderText = "combo";
            this.comboDataGridViewCheckBoxColumn.Name = "comboDataGridViewCheckBoxColumn";
            this.comboDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // gastoDataGridViewCheckBoxColumn
            // 
            this.gastoDataGridViewCheckBoxColumn.DataPropertyName = "gasto";
            this.gastoDataGridViewCheckBoxColumn.HeaderText = "gasto";
            this.gastoDataGridViewCheckBoxColumn.Name = "gastoDataGridViewCheckBoxColumn";
            this.gastoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // iceDataGridViewTextBoxColumn
            // 
            this.iceDataGridViewTextBoxColumn.DataPropertyName = "ice";
            this.iceDataGridViewTextBoxColumn.HeaderText = "ice";
            this.iceDataGridViewTextBoxColumn.Name = "iceDataGridViewTextBoxColumn";
            this.iceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorIceDataGridViewTextBoxColumn
            // 
            this.valorIceDataGridViewTextBoxColumn.DataPropertyName = "valorIce";
            this.valorIceDataGridViewTextBoxColumn.HeaderText = "valorIce";
            this.valorIceDataGridViewTextBoxColumn.Name = "valorIceDataGridViewTextBoxColumn";
            this.valorIceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ImagenBitmap
            // 
            this.ImagenBitmap.HeaderText = "Imagen";
            this.ImagenBitmap.Name = "ImagenBitmap";
            this.ImagenBitmap.ReadOnly = true;
            // 
            // imagenDataGridViewImageColumn
            // 
            this.imagenDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.imagenDataGridViewImageColumn.DataPropertyName = "imagen";
            this.imagenDataGridViewImageColumn.HeaderText = "imagen";
            this.imagenDataGridViewImageColumn.Name = "imagenDataGridViewImageColumn";
            this.imagenDataGridViewImageColumn.ReadOnly = true;
            this.imagenDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imagenDataGridViewImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // imagenUrlDataGridViewTextBoxColumn
            // 
            this.imagenUrlDataGridViewTextBoxColumn.DataPropertyName = "imagenUrl";
            this.imagenUrlDataGridViewTextBoxColumn.HeaderText = "imagenUrl";
            this.imagenUrlDataGridViewTextBoxColumn.Name = "imagenUrlDataGridViewTextBoxColumn";
            this.imagenUrlDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ivaDataGridViewTextBoxColumn
            // 
            this.ivaDataGridViewTextBoxColumn.DataPropertyName = "iva";
            this.ivaDataGridViewTextBoxColumn.HeaderText = "iva";
            this.ivaDataGridViewTextBoxColumn.Name = "ivaDataGridViewTextBoxColumn";
            this.ivaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoTotalDataGridViewTextBoxColumn
            // 
            this.montoTotalDataGridViewTextBoxColumn.DataPropertyName = "montoTotal";
            this.montoTotalDataGridViewTextBoxColumn.HeaderText = "montoTotal";
            this.montoTotalDataGridViewTextBoxColumn.Name = "montoTotalDataGridViewTextBoxColumn";
            this.montoTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoriaADataGridViewTextBoxColumn
            // 
            this.categoriaADataGridViewTextBoxColumn.DataPropertyName = "categoriaA";
            this.categoriaADataGridViewTextBoxColumn.HeaderText = "categoriaA";
            this.categoriaADataGridViewTextBoxColumn.Name = "categoriaADataGridViewTextBoxColumn";
            this.categoriaADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoriaBDataGridViewTextBoxColumn
            // 
            this.categoriaBDataGridViewTextBoxColumn.DataPropertyName = "categoriaB";
            this.categoriaBDataGridViewTextBoxColumn.HeaderText = "categoriaB";
            this.categoriaBDataGridViewTextBoxColumn.Name = "categoriaBDataGridViewTextBoxColumn";
            this.categoriaBDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoriaCDataGridViewTextBoxColumn
            // 
            this.categoriaCDataGridViewTextBoxColumn.DataPropertyName = "categoriaC";
            this.categoriaCDataGridViewTextBoxColumn.HeaderText = "categoriaC";
            this.categoriaCDataGridViewTextBoxColumn.Name = "categoriaCDataGridViewTextBoxColumn";
            this.categoriaCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoriaDDataGridViewTextBoxColumn
            // 
            this.categoriaDDataGridViewTextBoxColumn.DataPropertyName = "categoriaD";
            this.categoriaDDataGridViewTextBoxColumn.HeaderText = "categoriaD";
            this.categoriaDDataGridViewTextBoxColumn.Name = "categoriaDDataGridViewTextBoxColumn";
            this.categoriaDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoriaEDataGridViewTextBoxColumn
            // 
            this.categoriaEDataGridViewTextBoxColumn.DataPropertyName = "categoriaE";
            this.categoriaEDataGridViewTextBoxColumn.HeaderText = "categoriaE";
            this.categoriaEDataGridViewTextBoxColumn.Name = "categoriaEDataGridViewTextBoxColumn";
            this.categoriaEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoTotalDataGridViewTextBoxColumn
            // 
            this.costoTotalDataGridViewTextBoxColumn.DataPropertyName = "CostoTotal";
            this.costoTotalDataGridViewTextBoxColumn.HeaderText = "Precio total";
            this.costoTotalDataGridViewTextBoxColumn.Name = "costoTotalDataGridViewTextBoxColumn";
            this.costoTotalDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.ClientSize = new System.Drawing.Size(1284, 367);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Item";
            this.Text = "Item";
            this.Load += new System.EventHandler(this.Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasIvaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoUnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoTresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoCuatroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoBarrasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadCajaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn servicioDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aplicaSeriesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn negativoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn comboDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gastoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorIceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn ImagenBitmap;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagenDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagenUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}