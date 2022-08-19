
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using POSalesDb;

namespace POSales.Mantenimientos
{
    public partial class Mantenimiento : Form
    {
        DBConnect dbcon = new DBConnect();  
        MantenimientoModel mantenimiento = new MantenimientoModel();
        Usuarios usuario = new Usuarios();
        public Mantenimiento(int idUsuarioFacturador)
        {
            usuario = dbcon.selectUsuariosPorId(idUsuarioFacturador);
            InitializeComponent();
        }

        private void Mantenimiento_Load(object sender, System.EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            dgvClients.Rows.Clear();
            bool NoAprovado = false, Aprovado = false;

            DataTable dt = new DataTable();
            dt = dbcon.selectTodosLosMantenimientoDeHoyData();
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
        private void cargarDatosPorFechasDeMatenimiento(DateTime FechaDesde, DateTime FechaHasta)
        {
            dgvClients.Rows.Clear();
            bool NoAprovado = false, Aprovado = false;

            DataTable dt = new DataTable();
            dt = dbcon.selectLosMantenimientoPorFechaMantenimientoData(FechaDesde, FechaHasta);
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
        private void cargarDatosPorFechasDeEntrega(DateTime FechaDesde, DateTime FechaHasta)
        {
            dgvClients.Rows.Clear();
            bool NoAprovado = false, Aprovado = false;

            DataTable dt = new DataTable();
            dt = dbcon.selectLosMantenimientoPorFechaEntregaData(FechaDesde, FechaHasta);
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
        private void cargarDatosFiltrados(string Search)
        {
            dgvClients.Rows.Clear();
            bool NoAprovado = false, Aprovado = false;

            DataTable dt = new DataTable();
            dt = dbcon.selectLosMantenimientoFiltrados(Search);
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

        private void enviarSolucionAlClienteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void dataSet2BindingSource_CurrentChanged(object sender, System.EventArgs e)
        {

        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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
                      
                    }

                    Mantenimientos.precioReferencial MantenimientoView = new Mantenimientos.precioReferencial(mantenimiento, usuario.Id);
                            MantenimientoView.ShowDialog();
                    mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                    dgvClients.Rows[index].Cells["solucion"].Value = mantenimiento.solucion;
                    mantenimiento.estadoMantenimiento = dbcon.selectEstadoMantenimientoPorId(mantenimiento.idEstadoMantenimiento);
                    dgvClients.Rows[index].Cells["IdEstadoMantenimiento"].Value = mantenimiento.estadoMantenimiento.Id;
                    dgvClients.Rows[index].Cells["estado"].Value = mantenimiento.estadoMantenimiento.descripcion;

                }
                    if (colum.Name == "aplicarCorreccion")
                    {
                        if (usuario.role == "tecnico" && (bool)dgvClients.Rows[index].Cells["aplicarCorreccion"].Value == true)
                        {
                            mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                            mantenimiento.idEstadoMantenimiento = 5;
                            dbcon.actualizarMantenimientoModel(mantenimiento);
                        }
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

        private void btnIngresoBuscar_Click(object sender, EventArgs e)
        {
           
            cargarDatosPorFechasDeMatenimiento(dtFechaIngresoDesde.Value,dtFechaIngresoHasta.Value);
        }

        private void btnEntregaBuscar_Click(object sender, EventArgs e)
        {
     
            cargarDatosPorFechasDeEntrega(dtFechaEntregaDesde.Value, dtFechaEntregaMantenimientoHasta.Value);
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBucadorCodigo.Text))
            {
                cargarDatosFiltrados(txtBucadorCodigo.Text);
            }
            else
            {
                MessageBox.Show("Debe ingresar un valor en la caja de texto");
            }

        }

        private void enviarSolucionPorWhatsappToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dtFechaIngresoDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dtFechaIngresoDesde.Value > dtFechaIngresoHasta.Value)
            {
                dtFechaIngresoHasta.Value = dtFechaIngresoDesde.Value;
                MessageBox.Show("Debe escoger un valor menor en la fecha desde");
                return;
            }
        }

        private void dtFechaIngresoHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtFechaIngresoHasta.Value < dtFechaIngresoDesde.Value)
            {
                dtFechaIngresoDesde.Value = dtFechaIngresoHasta.Value;
                MessageBox.Show("Debe escoger un valor Mayor en la fecha Hasta");
                return;
            }

        }

        private void dtFechaEntregaDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dtFechaEntregaDesde.Value > dtFechaEntregaMantenimientoHasta.Value)
            {
                dtFechaEntregaMantenimientoHasta.Value = dtFechaEntregaDesde.Value;
                MessageBox.Show("Debe escoger un valor menor en la fecha desde");
                return;
            }
        }

        private void dtFechaEntregaMantenimientoHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtFechaEntregaMantenimientoHasta.Value < dtFechaEntregaDesde.Value)
            {
                dtFechaEntregaDesde.Value = dtFechaEntregaMantenimientoHasta.Value;
                MessageBox.Show("Debe escoger un valor Mayor en la fecha Hasta");
                return;
            }
        }
    }
}
