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
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprasBindingSource)).BeginInit();
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
            this.stock,
            this.Edit,
            this.Delete});
            this.dgvItem.DataSource = this.comprasBindingSource;
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
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 125;
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
            // dBPOSaleDataSet
            // 
        
            // 
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
            this.Load += new System.EventHandler(this.Compras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprasBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn descMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.BindingSource comprasBindingSource;
    }
}