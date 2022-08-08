using System;
using System.Collections.Generic;
using System.Windows.Forms;
using POSalesDb;
using System.Linq;

namespace POSales.Mantenimientos
{
    public partial class EntregasCajero : Form
    {
        Usuarios usuario = new Usuarios();
        DBConnect dbcon = new DBConnect();
        List<OrdenServicioModel> ordenes = new List<OrdenServicioModel>();
        public EntregasCajero(int IdUsuario)
        {

            InitializeComponent();
            CargarOrdenes();
            usuario = dbcon.selectUsuariosPorId(IdUsuario);
        }
        private void CargarOrdenes()
        {
           
            ordenes = dbcon.selectTodosLasOrdenServicioModel();
            if (ordenes.Count > 0)
            {
                foreach (var orden in ordenes)
                {
                    decimal Total = 0;
                    foreach (var mantenimiento in orden.mantenimientos)
                    {
                        foreach (var reserva in mantenimiento.reservas)
                        {
                            Total += reserva.precioFinal;
                        }
                        Total += mantenimiento.precioReferencial;
                    }
                    dgvOrdenes.Rows.Add(orden.Id, orden.cliente.Id, orden.cliente.nombre, Total, orden.IsReady);
                }
            }
            
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {

        }

        private void EntregasCajero_Load(object sender, EventArgs e)
        {

        }

        private void enviarSolucionPorWhatsappToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dgvOrdenes.CurrentCell.RowIndex;
            if (index < 0)
            {
                MessageBox.Show("Selecciona una Orden");
                return;
            }
            OrdenServicioModel ordenSeleccionada = new OrdenServicioModel();
            ordenSeleccionada = ordenes.ElementAt(index);
            Factura factura = new Factura();
            factura.total = Convert.ToDecimal(dgvOrdenes.Rows[index].Cells["Total"].Value.ToString());
            factura.subtotal = factura.total;
            factura.usuario = usuario.Id;

            string Error = string.Empty;
            decimal Total = 0;

            int idFactura = dbcon.insertFacturaMantenimiento(factura);
            if (idFactura > 0)
            {
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

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
