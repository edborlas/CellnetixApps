using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Classes;
using System.Linq;
namespace CellNetixApps.Source.Acc
{
    public partial class cAccCaseType : DevExpress.XtraEditors.XtraUserControl, iAcc
    {

        List<acc_type> lType = new List<acc_type>();
        PowerPathDataContext db = new PowerPathDataContext();
        public cAccCaseType()
        {
            InitializeComponent();
            var query = from a in db.acc_types
                        where a.active == 'Y' && !a.name.StartsWith("hx") && a.data_tmplt_id != null
                        orderby a.name
                        select a;

            lType = query.ToList();
        }

        public void LoadData()
        {
            this.gcAll.DataSource = lType;

            var query = from r in lType
                        join x in cMethods.Acc.lOrgRules on r.name equals x.value
                        where x.value_type_id == (int)Enums.RuleValues.CaseType
                        select r;
            this.gcSuggest.DataSource = query;
        }
    }
}
