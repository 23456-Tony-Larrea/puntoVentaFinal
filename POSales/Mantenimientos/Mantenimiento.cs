
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using POSalesDb;

namespace POSales.Mantenimientos
{
    public partial class Mantenimiento : Form
    {
        DBConnect dbcon = new DBConnect();  
        MantenimientoModel mantenimiento = new MantenimientoModel();
        int idUsuarioFacturador = 0;
        public Mantenimiento(int idUsuarioFacturador)
        {
            this.idUsuarioFacturador = idUsuarioFacturador;
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
            dt = dbcon.selectTodosLosMantenimientoModelsData();
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
                if (colum.Name == "solucion")
                {
                    if (idmantenimiento > 0)
                    {
                        mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                        mantenimiento.equipo = dbcon.selectEquipoPorId(mantenimiento.IdEquipo);
                        Mantenimientos.MantenimientoModulo MantenimientoView = new Mantenimientos.MantenimientoModulo(mantenimiento, idUsuarioFacturador);
                        MantenimientoView.ShowDialog();
                        cargarDatos();
                    }

                }
                if (colum.Name == "aplicarCorreccion")
                {
                    if (idmantenimiento > 0)
                    {
                        dgvClients.Rows[index].Cells["aplicarCorreccion"].Value = true;
                        dgvClients.Rows[index].Cells["NoAplicarCorreccion"].Value = false;
                        mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                        mantenimiento.equipo = dbcon.selectEquipoPorId(mantenimiento.IdEquipo);
                        mantenimiento.estadoAplicarCorreccion = true;
                        mantenimiento.estadoNoAplicarCorreccion = false;
                        dbcon.actualizarMantenimientoModel(mantenimiento);
                    }

                }
                if (colum.Name == "NoAplicarCorreccion")
                {
                    if (idmantenimiento > 0)
                    {
                        dgvClients.Rows[index].Cells["aplicarCorreccion"].Value = false;
                        dgvClients.Rows[index].Cells["NoAplicarCorreccion"].Value = true;
                        mantenimiento = dbcon.selectMantenimientoModelPorId(idmantenimiento);
                        mantenimiento.equipo = dbcon.selectEquipoPorId(mantenimiento.IdEquipo);
                        mantenimiento.estadoAplicarCorreccion = false;
                        mantenimiento.estadoNoAplicarCorreccion = true;
                        dbcon.actualizarMantenimientoModel(mantenimiento);
                    }

                }
            }
          

        }

        private void btnIngresoBuscar_Click(object sender, EventArgs e)
        {
            if (dtFechaEntregaDesde.Value > dtFechaEntregaMantenimientoHasta.Value)
            {
                dtFechaEntregaMantenimientoHasta.Value = dtFechaEntregaDesde.Value;
                MessageBox.Show("Debe escoger un valor menor en la fecha desde");
                return;
            }
            if (dtFechaEntregaDesde.Value < dtFechaEntregaMantenimientoHasta.Value)
            {
                dtFechaEntregaDesde.Value = dtFechaEntregaMantenimientoHasta.Value;
                MessageBox.Show("Debe escoger un valor Mayor en la fecha Hasta");
                return;
            }

            cargarDatosPorFechasDeMatenimiento(dtFechaEntregaDesde.Value, dtFechaEntregaMantenimientoHasta.Value);
        }

        private void btnEntregaBuscar_Click(object sender, EventArgs e)
        {
            if (dtFechaIngresoDesde.Value > dtFechaIngresoHasta.Value)
            {
                dtFechaIngresoDesde.Value = dtFechaIngresoHasta.Value;
                MessageBox.Show("Debe escoger un valor menor en la fecha desde");
                return;
            }
            if (dtFechaIngresoDesde.Value < dtFechaIngresoHasta.Value)
            {
                dtFechaIngresoDesde.Value = dtFechaIngresoHasta.Value;
                MessageBox.Show("Debe escoger un valor Mayor en la fecha Hasta");
                return;
            }
            cargarDatosPorFechasDeEntrega(dtFechaIngresoDesde.Value, dtFechaIngresoHasta.Value);
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
    }
}
