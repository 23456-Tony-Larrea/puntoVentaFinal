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
    public partial class UserAccount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        MainForm main;
        public string username;
        string name;
        string role;
        string accstatus;
        Usuarios usuario = new Usuarios();
        List<Usuarios> usuarios = new List<Usuarios>();
        public UserAccount(MainForm mn)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            main = mn;
            LoadUser();
        }

        public void LoadUser()
        {
            usuarios = dbcon.selectTodosLosUsuarios();
            dgvUser.DataSource = usuarios;
        }

        public void Clear()
        {
            txtName.Clear();
            txtPass.Clear();
            txtRePass.Clear();
            txtUsername.Clear();
            cbRole.Text = "";
            txtUsername.Focus();
        }

        private void btnAccSave_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != txtRePass.Text)
            {
                MessageBox.Show("No conciden las contraseñas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          
            usuario.username = txtUsername.Text;
            usuario.contraseña = txtPass.Text;
            usuario.role = cbRole.Text;
            usuario.nombre = txtName.Text;
            string Error = string.Empty;
            
            Error = dbcon.insertUsuarios(usuario);

            if (string.IsNullOrEmpty(Error))
            {
                MessageBox.Show("Agregado satisfactoriamente");

            }
            else
            {
                MessageBox.Show(Error, "Warning");
            }
           

        }

        private void btnAccCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnPassSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCurPass.Text != main._pass )
                {
                    MessageBox.Show("La contraseña actual no conicide!", "Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(txtNPass.Text != txtRePass2.Text)
                {
                    MessageBox.Show("Confirma la nueva contraseña no coincide!", "Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dbcon.ExecuteQuery("UPDATE Usuarios SET  contraseña = '" + txtNPass.Text + "' WHERE username='" + lblUsername.Text + "'");
                MessageBox.Show("Contraseña cambiada con exito!", "Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            lblUsername.Text = main.lblUsername.Text;
        }

        private void btnPassCancel_Click(object sender, EventArgs e)
        {
            ClearCP();
        }

        public void ClearCP()
        {
            txtCurPass.Clear();
            txtNPass.Clear();
            txtRePass2.Clear();
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            int i = dgvUser.CurrentRow.Index;
            username = dgvUser[1, i].Value.ToString();
            name = dgvUser[2, i].Value.ToString(); 
            role = dgvUser[4, i].Value.ToString();
            accstatus = dgvUser[3, i].Value.ToString();
            if (lblUsername.Text == username)
            {
                btnRemove.Enabled = false;
                btnResetPass.Enabled = false;
                lblAccNote.Text = "Para cambiar su contraseña, vaya a cambiar etiqueta de contraseña.";

            }
            else
            {
                btnRemove.Enabled = true;
                btnResetPass.Enabled = true;
                lblAccNote.Text = "Para cambiar la contraseña de " + username + ", click Resetear Contraseña.";
            }
            gbUser.Text = "Password For " + username;
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Eligió eliminar esta cuenta de la lista de usuarios de este sistema de punto de venta. \n\n ¿Está seguro de que desea eliminar? '" + username + "' \\ '" + role + "'", "User Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                dbcon.ExecuteQuery("DELETE FROM Usuarios WHERE username = '" + username + "'");
                MessageBox.Show("Cuenta eliminada con exito ");
                LoadUser();
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            ResetPassword reset = new ResetPassword(this);
            reset.ShowDialog();
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            UserProperties properties = new UserProperties(this);
            properties.Text = name +"\\"+ username +" Properties";
            properties.txtName.Text = name;
            properties.cbRole.Text = role;
            properties.cbActivate.Text = accstatus;
            properties.username = username;
            properties.ShowDialog();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
