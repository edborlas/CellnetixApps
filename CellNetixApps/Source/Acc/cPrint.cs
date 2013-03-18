using CellNetixApps.Source.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CellNetixApps.Source.Database;
using System.Reflection;
using System.IO;
using CellNetixApps.Properties;

namespace CellNetixApps.Source.Acc
{
    public class cPrint
    {
        /// <summary>
        /// Writes a .job file for printing using NiceLabel
        /// Loops through table Print_Template_Variables and cValue parameter to determine what to write
        /// </summary>
        /// <param name="pTemplate">Print Template</param>
        /// <param name="cValue">Class that will be used to Print</param>
        /// <param name="numCopies">Number of Copies to Print</param>
        public static void Print(Enums.PrintTemplates pTemplate, object cValue, int numCopies = 1)
        {
            Print_Template template = getTemplate(pTemplate);
            var variables = getTemplateVariables(pTemplate);
            StreamWriter file = File.CreateText(template.Job_Path + cValue.GetType().Name + "_" + cMethods.CurrentTime() + Resources.PrintJob);
            try
            {
                file.WriteLine(Resources.PrintLabel + template.UNC);
                foreach (var p in variables)
                {
                    string pValue = cValue.GetType().GetProperty(p.Alt_Name).GetValue(cValue, null).ToString();
                    file.WriteLine(Resources.PrintSet +  p.Name + "  = \"" + pValue.SetLength(p.Length) + "\"");
                }
                file.WriteLine(Resources.PrintPrinter + Program.User.Printer.Description);
                file.WriteLine(Resources.PrintCopies + numCopies);
            }
            finally
            {
                file.Flush();
                file.Close();
            }
        }

        private static Print_Template getTemplate(Enums.PrintTemplates pTemplate)
        {
            CellappsDataContext db = new CellappsDataContext();
            var query = from pt in db.Print_Templates
                        where pt.Print_Template_ID == (int)pTemplate
                        select pt;
            return query.First();
        }

        private static IQueryable<Print_Template_Variable> getTemplateVariables(Enums.PrintTemplates pTemplate)
        {
            CellappsDataContext db = new CellappsDataContext();
            var query = from pv in db.Print_Template_Variables
                        where pv.Print_Template_ID == (int)pTemplate
                        select pv;
            return query;
        }


    }
}
