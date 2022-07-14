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
    public partial class ClientModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string stitle = "Punto de venta";
        Clientes cliente;
        bool Nuevo = false;
        public ClientModule(Clientes cl)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cliente = cl;
            cargarClientes();
            
        }
        private void cargarClientes()
        {
            if (cliente.Id > 0)
            {
                btnSave.Visible = false;
                txtId.Text = cliente.Id.ToString();
                txtName.Text = cliente.nombre.ToString();
                txtComercio.Text = cliente.comercio.ToString();
                txtCodigo.Text = cliente.codigo.ToString();
                dateNacimiento.Value = cliente.fechaNacimiento.Date;
                dateRegisstro.Value = cliente.fechaRegistro.Date;
                txtCiudad.Text = cliente.ciudad.ToString();
                cboTipo.SelectedValue = cliente.codigo.ToString();
                txtCiRuc.Text = cliente.ciRuc.ToString();
                txtPais.Text = cliente.pais.ToString();
                cboEstado.SelectedValue = cliente.estado.ToString();
                txtDireccion.Text = cliente.direccion.ToString();
                txtTelf.Text = cliente.telefono.ToString();
                txtCelular.Text = cliente.celular.ToString();
                txtFax.Text = cliente.fax.ToString();
                txtCargo.Text = cliente.cargo.ToString();
                txtEmail.Text = cliente.email.ToString();
                cboTipoCliente.SelectedValue = cliente.tipo.ToString();
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
            int NoSelect = -1;

            if (cboTipoCliente.SelectedIndex == NoSelect)
            {
                MessageBox.Show("Por favor,seleccione un tipo de cliente");
                return;
            }
            try
            {
                if (MessageBox.Show("Estas seguro de guardar este ecliente?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Clientes cliente = new Clientes();    
                    
                    cliente.nombre= txtName.Text;
                    cliente.comercio= txtComercio.Text;
                    cliente.codigo= txtCodigo.Text;
                    cliente.fechaNacimiento= dateNacimiento.Value;
                    cliente.fechaRegistro= dateRegisstro.Value;
                    cliente.ciudad= txtCiudad.Text;
                    cliente.tipo= cboTipo.Text;
                    cliente.ciRuc= txtCiRuc.Text;
                    cliente.pais= txtPais.Text;
                    cliente.estado= cboEstado.SelectedItem.ToString();
                    cliente.direccion= txtDireccion.Text;
                    cliente.telefono= txtTelf.Text;
                    cliente.celular= txtCelular.Text;
                    cliente.fax= txtFax.Text;
                    cliente.cargo= txtCargo.Text;
                    cliente.email= txtEmail.Text;
                    cliente.tipoCliente=cboTipoCliente.Text;
                    string error= string.Empty;
                 error=dbcon.insertClientes(cliente);
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Existosamente guardado.", "POS");

                    }
                    else
                    {
                        MessageBox.Show(error);
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
            Clientes cliente = new Clientes();

            try
            {
                if (MessageBox.Show("Estas seguro de actualizar este cliente?", "Actualizar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cliente.nombre = txtName.Text;
                    cliente.comercio = txtComercio.Text;
                    cliente.codigo = txtCodigo.Text;
                    cliente.fechaNacimiento = dateNacimiento.Value;
                    cliente.fechaRegistro = dateRegisstro.Value;
                    cliente.ciudad = txtCiudad.Text;
                    cliente.tipo = cboTipo.Text;
                    cliente.ciRuc = txtCiRuc.Text;
                    cliente.pais = txtPais.Text;
                    cliente.estado = cboEstado.SelectedItem.ToString();
                    cliente.direccion = txtDireccion.Text;
                    cliente.telefono = txtTelf.Text;
                    cliente.celular = txtCelular.Text;
                    cliente.fax = txtFax.Text;
                    cliente.cargo = txtCargo.Text;
                    cliente.email = txtEmail.Text;
                    cliente.tipoCliente = cboTipoCliente.Text;
                    string error = string.Empty;
                    error = dbcon.actualizarClientes(cliente);
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Actualizado con exito.", stitle);
                        this.Dispose();

                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
