using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Path.Forms
{
    public partial class frmTemplate : DevExpress.XtraEditors.XtraForm
    {
        public frmTemplate()
        {
            InitializeComponent();
            Point p = new Point((Screen.PrimaryScreen.Bounds.Width/2), 0);
            this.Location = p;
            getTemplateData();
        }

        void getTemplateData()
        {
            var query = from s in Program.Specimens
                        join t in Program.Templates on s.code equals t.Code
                        join td in Program.TemplateData on t.TemplateID equals td.TemplateID
                        select new
                        {
                            Code = t.Code,
                            TypeID = td.TemplateTypeID,
                            Type = td.TypeDescription,
                            Data = td.Data
                        };

            var queryFinal = from q in query
                             where q.TypeID == (int)Enums.TemplateTypes.Final
                             select q;

            var queryMicro = from q in query
                             where q.TypeID == (int)Enums.TemplateTypes.Micro
                             select q;

            var queryICD9 = from q in query
                             where q.TypeID == (int)Enums.TemplateTypes.ICD9
                             select q;

            var queryCPT = from q in query
                            where q.TypeID == (int)Enums.TemplateTypes.ChargeCode
                            select q;


            if (query != null && query.Count() > 0)
            {
                this.gFinal.DataSource = queryFinal;
                this.gMicro.DataSource = queryMicro;
                this.gICD9.DataSource = queryICD9;
                this.gCPT.DataSource = queryCPT;
            }

        }
    }
}