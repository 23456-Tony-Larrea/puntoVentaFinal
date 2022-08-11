using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSalesDb;

namespace POSales.Mantenimientos
{
    public partial class SeleccionarMantenimiento : Form
    {
        DBConnect dbcon = new DBConnect();
        Usuarios usuario = new Usuarios();
        List<OrdenServicioModel> orden = new List<OrdenServicioModel>();
        MantenimientoModel mantenimiento = new MantenimientoModel();
        public SeleccionarMantenimiento(int idUsuario)
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
            dgvOrdenes.Rows.Clear();
            DataSet ordenes = new DataSet();
            ordenes = dbcon.selectTodosLasOrdenesDS();
            if (ordenes.Tables.Count > 0)
            {
                if (ordenes.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ordenes.Tables[0].Rows)
                    {
                        string Estado = string.Empty;
                        if (r["Estado"].ToString() == "1" || r["Estado"].ToString() == "true")
                        {
                            Estado = "Facturado";
                        }
                        else
                        {
                            Estado = "No Facturado";
                        }
                        dgvOrdenes.Rows.Add(r["id"].ToString(), r["Fecha Ingreso"].ToString(),
                            r["ciRuc"].ToString(), r["Nombre"].ToString(),
                            r["Estado"].ToString(), Estado, r["idUsuarios"].ToString(),
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
            int.TryParse(dgvOrdenes.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out idOrden);
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
                        Mantenimientos.precioReferencial MantenimientoView = new Mantenimientos.precioReferencial(mantenimiento, usuario.Id);
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
    }
}
