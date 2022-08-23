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
namespace POSales
{
    public partial class ClientModule : Form
    {
            Clientes clientes = new Clientes();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string stitle = "Punto de venta";
        public ClientModule(Clientes cliente)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            this.clientes = cliente;
              
        }
        private void EsNuevoIngreso()
        {
            if (clientes.Id > 0)
            {
                btnSave.Visible = false;
            }
            else
            {
                btnUpdate.Visible = false;
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro de guardar este cliente?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    clientes.nombre= txtName.Text;
                    clientes.comercio = txtComercio.Text;
                    clientes.codigo = txtCodigo.Text;
                    clientes.fechaNacimiento = dateNacimiento.Value;
                    clientes.fechaRegistro = dateRegisstro.Value;
                    clientes.ciudad = txtCiudad.Text;
                    clientes.tipo = cboTipo.SelectedItem.ToString();
                    clientes.ciRuc = txtCiRuc.Text;
                    clientes.pais = txtPais.Text;
                    clientes.estado = cboEstado.SelectedItem.ToString();
                    clientes.direccion = txtDireccion.Text;
                    clientes.telefono = txtTelf.Text;
                    clientes.celular = txtCelular.Text;
                    clientes.fax = txtFax.Text;
                    clientes.cargo = txtCargo.Text;
                    clientes.email = txtEmail.Text;
                    clientes.tipoCliente = cboTipoCliente.SelectedItem.ToString();
                    string Error = dbcon.insertClientes(clientes);
                    if (string.IsNullOrEmpty(Error))
                    {
                        MessageBox.Show("Existosamente guardado.", "POS");
                    }
                    Clear();
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }
        public void Clear()
        {
            txtName.Clear();
            txtComercio.Clear();
            txtCodigo.Clear();
            txtCiudad.Clear();
            txtCiRuc.Clear();
            txtPais.Clear();
            txtDireccion.Clear();
            txtTelf.Clear();
            txtCelular.Clear();
            txtFax.Clear();
            txtCargo.Clear();
            txtEmail.Clear();  
            txtId.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Update brand name
            if (MessageBox.Show("Estas seguro de actualizar este cliente?", "Actualizado con exito!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cm = new SqlCommand("UPDATE Clientes SET nombre=@nombre,comercio=@comercio,codigo=@codigo,fechaNacimiento=@fechaNacimiento,fechaRegistro=@fechaRegistro,ciudad=@ciudad,tip=@tipo,ciRuc=@ciRuc,pais=@pais,estado=@estado,direccion=@direccion,celular=@celular,fax=@fax,cargo=cargo,emaiñ=@email,tipoCliente=@tipoCliente  WHERE id LIKE'" + txtId.Text + "'", cn);
                cm.Parameters.AddWithValue("@nombre", txtName.Text);
                cm.Parameters.AddWithValue("@comercio", txtComercio.Text);
                cm.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                cm.Parameters.AddWithValue("@fechaNacimiento", dateNacimiento.Value.ToString("dd/MM/yyy"));
                cm.Parameters.AddWithValue("@fechaRegistro", dateRegisstro.Value.ToString("dd/MM/yyy"));
                cm.Parameters.AddWithValue("@ciudad", txtCiudad.Text);
                cm.Parameters.AddWithValue("@tipo", cboTipo.SelectedItem.ToString());
                cm.Parameters.AddWithValue("@ciRuc", txtCiRuc.Text);
                cm.Parameters.AddWithValue("@pais", txtPais.Text);
                cm.Parameters.AddWithValue("@estado", cboEstado.SelectedItem.ToString());
                cm.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                cm.Parameters.AddWithValue("@telefono", txtTelf.Text);
                cm.Parameters.AddWithValue("@celular", txtCelular.Text);
                cm.Parameters.AddWithValue("@fax", txtFax.Text);
                cm.Parameters.AddWithValue("@cargo", txtCargo.Text);
                cm.Parameters.AddWithValue("@email", txtEmail.Text);
                cm.Parameters.AddWithValue("@tipoCliente", cboTipoCliente.SelectedValue);

                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Existosamente guardado.", "POS");
                Clear(); cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Cliente actualizado correctamente.", "POS");
                Clear();
            }
        }

   

        }
    }
