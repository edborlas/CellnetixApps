using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Forms;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Embed.Forms;

namespace CellNetixApps.Source.Lab
{
    public partial class frmWorklistSettings : DevExpress.XtraEditors.XtraForm
    {
        List<facility> lFacility;
        List<lab_dept> lLabDept;
        List<lab_dept_worklist> lWorklist;
        int Lab_FacilityID, Lab_DepartmentID, Lab_WorklistID;
        frmWorklist frmWorklist;
        public frmWorklistSettings(frmWorklist frmWorklist)
        {
            InitializeComponent();
            this.frmWorklist = frmWorklist;
            cMethods.GetFacitlities(ref lFacility);
            cMethods.GetLabDept(ref lLabDept);
            cMethods.GetLabDeptWorklists(ref lWorklist);
            cMethods.ReadRegistryValues(ref Lab_FacilityID, ref Lab_DepartmentID, ref Lab_WorklistID);
            worklistChanged();
        }

        #region "Worklist Selection"

        private void tiFacility_ItemClick(object sender, TileItemEventArgs e)
        {
            List<string> lString = lFacility.Select(x => x.name).ToList();
            frmMultiSelectionPopup frm = new frmMultiSelectionPopup(lString, "Select Facility", true);
            frm.ShowDialog();
            int selectionOfUser = frm.returnedIndex;
            if (selectionOfUser > -1)
            {
                Lab_FacilityID = lFacility[selectionOfUser].id;
                ModifyRegistry mr = new ModifyRegistry();
                mr.Write("Lab_Facility", Lab_FacilityID.ToString());
                worklistChanged();
            }
        }

        private void tiLabDept_ItemClick(object sender, TileItemEventArgs e)
        {
            List<string> lString = lLabDept.Where(x => x.facility_id == Lab_FacilityID).Select(x => x.name).ToList();
            if (lString.Count > 0)
            {
                frmMultiSelectionPopup frm = new frmMultiSelectionPopup(lString, "Select Lab Department", true);
                frm.ShowDialog();
                int selectionOfUser = frm.returnedIndex;
                if (selectionOfUser > -1)
                {
                    Lab_DepartmentID = lLabDept.Where(x => x.facility_id == Lab_FacilityID).ToList()[selectionOfUser].id;
                    ModifyRegistry mr = new ModifyRegistry();
                    mr.Write("Lab_Department", Lab_DepartmentID.ToString());
                    worklistChanged();
                }
            }
            else
            {
                frmSimplePopup frm = new frmSimplePopup("No Worklists for this Facility. Change Facility.");
                frm.ShowDialog();
            }
        }

        private void tiLabDeptWorklist_ItemClick(object sender, TileItemEventArgs e)
        {
            List<string> lString = lWorklist.Where(x => x.lab_dept_id == Lab_DepartmentID).Select(x => x.name).ToList();
            if (lString.Count > 0)
            {
                frmMultiSelectionPopup frm = new frmMultiSelectionPopup(lString, "Select Worklist", true);
                frm.ShowDialog();
                int selectionOfUser = frm.returnedIndex;
                if (selectionOfUser > -1)
                {
                    Lab_WorklistID = lWorklist.Where(x => x.lab_dept_id == Lab_DepartmentID).ToList()[selectionOfUser].id;
                    ModifyRegistry mr = new ModifyRegistry();
                    mr.Write("Lab_Worklist", Lab_WorklistID.ToString());
                    worklistChanged();
                    // getOrders();
                    frmWorklist.WorklistChanged(Lab_WorklistID);
                }
            }
            else
            {
                frmSimplePopup frm = new frmSimplePopup("No Worklists for this Department");
                frm.ShowDialog();
            }
        }

        void worklistChanged()
        {
            this.tiFacility.Text = "Facility\n" + lFacility.Where(x => x.id == Lab_FacilityID).Select(x => x.name).First();
            this.tiLabDept.Text = "Lab\n" + lLabDept.Where(x => x.id == Lab_DepartmentID).Select(x => x.name).First();
            string worklistName = lWorklist.Where(x => x.id == Lab_WorklistID).Select(x => x.name).First();
            this.tiLabDeptWorklist.Text = "Worklist\n" + worklistName;
        }
        #endregion

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}