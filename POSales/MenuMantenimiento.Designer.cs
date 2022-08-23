namespace POSales
{
    partial class MenuMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuMantenimiento));
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnMatenimientos = new System.Windows.Forms.Button();
            this.panelSlide = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelSubMantenimiento = new System.Windows.Forms.Panel();
            this.btnEquipo = new System.Windows.Forms.Button();
            this.btnMantenimiento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogo.SuspendLayout();
            this.panelSlide.SuspendLayout();
            this.panelSubMantenimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(241, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1165, 512);
            this.panelMain.TabIndex = 5;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(7, 127);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ln";
            this.lblName.Visible = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(72, 151);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(72, 21);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Usuario";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(68, 197);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(80, 21);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Tecnico";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(76, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Blue;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 223);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(241, 59);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Blue;
            this.panelLogo.Controls.Add(this.lblName);
            this.panelLogo.Controls.Add(this.lblUsername);
            this.panelLogo.Controls.Add(this.lblRole);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(241, 223);
            this.panelLogo.TabIndex = 1;
            // 
            // btnMatenimientos
            // 
            this.btnMatenimientos.BackColor = System.Drawing.Color.Blue;
            this.btnMatenimientos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMatenimientos.FlatAppearance.BorderSize = 0;
            this.btnMatenimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatenimientos.ForeColor = System.Drawing.Color.White;
            this.btnMatenimientos.Location = new System.Drawing.Point(0, 282);
            this.btnMatenimientos.Margin = new System.Windows.Forms.Padding(4);
            this.btnMatenimientos.Name = "btnMatenimientos";
            this.btnMatenimientos.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.btnMatenimientos.Size = new System.Drawing.Size(241, 59);
            this.btnMatenimientos.TabIndex = 2;
            this.btnMatenimientos.Text = "Mantenimientos";
            this.btnMatenimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMatenimientos.UseVisualStyleBackColor = false;
            // 
            // panelSlide
            // 
            this.panelSlide.AllowDrop = true;
            this.panelSlide.AutoScroll = true;
            this.panelSlide.Controls.Add(this.btnSalir);
            this.panelSlide.Controls.Add(this.panelSubMantenimiento);
            this.panelSlide.Controls.Add(this.btnMatenimientos);
            this.panelSlide.Controls.Add(this.btnDashboard);
            this.panelSlide.Controls.Add(this.panelLogo);
            this.panelSlide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlide.Location = new System.Drawing.Point(0, 0);
            this.panelSlide.Margin = new System.Windows.Forms.Padding(4);
            this.panelSlide.Name = "panelSlide";
            this.panelSlide.Size = new System.Drawing.Size(241, 512);
            this.panelSlide.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Blue;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(0, 449);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(241, 61);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panelSubMantenimiento
            // 
            this.panelSubMantenimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(200)))));
            this.panelSubMantenimiento.Controls.Add(this.btnEquipo);
            this.panelSubMantenimiento.Controls.Add(this.btnMantenimiento);
            this.panelSubMantenimiento.Location = new System.Drawing.Point(0, 336);
            this.panelSubMantenimiento.Margin = new System.Windows.Forms.Padding(4);
            this.panelSubMantenimiento.Name = "panelSubMantenimiento";
            this.panelSubMantenimiento.Size = new System.Drawing.Size(241, 114);
            this.panelSubMantenimiento.TabIndex = 0;
            // 
            // btnEquipo
            // 
            this.btnEquipo.FlatAppearance.BorderSize = 0;
            this.btnEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquipo.ForeColor = System.Drawing.Color.White;
            this.btnEquipo.Location = new System.Drawing.Point(0, 61);
            this.btnEquipo.Margin = new System.Windows.Forms.Padding(4);
            this.btnEquipo.Name = "btnEquipo";
            this.btnEquipo.Padding = new System.Windows.Forms.Padding(48, 0, 0, 0);
            this.btnEquipo.Size = new System.Drawing.Size(241, 59);
            this.btnEquipo.TabIndex = 6;
            this.btnEquipo.Text = "Equipo";
            this.btnEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEquipo.UseVisualStyleBackColor = true;
            this.btnEquipo.Click += new System.EventHandler(this.btnEquipo_Click);
            // 
            // btnMantenimiento
            // 
            this.btnMantenimiento.FlatAppearance.BorderSize = 0;
            this.btnMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimiento.ForeColor = System.Drawing.Color.White;
            this.btnMantenimiento.Location = new System.Drawing.Point(-8, 0);
            this.btnMantenimiento.Margin = new System.Windows.Forms.Padding(4);
            this.btnMantenimiento.Name = "btnMantenimiento";
            this.btnMantenimiento.Padding = new System.Windows.Forms.Padding(48, 0, 0, 0);
            this.btnMantenimiento.Size = new System.Drawing.Size(241, 71);
            this.btnMantenimiento.TabIndex = 4;
            this.btnMantenimiento.Text = "Mantenimiento";
            this.btnMantenimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenimiento.UseVisualStyleBackColor = true;
            this.btnMantenimiento.Click += new System.EventHandler(this.btnMantenimiento_Click);
            // 
            // MenuMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 512);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSlide);
            this.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuMantenimiento";
            this.Text = " ";
            this.Load += new System.EventHandler(this.MenuMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelSlide.ResumeLayout(false);
            this.panelSubMantenimiento.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnMatenimientos;
        private System.Windows.Forms.Panel panelSlide;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelSubMantenimiento;
        private System.Windows.Forms.Button btnEquipo;
        private System.Windows.Forms.Button btnMantenimiento;
    }
}