using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace CrystalReportQR
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L3LK6E7;Initial Catalog=BD_TABLEAU;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from TB_E01_EBITDA_ANUAL",con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();

            crp.Load(Server.MapPath("CrystalReport2.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            CrystalReportViewer1.ReportSource = crp;
            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat,Response, false, "Relatorio Ebitda");

        }
    }
}