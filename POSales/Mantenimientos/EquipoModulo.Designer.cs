namespace POSales.Mantenimientos
{
    partial class EquipoModulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipoModulo));
            this.txtDescripcionFallo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeriesEquipo = new System.Windows.Forms.TextBox();
            this.txtCodigoEquipo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionEquipo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtIdEquipo = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescripcionFallo
            // 
            this.txtDescripcionFallo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionFallo.Location = new System.Drawing.Point(185, 242);
            this.txtDescripcionFallo.Multiline = true;
            this.txtDescripcionFallo.Name = "txtDescripcionFallo";
            this.txtDescripcionFallo.Size = new System.Drawing.Size(569, 120);
            this.txtDescripcionFallo.TabIndex = 155;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 255);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 21);
            this.label3.TabIndex = 154;
            this.label3.Text = "Descripcion del fallo";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 70);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 21);
            this.label18.TabIndex = 142;
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
            this.panel2.Size = new System.Drawing.Size(769, 45);
            this.panel2.TabIndex = 140;
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picClose.Location = new System.Drawing.Point(713, 0);
            this.picClose.Margin = new System.Windows.Forms.Padding(5);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(56, 45);
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 528);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 82);
            this.panel1.TabIndex = 139;
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
            this.label1.Size = new System.Drawing.Size(238, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modulo de Equipos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSeriesEquipo
            // 
            this.txtSeriesEquipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtSeriesEquipo.Location = new System.Drawing.Point(185, 428);
            this.txtSeriesEquipo.Name = "txtSeriesEquipo";
            this.txtSeriesEquipo.Size = new System.Drawing.Size(569, 30);
            this.txtSeriesEquipo.TabIndex = 167;
            // 
            // txtCodigoEquipo
            // 
            this.txtCodigoEquipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoEquipo.Location = new System.Drawing.Point(185, 377);
            this.txtCodigoEquipo.Name = "txtCodigoEquipo";
            this.txtCodigoEquipo.Size = new System.Drawing.Size(569, 30);
            this.txtCodigoEquipo.TabIndex = 166;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 437);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 21);
            this.label12.TabIndex = 165;
            this.label12.Text = "series equipo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 374);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 21);
            this.label11.TabIndex = 164;
            this.label11.Text = "codigo equipo";
            // 
            // txtDescripcionEquipo
            // 
            this.txtDescripcionEquipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionEquipo.Location = new System.Drawing.Point(185, 106);
            this.txtDescripcionEquipo.Multiline = true;
            this.txtDescripcionEquipo.Name = "txtDescripcionEquipo";
            this.txtDescripcionEquipo.Size = new System.Drawing.Size(569, 120);
            this.txtDescripcionEquipo.TabIndex = 163;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 109);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 21);
            this.label10.TabIndex = 162;
            this.label10.Text = "Descripcion equipo";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(646, 486);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 35);
            this.btnCancel.TabIndex = 146;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(522, 486);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 35);
            this.btnUpdate.TabIndex = 145;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(401, 486);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 35);
            this.btnSave.TabIndex = 144;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtIdEquipo
            // 
            this.txtIdEquipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdEquipo.Enabled = false;
            this.txtIdEquipo.Location = new System.Drawing.Point(42, 67);
            this.txtIdEquipo.Name = "txtIdEquipo";
            this.txtIdEquipo.Size = new System.Drawing.Size(114, 30);
            this.txtIdEquipo.TabIndex = 143;
            // 
            // EquipoModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 610);
            this.Controls.Add(this.txtDescripcionFallo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSeriesEquipo);
            this.Controls.Add(this.txtCodigoEquipo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDescripcionEquipo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtIdEquipo);
            this.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EquipoModulo";
            this.Text = "EquipoModulo";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtDescripcionFallo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeriesEquipo;
        private System.Windows.Forms.TextBox txtCodigoEquipo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtDescripcionEquipo;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtIdEquipo;
    }
}