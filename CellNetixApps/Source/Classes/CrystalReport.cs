using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using IDAutomation.Windows.Forms.DataMatrixBarcode;
using CellNetixApps.Source.Database;

namespace CellNetixApps.Source.Classes
{
    class CrystalReport
    {
        private int _Crystal_Report_ID;
        private string _Report_Location;
        private string _Report_Description;
        private string _Database_Server;
        private string _Database_Name;
        private string _Database_User;
        private string _Database_Password;
        private string _NumJobs;
        private string _Paramater1;
        private string _Paramater2;
        private string _Paramater3;
        private string _Paramater4;
        private object _Paramater1Value;
        private object _Paramater2Value;
        private object _Paramater3Value;
        private object _Paramater4Value;
        public CrystalReport(string Report_Description, string NumJobs, object Paramater1Value)
        {
            CellappsDataContext db = new CellappsDataContext();

            var query = from cr in db.Crystal_Reports
                        where cr.Description == Report_Description
                        select cr;

            if (query != null & query.Count() > 0)
            {
                Crystal_Report rec = query.FirstOrDefault();
                _Crystal_Report_ID = rec.Crystal_Report_ID;
                _Report_Location = rec.Report_Location;
                _Database_Server = rec.Database_Server;
                _Database_Name = rec.Database_Name;
                _Database_User = rec.Database_User;
                _Database_Password = rec.Database_Password;
                _Paramater1 = rec.Paramater1;
                _Paramater2 = rec.Paramater2;
                _Paramater3 = rec.Paramater3;
                _Paramater4 = rec.Paramater4;
                _Report_Description = Report_Description;
                _Paramater1Value = Paramater1Value;
                _Paramater2Value = null;
                _Paramater3Value = null;
                _Paramater4Value = null;
                _NumJobs = NumJobs;
            }

        }

        public CrystalReport(string Report_Description, string NumJobs, object Paramater1Value, object Paramater2Value, object Paramater3Value, object Paramater4Value)
        {

            CellappsDataContext db = new CellappsDataContext();

            var query = from cr in db.Crystal_Reports
                        where cr.Description == Report_Description
                        select cr;

            if (query != null & query.Count() > 0)
            {
                Crystal_Report rec = query.FirstOrDefault();
                _Crystal_Report_ID = rec.Crystal_Report_ID;
                _Report_Location = rec.Report_Location;
                _Database_Server = rec.Database_Server;
                _Database_Name = rec.Database_Name;
                _Database_User = rec.Database_User;
                _Database_Password = rec.Database_Password;
                _Paramater1 = rec.Paramater1;
                _Paramater2 = rec.Paramater2;
                _Paramater3 = rec.Paramater3;
                _Paramater4 = rec.Paramater4;
                _Report_Description = Report_Description;
                _Paramater1Value = Paramater1Value;
                _Paramater2Value = Paramater2Value;
                _Paramater3Value = Paramater3Value;
                _Paramater4Value = Paramater4Value;
                _NumJobs = NumJobs;
            }
        }

        private ReportDocument createPDF()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(_Report_Location);

            if (!string.IsNullOrEmpty(_Paramater1))
            {
                ParameterDiscreteValue paramValue1 = new ParameterDiscreteValue();
                paramValue1.Value = _Paramater1Value;
                crReportDocument.SetParameterValue(_Paramater1, paramValue1);
            }

            if (!string.IsNullOrEmpty(_Paramater2))
            {
                ParameterDiscreteValue paramValue2 = new ParameterDiscreteValue();
                paramValue2.Value = _Paramater2Value;
                crReportDocument.SetParameterValue(_Paramater2, paramValue2);
            }

            if (!string.IsNullOrEmpty(_Paramater3))
            {
                ParameterDiscreteValue paramValue3 = new ParameterDiscreteValue();
                paramValue3.Value = _Paramater3Value;
                crReportDocument.SetParameterValue(_Paramater3, paramValue3);
            }

            if (!string.IsNullOrEmpty(_Paramater4))
            {
                ParameterDiscreteValue paramValue4 = new ParameterDiscreteValue();
                paramValue4.Value = _Paramater4Value;
                crReportDocument.SetParameterValue(_Paramater4, paramValue4);
            }

            CrystalDecisions.CrystalReports.Engine.Database db = crReportDocument.Database;
            Tables tables = db.Tables;
            TableLogOnInfo tableLoginInfo = new TableLogOnInfo();

            ConnectionInfo dbConnInfo = new ConnectionInfo();
            dbConnInfo.UserID = _Database_User;
            dbConnInfo.Password = _Database_Password;
            dbConnInfo.ServerName = _Database_Server;
            dbConnInfo.DatabaseName = _Database_Name;



            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                tableLoginInfo = table.LogOnInfo;
                tableLoginInfo.ConnectionInfo = dbConnInfo;
                table.ApplyLogOnInfo(tableLoginInfo);
            }

            return crReportDocument;
        }



        public string PrintToCustomPrinter(string Printer_Name)
        {
            ReportDocument crReportDocument = null;
            string errMsg = null;
            try
            {
               // System.Security.Principal.WindowsImpersonationContext ctx = System.Security.Principal.WindowsIdentity.Impersonate(IntPtr.Zero);
                crReportDocument = createPDF();
                crReportDocument.PrintOptions.PrinterName = Printer_Name;
                crReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                crReportDocument.PrintToPrinter(Convert.ToInt32(_NumJobs), false, 0, 0);
               // ctx.Undo();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                if (crReportDocument != null)
                {
                    crReportDocument.Dispose();
                    crReportDocument.Close();
                }
            }
            return errMsg;
        }
        /// <summary>For block print</summary>
        /// <param name="printer">Should be the description of the printer (the plain english name)</param>
        /// <param name="count">Is addded to the end of the filename to avoid overwriting</param>
        public void PrintToTextFile(string printer, int count)
        {
            ReportDocument crReportDocument = createPDF();
            string fileName = @"\\CEL-DIS-001\DIS\" + printer + "/" + printer + "_PseudoDriver_CEL-DIS-001_" + count + ".txt";
            crReportDocument.ExportToDisk(ExportFormatType.Text, fileName);
        }
    }
}
