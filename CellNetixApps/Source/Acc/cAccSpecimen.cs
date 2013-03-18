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
    public partial class cAccSpecimen : DevExpress.XtraEditors.XtraUserControl, iAcc
    {
        List<cSpecimen> lSpecimen = new List<cSpecimen>();

        public cAccSpecimen()
        {
            InitializeComponent();
            PowerPathDataContext db = new PowerPathDataContext();
            var query = from ts in db.tmplt_specimens
                        join tp in db.tmplt_profiles on ts.tmplt_profile_id equals tp.id
                        where tp.active == 'Y' && !tp.code.StartsWith("q")
                        orderby tp.code
                        select new cSpecimen
                        {
                            code = tp.code,
                            Description = tp.description
                        };
            lSpecimen = query.ToList();
        }

        public void LoadData()
        {
            this.gcAll.DataSource = lSpecimen;

            var query = from r in lSpecimen
                        join x in cMethods.Acc.lOrgRules on r.code equals x.value
                        where x.value_type_id == (int)Enums.RuleValues.SpecimenCode
                        select r;
            this.gcSuggest.DataSource = query;
        }
    }
}
