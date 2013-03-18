using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RDPCOMAPILib;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Classes;
using System.Net.Sockets;
using System.Net;
using System.Linq;
namespace CellNetixApps.Source.Controls
{
    public partial class cScreenShare : DevExpress.XtraEditors.XtraUserControl
    {
        RDPSession x;
        cNetworkListener nl;
        public cScreenShare()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                x = new RDPSession();
            }
            catch
            {
                if (x != null)
                {
                    x.Close();
                    x = null;
                }
            }
            finally
            {

            }


            nl = new cNetworkListener(Program.frmPath);
        }

        public void Load()
        {
            CellappsDataContext db = new CellappsDataContext();
            this.gcUserStatus.DataSource = db.SP_Get_User_Status();
        }

        public void Close()
        {
            if (x != null)
            {
                x.Close();
                x = null;
            }
            if (nl != null)
                nl.Stop();
        }
        private void bDisconnect_Click(object sender, EventArgs e)
        {
            if (x != null)
            {
                x.Close();
                x = null;
            }

        }

        private void gvUserStatus_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                switch (e.CellValue.ToString())
                {
                    case "Active":
                        e.Appearance.BackColor = Color.ForestGreen;
                        break;
                    case "Offline":
                        e.Appearance.BackColor = Color.DimGray;
                        break;
                    case "Idle":
                        e.Appearance.BackColor = Color.LightGoldenrodYellow;
                        break;
                }
            }
        }

        private void bName_Click(object sender, EventArgs e)
        {
            if (x == null)
                return;
            string name = string.Empty;
            bool err = false;
            try
            {
                int rowIndex = this.gvUserStatus.FocusedRowHandle;
                int Attendee_User_ID = Convert.ToInt32(this.gvUserStatus.GetRowCellValue(rowIndex, this.cUserID));
                name = this.gvUserStatus.GetRowCellValue(rowIndex, this.cName).ToString();
                x.OnAttendeeConnected += Incoming;
                x.Open();
                IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation(name + DateTime.Now.Millisecond.ToString(), "Group_" + name + "_" + DateTime.Now.Millisecond.ToString(), "", 10);

                CellappsDataContext db = new CellappsDataContext();
                Telepathology tp = new Telepathology();
                tp.Request_User_ID = Program.User.UserID;
                tp.Attendee_User_ID = Attendee_User_ID;
                tp.Time_Stamp = DateTime.Now;
                tp.Connection_String = Invitation.ConnectionString;
                db.Telepathologies.InsertOnSubmit(tp);
                db.SubmitChanges();


                string userIpAddress = this.gvUserStatus.GetRowCellValue(rowIndex, this.cIpAddress).ToString();
               err = cMethods.SendTCPMsg(userIpAddress, name + "," + Invitation.ConnectionString);
            }
            catch (Exception)
            {
                err = true;
            }

            if (!err)
                MessageBox.Show("Invitation Sent to " + name);
        }

        private void Incoming(object Guest)
        {
            IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest;//???
            MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
        }

    }
}
