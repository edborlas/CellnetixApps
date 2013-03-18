using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Classes;
namespace CellNetixApps.Source.Path.Forms
{
    public partial class frmPhone : DevExpress.XtraEditors.XtraForm
    {
        frmPath frmPath;
        public frmPhone(frmPath frmPath)
        {
            InitializeComponent();
            this.frmPath = frmPath;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string name = this.tbName.Text;
            string work = this.tbWork.Text;
            string mobile = this.tbMobile.Text;
            string home = this.tbHome.Text;
            string note = this.tbNote.Text;
            string email = this.tbEmail.Text;
            CellappsDataContext db = new CellappsDataContext();
            Phone_Number p = new Phone_Number();
            bool exception = false;
            try
            {
            
                p.Name = name;
                p.Work_Phone = work;
                p.Mobile_Phone = mobile;
                p.Home_Phone = home;
                p.Note = note;
                p.User_ID = Program.User.UserID;
                p.Email = email;
                db.Phone_Numbers.InsertOnSubmit(p);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                exception = true;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (!exception)
                {
                    cPhoneNumbers phone = new cPhoneNumbers();
                    phone.Name = name;
                    phone.WorkNumber = work;
                    phone.MobileNumber = mobile;
                    phone.HomeNumber = home;
                    phone.Note = note;
                    phone.Editable = true;
                    phone.PhoneNumberID = p.Phone_Number_ID;
                    phone.Email = p.Email;
                    Program.PhoneNumbers.Add(phone);
                    frmPath.searchPhoneNumbers();
                }

                this.Close();
            }
        }
    }
}