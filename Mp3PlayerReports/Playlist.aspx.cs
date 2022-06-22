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
        SqlConnection cn = new SqlConnection(
            @"Data Source=DESKTOP-VC8JTUE\SQLEXPRESS;
            Initial Catalog=musicplayer;
            Integrated Security=True;"
        );
        SqlCommand cmd = new SqlCommand("SELECT * FROM vw_playlist;SELECT * FROM vw_added_songs;", cn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        ReportDocument rp = new ReportDocument();
        rp.Load(Server.MapPath("PlaylistReport.rpt"));
        rp.SetDataSource(ds.Tables["table"]);
        rp.Subreports[0].SetDataSource(ds.Tables["table1"]);

        //Añadir parámetro
        rp.SetParameterValue("IdPlaylist", Request["id"]);
        CrystalReportViewer1.ReportSource = rp;

        int fileType = int.Parse(Request["file"]);

        switch (fileType)
        {
            case 1:
                rp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Informe de reproductor");
                break;
            case 2:
                rp.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "Informe de reproductor");
                break;
        }

        
        

    }
}