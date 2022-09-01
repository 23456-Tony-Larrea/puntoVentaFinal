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
            ocultarActualizar();
           
        }
        
        private void cargarCliente()
        {
            
            txtName.Text = clientes.nombre;
            txtComercio.Text =clientes.comercio ;
            txtCodigo.Text= clientes.codigo;
            dateNacimiento.Value= clientes.fechaNacimiento;
            dateRegisstro.Value= clientes.fechaRegistro  ;
             txtCiudad.Text=clientes.ciudad ;
             cboTipo.Text= clientes.tipo;
            txtCiRuc.Text= clientes.ciRuc ;
            txtPais.Text=clientes.pais ;
            cboEstado.Text=clientes.estado ;
            txtDireccion.Text= clientes.direccion ;
            txtTelf.Text= clientes.telefono ;
            txtCelular.Text= clientes.celular ;
            txtFax.Text=clientes.fax ;
            txtCargo.Text= clientes.cargo ;
            txtEmail.Text=clientes.email  ;
            cboTipoCliente.Text=clientes.tipoCliente;
        }

        private void ocultarActualizar()
        {
             if (clientes.Id > 0)
            {
                btnSave.Visible = false;
                cargarCliente();
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
            try
            {


                if (MessageBox.Show("Estas seguro de actualizar este cliente?", "Actualizado con exito!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clientes.nombre = txtName.Text ;
                    clientes.comercio= txtComercio.Text ;
                    clientes.codigo= txtCodigo.Text ;
                    clientes.fechaNacimiento= dateNacimiento.Value ;
                    clientes.fechaRegistro = dateRegisstro.Value ;
                    clientes.ciudad = txtCiudad.Text ;
                     clientes.tipo= cboTipo.Text ;
                     clientes.ciRuc= txtCiRuc.Text ;
                    clientes.pais= txtPais.Text ;
                     clientes.estado= cboEstado.Text;
                    clientes.direccion= txtDireccion.Text ;
                    clientes.telefono=txtTelf.Text ;
                    clientes.celular= txtCelular.Text ;
                    clientes.fax= txtFax.Text ;
                    clientes.cargo= txtCargo.Text ;
                    clientes.email=txtEmail.Text ;
                    clientes.tipoCliente= cboTipoCliente.Text ;
                    dbcon.actualizarClientes(clientes);
                    MessageBox.Show("Cliente actualizado correctamente.", "POS");
                }
                Clear();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
  
        private void txtComercio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("por favor solo ingresa solo letras");
            }

           
        }

        private void txtCiRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("por favor solo ingresa solo numeros");
            }

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }

        }

    }
    }
