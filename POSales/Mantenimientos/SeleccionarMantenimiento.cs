using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSalesDb;

namespace POSales.Mantenimientos
{
    public partial class Mantenimientos : Form
    {
        DBConnect dbcon = new DBConnect();
        Usuarios usuario = new Usuarios();
        List<OrdenServicioModel> orden = new List<OrdenServicioModel>();
        MantenimientoModel mantenimiento = new MantenimientoModel();
        public Mantenimientos(int idUsuario)
        {
            this.usuario = dbcon.selectUsuariosPorId(idUsuario);
            InitializeComponent();
            CargarOrdenes();
        }

        private void btnEntregaBuscar_Click(object sender, EventArgs e)
        {
        
        }
        private void cargarDatosMantenimiento(int idOrden)
        {
            dgvClients.Rows.Clear();
            bool NoAprovado = false, Aprovado = false;

            DataTable dt = new DataTable();
            dt = dbcon.selectTodosLosMantenimientoPorOrdenData(idOrden);
            foreach (DataRow r in dt.Rows)
            {
                bool.TryParse(r["estadoNoAplicarCorreccion"].ToString(), out NoAprovado);
                bool.TryParse(r["estadoAplicarCorreccion"].ToString(), out Aprovado);
                dgvClients.Rows.Add(
                    r["id"].ToString(), r["fechaMantenimiento"].ToString(), r["fechaEntregaEquipo"].ToString(),
                    r["descripcionFalla"].ToString(), r["solucion"].ToString(), r["IdEstadoMantenimiento"].ToString(),
                    r["idUsuarios"].ToString(), r["idOrdenServicio"].ToString(), r["idEquipo"].ToString(),
                    r["codigo"].ToString(), r["descirpcionEquipo"].ToString(), r["descripcion"].ToString(), Aprovado,
                    NoAprovado);
            }
        }

        private void CargarOrdenes()
        {
            orden = dbcon.selectTodosLasOrdenServicioModel();
            dgvOrdenes.Rows.Clear()
            ;
            DataSet ordenes = new DataSet();
            ordenes = dbcon.selectTodosLasOrdenesDS();
            if (ordenes.Tables.Count > 0)
            {
                if (ordenes.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ordenes.Tables[0].Rows)
                    {
                        string Estado = string.Empty;
                        if (r["IsReady"].ToString() == "1" || r["IsReady"].ToString() == "true")
                        {
                            Estado = "Facturado";
                        }
                        else
                        {
                            Estado = "No Facturado";
                        }
                        dgvOrdenes.Rows.Add(r["id"].ToString(), r["Fecha Ingreso"].ToString(),
                            r["ciRuc"].ToString(), r["Nombre"].ToString(),
                            r["IsReady"].ToString(), Estado, r["idUsuarios"].ToString(),
                            r["idCliente"].ToString());
                    }

                }
            }
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void SeleccionarMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

            dgvOrdenes.Rows.Clear();
            DataSet ordenes = new DataSet();
            ordenes = dbcon.selectTodosLasOrdenesDS(dateTimePicker4.Value,dateTimePicker3.Value);
            if (ordenes.Tables.Count > 0)
            {
                if (ordenes.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ordenes.Tables[0].Rows)
                    {
                        string Estado = string.Empty;
                        if (r["IsReady"].ToString() == "1" || r["IsReady"].ToString() == "true")
                        {
                            Estado = "Facturado";
                        }
                        else
                        {
                            Estado = "No Facturado";
                        }
                        dgvOrdenes.Rows.Add(r["id"].ToString(), r["Fecha Ingreso"].ToString(),
                            r["ciRuc"].ToString(), r["Nombre"].ToString(),
                            r["IsReady"].ToString(), Estado, r["idUsuarios"].ToString(),
                            r["idCliente"].ToString());
                    }

                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idOrden = 0;
            if(e.RowIndex < 0)
            { 
                return;
            }
            int.TryParse(dgvOrdenes.Rows[e.RowIndex].Cells["idOrden"].Value.ToString(), out idOrden);
            if (idOrden > 0)
            {
                cargarDatosMantenimiento(idOrden);
            }
           
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idmantenimiento = 0;
            int index = e.RowIndex;
            if (index > (-1))
            {
                int.TryParse(dgvClients.Rows[index].Cells["id"].Value.ToString(), out idmantenimiento);
                DataGridViewColumn colum = dgvClients.Columns[e.ColumnIndex];
                if (colum.Name == "solucion" && usuario.role == "tecnico")
                {
                    if (idmantenimiento > 0)
                    {
                        mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                        mantenimiento.equipo = dbcon.selectEquipoPorId(mantenimiento.IdEquipo);
                        POSales.Mantenimientos.precioReferencial MantenimientoView = new POSales.Mantenimientos.precioReferencial(mantenimiento, usuario.Id);
                        MantenimientoView.ShowDialog();
                    }

                }
                if (colum.Name == "aplicarCorreccion")
                {
                    if (usuario.role == "tecnico" && (bool)dgvClients.Rows[index].Cells["aplicarCorreccion"].Value == true)
                    {
                        mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                        mantenimiento.idEstadoMantenimiento = 5;
                        dbcon.actualizarMantenimientoModel(mantenimiento);
                    }
                    else
                    if (idmantenimiento > 0 && usuario.role == "facturero")
                    {
                        dgvClients.Rows[index].Cells["aplicarCorreccion"].Value = true;
                        dgvClients.Rows[index].Cells["NoAplicarCorreccion"].Value = false;
                        mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                        mantenimiento.equipo = dbcon.selectEquipoPorId(mantenimiento.IdEquipo);
                        mantenimiento.estadoAplicarCorreccion = true;
                        mantenimiento.estadoNoAplicarCorreccion = false;
                        mantenimiento.idEstadoMantenimiento = 4;
                        dbcon.actualizarMantenimientoModel(mantenimiento);
                    }

                }
                if (colum.Name == "NoAplicarCorreccion" && usuario.role == "facturero")
                {
                    if (idmantenimiento > 0)
                    {
                        dgvClients.Rows[index].Cells["aplicarCorreccion"].Value = false;
                        dgvClients.Rows[index].Cells["NoAplicarCorreccion"].Value = true;
                        mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                        mantenimiento.equipo = dbcon.selectEquipoPorId(mantenimiento.IdEquipo);
                        mantenimiento.estadoAplicarCorreccion = false;
                        mantenimiento.estadoNoAplicarCorreccion = true;
                        mantenimiento.idEstadoMantenimiento = 5;
                        dbcon.actualizarMantenimientoModel(mantenimiento);
                    }

                }
            }

        }

        private void enviarSolucionPorWhatsappToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            int idmantenimiento = 0;
            int index = dgvClients.CurrentCell.RowIndex;
            if (index > (-1))
            {

                int.TryParse(dgvClients.Rows[index].Cells["id"].Value.ToString(), out idmantenimiento);
                OrdenServicioModel orden = new OrdenServicioModel();
                var mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                mantenimiento.reservas = dbcon.selectReservaPorMantenimiento(idmantenimiento);
                foreach (var reserva in mantenimiento.reservas)
                {
                    total += reserva.precioFinal;
                }
                total += mantenimiento.precioReferencial;
                orden = dbcon.selectOrdenServicioModelPorId(mantenimiento.idOrdenServicio);
                orden.cliente = dbcon.selectClientesId(orden.idCliente);
                decimal TotalPorMantenimiento = 0;
                string Message = $"Saludos, El equipo codigo. {mantenimiento.equipo.codigo} falla:{mantenimiento.descripcionFalla} tiene la solucion: {mantenimiento.solucion} con un costo de mantenimiento de: {total}";
                string Completo = $"https://web.whatsapp.com/send?phone=+59{orden.cliente.celular}&text={Message.Replace(" ", "%20")}";
                ProcessStartInfo SendWhatsapp = new ProcessStartInfo(Completo);
                Process.Start(SendWhatsapp);
                mantenimiento.idEstadoMantenimiento = 3;
                dbcon.actualizarMantenimientoModel(mantenimiento);
            }
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idFactura = 0;
            int index = dgvOrdenes.CurrentCell.RowIndex;
            if (index < 0)
            {
                MessageBox.Show("Selecciona una Orden");
                return;
            }


            OrdenServicioModel ordenSeleccionada = new OrdenServicioModel();
            ordenSeleccionada = orden.ElementAt(index);
            Factura factura = new Factura();
            factura = dbcon.selectFacturaPorOrden(ordenSeleccionada.Id);

            if (factura.id_venta == 0)
            {
                factura.total = Convert.ToDecimal(dgvOrdenes.Rows[index].Cells["Total"].Value.ToString());
                factura.subtotal = factura.total;
                factura.usuario = usuario.Id;
                factura.idORden = ordenSeleccionada.Id;
                factura.clienteId = ordenSeleccionada.idCliente;
                idFactura = dbcon.insertFacturaMantenimiento(factura);
            }

            string Error = string.Empty;
            decimal Total = 0;

            if (idFactura > 0)
            {
                factura.id_venta = idFactura;
                foreach (var mantenimiento in ordenSeleccionada.mantenimientos)
                {
                    DetallesVenta detallesVentaMantenimiento = new DetallesVenta();
                    detallesVentaMantenimiento.IdFactura = idFactura;
                    detallesVentaMantenimiento.IdItem = 1;
                    detallesVentaMantenimiento.montoTotal = mantenimiento.precioReferencial;
                    dbcon.insertDetalleVenta(detallesVentaMantenimiento);
                    foreach (var reserva in mantenimiento.reservas)
                    {
                        DetallesVenta detallesVentaReserva = new DetallesVenta();
                        detallesVentaReserva.IdFactura = idFactura;
                        detallesVentaReserva.IdItem = reserva.idItem;
                        detallesVentaReserva.montoTotal = reserva.precioFinal;
                        detallesVentaReserva.precioVenta = reserva.precioUnitario;
                        detallesVentaReserva.cantidad = reserva.Cantidad;
                        dbcon.insertDetalleVenta(detallesVentaReserva);
                    }
                }

            }
            else
            {
                MessageBox.Show("Error al insertar factura");
                return;
            }

            ReporteFacturaMantenimiento reporte = new ReporteFacturaMantenimiento(factura);
            reporte.Show();
        }

        private void generarReporteDeDañoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generarReporteDeDañoDeOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dgvOrdenes.CurrentCell.RowIndex;
            if (index < 0)
            {
                MessageBox.Show("Selecciona una Orden");
                return;
            }
            OrdenServicioModel ordenSeleccionada = new OrdenServicioModel();
            ordenSeleccionada = orden.ElementAt(index);
            InformeCliente informe = new InformeCliente(ordenSeleccionada.Id);
            informe.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvOrdenes.Rows.Clear();
            DataSet ordenes = new DataSet();
            ordenes = dbcon.selectTodosLasOrdenesDS(textBox1.Text);
            if (ordenes.Tables.Count > 0)
            {
                if (ordenes.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ordenes.Tables[0].Rows)
                    {
                        string Estado = string.Empty;
                        if (r["IsReady"].ToString() == "1" || r["IsReady"].ToString() == "true")
                        {
                            Estado = "Facturado";
                        }
                        else
                        {
                            Estado = "No Facturado";
                        }
                        dgvOrdenes.Rows.Add(r["id"].ToString(), r["Fecha Ingreso"].ToString(),
                            r["ciRuc"].ToString(), r["Nombre"].ToString(),
                            r["IsReady"].ToString(), Estado, r["idUsuarios"].ToString(),
                            r["idCliente"].ToString());
                    }

                }
            }
        }

        private void marcarEquipoEntregadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idmantenimiento = 0;
            int index = dgvClients.CurrentCell.RowIndex;
            if (index > (-1))
            {

                int.TryParse(dgvClients.Rows[index].Cells["id"].Value.ToString(), out idmantenimiento);
                if (usuario.role == "tecnico" && (bool)dgvClients.Rows[index].Cells["aplicarCorreccion"].Value == true && mantenimiento.idEstadoMantenimiento == 4)
                {
                    mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                    mantenimiento.idEstadoMantenimiento = 6;
                    mantenimiento.estadoMantenimiento = dbcon.selectEstadoMantenimientoPorId(mantenimiento.idEstadoMantenimiento);
                    dgvClients.Rows[index].Cells["IdEstadoMantenimiento"].Value = mantenimiento.estadoMantenimiento.Id;
                    dgvClients.Rows[index].Cells["descripcion"].Value = mantenimiento.estadoMantenimiento.descripcion;
                    dbcon.actualizarMantenimientoModel(mantenimiento);
                }
            }
        }

        private void txtBucadorCodigo_TextChanged(object sender, EventArgs e)
        {
            dgvClients.Rows.Clear();
            bool NoAprovado = false, Aprovado = false;

            DataTable dt = new DataTable();
            dt = dbcon.selectTodosLosMantenimientoPorOrdenData(txtBucadorCodigo.Text);
            foreach (DataRow r in dt.Rows)
            {
                bool.TryParse(r["estadoNoAplicarCorreccion"].ToString(), out NoAprovado);
                bool.TryParse(r["estadoAplicarCorreccion"].ToString(), out Aprovado);
                dgvClients.Rows.Add(
                    r["id"].ToString(), r["fechaMantenimiento"].ToString(), r["fechaEntregaEquipo"].ToString(),
                    r["descripcionFalla"].ToString(), r["solucion"].ToString(), r["IdEstadoMantenimiento"].ToString(),
                    r["idUsuarios"].ToString(), r["idOrdenServicio"].ToString(), r["idEquipo"].ToString(),
                    r["codigo"].ToString(), r["descirpcionEquipo"].ToString(), r["descripcion"].ToString(), Aprovado,
                    NoAprovado);
            }
        }
    }
}
