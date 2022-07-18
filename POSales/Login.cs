using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSalesDb;
using POSalesDb;

namespace POSales
{
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            txtName.Focus();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salir Aplicacion?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string _role = string.Empty;
            Usuarios usuario = new Usuarios();
            usuario = dbcon.loginAction(txtName.Text, txtPass.Text);
            if (usuario.Id > 0)
            {

                if (!usuario.isactive)
                {
                    MessageBox.Show("La cuenta está desactivada.Incapaz de iniciar sesión", "Cuenta inactiva", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (usuario.role == "cashier")
                {
                    MessageBox.Show("Bienvenido " + usuario.nombre + " |", "ACCESSO CONCEBIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtPass.Clear();
                    this.Hide();
                    
                    Cashier cashier = new Cashier();
                    cashier.lblUsername.Text = usuario.nombre;
                    cashier.lblname.Text = usuario.nombre + " | " + _role;
                    cashier.ShowDialog();
                }

                if (usuario.role == "Administrador")
                {
                    MessageBox.Show("BIENVENIDO " + usuario.nombre + " |", "ACCESSO CONCEBIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtPass.Clear();
                    this.Hide();
                    MainForm main = new MainForm();
                    main.lblUsername.Text = usuario.username;
                    main.lblName.Text = usuario.nombre;
                    main.ShowDialog();
                }
                if (usuario.role == "facturero")
                {
                    MessageBox.Show("Bienvenido " + usuario.nombre + " |", "ACCESSO CONCEBIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtPass.Clear();
                    this.Hide();
                    MenuPrincipalFactura menuPrincipalFactura = new MenuPrincipalFactura(usuario.Id);
                    menuPrincipalFactura.ShowDialog();

                }

            }
            else
            {
                MessageBox.Show("nombre de usuario y contraseña inválidos!", "ACCESS DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salir aplicacion?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.PerformClick();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
