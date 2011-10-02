using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.Data;
using QLTL_V2.QLTLTableAdapters;

namespace QLTL_V2.Controllers.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        private ReportViewer rv;
        public ReportController()
        {
            rv = new Microsoft.Reporting.WebForms.ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
        }
        public ActionResult HoaDon()
        {
            return View();
        }
        public FileResult PrintReport(int OrderId)
        {           
         
            rv.LocalReport.ReportPath = Server.MapPath("~/Report/Report1.rdlc");           
            OrderDetailProTableAdapter ad = new OrderDetailProTableAdapter();
            QLTL.OrderDetailProDataTable s = new QLTL.OrderDetailProDataTable();
            ad.Fill(s, OrderId);
            rv.LocalReport.DataSources.Clear();
            ReportDataSource rs = new ReportDataSource();            
            rs.Name = "DataSet1";
            rs.Value = s;
            rv.LocalReport.DataSources.Add(rs);
            byte[] streamBytes = null;
            string mimeType = "";
            string encoding = "";
            string filenameExtension = "";
            string[] streamids = null;
            Warning[] warnings = null;
            streamBytes = rv.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            rv.LocalReport.Refresh();
            return File(streamBytes, mimeType, "TestReport.pdf");
        }

    }
}
