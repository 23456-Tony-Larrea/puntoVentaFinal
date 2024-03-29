﻿namespace POSales.Mantenimientos
{
    partial class ReservasModulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservasModulo));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtIdReserva = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.txtDescripcionItem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCodBarrasItem = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBuscarItem = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtIvaItem = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSubTotalItem = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtTotalItem = new System.Windows.Forms.TextBox();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ggvProductos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IvaPorItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalPorItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modulo de Reservas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(59, 557);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 35);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // txtIdReserva
            // 
            this.txtIdReserva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdReserva.Enabled = false;
            this.txtIdReserva.Location = new System.Drawing.Point(42, 67);
            this.txtIdReserva.Name = "txtIdReserva";
            this.txtIdReserva.Size = new System.Drawing.Size(114, 28);
            this.txtIdReserva.TabIndex = 187;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 599);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 53);
            this.panel1.TabIndex = 184;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(700, 557);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 35);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picClose.Location = new System.Drawing.Point(771, 0);
            this.picClose.Margin = new System.Windows.Forms.Padding(5);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(56, 45);
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            // 
            // txtDescripcionItem
            // 
            this.txtDescripcionItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionItem.Enabled = false;
            this.txtDescripcionItem.Location = new System.Drawing.Point(208, 140);
            this.txtDescripcionItem.Name = "txtDescripcionItem";
            this.txtDescripcionItem.Size = new System.Drawing.Size(569, 28);
            this.txtDescripcionItem.TabIndex = 2;
            this.txtDescripcionItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 21);
            this.label2.TabIndex = 195;
            this.label2.Text = "descripcion del item";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 70);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 21);
            this.label18.TabIndex = 186;
            this.label18.Text = "Id";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel2.Controls.Add(this.picClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(827, 45);
            this.panel2.TabIndex = 185;
            // 
            // txtCodBarrasItem
            // 
            this.txtCodBarrasItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodBarrasItem.Enabled = false;
            this.txtCodBarrasItem.Location = new System.Drawing.Point(208, 99);
            this.txtCodBarrasItem.Name = "txtCodBarrasItem";
            this.txtCodBarrasItem.Size = new System.Drawing.Size(569, 28);
            this.txtCodBarrasItem.TabIndex = 1;
            this.txtCodBarrasItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 99);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(201, 21);
            this.label11.TabIndex = 193;
            this.label11.Text = "codigo barras del Item";
            // 
            // btnBuscarItem
            // 
            this.btnBuscarItem.Location = new System.Drawing.Point(787, 103);
            this.btnBuscarItem.Name = "btnBuscarItem";
            this.btnBuscarItem.Size = new System.Drawing.Size(34, 24);
            this.btnBuscarItem.TabIndex = 206;
            this.btnBuscarItem.Text = "...";
            this.btnBuscarItem.UseVisualStyleBackColor = true;
            this.btnBuscarItem.Click += new System.EventHandler(this.btnBuscarItem_Click);
            this.btnBuscarItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(357, 177);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(124, 28);
            this.txtPrecio.TabIndex = 4;
            this.txtPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(503, 431);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(124, 28);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 434);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 226;
            this.label3.Text = "TOTAL";
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(503, 399);
            this.txtIva.Margin = new System.Windows.Forms.Padding(4);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(124, 28);
            this.txtIva.TabIndex = 11;
            this.txtIva.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 402);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 21);
            this.label4.TabIndex = 224;
            this.label4.Text = "Iva";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(336, 402);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(124, 28);
            this.textBox11.TabIndex = 223;
            this.textBox11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(229, 405);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 21);
            this.label23.TabIndex = 222;
            this.label23.Text = "SubTotal 0%";
            // 
            // txtIvaItem
            // 
            this.txtIvaItem.Enabled = false;
            this.txtIvaItem.Location = new System.Drawing.Point(357, 225);
            this.txtIvaItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtIvaItem.Name = "txtIvaItem";
            this.txtIvaItem.Size = new System.Drawing.Size(124, 28);
            this.txtIvaItem.TabIndex = 7;
            this.txtIvaItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(325, 227);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(38, 21);
            this.label22.TabIndex = 220;
            this.label22.Text = "Iva";
            // 
            // txtSubTotalItem
            // 
            this.txtSubTotalItem.Enabled = false;
            this.txtSubTotalItem.Location = new System.Drawing.Point(173, 225);
            this.txtSubTotalItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubTotalItem.Name = "txtSubTotalItem";
            this.txtSubTotalItem.Size = new System.Drawing.Size(124, 28);
            this.txtSubTotalItem.TabIndex = 6;
            this.txtSubTotalItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(97, 228);
            this.label21.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 21);
            this.label21.TabIndex = 218;
            this.label21.Text = "Subtotal";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(96, 402);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(124, 28);
            this.txtSubtotal.TabIndex = 217;
            this.txtSubtotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 406);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 21);
            this.label9.TabIndex = 216;
            this.label9.Text = "SubTotal";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(642, 401);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(99, 29);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar ";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // txtTotalItem
            // 
            this.txtTotalItem.Enabled = false;
            this.txtTotalItem.Location = new System.Drawing.Point(545, 226);
            this.txtTotalItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalItem.Name = "txtTotalItem";
            this.txtTotalItem.Size = new System.Drawing.Size(91, 28);
            this.txtTotalItem.TabIndex = 8;
            this.txtTotalItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(173, 182);
            this.txtCant.Margin = new System.Windows.Forms.Padding(4);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(124, 28);
            this.txtCant.TabIndex = 3;
            this.txtCant.TextChanged += new System.EventHandler(this.txtCant_TextChanged);
            this.txtCant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(545, 178);
            this.txtStock.Margin = new System.Windows.Forms.Padding(4);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(91, 28);
            this.txtStock.TabIndex = 5;
            this.txtStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 228);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 21);
            this.label8.TabIndex = 210;
            this.label8.Text = "total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 182);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 21);
            this.label7.TabIndex = 209;
            this.label7.Text = "Cantidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 180);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 21);
            this.label6.TabIndex = 208;
            this.label6.Text = "Stock";
            // 
            // ggvProductos
            // 
            this.ggvProductos.AllowUserToAddRows = false;
            this.ggvProductos.AllowUserToDeleteRows = false;
            this.ggvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ggvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.No,
            this.Producto,
            this.precio,
            this.cantidad,
            this.IvaPorItem,
            this.subtotalPorItem,
            this.total});
            this.ggvProductos.Location = new System.Drawing.Point(18, 269);
            this.ggvProductos.Margin = new System.Windows.Forms.Padding(4);
            this.ggvProductos.Name = "ggvProductos";
            this.ggvProductos.ReadOnly = true;
            this.ggvProductos.RowHeadersVisible = false;
            this.ggvProductos.RowHeadersWidth = 51;
            this.ggvProductos.RowTemplate.Height = 24;
            this.ggvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ggvProductos.Size = new System.Drawing.Size(723, 124);
            this.ggvProductos.TabIndex = 215;
            this.ggvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 63;
            // 
            // Producto
            // 
            this.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Producto.HeaderText = "Productos";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.precio.HeaderText = "precio";
            this.precio.MinimumWidth = 6;
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 92;
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cantidad.HeaderText = "cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 118;
            // 
            // IvaPorItem
            // 
            this.IvaPorItem.HeaderText = "IvaPorItem";
            this.IvaPorItem.MinimumWidth = 6;
            this.IvaPorItem.Name = "IvaPorItem";
            this.IvaPorItem.ReadOnly = true;
            this.IvaPorItem.Visible = false;
            this.IvaPorItem.Width = 125;
            // 
            // subtotalPorItem
            // 
            this.subtotalPorItem.HeaderText = "subtotalPorItem";
            this.subtotalPorItem.MinimumWidth = 6;
            this.subtotalPorItem.Name = "subtotalPorItem";
            this.subtotalPorItem.ReadOnly = true;
            this.subtotalPorItem.Visible = false;
            this.subtotalPorItem.Width = 125;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.total.HeaderText = "total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 180);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 207;
            this.label5.Text = "Precio";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(650, 198);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(91, 31);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnAgregar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // ReservasModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 652);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtIvaItem);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtSubTotalItem);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtTotalItem);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ggvProductos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBuscarItem);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtIdReserva);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescripcionItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtCodBarrasItem);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReservasModulo";
            this.Text = "ReservasModulo";
            this.Load += new System.EventHandler(this.ReservasModulo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtIdReserva;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.TextBox txtDescripcionItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCodBarrasItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBuscarItem;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIva;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox11;
        public System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtIvaItem;
        public System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtSubTotalItem;
        public System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSubtotal;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtTotalItem;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.TextBox txtStock;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView ggvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IvaPorItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalPorItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregar;
    }
}