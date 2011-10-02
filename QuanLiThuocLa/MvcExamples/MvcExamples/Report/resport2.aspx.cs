using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;

namespace MvcExamples.Report
{
    public partial class resport2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.AppSettings.Get("DBEntities");
            con.Open();
            SqlCommand com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.CommandText = "OrderDetaiPro";


            LocalReport rep = ReportViewer1.LocalReport;
            rep.ReportPath = @"Report\Report1.rdlc";

            ReportViewer1.LocalReport.Refresh();


        }
    }
}