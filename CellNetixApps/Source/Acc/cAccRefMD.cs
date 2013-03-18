using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Classes;
namespace CellNetixApps.Source.Acc
{
    public partial class cAccRefMD : DevExpress.XtraEditors.XtraUserControl, iAcc
    {
        List<refmd_2> lRefmd = new List<refmd_2>();

        PowerPathDataContext db = new PowerPathDataContext();

        public cAccRefMD()
        {
            InitializeComponent();

            var query = from r in db.refmd_2s
                        where r.active == 'Y'
                        orderby r.last_name
                        select r;
            lRefmd = query.ToList();
        }

        public void LoadData()
        {
            this.gcCC.DataSource = lRefmd;

            var query = from r in lRefmd
                        join x in cMethods.Acc.lOrgRules on r.code equals x.value
                        where x.value_type_id == (int)Enums.RuleValues.RefmdCode
                        select r;
            this.gcRefMD.DataSource = query;

        }
    }
}
