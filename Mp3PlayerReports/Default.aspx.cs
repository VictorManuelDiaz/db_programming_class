using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-VC8JTUE\SQLEXPRESS;Initial Catalog=musicplayer;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand("SELECT * FROM tb_song;", cn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        ReportDocument rp = new ReportDocument();
        rp.Load(Server.MapPath("SongReport.rpt"));
        rp.SetDataSource(ds.Tables["table"]);

        CrystalReportViewer1.ReportSource=rp;
        rp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Informe de reproductor");

    }
}