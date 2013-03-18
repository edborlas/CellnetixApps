using CellNetixApps.Source.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Drawing.Drawing2D;
using Inlite.ClearImage;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid;
using CellNetixApps.Source.Embed.Forms;
using System.Reflection;
using Microsoft.Win32;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using CellNetixApps.Source.Acc;
using CellNetixApps.Source.Lab;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using DevExpress.XtraTab;

namespace CellNetixApps.Source.Classes
{
    class cMethods
    {

        public class Acc
        {
            public static cCase cCase = new cCase();
            public static List<XtraTabPage> lAccTabs { get; set; }
            public static XtraTabControl AccTabControl;
            public static List<SP_RulesResult> lOrgRules = new List<SP_RulesResult>();
            private static cAccCaseType cAccCaseType;
            private static cAccCif cAccCif;
            private static cAccOrder cAccOrder;
            private static cAccPatient cAccPatient;
            private static cAccPrint cAccPrint;
            private static cAccRefMD cAccRefMD;
            private static cAccReqData cAccReqData;
            private static cAccScan cAccScan;
            private static cAccSpecimen cAccSpecimen;
            private static cAccValidation cAccValidation;
            public static cAccSidebar cAccSidebar;
            public static List<cImage> lImages = new List<cImage>();
            public static XtraUserControl GetAccUserControl(Enums.AccControls acc)
            {
                switch (acc)
                {
                    case Enums.AccControls.cAccCaseType:
                        if (Acc.cAccCaseType == null)
                            Acc.cAccCaseType = new cAccCaseType();
                        Acc.cAccCaseType.LoadData();
                        return Acc.cAccCaseType;
                    case Enums.AccControls.cAccCif:
                        if (Acc.cAccCif == null)
                            Acc.cAccCif = new cAccCif();
                        Acc.cAccCif.LoadData();
                        return Acc.cAccCif;
                    case Enums.AccControls.cAccOrder:
                        if (Acc.cAccOrder == null)
                            Acc.cAccOrder = new cAccOrder();
                        Acc.cAccOrder.LoadData();
                        return Acc.cAccOrder;
                    case Enums.AccControls.cAccPatient:
                        if (Acc.cAccPatient == null)
                            Acc.cAccPatient = new cAccPatient();
                        Acc.cAccPatient.LoadData();
                        return Acc.cAccPatient;
                    case Enums.AccControls.cAccPrint:
                        if (Acc.cAccPrint == null)
                            Acc.cAccPrint = new cAccPrint();
                        Acc.cAccPrint.LoadData();
                        return Acc.cAccPrint;
                    case Enums.AccControls.cAccRefMD:
                        if (Acc.cAccRefMD == null)
                            Acc.cAccRefMD = new cAccRefMD();
                        Acc.cAccRefMD.LoadData();
                        return Acc.cAccRefMD;
                    case Enums.AccControls.cAccReqData:
                        if (Acc.cAccReqData == null)
                            Acc.cAccReqData = new cAccReqData();
                        Acc.cAccReqData.LoadData();
                        return Acc.cAccReqData;
                    case Enums.AccControls.cAccScan:
                        if (Acc.cAccScan == null)
                            Acc.cAccScan = new cAccScan();
                        Acc.cAccScan.LoadData();
                        return Acc.cAccScan;
                    case Enums.AccControls.cAccSpecimen:
                        if (Acc.cAccSpecimen == null)
                            Acc.cAccSpecimen = new cAccSpecimen();
                        Acc.cAccSpecimen.LoadData();
                        return Acc.cAccSpecimen;
                    case Enums.AccControls.cAccValidation:
                        if (Acc.cAccValidation == null)
                            Acc.cAccValidation = new cAccValidation();
                        Acc.cAccValidation.LoadData();
                        return Acc.cAccValidation;
                    //case Enums.AccControls.cAccSidebar:
                    //    if (Acc.cAccSidebar == null)
                    //        Acc.cAccSidebar = new cAccSidebar();
                    //    Acc.cAccSidebar.LoadData();
                    //    return Acc.cAccSidebar;
                }
                return null;
            }

            public static void MoveTab(int index, XtraTabPage curTab)
            {
                if (cMethods.Acc.lAccTabs == null)
                    return;

                int count = 0;
                foreach (XtraTabPage tp in cMethods.Acc.lAccTabs)
                {
                    if (curTab.Text == tp.Text)
                    {
                        if (index == (int)Enums.Move.Back && count == 0)
                            break;
                        if (index > (int)Enums.Move.Back && count == cMethods.Acc.lAccTabs.Count - 1)
                            break;

                        XtraTabPage newTab = cMethods.Acc.lAccTabs[count + index];
                        cMethods.Acc.AccTabControl.SelectedTabPage = newTab;
                        break;
                    }
                    count++;
                }
            }

            public static void SearchCIF(string sText)
            {
                CellappsDataContext db = new CellappsDataContext();
                string cif = sText.ToUpper().Replace("CI", "");
                if (cMethods.isNumeric(cif))
                {
                    int itemID = Convert.ToInt32(cif);
                    var query = from iw in db.Item_Waypoints
                                join l in db.Locations on iw.Location_ID equals l.Location_ID
                                join o in db.Organizations on l.Organization_ID equals o.Organization_ID
                                where iw.Waypoint_Order == 1 && iw.Item_ID == itemID
                                select o;

                    if (query != null && query.Count() > 0)
                    {
                        //65867436
                        Organization o = query.First();
                        cCase.Organization = o;
                        RulesDataContext rdb = new RulesDataContext();
                        lOrgRules = rdb.SP_Rules(o.Code, null, null, null, null, null, null).ToList();
                    }
                }
            }
        }

        public static string GetGroupEmail(int userID)
        {
            string emails = String.Empty;

            CellappsDataContext db = new CellappsDataContext();
            Ticket_Group_User tgu = (from t in db.Ticket_Group_Users
                                                      where t.User_ID == userID
                                                      select t).First();
           
            int groupID = (int)tgu.Ticket_Group_ID;

            IQueryable<User> uQuery = from t in db.Ticket_Group_Users
                                        from u in db.Users
                                        where t.Ticket_Group_ID == groupID
                                        where t.User_ID == u.User_ID
                                        select u;

            string uEmails = String.Empty;
            foreach (User u in uQuery)
                uEmails += u.Email_Address + ",";
            
            emails = uEmails.TrimEnd(',');
            return emails;
        }

        public static string Version
        {
            get
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
                return fvi.FileVersion.ToString();
            }
        }
        public static void SendEmail(string toEmail, string subject, string body)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(toEmail);
            msg.From = new MailAddress(Program.User.Email);
            msg.Subject = subject;
            msg.Body = body;
            SmtpClient smtp = new SmtpClient(Program.EMAIL_SERVER);
            smtp.Send(msg);
        }
        public class NiceLabel
        {

            public static void PrintSlideLabel(cSlide sl)
            {
                string labelLocation = string.Empty;

                if (sl.Consult_Accession_No != null && sl.Consult_Accession_No != string.Empty) //put this in the databse eventually
                {
                    labelLocation = @"\\cel-fil-001\NiceLabel\Labels\slide_Tech-Consult.lbl";
                }
                else
                {
                    labelLocation = @"\\cel-fil-001\NiceLabel\Labels\slide.lbl";
                }


                System.IO.StreamWriter oWrite = null;
                string printerName = Program.User.Printer.Description;

                string fileName = fileName = @"\\cel-fil-001\NiceLabel\Jobs\slide_label" + sl.AccessionNo + "_" + sl.Label + "_" + CurrentTime() + ".job";

                oWrite = System.IO.File.CreateText(fileName);
                oWrite.WriteLine("LABEL " + labelLocation);
                oWrite.WriteLine("Set accession_no = " + sl.AccessionNo.SetLength(14));

                if (sl.SpecimenDescription != null && sl.SpecimenDescription != string.Empty)
                {
                    oWrite.WriteLine("Set specimen_desc  = \"" + sl.SpecimenDescription.SetLength(25) + "\"");
                }
                if (sl.Procedure != null && sl.Procedure != string.Empty)
                {
                    oWrite.WriteLine("Set procedure_label_desc = \"" + sl.Procedure.SetLength(20) + "\"");
                }
                if (sl.Label != null && sl.Label != string.Empty)
                    oWrite.WriteLine("Set slide_label  = \"" + sl.Label.SetLength(6) + "\"");
                if (sl.CollectionDate != null)
                    oWrite.WriteLine("Set spec_coll_date  = \"" + sl.CollectionDate.SetLength(10) + "\"");
                if (sl.PatientName != null && sl.PatientName != string.Empty)
                {
                    oWrite.WriteLine("Set patient_name  = \"" + sl.PatientName.SetLength(24) + "\"");
                }
                if (sl.RevCenter != null && sl.RevCenter != string.Empty)
                    oWrite.WriteLine("Set rev_center_code  = \"" + sl.RevCenter.SetLength(5) + "\"");

                if (sl.Consult_Accession_No != null && sl.Consult_Accession_No != string.Empty) //dont put levels for cases with no consult label
                {
                    oWrite.WriteLine("Set consult  = \"" + sl.Consult_Accession_No.SetLength(12) + "\"");

                }
                else
                {
                    if (sl.Levels != null && sl.Levels != string.Empty)
                    {
                        oWrite.WriteLine("Set level_info  = \"" + sl.Levels.SetLength(6) + "\"");
                    }
                    else
                    {
                        oWrite.WriteLine("Set level_info  = \"" + "." + "\"");
                    }
                }

                oWrite.WriteLine("Set barcode = " + sl.EncodedValue);
                oWrite.WriteLine("PRINTER " + printerName);
                oWrite.WriteLine("PRINT 1");
                oWrite.Flush();
                oWrite.Close();
            }

            public static void PrintManifestLabel(cTray tray) { PrintManifestLabel(tray.ManifestItemID); }
            public static void PrintManifestLabel(int itemID)
            {
                CellappsDataContext db = new CellappsDataContext();
                db.CommandTimeout = 60;
                SP_Crystal_Manifest_Part3Result cr = db.SP_Crystal_Manifest_Part3(itemID).First();

                string labelLocation = @"\\cel-fil-001\NiceLabel\Labels\Manifest.lbl";

                System.IO.StreamWriter oWrite = null;
                string printerName = Program.User.Printer.Description;

                string fileName = @"\\cel-fil-001\NiceLabel\Jobs\manifest_label_" + cr.Item_ID + "_" + "_" + CurrentTime() + "_" + ".job";
                oWrite = System.IO.File.CreateText(fileName);
                oWrite.WriteLine("LABEL " + labelLocation);
                oWrite.WriteLine("Set Abbreviation  = \"" + cr.abbreviation.SetLength(10) + "\"");
                oWrite.WriteLine("Set Assigned  = \"" + cr.Assigned_To.SetLength(20) + "\"");
                oWrite.WriteLine("Set Barcode = " + cr.BC.SetLength(50));
                oWrite.WriteLine("Set Destination = " + cr.Destination.SetLength(24));
                oWrite.WriteLine("Set Item = " + cr.Item_ID.SetLength(11));
                oWrite.WriteLine("PRINTER " + printerName);
                oWrite.WriteLine("PRINT 1");
                oWrite.Flush();
                oWrite.Close();
            }

            public static void PrintTrayLabel(cTray tray, int numLabels)
            {

                string labelLocation = @"\\cel-fil-001\NiceLabel\Labels\Tray.lbl";

                System.IO.StreamWriter oWrite = null;
                string printerName = Program.User.Printer.Description;

                string fileName = @"\\cel-fil-001\NiceLabel\Jobs\tray_label_" + tray.Name + "_" + CurrentTime() + ".job";
                oWrite = System.IO.File.CreateText(fileName);
                oWrite.WriteLine("LABEL " + labelLocation);
                oWrite.WriteLine("Set Item = " + tray.Name);
                oWrite.WriteLine("Set Barcode = " + tray.Name);
                oWrite.WriteLine("PRINTER " + printerName);
                oWrite.WriteLine("PRINT " + numLabels);
                oWrite.Flush();
                oWrite.Close();
            }

            public static void PrintCassetteLabel(cBlock bl)
            {

                string labelLocation = @"\\cel-fil-001\NiceLabel\Labels\Tray.lbl";

                System.IO.StreamWriter oWrite = null;
                string printerName = Program.User.Printer.Description;

                string fileName = @"\\cel-fil-001\NiceLabel\Jobs\tray_label_" + bl.BlockName + "_" + CurrentTime() + ".job";
                oWrite = System.IO.File.CreateText(fileName);
                oWrite.WriteLine("LABEL " + labelLocation);
                oWrite.WriteLine("Set Barcode = " + "ENCODED");
                oWrite.WriteLine("Set Block_Desc = " + bl.Block);
                oWrite.WriteLine("Set Case_No = " + "ACC NO");
                oWrite.WriteLine("Set Spec_Type = " + bl.SpecimenDescription);
                oWrite.WriteLine("Set Division = " + "AK");
                oWrite.WriteLine("PRINTER " + printerName);
                oWrite.WriteLine("PRINT " + "1");
                oWrite.Flush();
                oWrite.Close();
            }

            private static string CurrentTime()
            {
                return DateTime.Now.Day.ToString()
                     + DateTime.Now.Month.ToString()
                     + DateTime.Now.Year.ToString()
                     + DateTime.Now.Hour.ToString()
                     + DateTime.Now.Minute.ToString()
                     + DateTime.Now.Second.ToString()
                     + DateTime.Now.Millisecond.ToString();
            }
        }


        public static void Insert_User_Status(int Idle_Time)
        {
            CellappsDataContext db = new CellappsDataContext();
            try
            {
                User_Status us = new User_Status();
                us.User_ID = Program.User.UserID;
                us.Time_Stamp = DateTime.Now;
                us.Idle_Time = Idle_Time;
                us.IP_Address = LocalIPAddress().ToString();
                db.User_Status.InsertOnSubmit(us);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static IPAddress LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }

        public static bool SendTCPMsg(string ipAddress, string msg)
        {
            bool err = false;
            try
            {
                TcpClient client = new TcpClient();

                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), Program.PORT_NUMBER);

                client.Connect(serverEndPoint);

                NetworkStream clientStream = client.GetStream();

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(msg);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
            catch (Exception ex)
            {
                err = true;
                MessageBox.Show(ex.Message);
            }
            return err;
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static void InsertConferenceImage(string AccessionNo)
        {

            try
            {

                Image bitmap = Bitmap.FromFile(Program.SlideFileName);

                FileInfo fi = new FileInfo(Program.SlideFileName);

                CellappsDataContext db = new CellappsDataContext();
                Conference_Image ci = new Conference_Image();
                ci.Conference_ID = Program.Conference.Conference_ID;
                ci.Photo = cMethods.ImageToByte(bitmap);
                // ci.Title = "Title";
                // ci.Description = "It's a slide";
                ci.Active = true;
                ci.Accession_No = AccessionNo;
                ci.File_Name = fi.Name;
                ci.Full_Path = Program.SlideFileName;
                db.Conference_Images.InsertOnSubmit(ci);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public static void InsertAccessionLog(stp_lab_worklistResult order, string worklist)
        {
            CellappsDataContext db = new CellappsDataContext();
            Accession_Log al = new Accession_Log();
            al.Accession_Log_ID = Guid.NewGuid();
            al.Acc_ID = Convert.ToInt32(order.acc_id);
            al.Accession_No = order.accession_no;
            al.Accession_Type_ID = 7; //worklist
            al.Accession_Field_ID = 50; //worklist
            al.Accession_Status_ID = GetStatusID(order.status);
            al.Details = worklist; // order.status.ToString();
            al.User_ID = Program.User.UserID;
            al.Time_Stamp = DateTime.Now;
            al.Acc_Order_ID = order.id;
            db.Accession_Logs.InsertOnSubmit(al);
            db.SubmitChanges();
        }

        /// <summary>
        /// Writes Registry for the first time, otherwise sets where clause based off previous selection
        /// </summary>
        public static void ReadRegistryValues(ref int Lab_FacilityID, ref int Lab_DepartmentID, ref int Lab_WorklistID)
        {
            ModifyRegistry mr = new ModifyRegistry();
            string Lab_Facility = mr.Read("Lab_Facility");

            if (Lab_Facility == null)
            {
                Lab_FacilityID = 4;
                mr.Write("Lab_Facility", Lab_FacilityID.ToString());

            }
            else
            {
                Lab_FacilityID = Lab_Facility.ToInt();
            }

            string Lab_Department = mr.Read("Lab_Department");
            if (Lab_Department == null)
            {
                Lab_DepartmentID = 7;
                mr.Write("Lab_Department", Lab_DepartmentID.ToString());
            }
            else
            {
                Lab_DepartmentID = Lab_Department.ToInt();
            }

            string Lab_Worklist = mr.Read("Lab_Worklist");
            if (Lab_Worklist == null)
            {
                Lab_WorklistID = 18;
                mr.Write("Lab_Worklist", Lab_WorklistID.ToString());
            }
            else
            {
                Lab_WorklistID = Lab_Worklist.ToInt();
            }
        }
        public static void WriteWorklistTileText(TileItem ti, stp_lab_worklistResult order, Enums.Mode mode)
        {
            //switch (mode)
            //{
            //    case Enums.Mode.accession_no:
            //    case Enums.Mode.ordered_date:
            //        ti.IsLarge = true;
            //        ti.Text = order.accession_no + "\n" + order.ordered_date + "\nOrders: " + order.specimen_sequence;
            //        ti.AppearanceItem.Normal.BackColor = Program.ColorBlue;
            //        ti.AppearanceItem.Normal.BackColor2 = Program.ColorBlue;
            //        break;
            //    case Enums.Mode.lab_procedure_description:
            ti.IsLarge = true;

            if (order.instructions == null || order.instructions == string.Empty)
            {
                ti.Text = order.accession_no + "  " + order.source_material_label + "    " + order.lab_procedure_code + "\n"
                    + order.specimen_description + "\n" + order.ordered_date + "\nStatus:" + GetStatusName(order.status);
            }
            else
            {
                ti.Text = order.accession_no + "  " + order.source_material_label + "    " + order.lab_procedure_code + "\n"
                    + order.specimen_description + "\nOrdered: " + order.ordered_date + "\nStatus: " + GetStatusName(order.status) + "\nInstructions: <size=10>" + order.instructions + "</size>";
            }
            ti.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            ti.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOn;
            //    break;
            // }
        }

        public static string GetStatusName(char? status)
        {
            string name = string.Empty;

            switch (status)
            {
                case 'N':
                    name = "<color=Red>Ordered</color>";
                    break;
                case 'I':
                    name = "<color=Blue>Printed <size=8>(In Process)</size></color>";
                    break;
                case 'C':
                    name = "<color=Green>Complete</color>";
                    break;
            }
            return name;
        }


        public static int GetStatusID(char? status)
        {
            int id = 0;

            switch (status)
            {
                case 'N':
                    id = 105;
                    break;
                case 'I':
                    id = 110;
                    break;
                case 'C':
                    id = 200;
                    break;
            }
            return id;
        }

        public static IQueryable<cPatient> GetPatients()
        {
            PowerPathDataContext db = new PowerPathDataContext();
            var query = from p in db.vw_patient_2s
                        where p.first_name != null
                        select new cPatient
                        {
                            Id = p.id,
                            First_name = p.first_name,
                            Last_name = p.last_name,
                            Mid_name = p.mid_name,
                            SSN = p.ssn,
                            Full_name = p.full_name,
                            Sex = p.sex.ToString(),
                            DOB = p.birth_date.ToString()
                        };

            var query2 = from o in db.vw_order_requests
                         join m in db.patient_mrn_2s on o.patient_mrn_id equals m.id
                         where o.status == 'N'
                         select new cPatient
                         {
                             Id = Convert.ToInt32(o.patient_id),
                             Order_Number = o.order_number,
                             Facility = o.sending_facility,
                             Service_Code = o.uservice_code,
                             Created_Date = o.created_date,
                             MRN = m.med_rec_no
                         };

            IQueryable<cPatient> query3 = from patients in query
                                          join x in query2 on patients.Id equals x.Id into temp
                                          from fuck in temp.DefaultIfEmpty()
                                          select new cPatient
                                          {
                                              Id = patients.Id,
                                              First_name = patients.First_name,
                                              Last_name = patients.Last_name,
                                              Mid_name = patients.Mid_name,
                                              SSN = patients.SSN,
                                              Full_name = patients.Full_name,
                                              Sex = patients.Sex,
                                              DOB = patients.DOB,
                                              MRN = fuck.MRN,
                                              Order_Number = fuck.Order_Number,
                                              Facility = fuck.Facility,
                                              Service_Code = fuck.Service_Code,
                                              Created_Date = fuck.Created_Date
                                          };


            return query3;
        }

        //public static IQueryable<object> GetPatients()
        //{
        //    PowerPathDataContext db = new PowerPathDataContext();
        //    var query = from p in db.vw_patient_2s 
        //                join o in db.vw_order_requests on p.id equals o.patient_id into orderRequests
        //                from order in orderRequests.DefaultIfEmpty()
        //                where order.status == 'N' && p.first_name != null
        //                select new cPatient
        //                {
        //                    Id = p.id,
        //                    First_name = p.first_name,
        //                    Last_name = p.last_name,
        //                    Mid_name = p.mid_name,
        //                    SSN = p.ssn,
        //                    Full_name = p.full_name,
        //                    Sex = p.sex.ToString(),
        //                    DOB = p.birth_date.ToString(),
        //                    Order_Number = order.order_number,
        //                    Facility = order.sending_facility,
        //                    Service_Code = order.uservice_code,
        //                    Created_Date = order.created_date
        //                };
        //    return query;
        //}

        public static void GetFacitlities(ref List<facility> lFacility)
        {
            PowerPathDataContext db = new PowerPathDataContext();
            var query = from f in db.facilities
                        where f.type == 'E' && f.active == 'Y'
                        orderby f.name
                        select f;
            lFacility = query.ToList();
        }

        public static void GetLabDept(ref List<lab_dept> lLabDept)
        {

            PowerPathDataContext db = new PowerPathDataContext();
            var query = from l in db.lab_depts
                        where l.active == 'Y'
                        orderby l.name
                        select l;
            lLabDept = query.ToList();
        }

        public static void GetLabDeptWorklists(ref List<lab_dept_worklist> lWorklist)
        {


            PowerPathDataContext db = new PowerPathDataContext();
            var query = from l in db.lab_dept_worklists
                        where l.active == 'Y'
                        orderby l.name
                        select l;
            lWorklist = query.ToList();
        }



        public static List<cWebsite> GetWebsites()
        {
            List<cWebsite> l = new List<cWebsite>();

            CellappsDataContext db = new CellappsDataContext();

            var query = from w in db.Websites
                        join wp in db.Website_Pages on w.Website_ID equals wp.Website_ID
                        where w.Website_ID == 8
                        select wp;

            foreach (var web in query)
            {
                cWebsite c = new cWebsite();
                c.Description = web.Description;
                c.URL = web.URL;
                l.Add(c);
            }


            return l;
        }

        public static cPatient GetPatient()
        {
            cPatient cp = new cPatient();
            PowerPathDataContext db = new PowerPathDataContext();
            var query = from p in db.vw_patient_2s
                        where p.id == Program.Acc.PatientID
                        select p;

            vw_patient_2 vw = query.First();

            cp.First_name = vw.first_name;
            cp.Full_name = vw.full_name;
            cp.Last_name = vw.last_name;
            cp.Mid_name = vw.mid_name;
            return cp;
        }
        public static void GetTemplates()
        {
            CellappsDataContext db = new CellappsDataContext();
            Program.Templates = new List<cTemplate>();
            var query = from t in db.Templates
                        where t.Active == true
                        select t;

            foreach (Template t in query)
            {
                cTemplate ct = new cTemplate();
                ct.Code = t.Code;
                ct.Description = t.Description;
                ct.TemplateID = t.Template_ID;
                Program.Templates.Add(ct);
            }
        }

        public static void GetDivisions()
        {
            CellappsDataContext db = new CellappsDataContext();
            var query = from d in db.Divisions
                        where d.Lab_Use == true
                        select d;
            Program.lDivisions = query.ToList();
        }

        public static void GetTemplateData()
        {
            CellappsDataContext db = new CellappsDataContext();
            Program.TemplateData = new List<cTemplateData>();
            var query = from t in db.Template_Datas
                        join tt in db.Template_Types on t.Template_Type_ID equals tt.Template_Type_ID
                        select new
                        {
                            Data = t.Data,
                            TemplateID = t.Template_ID,
                            TemplateTypeID = t.Template_Type_ID,
                            Description = tt.Description
                        };

            foreach (var t in query)
            {
                cTemplateData ct = new cTemplateData();
                ct.Data = t.Data;
                ct.TemplateID = t.TemplateID;
                ct.TemplateTypeID = t.TemplateTypeID;
                ct.TypeDescription = t.Description;
                Program.TemplateData.Add(ct);
            }
        }

        public static void InsertMachineAttribute(int attributeID)
        {
            CellappsDataContext db = new CellappsDataContext();
            var query = from m in db.Machines
                        where m.Machine_Name == Environment.MachineName
                        select m;

            Machine_Attribute ma = new Machine_Attribute();
            ma.Machine_ID = query.FirstOrDefault().Machine_ID;
            ma.Machine_Attribute_Type_ID = attributeID;
            db.Machine_Attributes.InsertOnSubmit(ma);
            db.SubmitChanges();
        }

        public static cMachine GetMachine()
        {

            cMachine machine = new cMachine();
            CellappsDataContext db = new CellappsDataContext();
            var query = from m in db.Machines
                        join ma in db.Machine_Attributes on m.Machine_ID equals ma.Machine_ID into joinMachineAttribute
                        from ma in joinMachineAttribute.DefaultIfEmpty()
                        where m.Machine_Name == Environment.MachineName
                        select new
                        {
                            machineID = m.Machine_ID,
                            description = m.Machine_Name,
                            printerID = m.Printer_ID,
                            attributeID = ma.Machine_Attribute_Type_ID,
                            locationID = m.Location
                        };
            if (query != null && query.Count() > 0)
            {
                List<int> li = new List<int>();
                foreach (var mac in query)
                {
                    machine.LocationID = mac.locationID;
                    machine.MachineID = mac.machineID;
                    machine.Description = mac.description;
                    machine.PrinterID = Convert.ToInt32(mac.printerID);
                    li.Add(mac.attributeID);
                }
                machine.Attributes = li;
            }
            return machine;
        }

        public static List<Enums.TicketRecType> getTicketRecTypes(int errorID)
        {
            CellappsDataContext db = new CellappsDataContext();
            List<Enums.TicketRecType> lRecTypes = new List<Enums.TicketRecType>();
            var query = from ticketAttributes in db.Ticket_Error_Attributes
                        where ticketAttributes.Ticket_Error_ID == errorID
                        orderby ticketAttributes.Ticket_Attribute_Type_ID
                        select new
                        {
                            ticketErrorAttribute = ticketAttributes.Ticket_Attribute_Type_ID
                        };
            foreach (var attribute in query)
            {
                if (attribute.ticketErrorAttribute <= 3)
                {
                    Enums.TicketRecType conversion = (Enums.TicketRecType)attribute.ticketErrorAttribute;
                    lRecTypes.Add(conversion);
                }
            }
            return lRecTypes;
        }

        /// <remarks>SP_Get_Ticket_Stages grabs the owner's name. I didn't think this was necessary. I also didn't think this deserved to be apart of the Program lists (not used often enough).</remarks>
        public static List<cTicketStage> GetTicketStages()
        {
            List<cTicketStage> lStages = new List<cTicketStage>();
            CellappsDataContext db = new CellappsDataContext();
            List<cTicketError> ticketList = new List<cTicketError>();
            //same as SP_Get_Ticket_Errors
            var query = from stages in db.Ticket_Stages
                        where stages.Ticket_Stage_ID > 0 && stages.Ticket_Stage_ID != 6
                        orderby stages.Sort_Order
                        select new
                        {
                            stageID = stages.Ticket_Stage_ID,
                            description = stages.Description,
                            ownerID = stages.Owner_ID
                        };
            foreach (var stage in query)
            {
                cTicketStage cStage = new cTicketStage();
                cStage.stageID = stage.stageID;
                cStage.description = stage.description;
                if (stage.ownerID != null)
                    cStage.ownerID = (int)stage.ownerID;
                lStages.Add(cStage);
            }
            return lStages;
        }

        public static void StartOSK()
        {
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            string osk = null;

            if (osk == null)
            {
                osk = System.IO.Path.Combine(System.IO.Path.Combine(windir, "sysnative"), "osk.exe");
                if (!File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = System.IO.Path.Combine(System.IO.Path.Combine(windir, "system32"), "osk.exe");
                if (!File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = "osk.exe";
            }

            Process.Start(osk);
        }

        public static void StopOSK()
        {
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            string osk = null;

            if (osk == null)
            {
                osk = System.IO.Path.Combine(System.IO.Path.Combine(windir, "sysnative"), "osk.exe");
                if (!File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = System.IO.Path.Combine(System.IO.Path.Combine(windir, "system32"), "osk.exe");
                if (!File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = "osk.exe";
            }

            Process[] proc = Process.GetProcessesByName("osk");
            foreach (Process p in proc)
            {
                p.Kill();
            }
        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static void DeleteItemLog(int itemGroupID)
        {
            CellappsDataContext db = new CellappsDataContext();
            var query = from il in db.Item_Logs
                        where il.Item_Group_ID == itemGroupID && il.Item_Status_ID == 125
                        select il;

            foreach (Item_Log l in query)
            {
                db.Item_Logs.DeleteOnSubmit(l);
            }
            db.SubmitChanges();
        }

        public static string FormatTileText(cBlock bl)
        {
            string txt = string.Empty;
            if (bl.Pieces != string.Empty)
            {
                if (bl.EmbedComplete)
                {
                    txt = "<size=20>" + bl.BlockName + "</size><size=10>       Pieces:" + bl.Pieces + "</size><br><size=12>" + bl.SpecimenDescription + "</size><br>" + bl.EmbedBy + "<br>" + bl.EmbedTime +
                  "<br>Embed Inst:<color=black> " + bl.EmbeddingInstruction.IsNull("None") + "</color><br>Order Inst: <color=black>" + bl.OrderInstructions.IsNull("None") + "</color>";
                }
                else
                {
                    txt = "<size=20>" + bl.BlockName + "</size><size=10>       Pieces:" + bl.Pieces + "</size><br><size=12>" + bl.SpecimenDescription + "</size>" +
                    "<br>Embed Inst:<color=black> " + bl.EmbeddingInstruction.IsNull("None") + "</color><br>Order Inst: <color=black>" + bl.OrderInstructions.IsNull("None") + "</color>";
                }

            }
            else
            {
                if (bl.EmbedComplete)
                {
                    txt = "<size=20>" + bl.BlockName + "</size><br><size=12>" + bl.SpecimenDescription + "</size><br>" + bl.EmbedBy + "<br>" + bl.EmbedTime +
                    "<br>Embed Inst:<color=black> " + bl.EmbeddingInstruction.IsNull("None") + "</color><br>Order Inst: <color=black>" + bl.OrderInstructions.IsNull("None") + "</color>";
                }
                else
                {
                    txt = "<size=20>" + bl.BlockName + "</size><br><size=12>" + bl.SpecimenDescription + "</size>" +
                     "<br>Embed Inst:<color=black> " + bl.EmbeddingInstruction.IsNull("None") + "</color><br>Order Inst: <color=black>" + bl.OrderInstructions.IsNull("None") + "</color>";
                }
            }
            return txt;
        }

        public static string FormatTileText(cSlide sl)
        {
            string txt = string.Empty;

            if (sl.CutComplete)
            {
                DateTimeFormatInfo fmt = (new CultureInfo("hr-HR")).DateTimeFormat;
                txt = "<size=20>" + sl.Label + "</size><size=15><color=black>    " + sl.Levels + "</color></size><size=10>" + sl.Code + "</size><br><size=12>" + sl.SpecimenDescription.SetLength(50) + "</size><br>" + sl.CutBy + "  " + sl.CutTime.ToString("M/d/yy") + " " + sl.CutTime.ToString("t", fmt) + "<size=10><br>" + sl.Instructions + "</size>";
            }
            else
            {
                txt = "<size=20>" + sl.Label + "</size><size=15><color=black>    " + sl.Levels + "</color></size><size=10> " + sl.Code + "</size><br><size=12>" + sl.SpecimenDescription.SetLength(50) + "</size><br>" + sl.Instructions;
            }

            return txt;
        }

        //private static string formatLevelText(cSlide sl)
        //{
        //    string levels = string.Empty;

        //    if (sl.StartLevel > 0 && sl.EndLevel > 0)
        //    {
        //        levels = sl.StartLevel + "-" + sl.EndLevel;
        //    }


        //    return levels;
        //}

        public static List<cUser> GetPatholigists()
        {
            List<cUser> lUsers = new List<cUser>();
            CellappsDataContext db = new CellappsDataContext();
            var query = from u in db.Users
                        join ur in db.User_Roles on u.User_ID equals ur.User_ID
                        where ur.Role_ID == (int)Enums.Roles.DistributionPath //&& Convert.ToBoolean(u.Active) == true
                        orderby u.Last_Name
                        select u;
            foreach (User u in query)
            {
                cUser temp = new cUser();
                temp.UserID = u.User_ID;
                if (u.PowerPath_ID != null)
                    temp.PPuserID = (int)u.PowerPath_ID;
                temp.Name = u.Full_Name;
                temp.Login = u.Login;
                if (u.Badge_Number != null)
                    temp.BadgeNumber = (int)u.Badge_Number;
                temp.Email = u.Email_Address;
                if (isNumeric(u.User_Type_ID.ToString()))
                    temp.UserTypeID = (int)u.User_Type_ID;
                lUsers.Add(temp);
            }
            return lUsers;
        }

        public static List<cOverride> GetOverrides()
        {
            List<cOverride> lOverrides = new List<cOverride>();
            CellappsDataContext db = new CellappsDataContext();
            var query = from over in db.STS_Overrides
                        select over;
            foreach (STS_Override s in query)
            {
                cOverride co = new cOverride();
                co.Description = s.Description;
                co.Required = true;
                lOverrides.Add(co);
            }
            return lOverrides;
        }

        public static List<cLocation> getDestinations()
        {
            List<cLocation> lLocations = new List<cLocation>();
            CellappsDataContext db = new CellappsDataContext();
            var query = from loc in db.Locations
                        join attrb in db.Location_Attributes on loc.Location_ID equals attrb.Location_ID
                        where attrb.Location_Attribute_Type_ID == 1
                        orderby loc.Description
                        select loc;
            foreach (Location l in query)
            {
                cLocation temp = new cLocation();
                temp.area = l.Area;
                temp.description = l.Description;
                temp.locationID = l.Location_ID;
                temp.note = l.Note;
                temp.organizationID = l.Organization_ID;
                temp.plNumber = l.Abbreviation;
                lLocations.Add(temp);
            }
            cLocation pathBox = new cLocation();
            pathBox.description = "Pathologist Box";
            pathBox.locationID = -1;
            lLocations.Insert(0, pathBox);
            return lLocations;
        }
        public static void RemoveTiles(List<TileItem> lti)
        {
            foreach (TileItem ti in lti)
            {
                TileGroup tg = ti.Group;
                if (tg != null)
                    tg.Items.Remove(ti);
            }
        }

        public static void AddTiles(List<TileItem> lti, TileGroup tg)
        {
            foreach (TileItem ti in lti)
            {
                ti.Checked = false;
                tg.Items.Add(ti);
            }
        }

        /// <summary>
        /// Colors all of the tiles in the first tilegroup of the control to colorOfTile. 
        /// Also sets the default Color to that color (in case any tiles are dynamically added).
        /// This does not change the border color or the Second backcolor.
        /// </summary>
        public static void ColorTiles(TileControl tc, Color colorOfTile)
        {
            TileGroup tg = tc.Groups[0];
            tc.AppearanceItem.Normal.BackColor = colorOfTile;
            foreach (TileItem ti in tg.Items)
                ti.AppearanceItem.Normal.BackColor = colorOfTile;
        }

        public static void FormatTileEmbed(TileItem t, cBlock bl)
        {


            t.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            t.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOff;

            t.AppearanceItem.Normal.BorderColor = Color.Black;


            if (bl.EmbedComplete)
            {
                t.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
                t.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOn;
            }
            t.Text = cMethods.FormatTileText(bl);
            t.Tag = bl;

        }

        public static int FormatTilesEmbed(TileItem t, List<cBlock> lBlocks, int count)
        {

            t.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            t.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOff;

            t.AppearanceItem.Normal.BorderColor = Color.Black;
            if (lBlocks.Count > count)
            {
                cBlock bl = lBlocks[count];

                if (bl != null)
                {
                    if (bl.EmbedComplete)
                    {
                        t.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
                        t.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOn;
                    }
                    t.Text = cMethods.FormatTileText(bl);
                    t.Tag = bl;
                    count++;
                }
            }
            return count;
        }

        public static void FormatTileCut(TileItem t, cSlide sl)
        {


            t.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            t.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOff;
            t.AppearanceItem.Normal.BorderColor = Color.Black;


            if (sl.CutComplete)
            {
                t.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
                t.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOn;
            }
            t.Text = cMethods.FormatTileText(sl);
            t.Tag = sl;

        }

        public static int FormatTilesCut(TileItem t, List<cSlide> lSlides, int count)
        {


            t.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            t.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOff;

            t.AppearanceItem.Normal.BorderColor = Color.Black;
            if (lSlides.Count > count)
            {
                cSlide sl = lSlides[count];

                if (sl != null)
                {
                    if (sl.CutComplete)
                    {
                        t.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
                        t.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOn;
                    }
                    t.Text = cMethods.FormatTileText(sl);
                    t.Tag = sl;
                    count++;
                }
            }
            return count;
        }
        public static void FormatTicketErrorTiles(TileGroup tg, ref int count)
        {
            foreach (TileItem t in tg.Items)
            {
                if (Program.TicketErrors.Count > count)
                {
                    cTicketError tick = Program.TicketErrors[count];
                    if (tick != null)
                    {
                        if (tick.description.Length > 80)//to make sure they fit on the screen. Pretty arbitrary!
                            t.Text = "<size=12>" + tick.description + "</size>";
                        else
                            t.Text = "<size=16>" + tick.description + "</size>";
                        t.Tag = tick;
                        count++;
                    }
                }
            }
        }

        /// <summary>
        /// Used for multi page forms. This gets rid of the blank tiles if there are any present. 
        /// </summary>
        /// <param name="tg">The tilegroup to remove the potential blank tiles from</param>
        /// <param name="currentEndCount">End of the current page. Not an index!</param>
        public static void RemoveEmptyTiles(TileGroup tg, int currentEndCount, int pageSize)
        {
            int lastIndexOnPage = currentEndCount % pageSize;
            if (lastIndexOnPage != 0)//divisible by pagesize so all the tile's have something on them.
            {
                for (int i = pageSize - 1; i >= lastIndexOnPage; i--)
                    tg.Items.RemoveAt(i);
            }
        }
        /// <summary>
        /// Sets all the counters in counters[] to what they should be for the current page. For an example of how this function works please see frmMultiSelectionPopup.
        /// </summary>
        /// <param name="filledTileTotal">The total number of tile items over all pages of the tilegroup</param>
        /// <param name="counters">The array of counters. Must use the same format as seen in frmMultiSelectionPopup.</param>
        /// <param name="pageSize">The size of each page.</param>
        public static void SetCountersForMultiPageForms(int filledTileTotal, ref int[] counters, int pageSize)
        {
            #region explanation
            //"MAIN_COUNT" is used for counting while tiles are coming in
            //"Current" counters represent what is currently being shown to the user.</para>
            //"Previous" counters represent what was shown to the user last page</para>
            //Next" counters represent what will be shown to the user next page.</para>
            //"Start" counters represent on which object the page starts on (not zero-based)</para>
            //"End" counters represent on which object the page ends on (not zero-based)</para>
            const int MAIN_COUNT = 0;
            const int CURRENT_START_COUNT = 1;
            const int CURRENT_END_COUNT = 2;
            const int PREVIOUS_START_COUNT = 3;
            const int PREVIOUS_END_COUNT = 4;
            const int NEXT_START_COUNT = 5;
            const int NEXT_END_COUNT = 6;
            #endregion
            counters[CURRENT_START_COUNT] = ((counters[MAIN_COUNT] / (pageSize + 1)) * (pageSize)) + 1;//if showing 1-20, should be 1. if showing 21-40 should be 21 and so forth...
            //example of ^: let pagesize=20, counters[maincount]=24 so currentstartcount should = 21.
            // 24/(20+1) = 1 (int division). 1*20 = 20. 20+1 = 1.
            counters[CURRENT_END_COUNT] = counters[MAIN_COUNT];
            counters[PREVIOUS_START_COUNT] = counters[CURRENT_START_COUNT] - pageSize;
            counters[PREVIOUS_END_COUNT] = counters[CURRENT_START_COUNT] - 1;
            counters[NEXT_START_COUNT] = counters[CURRENT_END_COUNT] + 1;
            counters[NEXT_END_COUNT] = counters[CURRENT_END_COUNT] + pageSize;
            for (int i = CURRENT_START_COUNT; i < counters.Length; i++)
            {
                if (filledTileTotal == 1)
                    counters[i] = 1;
                else if (counters[i] > filledTileTotal)
                    counters[i] = filledTileTotal;
                else if (counters[i] < 0)
                    counters[i] = 0;
            }
        }

        //Commented out portions of code are because I'm not sure the user needs that much info for issuing a ticket. -NLucyk
        public static void FormatTicketItemTiles(TileGroup tg, ref int count, Enums.TicketRecType recType)
        {
            if (recType == Enums.TicketRecType.Slides)
            {
                foreach (TileItem t in tg.Items)
                {
                    if (Program.Slides.Count > count)
                    {
                        cSlide slide = Program.Slides[count];
                        if (slide != null)
                        {
                            String txt = "";
                            /*if (slide.CutComplete)
                                txt = "<size=12>" + slide.Label + "</size><size=6>       " + slide.Code + "</size><br><size=8>" 
                                    + slide.SpecimenDescription + "</size><br>" + slide.CutBy + "<br>" + slide.CutTime;
                            else*/
                            txt = "<size=12>" + slide.Label + "</size><size=6>       " + slide.Code + "</size><br><size=8>"
                                + slide.SpecimenDescription + "</size><br>" + slide.Instructions;
                            t.Text = txt;
                            t.Tag = slide;
                            count++;
                        }
                    }
                }
            }
            else if (recType == Enums.TicketRecType.Blocks)
            {
                foreach (TileItem t in tg.Items)
                {
                    if (Program.Blocks.Count > count)
                    {
                        cBlock bl = Program.Blocks[count];
                        if (bl != null)
                        {
                            String txt = string.Empty;
                            if (bl.Pieces != string.Empty)
                            {
                                /*if (bl.EmbedComplete)
                                    txt = "<size=12>" + bl.BlockName + "</size><size=6>       Pieces:" + bl.Pieces + "</size><br><size=8>" 
                                        + bl.SpecimenDescription + "</size><br>" + bl.EmbedBy + "<br>" + bl.EmbedTime;
                                else*/
                                txt = "<size=12>" + bl.BlockName + "</size><size=6>       Pieces:" + bl.Pieces + "</size><br><size=8>"
                                    + bl.SpecimenDescription + "</size><br>" + bl.EmbeddingInstruction;
                            }
                            else
                            {
                                /*if (bl.EmbedComplete)
                                    txt = "<size=12>" + bl.BlockName + "</size><br><size=8>" + bl.SpecimenDescription + "</size><br>" + bl.EmbedBy + "<br>" + bl.EmbedTime;
                                else*/
                                txt = "<size=12>" + bl.BlockName + "</size><br><size=8>" + bl.SpecimenDescription + "</size><br>" + bl.EmbeddingInstruction;
                            }
                            t.Text = txt;
                            t.Tag = bl;
                            count++;
                        }
                    }
                }
            }
            else if (recType == Enums.TicketRecType.Specimens)
            {
                foreach (TileItem t in tg.Items)
                {
                    if (Program.Specimens.Count > count)
                    {
                        cSpecimen speci = Program.Specimens[count];
                        if (speci != null)
                        {
                            String txt = string.Empty;
                            if (speci.Description != string.Empty)
                                txt = "<size=12>" + speci.Label + "</size><size=7>       Description: " + speci.Description;
                            else
                                txt = "<size=16>" + speci.Label + "</size>";
                            t.Text = txt;
                            t.Tag = speci;
                            count++;
                        }
                    }
                }
            }
        }
        public static void InsertAudit() { InsertAudit(Program.Acc.AccID, 0, 0, string.Empty); }
        public static void InsertAudit(int Material_ID, int Material_Type_ID) { InsertAudit(Program.Acc.AccID, Material_ID, Material_Type_ID, string.Empty); }
        public static void InsertAudit(int accID, int materialID, int materialTypeID, string Note)
        {
            //VoiceDataContext db = new VoiceDataContext();
            //Acc_Audit aa = new Acc_Audit()
            //{
            //    Acc_ID = accID,
            //    Material_ID = materialID,
            //    Material_Type_ID = materialTypeID,
            //    User_ID = Program.UserID,
            //    Time_Stamp = DateTime.Now,
            //    Note = Note
            //};
            //db.Acc_Audits.InsertOnSubmit(aa);
            //db.SubmitChanges();
        }
        /// <summary>
        /// Inserts a new ticket into the database. Returns 0 if the ticket insertion failed.
        /// </summary>
        /// <author>NLucyk</author>
        public static int insertTicket(cTicketError cTick, String details, int stageID, int userID, int itemID = 0, int accID = 0, String itemName = null, String accNo = null, bool Urgent = false)
        {
            int ticketID = 0;
            CellappsDataContext db = new CellappsDataContext();
            Ticket tick = new Ticket();
            //fill all the columns with values
            tick.Ticket_Stage_ID = stageID;
            tick.Ticket_Error_ID = cTick.ticketErrorID;
            tick.Ticket_Source_ID = cTick.ticketSourceID;
            tick.Ticket_Error_Classification_ID = 1;
            tick.Ticket_Status_ID = 3;
            tick.Title = cTick.description;
            tick.Ticket_Details = details;
            if (cTick.sourceOwnerID != 0)
                tick.Assigned__To_ID = cTick.sourceOwnerID;//else null
            tick.Date_Created = DateTime.Now;
            tick.Created_By_ID = userID;
            tick.Modified_By_ID = userID;
            tick.Date_Modified = DateTime.Now;
            if (itemID != 0)
                tick.Item_ID = itemID;//else null
            tick.Item_Name = itemName;
            if (accID != 0)
                tick.Acc_ID = accID;//else null
            tick.Accession_No = accNo;
            //get it ready for submission
            tick.Urgent = Urgent;
            db.Tickets.InsertOnSubmit(tick);
            try
            {
                db.SubmitChanges();
                ticketID = tick.Ticket_ID;
            }
            catch (Exception)
            { }
            finally
            {
                InsertTicketLog(tick);
            }
            return ticketID;
        }
        /// <summary>Updates the specific ticket passed to the function. It's assumed that the Ticket passed is well formed.</summary>
        public static void UpdateTicket(Ticket toUpdate)
        {
            CellappsDataContext db = new CellappsDataContext();
            Ticket query = (from tic in db.Tickets
                            where tic.Ticket_ID == toUpdate.Ticket_ID
                            select tic).First();
            if (query != null)
            {//Currently only changes the things that are able to be updated via the frmRecentTickets. Will need to update this if you want to change more things.
                query.Ticket_Stage_ID = toUpdate.Ticket_Stage_ID;
                query.Ticket_Status_ID = toUpdate.Ticket_Status_ID;
                query.Ticket_Error_ID = toUpdate.Ticket_Error_ID;
                query.Ticket_Error_Classification_ID = toUpdate.Ticket_Error_Classification_ID;
                query.Ticket_Details = toUpdate.Ticket_Details;
                query.Modified_By_ID = toUpdate.Modified_By_ID;
                query.Date_Modified = toUpdate.Date_Modified;
                db.SubmitChanges();
                InsertTicketLog(toUpdate);
            }
        }
        public static void InsertTicketLog(Ticket tickLog)
        {
            CellappsDataContext db = new CellappsDataContext();
            Ticket_Log tLog = new Ticket_Log();
            //Copy The passed ticket into a log
            tLog.Acc_ID = (tickLog.Acc_ID != null) ? tickLog.Acc_ID : 0;
            tLog.Accession_No = tickLog.Accession_No;
            tLog.Active = true;
            tLog.Assigned_To_ID = tickLog.Assigned__To_ID;
            tLog.Created_By_ID = tickLog.Created_By_ID;
            tLog.Date_Created = DateTime.Now;
            tLog.Date_Modified = DateTime.Now;
            tLog.Item_ID = tickLog.Item_ID;
            tLog.Item_Name = tickLog.Item_Name;
            tLog.Modified_By_ID = tickLog.Modified_By_ID;
            tLog.Resolution_Details = tickLog.Resolution_Details;
            tLog.Responsible_ID = tickLog.Responsible_ID;
            tLog.Ticket_Details = tickLog.Ticket_Details;
            tLog.Ticket_Error_ID = tickLog.Ticket_Error_ID;
            tLog.Ticket_Error_Classification_ID = tickLog.Ticket_Error_Classification_ID;
            tLog.Ticket_ID = tickLog.Ticket_ID;
            tLog.Ticket_Source_ID = tickLog.Ticket_Source_ID;
            tLog.Ticket_Stage_ID = tickLog.Ticket_Stage_ID;
            tLog.Ticket_Status_ID = tickLog.Ticket_Status_ID;
            tLog.Title = "";
            //insert the ticket
            db.Ticket_Logs.InsertOnSubmit(tLog);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\n" + ex.Message);
            }
        }
        //next four functions were made for frmRecentTickets. They don't use properties like cTicket or anything like that because i dont see the point - Nathan
        public static List<Ticket> GetRecentTickets(int userID)
        {
            List<Ticket> tickets = new List<Ticket>();
            CellappsDataContext db = new CellappsDataContext();
            var query = from tick in db.Tickets
                        where tick.Created_By_ID == userID && tick.Ticket_Status_ID != 2 && tick.Date_Created > DateTime.Now.AddDays(-30)
                        orderby tick.Ticket_ID descending
                        select tick;
            foreach (Ticket t in query)
            {
                tickets.Add(t);
            }
            return tickets;
        }
        public static List<Ticket_Error_Classification> GetTicketClassifications()
        {
            List<Ticket_Error_Classification> classifications = new List<Ticket_Error_Classification>();
            CellappsDataContext db = new CellappsDataContext();
            var query = from tick in db.Ticket_Error_Classifications
                        orderby tick.Ticket_Error_Classification_ID ascending
                        select tick;
            foreach (Ticket_Error_Classification t in query)
            {
                classifications.Add(t);
            }
            return classifications;
        }
        public static List<Ticket_Statuse> GetTicketStatuses()
        {
            List<Ticket_Statuse> statuses = new List<Ticket_Statuse>();
            CellappsDataContext db = new CellappsDataContext();
            var query = from tick in db.Ticket_Statuses
                        orderby tick.Ticket_Status_ID ascending
                        select tick;
            foreach (Ticket_Statuse t in query)
            {
                statuses.Add(t);
            }
            return statuses;
        }
        public static List<Ticket_Error> GetAllTicketErrors()
        {
            List<Ticket_Error> errs = new List<Ticket_Error>();
            CellappsDataContext db = new CellappsDataContext();
            var query = from tick in db.Ticket_Errors
                        orderby tick.Description
                        select tick;
            foreach (Ticket_Error t in query)
            {
                errs.Add(t);
            }
            return errs;
        }
        //Any form that has a ticket tile on it should call this function. If the stage numbers change in the db, this should be the only place you have to change them.
        public static void GoToTicketFromAForm(Enums.Mode mode)
        {
            const int CUTTING_STAGE = 19;
            const int EMBEDDING_STAGE = 20;
            frmTicket frm;
            switch (mode)
            {
                case Enums.Mode.Cut:
                    frm = new frmTicket(CUTTING_STAGE);
                    frm.ShowDialog();
                    break;
                case Enums.Mode.Embed:
                    frm = new frmTicket(EMBEDDING_STAGE);
                    frm.ShowDialog();
                    break;
            }
        }
        public static int ConvertAmp(string val)
        {
            try
            {
                int strlen = val.Length;
                string valuetodecode = val.ToUpper();
                int currchar = 0;
                string currdigit = null;
                long retval = 0;
                long currvalue = 0;
                string stp = "N";
                while (currchar < strlen - 1 & stp == "N")
                {
                    currdigit = valuetodecode.Substring(strlen - currchar - 1, currchar + 1);
                    if (GetAsciiCode(currdigit) <= GetAsciiCode("9") & GetAsciiCode(currdigit) >= GetAsciiCode("0"))
                    {
                        currvalue = GetAsciiCode(currdigit) - GetAsciiCode("0");
                    }
                    else if (GetAsciiCode(currdigit) <= GetAsciiCode("Z") & GetAsciiCode(currdigit) >= GetAsciiCode("A"))
                    {
                        currvalue = GetAsciiCode(currdigit) - GetAsciiCode("A") + 10;
                    }
                    else
                    {
                        stp = "Y";
                    }
                    retval = retval + currvalue * Convert.ToInt64(Math.Pow(36, currchar));
                    currchar = currchar + 1;
                }
                if (retval > 2147483647) //max size for 32bit int
                    return 0;

                return Convert.ToInt32(retval);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static int GetAsciiCode(string val)
        {
            byte[] b = System.Text.Encoding.ASCII.GetBytes(val);
            return Convert.ToInt32(b[0]);
        }

        public static void GetCaseSpecimens()
        {
            PowerPathDataContext p = new PowerPathDataContext();
            var specimen = from spec in p.acc_specimens
                           join tmplt in p.tmplt_profiles on spec.tmplt_profile_id equals tmplt.id
                           where spec.acc_id == Program.Acc.AccID
                           orderby spec.specimen_label
                           select new
                           {
                               accID = spec.acc_id,
                               specimen_label = spec.specimen_label,
                               description = spec.description,
                               id = spec.id,
                               code = tmplt.code
                           };
            List<cSpecimen> specArray = new List<cSpecimen>();

            foreach (var sp in specimen)
            {
                cSpecimen cSpecimen = new cSpecimen();

                cSpecimen.AccID = sp.accID;
                cSpecimen.Label = sp.specimen_label;
                cSpecimen.code = sp.code;
                cSpecimen.Description = sp.description;
                cSpecimen.SpecimenID = sp.id;
                cSpecimen.GrossComplete = false;

                specArray.Add(cSpecimen);
            }
            Program.Specimens = specArray;
        }

        /// <summary>
        /// Optomize this sometime
        /// </summary>
        public static void GetCaseBlocks()
        {

            PowerPathDataContext p = new PowerPathDataContext();
            CellappsDataContext db = new CellappsDataContext();
            var block = from bl in p.acc_blocks
                        join spe in p.acc_specimens on bl.acc_specimen_id equals spe.id
                        join embed in p.embedding_instructions on bl.embedding_instruction_id equals embed.id into joinEmbed
                        from embed in joinEmbed.DefaultIfEmpty()
                        join order in p.acc_orders on bl.acc_order_id equals order.id into joinOrder
                        from order in joinOrder.DefaultIfEmpty()
                        where bl.acc_id == Program.Acc.AccID
                        orderby spe.specimen_label, Convert.ToInt32(bl.label)
                        select new
                        {
                            bl.acc_id,
                            bl.id,
                            bl.label,
                            bl.pieces,
                            spe.specimen_label,
                            SpecimenID = spe.id,
                            embed.description,
                            spDescription = spe.description,
                            instructions = order.instructions
                        };
            List<cBlock> blArray = new List<cBlock>();

            foreach (var bl in block)
            {
                cBlock cBlock = new cBlock();
                cBlock.AccID = bl.acc_id;
                cBlock.Block = bl.label;
                cBlock.BlockID = bl.id;
                cBlock.SpecimenLabel = bl.specimen_label;
                cBlock.BlockName = bl.specimen_label + bl.label;
                cBlock.Pieces = bl.pieces.ToString();
                cBlock.SpecimenID = bl.SpecimenID;
                cBlock.SpecimenDescription = bl.spDescription;
                cBlock.EmbeddingInstruction = bl.description;
                cBlock.OrderInstructions = bl.instructions;
                blArray.Add(cBlock);
            }
            Program.Blocks = blArray;
            SP.PowerPath.GetCtraxDetailsListBlock();

        }

        public static void GetCaseSlides()
        {

            //   SP.PowerPath.stp_Get_Case_Materials_List(Program.Acc.AccID.ToString());

            Program.Slides = SP.Tools.SP_PP_Get_Slide_Details_Case(Program.Acc.AccID);
        }


        public static void GetTicketStageName(int ticketStageID)
        {
        }
        public static void GetTicketErrors(int ticketStageID)
        {
            CellappsDataContext db = new CellappsDataContext();
            List<cTicketError> ticketList = new List<cTicketError>();
            //same as SP_Get_Ticket_Errors
            var query = from tickets in db.Ticket_Errors
                        join sources in db.Ticket_Sources on tickets.Ticket_Source_ID equals sources.Ticket_Source_ID
                        join users in db.Users on sources.Owner_ID equals users.User_ID
                        where tickets.Ticket_Stage_ID == ticketStageID
                        orderby tickets.Description
                        select new
                        {
                            ticket_Error_ID = tickets.Ticket_Error_ID,
                            description = tickets.Description,
                            source = sources.Description,
                            ticket_Source_ID = sources.Ticket_Source_ID,
                            source_owner_id = sources.Owner_ID,
                            OwnerEmail = users.Email_Address
                        };
            foreach (var ticketError in query)
            {
                cTicketError cTick = new cTicketError();
                cTick.ticketErrorID = ticketError.ticket_Error_ID;
                cTick.description = ticketError.description;
                cTick.source = ticketError.source;
                cTick.ticketSourceID = ticketError.ticket_Source_ID;
                if (ticketError.source_owner_id != null)
                    cTick.sourceOwnerID = (int)ticketError.source_owner_id;
                else
                    cTick.sourceOwnerID = 0;
                cTick.OwnerEmail = ticketError.OwnerEmail;
                ticketList.Add(cTick);
            }
            Program.TicketErrors = ticketList;
        }

        public static void GetImages()
        {
            try
            {
                PowerPathDataContext p = new PowerPathDataContext();
                p.ExecuteCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                var image = from img in p.acc_images
                            where img.acc_id == Program.Acc.AccID
                            select img;
                List<cImage> imgArray = new List<cImage>();

                foreach (acc_image acc in image)
                {
                    cImage cimg = new cImage();
                    ImageConverter ic = new ImageConverter();
                    Image img = (Image)ic.ConvertFrom(acc.data.ToArray());
                    Bitmap bitmap1 = new Bitmap(img);
                    cimg.bmpImage = bitmap1;
                    cimg.imgImage = img;
                    cimg.Image = acc.image_thumbnail.ToArray();
                    cimg.ImageThubnail = acc.image_thumbnail.ToArray();
                    cimg.AccImageTypeID = acc.image_type_id;
                    cimg.AccImageID = acc.acc_image_id;
                    cimg.Description = acc.description;
                    imgArray.Add(cimg);
                }
                Program.Images = imgArray;
            }
            catch (Exception)
            {

                MessageBox.Show("Error Getting Req Images. Try Reloading the case");
            }

        }


        public static void GetCaseSlideImages()
        {
            PowerPathDataContext p = new PowerPathDataContext();

            List<cImage> imgArray = new List<cImage>();

            var slideImages = from simg in p.accession_2s
                              join accS in p.acc_slides on simg.id equals accS.acc_id
                              join accI in p.acc_images on accS.id equals accI.acc_slide_id
                              where simg.id == Program.Acc.AccID
                              select new
                              {
                                  acc_id = simg.id,
                                  data = accI.data,
                                  image_thumbnail = accI.image_thumbnail,
                                  image_type_id = accI.image_type_id,
                                  acc_image_id = accI.acc_image_id,
                                  description = accI.description
                              };

            foreach (var acc in slideImages)
            {
                cImage cimg = new cImage();
                ImageConverter ic = new ImageConverter();
                Image img = (Image)ic.ConvertFrom(acc.data.ToArray());
                Bitmap bitmap1 = new Bitmap(img);
                cimg.bmpImage = bitmap1;
                cimg.imgImage = img;
                cimg.Image = acc.image_thumbnail.ToArray();
                cimg.ImageThubnail = acc.image_thumbnail.ToArray();
                cimg.AccImageTypeID = acc.image_type_id;
                cimg.AccImageID = acc.acc_image_id;
                cimg.Description = acc.description;
                imgArray.Add(cimg);
            }
            Program.CaseSlideImages = imgArray;
        }

        public static void GetPhoneNumbers()
        {
            List<cPhoneNumbers> list = new List<cPhoneNumbers>();
            CellappsDataContext db = new CellappsDataContext();
            var query = from u in db.Users
                        join ut in db.User_Types on u.User_Type_ID equals ut.User_Type_ID
                        where u.User_Type_ID == 1 && u.Active == true && u.Work_Phone != null
                        orderby u.Last_Name
                        select new
                        {
                            u.Name,
                            u.Work_Phone,
                            u.Mobile_Phone,
                            u.Home_Phone,
                            u.Email_Address,
                            ut.Description,
                            u.Division_ID
                        };
            foreach (var user in query)
            {
                cPhoneNumbers phone = new cPhoneNumbers();
                phone.Name = user.Name;
                phone.WorkNumber = user.Work_Phone;
                phone.MobileNumber = user.Mobile_Phone;
                phone.HomeNumber = user.Home_Phone;
                phone.Note = user.Description;
                phone.Email = user.Email_Address;
                phone.Editable = false;
                phone.PhoneNumberID = 0;
                phone.DivisionID = user.Division_ID.IsNull(0);
                list.Add(phone);
            }

            var queryExtensions = from e in db.Extensions
                                  where e.Active == true
                                  select e;
            foreach (var ext in queryExtensions)
            {
                cPhoneNumbers phone = new cPhoneNumbers();
                phone.Name = ext.Description;
                phone.WorkNumber = ext.Number;
                phone.MobileNumber = string.Empty;
                phone.HomeNumber = string.Empty;
                phone.Email = string.Empty;
                phone.Editable = false;
                phone.PhoneNumberID = 0;
                phone.DivisionID = ext.Division_ID;
                if (ext.Position_Note != null)
                {
                    phone.Note = ext.Position_Note;
                }
                else
                {
                    phone.Note = string.Empty;
                }

                list.Add(phone);
            }

            var phoneExtensions = from p in db.Phone_Numbers
                                  where p.User_ID == Program.User.UserID
                                  select p;
            foreach (var p in phoneExtensions)
            {
                cPhoneNumbers phone = new cPhoneNumbers();
                phone.Name = p.Name;
                phone.WorkNumber = p.Work_Phone;
                phone.MobileNumber = p.Mobile_Phone;
                phone.HomeNumber = p.Home_Phone;
                phone.Note = p.Note;
                phone.Editable = true;
                phone.PhoneNumberID = p.Phone_Number_ID;
                phone.Email = p.Email;
                phone.DivisionID = 0;
                list.Add(phone);
            }


            Program.PhoneNumbers = list;
        }

        public static void GetCaseCharges()
        {
            PowerPathDataContext p = new PowerPathDataContext();
            var charges = from c in p.acc_charges
                          where c.acc_id == Program.Acc.AccID
                          orderby c.sort_ord
                          select c;
            List<cCharge> chArray = new List<cCharge>();

            foreach (var ch in charges)
            {
                cCharge cCharge = new cCharge();
                cCharge.ChargeID = ch.id;
                cCharge.Code = ch.billing_code;
                cCharge.Description = ch.description;
                chArray.Add(cCharge);
            }
            Program.CaseCharges = chArray;
        }

        public static void GetCaseICD9()
        {
            List<cICD9> aryList = new List<cICD9>();
            PowerPathDataContext p = new PowerPathDataContext();
            var icd9s = from icd9 in p.acc_icd9s
                        join medcode in p.medical_codes on icd9.icd9_id equals medcode.id
                        where icd9.acc_id == Program.Acc.AccID
                        select new
                        {
                            medcode.id,
                            medcode.code,
                            medcode.description
                        };

            foreach (var icd9code in icd9s)
            {
                cICD9 c = new cICD9();
                c.Code = icd9code.code;
                c.ICD_ID = icd9code.id;
                c.Description = icd9code.description;
                aryList.Add(c);
            }
            Program.CaseICD9s = aryList;
        }


        public static List<cNoteTopic> getNoteTopics()
        {
            List<cNoteTopic> list = new List<cNoteTopic>();
            PowerPathDataContext db = new PowerPathDataContext();
            var query = from note in db.notes_topics
                        orderby note.topic
                        select note;
            foreach (var note in query)
            {
                cNoteTopic topic = new cNoteTopic();
                topic.NoteTopicID = note.id;
                topic.Description = note.topic;
                list.Add(topic);
            }
            return list;
        }

        public static void GetCaseNotes()
        {
            List<cCaseNote> aryList = new List<cCaseNote>();
            PowerPathDataContext p = new PowerPathDataContext();

            var notes = from note in p.acc_notes
                        join employee in p.personnel_2s on note.author_id equals employee.id
                        where note.acc_id == Program.Acc.AccID
                        orderby note.edit_date descending
                        select new
                        {
                            note.note,
                            note.note_text,
                            note.topic,
                            employee.full_name,
                            note.edit_date,
                            note.author_id,
                            note.id
                        };

            foreach (var note in notes)
            {

                cCaseNote c = new cCaseNote();
                c.Note = note.note.NoNull() + note.note_text.NoNull();
                c.Topic = note.topic.NoNull();
                c.By = note.full_name.NoNull();
                c.AuthorID = Convert.ToInt32(note.author_id);
                c.LastEdit = note.edit_date.ToString();
                c.NoteID = note.id;
                aryList.Add(c);
            }
            Program.CaseNotes = aryList;
        }

        public static cCaseNote GetCaseNotes(int noteID)
        {
            PowerPathDataContext p = new PowerPathDataContext();
            cCaseNote c = new cCaseNote();
            var notes = from note in p.acc_notes
                        join employee in p.personnel_2s on note.author_id equals employee.id
                        where note.id == noteID
                        orderby note.edit_date descending
                        select new
                        {
                            note.note,
                            note.note_text,
                            note.topic,
                            employee.full_name,
                            note.edit_date,
                            note.author_id,
                            note.id
                        };

            if (notes != null && notes.Count() > 0)
            {
                var note = notes.FirstOrDefault();

                c.Note = note.note.NoNull() + note.note_text.NoNull();
                c.Topic = note.topic.NoNull();
                c.By = note.full_name.NoNull();
                c.AuthorID = Convert.ToInt32(note.author_id);
                c.LastEdit = note.edit_date.ToString();
                c.NoteID = note.id;
            }
            return c;

        }


        public static List<string> GetGrossNotes(int accID)
        {
            List<string> aryList = new List<string>();
            ToolsDataContext tool = new ToolsDataContext();
            var gross = tool.SP_PP_Get_Gross_desc(accID);

            foreach (SP_PP_Get_Gross_descResult result in gross)
            {
                string desc = result.GrossDescription;
                aryList.Add(desc);
            }
            return aryList;
        }
        public static cUser CreateUser(Enums.UserCreationType uct, object value)
        {
            cUser cu = new cUser();
            cu.Roles = new List<cRole>();
            try
            {
                CellappsDataContext db = new CellappsDataContext();
                User USER = null;


                switch (uct)
                {
                    case Enums.UserCreationType.Badge:
                        var userBadge = from u in db.Users
                                        where u.Badge_Number == Convert.ToInt32(value)
                                        select u;
                        USER = userBadge.FirstOrDefault();
                        break;
                    case Enums.UserCreationType.Login:
                        var userLogin = from u in db.Users
                                        where u.Login == (string)value
                                        select u;
                        USER = userLogin.FirstOrDefault();
                        break;
                    case Enums.UserCreationType.UserID:
                        var userUserID = from u in db.Users
                                         where u.User_ID == Convert.ToInt32(value)
                                         select u;
                        USER = userUserID.FirstOrDefault();
                        break;
                    case Enums.UserCreationType.EmployeeNumber:
                        var userEmployeeNumber = from u in db.Users
                                                 where u.Employee_Number == Convert.ToInt32(value)
                                                 select u;
                        USER = userEmployeeNumber.FirstOrDefault();
                        break;
                }

                if (USER != null)
                {
                    cu.Login = USER.Login;
                    cu.Name = USER.Name;
                    cu.UserID = USER.User_ID;
                    cu.DivisionID = Convert.ToInt32(USER.Division_ID);
                    cu.PPuserID = Convert.ToInt32(USER.PowerPath_ID);
                    cu.Machine = GetMachine();
                    cu.Email = USER.Email_Address;
                    var allRoles = from uRole in db.User_Roles
                                   join role in db.Roles on uRole.Role_ID equals role.Role_ID
                                   where uRole.User_ID == cu.UserID
                                   select role;
                    foreach (Role role in allRoles)
                    {
                        cRole temp = new cRole();
                        temp.RoleID = role.Role_ID;
                        temp.Description = role.Description;
                        cu.Roles.Add(temp);
                    }
                }
            }
            catch (Exception)
            {

            }
            return cu;
        }

        public static void formatGrids(GridView dgvMaterials, int material)
        {
            if (dgvMaterials != null)
            {
                dgvMaterials.Columns[0].Visible = false;
                switch (material)
                {
                    case (int)Enums.Materials.Specimen:
                        //dgvMaterials.Columns[1].colu = "";
                        dgvMaterials.Columns[1].Width = 25;
                        dgvMaterials.Columns[2].Width = 50;
                        dgvMaterials.Columns[3].Width = 165;
                        dgvMaterials.Columns[4].Visible = false;
                        dgvMaterials.Columns[5].Visible = false;


                        break;
                    case (int)Enums.Materials.Block:

                        dgvMaterials.Columns[0].Visible = false;
                        dgvMaterials.Columns[1].Visible = false;
                        //   dgvMaterials.Columns[3].HeaderText = "";
                        dgvMaterials.Columns[3].Width = 40;
                        dgvMaterials.Columns[4].Width = 50;
                        dgvMaterials.Columns[2].Visible = false;
                        dgvMaterials.Columns[5].Visible = false;
                        dgvMaterials.Columns[6].Visible = false;
                        dgvMaterials.Columns[7].Visible = false;
                        break;
                    case (int)Enums.Materials.Slide:
                        dgvMaterials.Columns[0].Visible = false;
                        dgvMaterials.Columns[1].Visible = true;
                        dgvMaterials.Columns[2].Visible = false;
                        dgvMaterials.Columns[3].Visible = true;
                        dgvMaterials.Columns[4].Visible = false;
                        dgvMaterials.Columns[5].Visible = false;
                        dgvMaterials.Columns[6].Visible = false;
                        dgvMaterials.Columns[7].Visible = true;
                        break;

                    case (int)Enums.Materials.ICD9:
                        dgvMaterials.Columns[0].Visible = false;
                        break;
                    case (int)Enums.Materials.Charges:
                        dgvMaterials.Columns[0].Visible = false;
                        break;

                }
            }
        }

        public static int GetItemID(int itemGroupID, CellappsDataContext db)
        {
            int itemID = 0;
            var query = from ig in db.Item_Groups
                        where ig.Item_Group_ID == itemGroupID
                        select ig;
            if (query != null && query.Count() > 0)
                itemID = query.FirstOrDefault().Parent_Item_ID;

            return itemID;
        }

        public static void UpdateItemAssignedToID(int itemID, int AssignedToID, CellappsDataContext db)
        {
            db.SP_Update_Item_Assigned_To_ID(itemID, AssignedToID);
        }


        public static bool SaveForPowerPoint(Image imgTmp, string dest, PowerPoint._Presentation objPres, int heightOfAbovePhoto = 0)
        {
            // System.Drawing.Image imgTmp = null;
            double ratioDecreaseWidth = 1;
            double ratioDecreaseHeight = 1;
            System.Drawing.Bitmap imgFoto = null;
            //imgTmp = System.Drawing.Image.FromFile(src);
            int maxWidth = (int)objPres.PageSetup.SlideWidth;
            int maxHeight = (int)objPres.PageSetup.SlideHeight - heightOfAbovePhoto;
            if ((imgTmp.Width > maxWidth))
                ratioDecreaseWidth = (double)imgTmp.Width / maxWidth;//else = 1
            if ((imgTmp.Height > maxHeight))
                ratioDecreaseHeight = (double)imgTmp.Height / maxHeight;//else = 1
            double absRatioDecrease = (ratioDecreaseHeight < ratioDecreaseWidth) ? ratioDecreaseWidth : ratioDecreaseHeight; // = the biggest difference of ratio
            //absRationDecrease will be 1 if the picture doesn't need to be shrunk

            imgFoto = new System.Drawing.Bitmap(Convert.ToInt32(imgTmp.Width / absRatioDecrease), Convert.ToInt32(imgTmp.Height / absRatioDecrease));
            Rectangle recDest = new Rectangle(0, 0, imgFoto.Width, imgFoto.Height);
            Graphics gphCrop = Graphics.FromImage(imgFoto);
            gphCrop.SmoothingMode = SmoothingMode.HighQuality;
            gphCrop.CompositingQuality = CompositingQuality.HighQuality;
            gphCrop.InterpolationMode = InterpolationMode.High;
            gphCrop.DrawImage(imgTmp, recDest, 0, 0, imgTmp.Width, imgTmp.Height, GraphicsUnit.Pixel);

            System.Drawing.Imaging.Encoder myEncoder = null;
            System.Drawing.Imaging.EncoderParameter myEncoderParameter = null;
            System.Drawing.Imaging.EncoderParameters myEncoderParameters = null;
            System.Drawing.Imaging.ImageCodecInfo[] arrayICI = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            System.Drawing.Imaging.ImageCodecInfo jpegICI = null;
            int x = 0;
            for (x = 0; x <= arrayICI.Length - 1; x++)
            {
                if ((arrayICI[x].FormatDescription.Equals("JPEG")))
                {
                    jpegICI = arrayICI[x];
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
            myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 60L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            imgFoto.Save(dest, jpegICI, myEncoderParameters);
            imgFoto.Dispose();
            imgTmp.Dispose();
            return true;
        }

        public static bool SaveForPowerpoint(string src, string dest, PowerPoint._Presentation objPres, int heightOfAbovePhoto = 0)
        {
            System.Drawing.Image imgTmp = null;
            double ratioDecreaseWidth = 1;
            double ratioDecreaseHeight = 1;
            System.Drawing.Bitmap imgFoto = null;
            imgTmp = System.Drawing.Image.FromFile(src);
            int maxWidth = (int)objPres.PageSetup.SlideWidth;
            int maxHeight = (int)objPres.PageSetup.SlideHeight - heightOfAbovePhoto;
            if ((imgTmp.Width > maxWidth))
                ratioDecreaseWidth = (double)imgTmp.Width / maxWidth;//else = 1
            if ((imgTmp.Height > maxHeight))
                ratioDecreaseHeight = (double)imgTmp.Height / maxHeight;//else = 1
            double absRatioDecrease = (ratioDecreaseHeight < ratioDecreaseWidth) ? ratioDecreaseWidth : ratioDecreaseHeight; // = the biggest difference of ratio
            //absRationDecrease will be 1 if the picture doesn't need to be shrunk

            imgFoto = new System.Drawing.Bitmap(Convert.ToInt32(imgTmp.Width / absRatioDecrease), Convert.ToInt32(imgTmp.Height / absRatioDecrease));
            Rectangle recDest = new Rectangle(0, 0, imgFoto.Width, imgFoto.Height);
            Graphics gphCrop = Graphics.FromImage(imgFoto);
            gphCrop.SmoothingMode = SmoothingMode.HighQuality;
            gphCrop.CompositingQuality = CompositingQuality.HighQuality;
            gphCrop.InterpolationMode = InterpolationMode.High;
            gphCrop.DrawImage(imgTmp, recDest, 0, 0, imgTmp.Width, imgTmp.Height, GraphicsUnit.Pixel);

            System.Drawing.Imaging.Encoder myEncoder = null;
            System.Drawing.Imaging.EncoderParameter myEncoderParameter = null;
            System.Drawing.Imaging.EncoderParameters myEncoderParameters = null;
            System.Drawing.Imaging.ImageCodecInfo[] arrayICI = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            System.Drawing.Imaging.ImageCodecInfo jpegICI = null;
            int x = 0;
            for (x = 0; x <= arrayICI.Length - 1; x++)
            {
                if ((arrayICI[x].FormatDescription.Equals("JPEG")))
                {
                    jpegICI = arrayICI[x];
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
            myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 60L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            imgFoto.Save(dest, jpegICI, myEncoderParameters);
            imgFoto.Dispose();
            imgTmp.Dispose();
            return true;
        }

        public static bool SaveThumb(string src, string dest, int width = 96)
        {
            System.Drawing.Image imgTmp = null;
            double sf = 0;
            // int w = 96;
            System.Drawing.Bitmap imgFoto = null;
            imgTmp = System.Drawing.Image.FromFile(src);
            if ((imgTmp.Width > width))
            {
                sf = imgTmp.Width / width;
                imgFoto = new System.Drawing.Bitmap(width, Convert.ToInt32(imgTmp.Height / sf));
                Rectangle recDest = new Rectangle(0, 0, width, imgFoto.Height);
                Graphics gphCrop = Graphics.FromImage(imgFoto);
                gphCrop.SmoothingMode = SmoothingMode.HighQuality;
                gphCrop.CompositingQuality = CompositingQuality.HighQuality;
                gphCrop.InterpolationMode = InterpolationMode.High;
                gphCrop.DrawImage(imgTmp, recDest, 0, 0, imgTmp.Width, imgTmp.Height, GraphicsUnit.Pixel);
            }
            else
            {
                imgFoto = (System.Drawing.Bitmap)imgTmp;
            }
            System.Drawing.Imaging.Encoder myEncoder = null;
            System.Drawing.Imaging.EncoderParameter myEncoderParameter = null;
            System.Drawing.Imaging.EncoderParameters myEncoderParameters = null;
            System.Drawing.Imaging.ImageCodecInfo[] arrayICI = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            System.Drawing.Imaging.ImageCodecInfo jpegICI = null;
            int x = 0;
            for (x = 0; x <= arrayICI.Length - 1; x++)
            {
                if ((arrayICI[x].FormatDescription.Equals("JPEG")))
                {
                    jpegICI = arrayICI[x];
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
            myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 60L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            imgFoto.Save(dest, jpegICI, myEncoderParameters);
            imgFoto.Dispose();
            imgTmp.Dispose();
            return true;
        }

        public static Image GetThumb(Image imgFull, int width = 96)
        {
            System.Drawing.Image imgTmp = null;
            double sf = 0;
            System.Drawing.Bitmap imgFoto = null;
            imgTmp = (Image)imgFull.Clone();
            if ((imgTmp.Width > width))
            {
                sf = imgTmp.Width / width;
                imgFoto = new System.Drawing.Bitmap(width, Convert.ToInt32(imgTmp.Height / sf));
                Rectangle recDest = new Rectangle(0, 0, width, imgFoto.Height);
                Graphics gphCrop = Graphics.FromImage(imgFoto);
                gphCrop.SmoothingMode = SmoothingMode.HighQuality;
                gphCrop.CompositingQuality = CompositingQuality.HighQuality;
                gphCrop.InterpolationMode = InterpolationMode.High;
                gphCrop.DrawImage(imgTmp, recDest, 0, 0, imgTmp.Width, imgTmp.Height, GraphicsUnit.Pixel);
            }
            else
            {
                imgFoto = (System.Drawing.Bitmap)imgTmp;
            }
            System.Drawing.Imaging.Encoder myEncoder = null;
            System.Drawing.Imaging.EncoderParameter myEncoderParameter = null;
            System.Drawing.Imaging.EncoderParameters myEncoderParameters = null;
            System.Drawing.Imaging.ImageCodecInfo[] arrayICI = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            System.Drawing.Imaging.ImageCodecInfo jpegICI = null;
            int x = 0;
            for (x = 0; x <= arrayICI.Length - 1; x++)
            {
                if ((arrayICI[x].FormatDescription.Equals("JPEG")))
                {
                    jpegICI = arrayICI[x];
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            //myEncoder = System.Drawing.Imaging.Encoder.Quality;
            //myEncoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
            //myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 60L);
            //myEncoderParameters.Param[0] = myEncoderParameter;
            //imgFoto.Save(dest, jpegICI, myEncoderParameters);
            //imgFoto.Dispose();
            imgTmp.Dispose();
            return imgFoto;
        }



        public static byte[] Getpic(string fullpath)
        {
            System.IO.FileStream fs = new System.IO.FileStream(fullpath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
            int iLen = Convert.ToInt32(fs.Length);
            byte[] bBLOBStorage = new byte[iLen + 1];
            fs.Read(bBLOBStorage, 0, iLen);
            fs.Close();
            return bBLOBStorage;
        }

        public static string SpliceText(string text, int lineLength)
        {
            if (text != null)
            {
                return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
            }
            else
            {
                return string.Empty;
            }
        }


        /// <summary>A more generic version of populate printers. This does not populate anything, simply returns what can be used to populate something.</summary>
        /// <returns>A list of all the printers that match the type id</returns>
        public static List<cPrinter> getPrinters(int printerTypeID)
        {

            CellappsDataContext db = new CellappsDataContext();
            List<cPrinter> lPrinters = new List<cPrinter>();
            var query = from p in db.Printers
                        join l in db.Locations on p.Location_ID equals l.Location_ID
                        where p.Printer_Type_ID == printerTypeID && l.Area == Program.User.DivisionID
                        select p;
            if (query != null && query.Count() > 0)
            {
                foreach (Printer print in query)
                {
                    cPrinter item = new cPrinter();
                    item.Description = print.Description;
                    item.PrinterID = print.Printer_ID;
                    item.UNC = print.UNC;
                    lPrinters.Add(item);
                }
            }

            return lPrinters;
        }
        public static cPrinter GetSinglePrinter(int printerTypeID, string printerDesc)
        {
            CellappsDataContext db = new CellappsDataContext();
            Printer print = (from p in db.Printers
                             where p.Printer_Type_ID == printerTypeID && p.Description == printerDesc
                             select p).SingleOrDefault();
            cPrinter item = new cPrinter();
            item.Description = print.Description;
            item.PrinterID = print.Printer_ID;
            item.UNC = print.UNC;
            return item;
        }
        public static void SetDefaultPrinter()
        {
            CellappsDataContext db = new CellappsDataContext();
            var query = from p in db.Printers
                        where p.Printer_ID == Program.Machine.PrinterID
                        select p;
            if (query.Count() > 0)
            {
                cPrinter cp = new cPrinter();
                cp.PrinterID = query.FirstOrDefault().Printer_ID;
                cp.Description = query.FirstOrDefault().Description;
                cp.UNC = query.FirstOrDefault().UNC;
                Program.User.Printer = cp;
            }
            else
            {
                var lastSelectedPrinterQuery = from up in db.User_Printers
                                               join p in db.Printers on up.Printer_ID equals p.Printer_ID
                                               where up.Default_Printer && up.User_ID == Program.User.UserID
                                               select p;
                if (lastSelectedPrinterQuery.Count() > 0)
                {
                    cPrinter cp = new cPrinter();
                    cp.PrinterID = lastSelectedPrinterQuery.FirstOrDefault().Printer_ID;
                    cp.Description = lastSelectedPrinterQuery.FirstOrDefault().Description;
                    cp.UNC = lastSelectedPrinterQuery.FirstOrDefault().UNC;
                    Program.User.Printer = cp;
                }
            }
            db.Connection.Close();
        }

        /* public static void SetDefaultPrinter(System.Windows.Forms.ComboBox cb)
         {
             CellappsDataContext db = new CellappsDataContext();
             var query = from up in db.User_Printers
                         join p in db.Printers on up.Printer_ID equals p.Printer_ID
                         where up.Default_Printer && up.User_ID == Program.User.UserID
                         select p;

             if (query.Count() > 0)
             {
                 if (cb != null)
                 {
                     foreach (Printer print in query)
                     {
                         foreach (ComboboxItem item in cb.Items)
                         {
                             if (item.Text == print.Description)
                             {
                                 cb.SelectedItem = item;
                                 cPrinter cp = new cPrinter();
                                 cp.PrinterID = print.Printer_ID;
                                 cp.Description = print.Description;
                                 cp.UNC = print.UNC;
                                 Program.User.Printer = cp;
                                 break;
                             }
                         }
                     }
                 }
                 else
                 {
                     cPrinter cp = new cPrinter();
                     cp.PrinterID = query.FirstOrDefault().Printer_ID;
                     cp.Description = query.FirstOrDefault().Description;
                     cp.UNC = query.FirstOrDefault().UNC;
                     Program.User.Printer = cp;
                 }
             }
         }*/
        /// <summary>
        /// Creates a frmMultiSelectionPopup that displays to the user all of the printers that correspond to the mode passed.
        /// <para>If the user selects a printer, the default printer for the user is updated.</para>
        /// </summary>
        public static void printerSelectionScreen(Enums.Mode mode, bool mustSelect = false, bool showPopup = true)
        {
            int printerTypeID = -1;
            switch (mode)
            {
                case Enums.Mode.Cut:
                case Enums.Mode.Embed:
                    printerTypeID = (int)Enums.PrinterTypes.Slide;
                    break;
                case Enums.Mode.Distribute:
                    printerTypeID = (int)Enums.PrinterTypes.Specimen;
                    break;
                case Enums.Mode.BlockPrint:
                    printerTypeID = (int)Enums.PrinterTypes.BlockPrint;
                    break;
                case Enums.Mode.Report:
                    printerTypeID = (int)Enums.PrinterTypes.Report;
                    break;
            }
            List<cPrinter> lPrinters = cMethods.getPrinters(printerTypeID);
            List<String> lPrinterNames = new List<string>();
            foreach (cPrinter print in lPrinters)
                lPrinterNames.Add(print.Description);
            int selectedPrinterIndex = -1;

            if (showPopup)
            {
                Source.Forms.frmMultiSelectionPopup printerSelector = new Source.Forms.frmMultiSelectionPopup(lPrinterNames, "Printer", true, mustSelect);
                printerSelector.ShowDialog();
                selectedPrinterIndex = printerSelector.returnedIndex;
            }
            else
            {
                ModifyRegistry mr = new ModifyRegistry();
                string printerID = mr.Read("Printer");
                if (printerID == null)
                {
                    Program.User.Printer = lPrinters.First();
                }
                else
                {
                    Program.User.Printer = lPrinters.Where(x => x.PrinterID == Convert.ToInt32(printerID)).First();
                }
            }

            if (selectedPrinterIndex >= 0)
            {
                Program.User.Printer = lPrinters[selectedPrinterIndex];
                if (mode != Enums.Mode.BlockPrint || mode != Enums.Mode.Report)
                    cMethods.UpdateUserPrinters(lPrinters[selectedPrinterIndex]);

                if (mode == Enums.Mode.Report)
                {
                    ModifyRegistry mr = new ModifyRegistry();
                    mr.Write("Printer", lPrinters[selectedPrinterIndex].PrinterID.ToString());
                }
            }
        }
        public static void UpdateUserPrinters(cPrinter cp)
        {
            CellappsDataContext db = new CellappsDataContext();
            db.SP_Insert_User_Printers(Program.User.UserID, cp.PrinterID);
            Program.User.Printer = cp;
        }

        public static int GetItemGroupID(int itemID)
        {
            int ItemGroupID = 0;
            CellappsDataContext db = new CellappsDataContext();
            var query = from ig in db.Item_Groups
                        where ig.Parent_Item_ID == itemID
                        select ig;

            if (query.Count() > 0)
                ItemGroupID = query.FirstOrDefault().Item_Group_ID;

            return ItemGroupID;
        }

        public static bool isNumeric(string value)
        {
            Int32 ints;
            return Int32.TryParse(value, out ints);
        }

        public static bool IsFileLocked(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public class Distribute
        {
            public static List<cBarcode> ReadBarcodes(Bitmap bmp, CiServer ci)
            {


                DateTime startTime = DateTime.Now;

                List<cBarcode> li = null;

                li = new List<cBarcode>();
                IntPtr src = IntPtr.Zero;
                //  Bitmap bmp = new Bitmap(filename);
                try
                {
                    // ClearImageFnc ciProc = new ClearImageFnc();
                    //  CiServer ci = Inlite.ClearImageNet.Server.GetThreadServer();
                    CiDataMatrix reader = ci.CreateDataMatrix();

                    reader.Directions = FBarcodeDirections.cibHorz | FBarcodeDirections.cibVert | FBarcodeDirections.cibDiag;

                    CiPdf417 pdfReader = ci.CreatePdf417();
                    pdfReader.Directions = FBarcodeDirections.cibHorz | FBarcodeDirections.cibVert | FBarcodeDirections.cibDiag;
                    pdfReader.Directions = FBarcodeDirections.cibHorz; //| FBarcodeDirections.cibVert | FBarcodeDirections.cibDiag;


                    src = bmp.GetHbitmap();
                    reader.Image.OpenFromBitmap(src);
                    reader.Find(25);

                    pdfReader.Image.OpenFromBitmap(src);
                    pdfReader.Find(25);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    foreach (CiBarcode bc in reader.Barcodes)
                    {
                        cBarcode barcode = new cBarcode();
                        CiRect rec = bc.Rect;
                        Rectangle rectangle = new Rectangle(rec.left, rec.top, 80, 80);
                        barcode.Value = bc.Text;
                        barcode.Rectangle = rectangle;
                        if (bc.Text.StartsWith("3"))
                            barcode.DecodedValue = cMethods.ConvertAmp(bc.Text);
                        else if (bc.Text.StartsWith(Program.TrayPrefix))
                        {

                        }
                        else
                        {
                            int slidid = DecodeLabflowBarcode(bc.Text);
                            if (slidid > 0)
                            {
                                barcode.DecodedValue = slidid;
                                barcode.Value = "3";
                            }
                        }

                        li.Add(barcode);
                    }

                    foreach (CiBarcode bc in pdfReader.Barcodes)
                    {
                        cBarcode barcode = new cBarcode();
                        CiRect rec = bc.Rect;
                        Rectangle rectangle = new Rectangle(rec.left, rec.top, 80, 80);
                        barcode.Value = bc.Text;
                        barcode.Rectangle = rectangle;
                        if (bc.Text.StartsWith("3"))
                            barcode.DecodedValue = cMethods.ConvertAmp(bc.Text);
                        else if (bc.Text.StartsWith(Program.TrayPrefix))
                        {

                        }
                        else
                        {
                            int slidid = DecodeLabflowBarcode(bc.Text);
                            if (slidid > 0)
                            {
                                barcode.DecodedValue = slidid;
                                barcode.Value = "3";
                            }
                        }

                        li.Add(barcode);
                    }


                }
                finally
                {
                    //  bmp.Dispose();
                    DeleteObject(src);
                    GC.Collect();
                }
                return li;


            }

            private static int DecodeLabflowBarcode(string sText)
            {
                int slideID = 0;
                try
                {
                    string[] barcode = sText.Split('~');
                    string accession = barcode[0];
                    string slide = barcode[1];
                    CellappsDataContext db = new CellappsDataContext();
                    var query = from s in db.Temp_Slides
                                where s.Accession_No == accession && s.Slide_Number.Replace(" ", "") == slide
                                select s;
                    slideID = query.First().Slide_ID;
    
                }
                catch (Exception)
                {
                    
                }
                return slideID;
            }
            public static string ReadTrayBarcode(Bitmap bmp, CiServer ci)
            {
                string value = string.Empty;

                IntPtr src = IntPtr.Zero;

                CiDataMatrix reader = ci.CreateDataMatrix();
                reader.Directions = FBarcodeDirections.cibHorz | FBarcodeDirections.cibVert | FBarcodeDirections.cibDiag;
                src = bmp.GetHbitmap();
                reader.Image.OpenFromBitmap(src);
                reader.Find(1);

                foreach (CiBarcode bc in reader.Barcodes)
                {
                    value = bc.Text;
                    break;
                }

                DeleteObject(src);
                GC.Collect();

                return value;
            }

            [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
            public static extern IntPtr DeleteObject(IntPtr hDc);


            public static List<cSlide> CreateAllSlides(List<cBarcode> lBarcodes, CellappsDataContext db)
            {
                List<cSlide> lSlides = new List<cSlide>();
                int prefix = (int)Enums.ItemPrefix.Slide;

                string list = string.Join(",", (from l in lBarcodes.Where(x => x.Value.StartsWith(prefix.ToString())) select l.DecodedValue).ToArray());


                lSlides = SP.Tools.SP_PP_Get_Slide_Details_List(list, lBarcodes, db);

                var query = from lb in lBarcodes
                            where lb.DecodedValue > 0
                            select lb;

                int count = 0;
                foreach (cSlide sl in lSlides)
                {

                    FindSlot(sl);
                    count++;
                }
                return lSlides;
            }

            private static void FindSlot(cSlide sl)
            {
                foreach (cTraySlot slot in Program.TraySlots)
                {
                    Rectangle recWhole = slot.Rectangle;
                    if (recWhole.Contains(sl.Rectangle))
                    {
                        sl.TraySlot = slot.Slot;
                        //    sl.Rectangle = b.Rectangle;          //this was orgnially here. it might be a good idea that way we know it is inside a slot. if its not inside a slot then it is pretty much useless
                        sl.ParentRectangle = recWhole;
                        slot.HasBarcode = true;
                        break;
                    }
                }
            }

            //public static List<cSlide> CreateAllSlides(List<cBarcode> lBarcodes, CellappsDataContext db)
            //{
            //    List<cSlide> lSlides = new List<cSlide>();
            //    foreach (cBarcode b in lBarcodes)
            //    {

            //        string value = b.Value;
            //        if (value.StartsWith("3"))
            //        {

            //            int slideID = cMethods.ConvertAmp(value);
            //            int x = b.Rectangle.X;
            //            int y = b.Rectangle.Y;
            //            cSlide sl = cMethods.Distribute.CreateSlide(slideID, db);
            //            sl.Rectangle = b.Rectangle;
            //            foreach (cTraySlot slot in Program.TraySlots)
            //            {
            //                Rectangle recWhole = slot.Rectangle;
            //                if (recWhole.Contains(b.Rectangle))
            //                {
            //                    sl.TraySlot = slot.Slot;
            //                    // sl.Rectangle = b.Rectangle;          //this was orgnially here. it might be a good idea that way we know it is inside a slot. if its not inside a slot then it is pretty much useless
            //                    sl.ParentRectangle = recWhole;
            //                    slot.HasBarcode = true;
            //                    break;
            //                }
            //            }
            //            lSlides.Add(sl);
            //        }
            //    }
            //    return lSlides;
            //}

            public static void DrawSlideRectangles(List<cSlide> lSlides, Graphics g)
            {
                int count = 0;

                Pen pinkPen = new Pen(Color.HotPink, 10f);
                Rectangle[] recs = new Rectangle[20];
                foreach (cSlide sl in lSlides)
                {
                    recs[count] = sl.Rectangle;
                    count++;
                }
                g.DrawRectangles(pinkPen, recs);
            }

            /// <summary>
            /// Write Text on Slides and then Draw Slot Rectangles
            /// </summary>
            /// <param name="lSlides"></param>
            /// <param name="g"></param>
            public static void WriteSlideText(List<cSlide> lSlides, Graphics g)
            {
                Rectangle[] slotRects = new Rectangle[20];
                int countslotRects = 0;
                foreach (cTraySlot ts in Program.TraySlots)
                {
                    slotRects[countslotRects] = ts.Rectangle;
                    countslotRects++;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    Point pAccession = new Point(ts.Rectangle.X, ts.Rectangle.Y + 425);
                    Point pSlideNumber = new Point(ts.Rectangle.X, ts.Rectangle.Y + 525);
                    Point pCode = new Point(ts.Rectangle.X, ts.Rectangle.Y + 625);
                    Point pAssignedTo = new Point(ts.Rectangle.X, ts.Rectangle.Y + 725);
                    Point pOrderedBy = new Point(ts.Rectangle.X, ts.Rectangle.Y + 825);
                    Point pInstructions = new Point(ts.Rectangle.X, ts.Rectangle.Y + 925);
                    foreach (cSlide sl in lSlides)
                    {
                        if (sl.TraySlot == ts.Slot)
                        {

                            g.DrawString(sl.AccessionNo, new Font("Tahoma", 40), Brushes.Navy, pAccession);
                            g.DrawString(sl.Label, new Font("Tahoma", 40), Brushes.Navy, pSlideNumber);
                            g.DrawString(sl.Code, new Font("Tahoma", 40), Brushes.Navy, pCode);
                            string instructions = cMethods.SpliceText(sl.Instructions, 18);
                            string assignedTo = sl.Assigned_To.Trim(); //max 12chars
                            string orderedBy = sl.Ordered_By.Trim();

                            Brush bAssignedAndOrdered = Brushes.Navy;
                            if (sl.PP_Ordered_By_ID > 0 && sl.PP_Ordered_By_ID != sl.PP_Assigned_To_ID)
                                bAssignedAndOrdered = Brushes.DarkViolet;


                            g.FillRectangle(Brushes.White, ts.Rectangle.X, ts.Rectangle.Y + 725, ts.Rectangle.Width, ts.Rectangle.Height - 720);
                            g.DrawString("A: " + assignedTo, new Font("Tahoma", 40), bAssignedAndOrdered, pAssignedTo);
                            g.DrawString("O:" + orderedBy, new Font("Tahoma", 30), bAssignedAndOrdered, pOrderedBy);

                            g.DrawString(instructions, new Font("Tahoma", 30), Brushes.Red, pInstructions);
                            break;
                        }
                    }

                }

                Pen greenPen = new Pen(Color.DarkCyan, 6f);

                g.DrawRectangles(greenPen, slotRects);
            }

            public static cTray CreateTray(string trayBarcode, CellappsDataContext db)
            {
                cTray tray = new cTray();



                if (trayBarcode != string.Empty && trayBarcode.ToUpper().StartsWith(Program.TrayPrefix))
                {
                    int id = Convert.ToInt32(trayBarcode.ToUpper().Replace(Program.TrayPrefix, ""));

                    var queryTrays = from i in db.Items
                                     join g in db.Item_Groups on i.Item_ID equals g.Parent_Item_ID
                                     where i.Item_Type_ID == (int)Enums.ItemTypes.Tray && (i.Item_ID == id || i.External_ID == id)
                                     select new
                                     {
                                         externalID = i.External_ID,
                                         itemID = i.Item_ID,
                                         itemGroupID = g.Item_Group_ID
                                     };

                    if (queryTrays != null && queryTrays.Count() > 0)
                    {
                        var item = queryTrays.FirstOrDefault();
                        tray.ItemID = item.itemID;
                        tray.ItemGroupID = item.itemGroupID;
                        if (item.externalID > 0)
                        {
                            tray.Name = Program.TrayPrefix + item.externalID;
                        }
                        else
                        {
                            tray.Name = Program.TrayPrefix + item.itemID;
                        }

                    }


                }
                else
                {
                    tray.ItemID = 69101893;
                    tray.Name = "Temp Tray";
                    tray.ItemGroupID = 66236272;
                }
                db.SP_Delete_Slides_From_Tray(tray.ItemGroupID);
                return tray;

            }

            static public Bitmap Copy(Bitmap srcBitmap, Rectangle section)
            {
                // Create the new bitmap and associated graphics object
                Bitmap bmp = new Bitmap(section.Width, section.Height);
                Graphics g = Graphics.FromImage(bmp);

                // Draw the specified section of the source bitmap to the new one
                g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);

                // Clean up
                g.Dispose();

                // Return the bitmap
                return bmp;
            }

            /// <summary>
            /// Figure out what slot the slide is in. 
            /// Moves the horizontal and vertical rectangles representing slots around to find the best/max location where slides are inside slots
            /// </summary>
            public static void FindSlideLocations(List<cBarcode> lBarcodes)
            {
                int slideBarcodeCount = 0;

                foreach (cBarcode bc in lBarcodes)
                {
                    if (bc.Value.StartsWith("3"))
                    {
                        slideBarcodeCount++;
                    }
                }

                int currCount = 0;
                cRectangle bestV = getcRectangleHorizontal(170, 135, 170, 1400, 25, lBarcodes, -1);

                if (bestV != null)
                {
                    currCount = bestV.count;
                    if (currCount != slideBarcodeCount)
                    {
                        cRectangle bestH = getcRectangleVertical(bestV.topX, bestV.topY, bestV.bottomX, bestV.bottomY, 75, lBarcodes, bestV.count);
                        if (bestH != null)
                        {
                            if (bestH.count > currCount)
                            {
                                currCount = bestH.count;
                            }
                        }
                    }
                }

                if (currCount != slideBarcodeCount)
                {
                    cRectangle bestF1 = getcRectangleVertical(170, 135, 170, 1400, 25, lBarcodes, currCount);
                    if (bestF1 != null)
                    {
                        currCount = bestF1.count;

                        if (currCount != slideBarcodeCount)
                        {
                            cRectangle bestF2 = getcRectangleHorizontal(bestF1.topX, bestF1.topY, bestF1.bottomX, bestF1.bottomY, 100, lBarcodes, bestV.count);
                            if (bestF2 != null)
                            {
                                if (bestF2.count > currCount)
                                {
                                    currCount = bestF2.count;
                                }
                            }
                        }
                    }
                }
            }

            private static cRectangle getcRectangleHorizontal(int topX, int topY, int bottomX, int bottomY, int iterations, List<cBarcode> lBarcodes, int max)
            {
                List<cRectangle> bestRecs = new List<cRectangle>();

                for (int i = 0; i < iterations; i++)
                {
                    int count = 0;
                    topX += 2;
                    bottomX += 2;
                    List<cTraySlot> slotList = createSlotRectangles(topX, topY, bottomX, bottomY);

                    foreach (cBarcode b in lBarcodes)
                    {
                        foreach (cTraySlot slot in slotList)
                        {
                            Rectangle recWhole = slot.Rectangle;
                            if (!barcodeInSlot(b.Value))
                            {
                                if (recWhole.Contains(b.Rectangle))
                                {
                                    slot.HasBarcode = true;
                                    slot.Text = b.Value;
                                    count++;
                                    break;
                                }
                                else
                                {
                                    slot.HasBarcode = false;
                                }
                            }
                        }
                    }
                    cRectangle br = new cRectangle();
                    br.count = count;
                    br.slotList = slotList;
                    br.topX = topX;
                    br.topY = topY;
                    br.bottomX = bottomX;
                    br.bottomY = bottomY;
                    bestRecs.Add(br);
                }

                //    int max = -1;
                cRectangle best = null;
                foreach (cRectangle br in bestRecs)
                {
                    if (br.count >= max)
                    {
                        max = br.count;
                        Program.TraySlots = br.slotList;
                        best = br;
                    }
                }
                return best;
            }

            private static cRectangle getcRectangleVertical(int topX, int topY, int bottomX, int bottomY, int iterations, List<cBarcode> lBarcodes, int max)
            {
                List<cRectangle> bestRecs = new List<cRectangle>();

                for (int i = 0; i < iterations; i++)
                {
                    int count = 0;
                    topY += 2;
                    bottomY += 2;
                    List<cTraySlot> slotList = createSlotRectangles(topX, topY, bottomX, bottomY);

                    foreach (cBarcode b in lBarcodes)
                    {
                        foreach (cTraySlot slot in slotList)
                        {
                            Rectangle recWhole = slot.Rectangle;
                            if (!barcodeInSlot(b.Value))
                            {
                                if (recWhole.Contains(b.Rectangle))
                                {
                                    slot.HasBarcode = true;
                                    slot.Text = b.Value;
                                    count++;
                                    break;
                                }
                                else
                                {
                                    slot.HasBarcode = false;
                                }
                            }
                        }
                    }
                    cRectangle br = new cRectangle();
                    br.count = count;
                    br.slotList = slotList;
                    br.topX = topX;
                    br.topY = topY;
                    br.bottomX = bottomX;
                    br.bottomY = bottomY;
                    bestRecs.Add(br);
                }

                // int max = -1;
                cRectangle best = null;
                foreach (cRectangle br in bestRecs)
                {
                    if (br.count > max)
                    {
                        max = br.count;
                        Program.TraySlots = br.slotList;
                        best = br;
                    }
                }
                return best;
            }

            private static bool barcodeInSlot(string bcText)
            {
                bool found = false;
                if (Program.TraySlots != null)
                {
                    foreach (cTraySlot sl in Program.TraySlots)
                    {
                        if (sl.Text == bcText)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                return found;
            }

            private static List<cTraySlot> createSlotRectangles(int topX, int topY, int bottomX, int bottomY)
            {
                List<cTraySlot> recs = new List<cTraySlot>();

                //demensions of the tray slot
                int width = 380;
                int height = 1100;

                int space = 425;

                int growSize = 5;
                for (int i = 1; i <= 20; i++)
                {
                    int slot = i;
                    growSize += 1;
                    if (slot <= 10)
                    {
                        slot += 10;
                        if (i > 1)
                            topX += space;
                        int x = topX;

                        Rectangle rec = new Rectangle(x, topY, width, height);
                        cTraySlot sl = new cTraySlot();
                        sl.Rectangle = rec;
                        sl.HasBarcode = false;
                        sl.Slot = slot;
                        recs.Add(sl);
                    }
                    else
                    {
                        slot -= 10;
                        if (i > 11)
                        {
                            bottomX += space;
                        }
                        else
                        {
                            growSize = 1;
                        }

                        Rectangle rec = new Rectangle(bottomX, bottomY, width, height);
                        cTraySlot sl = new cTraySlot();
                        sl.Rectangle = rec;
                        sl.HasBarcode = false;
                        sl.Slot = slot;
                        recs.Add(sl);
                    }

                }
                return recs.OrderBy(x => x.Slot).ToList();
            }



            public static cSlide CreateSlide(int slideID, CellappsDataContext db)
            {

                cSlide sl = SP.Tools.SP_PP_Get_Slide_Details(slideID);

                var query = from i in db.Items
                            where i.External_ID == sl.SlideID && i.Item_Type_ID == (int)Enums.ItemTypes.Slide
                            select i;

                if (sl.PP_Assigned_To_ID == 773) //not assigned
                {
                    int userID = Convert.ToInt32(db.FN_PP_Get_Assigned_To_ID_slideID(sl.SlideID));
                    var userQuery = from u in db.Users
                                    where u.User_ID == userID
                                    select u;
                    if (userQuery.Count() > 0)
                    {
                        Source.Database.User user = userQuery.FirstOrDefault();
                        sl.Assigned_To = user.Full_Name;
                        sl.Assigned_To_ID = user.User_ID;
                    }
                }
                else
                {

                    var userQuery = from u in db.Users
                                    where u.PowerPath_ID == sl.PP_Assigned_To_ID
                                    select u;
                    if (userQuery.Count() > 0)
                    {
                        Source.Database.User user = userQuery.FirstOrDefault();
                        sl.Assigned_To = user.Full_Name;
                        sl.Assigned_To_ID = user.User_ID;
                    }
                }
                if (query.Count() > 0)
                {
                    sl.ItemID = Convert.ToInt32(query.FirstOrDefault().Item_ID);
                }
                return sl;
            }



            //Assumes lSlides' elements have a slot [0, 20] and do not have any repeats after 0 (one slot per slide)
            public static void AddSlidesToTray(List<cSlide> lSlides, cTray tray, bool library)
            {
                CellappsDataContext db = new CellappsDataContext();
                db.SP_Delete_Slides_From_Tray(tray.ItemGroupID);
                //Order the slides by trayslot. 
                string[] positionsArr = new string[21];//this avoids the cost of sorting the list
                foreach (cSlide sl in lSlides)
                {
                    db.SP_Insert_Item_Group_Items(sl.ItemID, tray.ItemGroupID, (int)Enums.ItemGroupItemTypes.Child, Program.User.UserID);
                    positionsArr[sl.TraySlot] = sl.AccessionNo;
                }
                if (!library) //if its going to the library dont care about the slide order
                    CheckForSlideOrder(positionsArr, lSlides.Count);
            }

            /// <summary>Checks to make sure the slides are in order. If they aren't, a popup will tell the user which slots are out of order.</summary>
            /// <param name="slideSlots">The Acc Numbers of all the slides (null for empty slots)</param>
            /// <param name="numElem">How many slides aren't empty</param>
            /// A slide is out of order if the accession number changes and then goes back to a previous accession number. I.E., AAAA_BBBBB_AAAA would be out of order.
            /// AAABBBB is also out of order because an empty slot is not between them.
            public static void CheckForSlideOrder(string[] slideSlots, int numElem)
            {
                const int FIRST_SLOT = 1;
                const int PREVIOUS_SLOT = -1;
                const int MAX_SLOTS = 21;
                const int SECOND_SLOT = 2;
                string outOfOrders = "";
                HashSet<string> usedAccNOs = new HashSet<string>();
                string previousAccNo = slideSlots[FIRST_SLOT];
                usedAccNOs.Add(previousAccNo);//doesn't matter if it's null
                int numElemFound = (previousAccNo != null) ? 1 : 0;
                int index = SECOND_SLOT;//start on second slot
                while (numElemFound < numElem && index < MAX_SLOTS)
                {
                    if (slideSlots[index] != null)
                    {//dont look at empty space
                        ++numElemFound;
                        if (slideSlots[index] != previousAccNo)
                        {
                            if (slideSlots[index + PREVIOUS_SLOT] == null && usedAccNOs.Add(slideSlots[index]))//.add will return true if it's added. O(1) operation
                            {//if the slot before is empty and the AccNo has not been encountered yet
                                previousAccNo = slideSlots[index];
                            }
                            else
                                outOfOrders += "\nSlot " + index;
                        }
                    }
                    ++index;
                }
                if (outOfOrders != "")
                {
                    frmSimplePopup pop = new frmSimplePopup(outOfOrders, true, "Slides out of order");
                    pop.ShowDialog();
                }
            }

            public static void SetTrayAssignedTo(List<cSlide> lSlides, cTray tray)
            {
                int userId = 0;
                cOverride co = new cOverride();
                co.Required = true;
                tray.AssignedTo = null;
                tray.Desination = null;
                if (lSlides.Count > 0)
                {
                    int count = lSlides.GroupBy(sl => sl.Assigned_To_ID).Count(); //num distinct paths

                    if (count == 1)
                        userId = lSlides[0].Assigned_To_ID; //grab the first path becuase they are all the same
                }
                if (userId != 0)// 0 if they dont all match
                {
                    cUser cu = CreateUser(Enums.UserCreationType.UserID, userId);
                    co.Required = false;

                    tray.AssignedTo = cu;
                }
                tray.Override = co;
            }

            public static void SetTrayDestAndDetails(cTray tray, GridControl gcCalendar, TileGroup tgMangmentProperties, TileGroup tgOpenShipments, bool updateDestination, CellappsDataContext db)
            {



                cUser u = tray.AssignedTo;
                if (u != null)
                {
                    var query = db.SP_Get_Pathologist_Location_From_Calix_Today(tray.AssignedTo.UserID); //u.userid
                    List<SP_Get_Pathologist_Location_From_Calix_TodayResult> l = query.ToList();
                    gcCalendar.DataSource = l;
                    if (updateDestination)
                    {
                        tray.Desination = null;
                        SP_Get_Pathologist_Location_From_Calix_TodayResult loc = l.FirstOrDefault();
                        if (loc != null)
                        {

                            cLocation cl = new cLocation();
                            cl.locationID = Convert.ToInt32(loc.Destination_ID);
                            cl.description = loc.Destination;
                            tray.Desination = cl;

                        }
                    }
                }
                if (tray.Desination == null)
                    tray.Override.Required = true;

                Color BackColorComplete = Color.FromArgb(51, 102, 204);
                Color BackColorComplete2 = Color.FromArgb(51, 102, 255);

                cTrayDetails cd = SetTrayDetails(tray, gcCalendar);
                Color BackColor = Color.FromArgb(104, 0, 0);
                Color BackColor2 = Color.FromArgb(120, 0, 0);


                foreach (TileItem ti in tgMangmentProperties.Items)
                {

                    ti.AppearanceItem.Normal.BackColor = BackColorComplete;
                    ti.AppearanceItem.Normal.BackColor2 = BackColorComplete2;

                    switch (ti.Name)
                    {
                        case "tiPropertiesPathologist":
                            if (cd.AssignedTo == null)
                            {
                                ti.AppearanceItem.Normal.BackColor = BackColor;
                                ti.AppearanceItem.Normal.BackColor2 = BackColor2;
                            }
                            ti.Text = "<size=24>Pathologist</size><br><size=12>" + cd.AssignedTo + "</size>";
                            break;
                        case "tiPropertiesDestination":
                            if (cd.Destination == null)
                            {
                                ti.AppearanceItem.Normal.BackColor = BackColor;
                                ti.AppearanceItem.Normal.BackColor2 = BackColor2;
                            }
                            ti.Text = "<size=24>Destination</size><br><size=12>" + cd.Destination + "</size>";
                            break;
                        case "tiPropertiesOverride":
                            if (cd.Override == "True" && cd.OverrideReason == null)
                            {
                                ti.AppearanceItem.Normal.BackColor = BackColor;
                                ti.AppearanceItem.Normal.BackColor2 = BackColor2;
                            }
                            ti.Text = "<size=24>Override Reason</size><br><size=12>" + cd.OverrideReason + "</size>";
                            break;
                        case "tiButtonsPrint":
                            ti.AppearanceItem.Normal.BackColor = BackColor;
                            ti.AppearanceItem.Normal.BackColor2 = BackColor2;
                            break;
                    }
                }


                if (tray.AssignedTo != null)
                {
                    var queryShip = db.SP_Get_Shipments_Assigned_To_ID(tray.AssignedTo.UserID, Program.User.Machine.LocationID);
                    List<SP_Get_Shipments_Assigned_To_IDResult> lShip = queryShip.ToList();
                    tgOpenShipments.Items.Clear();
                    foreach (SP_Get_Shipments_Assigned_To_IDResult sp in lShip)
                    {
                        cTray tempTray = new cTray();
                        tempTray.ManifestItemID = sp.Item_ID;
                        tempTray.Name = tray.Name;
                        tempTray.ItemID = tray.ItemID;
                        TileItem ti = new TileItem();
                        ti.Tag = tempTray;
                        ti.Text = sp.Manifest + "<br>C:" + sp.Time + "<br>CB:" + sp.Created_By + "<br>D:" + sp.Destination;
                        ti.IsLarge = true;

                        ti.ItemClick += ti_ItemClick;
                        tgOpenShipments.Items.Add(ti);

                    }
                }

            }

            public static void PopulateActivity(CellappsDataContext db, TileGroup tg)
            {
                tg.Items.Clear();
                var query = db.SP_Get_STS_Activity_Log(Program.User.UserID);
                Color BackColorComplete = Color.FromArgb(51, 102, 204);
                Color BackColorComplete2 = Color.FromArgb(51, 102, 255);

                List<SP_Get_STS_Activity_LogResult> l = query.ToList();

                foreach (SP_Get_STS_Activity_LogResult r in l)
                {
                    TileItem tiActivity = new TileItem();
                    tiActivity.AppearanceItem.Normal.BackColor = BackColorComplete;
                    tiActivity.AppearanceItem.Normal.BackColor2 = BackColorComplete2;
                    tiActivity.Tag = r.Item_ID;
                    tiActivity.Text = r.Item + "<br>P:" + r.Path + "<br>" + "D:" + r.Dest + "<br>C:" + r.Date_Created;
                    tiActivity.ItemClick += tiActivity_ItemClick;
                    tg.Items.Add(tiActivity);
                }


            }

            static void tiActivity_ItemClick(object sender, TileItemEventArgs e)
            {
                frmDialog frm = new frmDialog((TileItem)sender);
                frm.ShowDialog();
            }

            static void ti_ItemClick(object sender, TileItemEventArgs e)
            {


                //popup and print?
                cTray ci = (cTray)e.Item.Tag;

                DialogResult dr = MessageBox.Show("Add Tray " + ci.Name + " To Manifest MA" + ci.ManifestItemID + "?", "You Sure?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {

                    CellappsDataContext db = new CellappsDataContext();

                    db.SP_Insert_Item_Group_Items2(ci.ManifestItemID, ci.ItemID, Program.User.UserID);

                    string mst = "Tray " + ci.Name + " Added To Manifest MA" + ci.ManifestItemID;
                    frmSimplePopup frmS = new frmSimplePopup(mst, false, "SUCCESS");
                    frmS.ShowDialog();
                    frmDialog frm = new frmDialog(e.Item);
                    frm.ShowDialog();
                }

            }

            public static cTrayDetails SetTrayDetails(cTray tray, GridControl gcCalendar)
            {
                cTrayDetails cd = new cTrayDetails();
                if (tray.AssignedTo != null)
                    cd.AssignedTo = tray.AssignedTo.Name;
                if (tray.Desination != null)
                    cd.Destination = tray.Desination.description;
                if (tray.Override != null)
                {
                    cd.Override = tray.Override.Required.ToString();
                    cd.OverrideReason = tray.Override.Description;
                }
                cd.Tray = tray.Name;

                List<cTrayDetails> cList = new List<cTrayDetails>();
                cList.Add(cd);


                return cd;
            }


            public static int CreateShipment(cTray tray, CellappsDataContext db)
            {
                int shipmentItemGroupID = 0;
                int shipmentItemID = 0;
                db.CommandTimeout = 60;
                if (Program.User.Machine != null && Program.User != null && tray.Desination != null)
                {
                    shipmentItemGroupID = db.SP_Insert_Shipment(Program.User.Machine.LocationID, tray.Desination.locationID, Program.User.UserID, Program.User.Machine.MachineID);
                    shipmentItemID = cMethods.GetItemID(shipmentItemGroupID, db);

                    if (tray.Override.Required)
                    {
                        db.SP_InsertItem_LogWithNote(tray.ItemGroupID, (int)Enums.ItemStatus.Ready, Program.User.Machine.LocationID, Program.User.UserID, Program.User.Machine.MachineID, tray.Override.Description, DateTime.Now);
                    }
                    else
                    {
                        db.SP_InsertItem_Log(tray.ItemGroupID, (int)Enums.ItemStatus.Ready, Program.User.Machine.LocationID, Program.User.UserID, Program.User.Machine.MachineID);
                    }

                    // --changehere-- testing testing here
                    //shipmentItemID = 0;

                    // db.SP_InsertItem_Log(shipmentItemGroupID, (int)Enums.ItemStatus.Ready, Program.User.Machine.LocationID, Program.User.UserID, Program.User.Machine.MachineID);
                    System.Threading.Thread.Sleep(50);
                    db.SP_Insert_Item_Group_Items2(shipmentItemID, tray.ItemID, Program.User.UserID);
                    db.SP_InsertItem_Log(shipmentItemGroupID, (int)Enums.ItemStatus.ConfiguringShipment, Program.User.Machine.LocationID, Program.User.UserID, Program.User.Machine.MachineID);
                    System.Threading.Thread.Sleep(250);
                    db.SP_InsertItem_Log(shipmentItemGroupID, (int)Enums.ItemStatus.ReadyForPickup, Program.User.Machine.LocationID, Program.User.UserID, Program.User.Machine.MachineID);
                    cMethods.UpdateItemAssignedToID(shipmentItemID, tray.AssignedTo.UserID, db);
                    cMethods.UpdateItemAssignedToID(tray.ItemID, tray.AssignedTo.UserID, db);
                    db.SP_Insert_Activity_Log(Program.User.UserID, shipmentItemID);
                }
                tray.ManifestItemID = shipmentItemID;
                return shipmentItemID;
            }

            public static int LogManuallyAddedSlide(cSlide manualSlide, bool manual, CellappsDataContext db)
            {
                Slide_Distribution_Manual_Scan log = new Slide_Distribution_Manual_Scan();
                log.Slide_ID = manualSlide.SlideID;
                log.Time_Scanned = DateTime.Now;
                log.Manual = manual;
                log.User_ID = Program.User.UserID;
                log.Machine_ID = Program.User.Machine.MachineID;
                try
                {
                    db.Slide_Distribution_Manual_Scans.InsertOnSubmit(log);
                    db.SubmitChanges();
                    return log.Slide_Scan_ID;
                }
                catch { return -1; }
            }

            public static void AddTime(string action, List<cTime> ls)
            {
                cTime t = new cTime();
                t.Action = action;
                t.Time = DateTime.Now;
                if (ls.Count == 0 || action == "Done")
                {
                    t.Value = t.Time.ToString();
                }
                else if (action == "Total")
                {
                    DateTime startTime = ls[0].Time;
                    DateTime endTime = ls[ls.Count - 1].Time;
                    TimeSpan tsTotal = endTime - startTime;
                    t.Value = tsTotal.Seconds + "." + tsTotal.Milliseconds.ToString() + " sec";
                }
                else
                {
                    DateTime lastTime = ls[ls.Count - 1].Time;
                    TimeSpan ts = t.Time - lastTime;
                    t.TimeSpan = ts;
                    t.Value = ts.Seconds + "." + ts.Milliseconds.ToString() + " sec";
                }
                ls.Add(t);
            }
        }

        public static void FormatGrid(GridView gv, RepositoryItemHyperLinkEdit bID, GridColumn cID, Enums.FormControls FC)
        {
            gv.Columns.Clear();

            GridControl gc = gv.GridControl;

            CellappsDataContext cdb = new CellappsDataContext();
            var query = from f in cdb.Form_Controls
                        where
                        f.Form_Control_Parent_ID == (int)FC &&
                        f.Form_Control_Type_ID == (int)Enums.FormControlTypes.Column ||
                        f.Form_Control_Type_ID == (int)Enums.FormControlTypes.ColumnButton ||
                        f.Form_Control_Type_ID == (int)Enums.FormControlTypes.ColumnPK
                        select f;

            foreach (Form_Control fc in query)
            {
                GridColumn g = new GridColumn();
                g.Caption = fc.Display_Name;
                g.FieldName = fc.Field_Name;
                g.VisibleIndex = Convert.ToInt32(fc.Sort_Order);
                g.Visible = true;


                if (fc.Form_Control_Type_ID == (int)Enums.FormControlTypes.ColumnButton)
                {
                    g.ColumnEdit = bID;
                }
                else if (fc.Form_Control_Type_ID == (int)Enums.FormControlTypes.ColumnPK)
                {
                    g.Visible = false;
                    cID.FieldName = fc.Field_Name;
                }
                else
                {
                    g.OptionsColumn.AllowEdit = false;
                }

                gv.Columns.Add(g);
            }

            gv.Columns.Add(cID);
        }

        public static void FormatPage(XtraForm frm, Enums.FormControls FC)
        {
            CellappsDataContext cdb = new CellappsDataContext();
            var query = from f in cdb.Form_Controls
                        join font in cdb.Form_Fonts on f.Form_Font_ID equals font.Form_Font_ID into joinFormFonts
                        from font in joinFormFonts.DefaultIfEmpty()
                        where
                        f.Form_Control_Parent_ID == (int)FC &&
                        f.Form_Control_Type_ID == (int)Enums.FormControlTypes.Label ||
                        f.Form_Control_Type_ID == (int)Enums.FormControlTypes.Textbox ||
                        f.Form_Control_Type_ID == (int)Enums.FormControlTypes.Form
                        select new
                        {
                            X = Convert.ToInt32(f.Location_X),
                            Y = Convert.ToInt32(f.Location_Y),
                            Display_Name = f.Display_Name,
                            Font_Name = font.Description,
                            Font_Size = Convert.ToInt32(f.Font_Size),
                            Field_Name = f.Field_Name,
                            Focus = Convert.ToBoolean(f.Focus),
                            Form_Control_Type_ID = f.Form_Control_Type_ID,
                            Width = f.Width,
                            Height = f.Height

                        };

            foreach (var fc in query)
            {
                Font f = new System.Drawing.Font(fc.Font_Name, fc.Font_Size);
                switch (fc.Form_Control_Type_ID)
                {
                    case (int)Enums.FormControlTypes.Label:
                        LabelControl l = new LabelControl();
                        l.Location = new Point(fc.X, fc.Y);
                        l.Text = fc.Display_Name;
                        l.Font = f;
                        frm.Controls.Add(l);
                        break;
                    case (int)Enums.FormControlTypes.Textbox:
                        TextEdit te = new TextEdit();
                        te.Font = f;
                        te.Location = new Point(fc.X, fc.Y);
                        te.Tag = fc.Field_Name;
                        frm.Controls.Add(te);
                        if (fc.Focus)
                            frm.ActiveControl = te;
                        break;
                    case (int)Enums.FormControlTypes.Form:
                        frm.Width = Convert.ToInt32(fc.Width);
                        frm.Height = Convert.ToInt32(fc.Height);
                        break;
                }
            }
        }

        public static IQueryable<object> Search(List<TextEdit> lTb, IQueryable<cPatient> Query)
        {
            IQueryable<cPatient> queryTemp = Query;

            foreach (TextEdit te in lTb)
            {

                string value = te.Text;
                if (value.Length > 0) //something to search
                {
                    //  queryTemp = queryTemp.Where(te.Tag + ".contains(@0)", te.Text);
                    //  queryTemp = queryTemp.Where(te.Tag + " == @0 ", te.Text);
                    if (IsDate(value))
                    {
                        DateTime dt = Convert.ToDateTime(value);
                        queryTemp = queryTemp.Where("Convert.ToDateTime(" + te.Tag + ") == @0", dt);
                    }
                    else
                    {
                        if (value != string.Empty)
                            queryTemp = queryTemp.Where(te.Tag + ".StartsWith(@0)", value);
                    }
                }

            }
            return queryTemp;
        }

        public static IEnumerable<cPatient> SearchPatients(List<TextEdit> lTb, IQueryable<cPatient> Query)
        {

            IEnumerable<cPatient> lPatients = null;
            foreach (TextEdit te in lTb)
            {

                string value = te.Text;
                if (value.Length > 0) //something to search
                {
                    //  queryTemp = queryTemp.Where(te.Tag + ".contains(@0)", te.Text);
                    //  queryTemp = queryTemp.Where(te.Tag + " == @0 ", te.Text);
                    if (IsDate(value))
                    {
                        DateTime dt = Convert.ToDateTime(value);
                       // Query = Query.Where("Convert.ToDateTime(" + te.Tag + ") == @0", dt);
                    }
                    else
                    {
                        if (value != string.Empty)
                            lPatients = Query.Where(x => x.Last_name.StartsWith(value, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

            }
            return lPatients;
        }

        public static IQueryable<object> Search(IQueryable<object> Query, string whereField, string whereValue, string whereField2, char whereValue2, string orderBy)
        {
            IQueryable<object> queryTemp = Query;
            if (whereValue2 == 'O')
            {
                queryTemp = queryTemp.Where(whereField + ".Contains(@0)", whereValue).OrderBy(orderBy);
            }
            else
            {
                queryTemp = queryTemp.Where(whereField + ".Contains(@0) && " + whereField2 + " == @1", whereValue, whereValue2).OrderBy(orderBy);
            }
            //    queryTemp = queryTemp.Where(whereField + ".Contains(@0)", whereValue).OrderBy(orderBy);
            return queryTemp;
        }

        public static void ClearTextboxes(XtraForm frm)
        {
            foreach (Control c in frm.Controls)
            {
                if (c is TextEdit)
                {
                    TextEdit te = (TextEdit)c;
                    te.Text = string.Empty;
                }
            }
        }
       
        public static string CurrentTime()
        {
            return DateTime.Now.Day.ToString()
                 + DateTime.Now.Month.ToString()
                 + DateTime.Now.Year.ToString()
                 + DateTime.Now.Hour.ToString()
                 + DateTime.Now.Minute.ToString()
                 + DateTime.Now.Second.ToString()
                 + DateTime.Now.Millisecond.ToString();
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}

