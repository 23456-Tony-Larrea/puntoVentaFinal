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

namespace POSales.Mantenimientos
{
    public partial class InformeCliente : Form
    {
        DBConnect dbcon = new DBConnect();
        int _idOrden = 0;
        public InformeCliente(int IdOrden)
        {
            _idOrden = IdOrden;
            InitializeComponent();
            LoadRecept();
        }
        public void LoadRecept()
        {
            ReportDataSource rptDataSourece;
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\ReportTeest.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();

            DataSet ds1 = new DataSet();
            ds1 = dbcon.generarInformeOrdenMatenimiento(_idOrden);
            SqlDataAdapter da = new SqlDataAdapter();
            rptDataSourece = new ReportDataSource("DataSet1", ds1.Tables[0]);
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
