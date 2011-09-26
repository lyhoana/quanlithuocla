using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace MvcExamples.Report
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LocalReport rep = ReportViewer1.LocalReport;
                DateTime p = (DateTime)Session["HEADER"];
                rep.ReportPath = "Report\\Report1.rdlc";
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] {
                     new Microsoft.Reporting.WebForms.ReportParameter("HEADER",p.ToString())    
                        });
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}