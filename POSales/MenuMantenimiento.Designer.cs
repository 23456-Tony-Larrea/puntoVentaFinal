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
            this.btnOrdenProductos = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnMatenimientos = new System.Windows.Forms.Button();
            this.btnMantenimiento = new System.Windows.Forms.Button();
            this.panelSubMantenimiento = new System.Windows.Forms.Panel();
            this.btnAccesorios = new System.Windows.Forms.Button();
            this.btnEquipo = new System.Windows.Forms.Button();
            this.btnReservas = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.panelSubReserva = new System.Windows.Forms.Panel();
            this.btnReserva = new System.Windows.Forms.Button();
            this.panelSlide = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogo.SuspendLayout();
            this.panelSubMantenimiento.SuspendLayout();
            this.panelSubReserva.SuspendLayout();
            this.panelSlide.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(241, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1043, 786);
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
            this.lblName.Size = new System.Drawing.Size(25, 20);
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
            this.lblUsername.Size = new System.Drawing.Size(63, 20);
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
            this.lblRole.Size = new System.Drawing.Size(66, 20);
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
            // btnOrdenProductos
            // 
            this.btnOrdenProductos.BackColor = System.Drawing.Color.Blue;
            this.btnOrdenProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrdenProductos.FlatAppearance.BorderSize = 0;
            this.btnOrdenProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenProductos.ForeColor = System.Drawing.Color.White;
            this.btnOrdenProductos.Location = new System.Drawing.Point(0, 282);
            this.btnOrdenProductos.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrdenProductos.Name = "btnOrdenProductos";
            this.btnOrdenProductos.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.btnOrdenProductos.Size = new System.Drawing.Size(241, 59);
            this.btnOrdenProductos.TabIndex = 2;
            this.btnOrdenProductos.Text = "Orden Servicio";
            this.btnOrdenProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrdenProductos.UseVisualStyleBackColor = false;
            this.btnOrdenProductos.Click += new System.EventHandler(this.btnOrdenProductos_Click);
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
            this.btnMatenimientos.Location = new System.Drawing.Point(0, 341);
            this.btnMatenimientos.Margin = new System.Windows.Forms.Padding(4);
            this.btnMatenimientos.Name = "btnMatenimientos";
            this.btnMatenimientos.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.btnMatenimientos.Size = new System.Drawing.Size(241, 59);
            this.btnMatenimientos.TabIndex = 3;
            this.btnMatenimientos.Text = "Mantenimientos";
            this.btnMatenimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMatenimientos.UseVisualStyleBackColor = false;
            // 
            // btnMantenimiento
            // 
            this.btnMantenimiento.FlatAppearance.BorderSize = 0;
            this.btnMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimiento.ForeColor = System.Drawing.Color.White;
            this.btnMantenimiento.Location = new System.Drawing.Point(0, 0);
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
            // panelSubMantenimiento
            // 
            this.panelSubMantenimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(200)))));
            this.panelSubMantenimiento.Controls.Add(this.btnAccesorios);
            this.panelSubMantenimiento.Controls.Add(this.btnEquipo);
            this.panelSubMantenimiento.Controls.Add(this.btnMantenimiento);
            this.panelSubMantenimiento.Location = new System.Drawing.Point(0, 399);
            this.panelSubMantenimiento.Margin = new System.Windows.Forms.Padding(4);
            this.panelSubMantenimiento.Name = "panelSubMantenimiento";
            this.panelSubMantenimiento.Size = new System.Drawing.Size(241, 209);
            this.panelSubMantenimiento.TabIndex = 0;
            // 
            // btnAccesorios
            // 
            this.btnAccesorios.FlatAppearance.BorderSize = 0;
            this.btnAccesorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccesorios.ForeColor = System.Drawing.Color.White;
            this.btnAccesorios.Location = new System.Drawing.Point(0, 111);
            this.btnAccesorios.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccesorios.Name = "btnAccesorios";
            this.btnAccesorios.Padding = new System.Windows.Forms.Padding(48, 0, 0, 0);
            this.btnAccesorios.Size = new System.Drawing.Size(241, 59);
            this.btnAccesorios.TabIndex = 7;
            this.btnAccesorios.Text = "Accesorios";
            this.btnAccesorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccesorios.UseVisualStyleBackColor = true;
            this.btnAccesorios.Click += new System.EventHandler(this.btnAccesorios_Click);
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
            // btnReservas
            // 
            this.btnReservas.BackColor = System.Drawing.Color.Blue;
            this.btnReservas.FlatAppearance.BorderSize = 0;
            this.btnReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservas.ForeColor = System.Drawing.Color.White;
            this.btnReservas.Location = new System.Drawing.Point(0, 603);
            this.btnReservas.Margin = new System.Windows.Forms.Padding(4);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.btnReservas.Size = new System.Drawing.Size(241, 68);
            this.btnReservas.TabIndex = 7;
            this.btnReservas.Text = "Reservas";
            this.btnReservas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservas.UseVisualStyleBackColor = false;
            // 
            // btnItems
            // 
            this.btnItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(200)))));
            this.btnItems.FlatAppearance.BorderSize = 0;
            this.btnItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItems.ForeColor = System.Drawing.Color.White;
            this.btnItems.Location = new System.Drawing.Point(0, 62);
            this.btnItems.Margin = new System.Windows.Forms.Padding(4);
            this.btnItems.Name = "btnItems";
            this.btnItems.Padding = new System.Windows.Forms.Padding(48, 0, 0, 0);
            this.btnItems.Size = new System.Drawing.Size(241, 59);
            this.btnItems.TabIndex = 4;
            this.btnItems.Text = "Items";
            this.btnItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItems.UseVisualStyleBackColor = false;
            // 
            // panelSubReserva
            // 
            this.panelSubReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(200)))));
            this.panelSubReserva.Controls.Add(this.btnReserva);
            this.panelSubReserva.Controls.Add(this.btnItems);
            this.panelSubReserva.Location = new System.Drawing.Point(0, 666);
            this.panelSubReserva.Margin = new System.Windows.Forms.Padding(4);
            this.panelSubReserva.Name = "panelSubReserva";
            this.panelSubReserva.Size = new System.Drawing.Size(241, 125);
            this.panelSubReserva.TabIndex = 8;
            // 
            // btnReserva
            // 
            this.btnReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(200)))));
            this.btnReserva.FlatAppearance.BorderSize = 0;
            this.btnReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserva.ForeColor = System.Drawing.Color.White;
            this.btnReserva.Location = new System.Drawing.Point(0, 0);
            this.btnReserva.Margin = new System.Windows.Forms.Padding(4);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Padding = new System.Windows.Forms.Padding(48, 0, 0, 0);
            this.btnReserva.Size = new System.Drawing.Size(241, 59);
            this.btnReserva.TabIndex = 5;
            this.btnReserva.Text = "Reserva";
            this.btnReserva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReserva.UseVisualStyleBackColor = false;
            // 
            // panelSlide
            // 
            this.panelSlide.AllowDrop = true;
            this.panelSlide.AutoScroll = true;
            this.panelSlide.Controls.Add(this.btnSalir);
            this.panelSlide.Controls.Add(this.panelSubReserva);
            this.panelSlide.Controls.Add(this.btnReservas);
            this.panelSlide.Controls.Add(this.panelSubMantenimiento);
            this.panelSlide.Controls.Add(this.btnMatenimientos);
            this.panelSlide.Controls.Add(this.btnOrdenProductos);
            this.panelSlide.Controls.Add(this.btnDashboard);
            this.panelSlide.Controls.Add(this.panelLogo);
            this.panelSlide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlide.Location = new System.Drawing.Point(0, 0);
            this.panelSlide.Margin = new System.Windows.Forms.Padding(4);
            this.panelSlide.Name = "panelSlide";
            this.panelSlide.Size = new System.Drawing.Size(241, 786);
            this.panelSlide.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Blue;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(0, 785);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(241, 61);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // MenuMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 786);
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
            this.panelSubMantenimiento.ResumeLayout(false);
            this.panelSubReserva.ResumeLayout(false);
            this.panelSlide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOrdenProductos;
        public System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnMatenimientos;
        private System.Windows.Forms.Button btnMantenimiento;
        private System.Windows.Forms.Panel panelSubMantenimiento;
        private System.Windows.Forms.Button btnReservas;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Panel panelSubReserva;
        private System.Windows.Forms.Panel panelSlide;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAccesorios;
        private System.Windows.Forms.Button btnEquipo;
        private System.Windows.Forms.Button btnReserva;
    }
}