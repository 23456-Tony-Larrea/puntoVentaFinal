using System;
using System.Collections.Generic;
using System.Windows.Forms;
using POSalesDb;

namespace POSales.Mantenimientos
{
    public partial class ReservasModulo : Form
    {
        int idMantenimiento;
        List<Items> ItemsPorfactura = new List<Items>();
        public List<POSalesDb.Reserva> ItemsFacturados = new List<POSalesDb.Reserva>();
        Usuarios usuario = new Usuarios();
        Items Itemseleccionado = new Items();
        DBConnect dbcon = new DBConnect();
        decimal Subtotal = 0, iva = 0, TotalFactura = 0;
        public ReservasModulo(int idMantenimiento)
        {
            this.idMantenimiento = idMantenimiento;
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnBuscarItem_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            LookUpProduct supplier = new LookUpProduct("");
            supplier.ShowDialog();
            Itemseleccionado = supplier.item;
            txtCodBarrasItem.Text = Itemseleccionado.codigoBarras;
            txtDescripcionItem.Text = Itemseleccionado.nombre;
            txtStock.Text = Itemseleccionado.stock.ToString();
            txtPrecio.Text = Itemseleccionado.precioA.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ggvProductos.SelectedRows.Count > (-1))
            {
                foreach (DataGridViewRow r in ggvProductos.SelectedRows)
                {
                    decimal subTotalItem, totalItem, totalIvaItem;
                    decimal.TryParse(r.Cells["subtotalPorItem"].Value.ToString(), out subTotalItem);
                    decimal ivaItem = 0;
                    decimal.TryParse(r.Cells["ivaPorItem"].Value.ToString(), out totalIvaItem);
                    decimal.TryParse(r.Cells["total"].Value.ToString(), out totalItem);
                    Subtotal -= subTotalItem;
                    TotalFactura -= totalItem;
                    iva -= totalIvaItem;
                    ggvProductos.Rows.Remove(r);
                }
            }



            txtSubtotal.Text = Subtotal.ToString();
            txtTotal.Text = TotalFactura.ToString();
            txtIva.Text = iva.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agregado Satisfactoriamente");
            this.Close();
        }

        private void ReservasModulo_Load(object sender, EventArgs e)
        {
            decimal ivaItem = 0;
            decimal resultado = 0;
            ItemsFacturados = dbcon.selectReservaPorMantenimiento(idMantenimiento);
            foreach (var items in ItemsFacturados)
            {
                if (items.items.HasIva)
                {
                    ivaItem = resultado * Itemseleccionado.iva / 100;
                    txtIvaItem.Text = ivaItem.ToString();

                }
                resultado += ivaItem;
                txtTotalItem.Text = resultado.ToString();
                Subtotal += items.precioUnitario;
                TotalFactura += items.precioFinal;
                iva += ivaItem;
                ggvProductos.Rows.Add(items.items.Id, items.items.codigoBarras, items.items.nombre, items.precioUnitario, items.Cantidad, items.items.iva.ToString(), ivaItem.ToString(), items.precioFinal);
                txtSubtotal.Text = Subtotal.ToString();
                txtTotal.Text = TotalFactura.ToString();
                txtIva.Text = iva.ToString();
            }

        }

        private void txtCant_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCant.Text))
            {
                if (!string.IsNullOrEmpty(txtPrecio.Text))
                {
                    int cantidad = 0;
                    int.TryParse(txtCant.Text, out cantidad);
                    decimal Precio = 0, Subtotal = 0, ivaItem = 0;
                    decimal.TryParse(txtPrecio.Text, out Precio);
                    decimal resultado = Precio * cantidad;
                    txtSubTotalItem.Text = resultado.ToString();
                    if (Itemseleccionado.HasIva)
                    {
                        ivaItem = resultado * Itemseleccionado.iva / 100;
                        txtIvaItem.Text = ivaItem.ToString();

                    }
                    resultado += ivaItem;
                    txtTotalItem.Text = resultado.ToString();

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEstadoReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======
            
>>>>>>> f07e5244f654379719e702c90e042dd95843d12e
        }

        private void LimpiarCampos()
        {
            txtCant.Clear();
            txtPrecio.Clear();
            txtIvaItem.Clear();
            txtStock.Clear();
            txtSubtotal.Clear();
            txtSubTotalItem.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Itemseleccionado.Id == 0)
            {
                MessageBox.Show("Debe ingresar un producto");
                return;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text) || txtPrecio.Text == "0")
            {
                MessageBox.Show("Debe ingresar un precio");
                return;
            }
            if (string.IsNullOrEmpty(txtCant.Text) || txtCant.Text == "0")
            {
                MessageBox.Show("Debe ingresar una cantidad del producvto");
                return;
            }
            foreach (DataGridViewRow r in ggvProductos.Rows)
            {
                if (r.Cells["No"].ToString() == Itemseleccionado.codigoBarras)
                {
                    MessageBox.Show("Articulo ya ingresado!!");
                    return;
                }
            }
            decimal subTotalItem, totalItem, totalIvaItem;
            decimal.TryParse(txtSubTotalItem.Text, out subTotalItem);
            decimal.TryParse(txtIvaItem.Text, out totalIvaItem);
            decimal.TryParse(txtTotalItem.Text, out totalItem);
            Subtotal += subTotalItem;
            TotalFactura += totalItem;
            iva += totalIvaItem;
            ggvProductos.Rows.Add(Itemseleccionado.Id, Itemseleccionado.codigoBarras, Itemseleccionado.nombre, txtPrecio.Text, txtCant.Text, totalIvaItem.ToString(), subTotalItem.ToString(), txtTotalItem.Text);
            POSalesDb.Reserva ItemsFacturado = new POSalesDb.Reserva();
            ItemsFacturado.items = Itemseleccionado;
            ItemsFacturado.precioFinal = totalItem;
            ItemsFacturado.Cantidad = Convert.ToInt32(txtCant.Text);
            ItemsFacturados.Add(ItemsFacturado);
            txtSubtotal.Text = Subtotal.ToString();
            txtTotal.Text = TotalFactura.ToString();
            txtIva.Text = iva.ToString();
            LimpiarCampos();
        }
    }
}
