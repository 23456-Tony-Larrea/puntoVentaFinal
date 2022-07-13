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
    public partial class UserProperties : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();

        Usuarios account;
        public string username;
        public UserProperties(Usuarios user)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            account = user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

  
        private void btnApply_Click(object sender, EventArgs e)
        {
            string Error = string.Empty;

                if ((MessageBox.Show("Está seguro de que desea cambiar las propiedades de esta cuenta?", "Cambiar propiedades", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                 {
                    cn.Open();
                    cm = new SqlCommand("UPDATE Usuarios SET nombre=@nombre, role=@role, isactive=@isactive WHERE username='" + username + "'",cn);
                    account.nombre= txtName.Text;
                    account.role = cbRole.Text;
                    if (cbActivate.SelectedIndex == 0)
                    {
                        account.isactive = true;
                    }
                    else
                    {
                        account.isactive = false;
                    }


                    Error = dbcon.actualizarUsuario(account);
                    if (string.IsNullOrEmpty(Error))
                    {
                        MessageBox.Show("Actualizado satisfactoriamente");
                    }
                    else 
                    {
                        MessageBox.Show(Error);
                    }
                    this.Dispose();;
                }
        }

        private void UserProperties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void UserProperties_Load(object sender, EventArgs e)
        {

        }
    }
}
