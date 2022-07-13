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
using POSalesDB;
using POSalesDb;
namespace POSales
{
    public partial class UserAccount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        Usuarios usuario = new Usuarios();
        int Id;
        List<Usuarios> usuarios = new List<Usuarios>();
        public UserAccount(int idUser)
        {
           InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadUser();
            Id = idUser;
        }

        public void LoadUser()
        {
            usuario = dbcon.selectUsuariosPorId(Id);
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

            string Error = string.Empty;
            try
            {
                if (txtCurPass.Text != usuario.contraseña)
                {
                    MessageBox.Show("La contraseña actual no conicide!", "Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNPass.Text != txtRePass2.Text)
                {
                    MessageBox.Show("Confirma la nueva contraseña no coincide!", "Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                usuario.contraseña = txtNPass.Text;
                dbcon.actualizarUsuario(usuario);
                if (string.IsNullOrEmpty(Error))
                {
                    MessageBox.Show("Contraseña cambiada con exito!", "Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Error, "Error");
                }
              
            }
            catch (Exception ex)
            {
                
            }
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            lblUsername.Text = usuario.username;
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
            usuario.username = dgvUser[1, i].Value.ToString();
            usuario.nombre = dgvUser[2, i].Value.ToString();
            usuario.role = dgvUser[4, i].Value.ToString();
            if (bool.TryParse(dgvUser[3, i].Value.ToString(), out bool parse))
            {
                usuario.isactive = parse;
            }

            if (lblUsername.Text == usuario.username)
            {
                btnRemove.Enabled = false;
                btnResetPass.Enabled = false;
                lblAccNote.Text = "Para cambiar su contraseña, vaya a cambiar etiqueta de contraseña.";

            }
            else
            {
                btnRemove.Enabled = true;
                btnResetPass.Enabled = true;
                lblAccNote.Text = "Para cambiar la contraseña de " + usuario.username + ", click Resetear Contraseña.";
            }
            gbUser.Text = "Password For " + usuario.username;
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Eligió eliminar esta cuenta de la lista de usuarios de este sistema de punto de venta. \n\n ¿Está seguro de que desea eliminar? '" + usuario.username + "' \\ '" + usuario.role + "'", "User Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                dbcon.ExecuteQuery("DELETE FROM Usuarios WHERE username = '" + usuario.username + "'");
                MessageBox.Show("Cuenta eliminada con exito ");
                LoadUser();
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            ResetPassword reset = new ResetPassword(usuario);
            reset.ShowDialog();
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {

            UserProperties properties = new UserProperties(usuario);
            properties.ShowDialog();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
