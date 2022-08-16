using FontAwesome.Sharp;
using Microsoft.Reporting.WinForms;
using POSalesDb;
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
using System.Windows.Controls;

namespace POSales.Mantenimientos
{
    public partial class InformeCliente : Form
    {
        DBConnect dbcon = new DBConnect();
        int _idOrden = 0;
        OrdenServicioModel Orden = new OrdenServicioModel();
        public InformeCliente(int IdOrden)
        {
            _idOrden = IdOrden;
            InitializeComponent();
            LoadRecept();
        }
        public void LoadRecept()
        {
            Orden = dbcon.selectOrdenServicioModelPorId(_idOrden);
            ReportDataSource rptDataSourece;
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Testing.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();

            DataSet ds1 = new DataSet();
            ds1 = dbcon.generarInformeOrdenMatenimiento(_idOrden);
            SqlDataAdapter da = new SqlDataAdapter();
            rptDataSourece = new ReportDataSource("DataSet1", ds1.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
            DataSet ds4 = new DataSet();
            ds4 = dbcon.selectClienteIdData(Orden.idCliente);
            rptDataSourece = new ReportDataSource("Cliente", ds4.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
            DataSet ds5 = new DataSet();
            ds5 = dbcon.selectTiendasDataId(1);
            rptDataSourece = new ReportDataSource("DetallesDeTienda", ds5.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;



        }
        private void InformeCliente_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
