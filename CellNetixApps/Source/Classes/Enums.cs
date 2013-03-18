using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CellNetixApps.Source.Acc;

namespace CellNetixApps.Source.Classes
{
    public class Enums
    {
        public enum PrintTemplates
        {
            Slide = 1
        }

        public enum RuleValues
        {
            RevCenter = 1,
            EnterpriseFacility = 2,
            FeeSchedule = 3,
            SpecimenCode = 31,
            CaseType = 32,
            RefmdCode = 33
        }

        public enum Move
        {
            Back = -1,
            Next = 1
        }

        public enum AccControls
        {
            cAccScan = 0,
            cAccCif = 1,
            cAccPatient = 2,
            cAccRefMD = 3,
            cAccSpecimen = 4,
            cAccOrder = 5,
            cAccCaseType = 6,
            cAccReqData = 7,
            cAccValidation = 8,
            cAccPrint = 9

        }

        public enum FormControls
        {
            frmSearch = 1
        }

        public enum FormControlTypes
        {
            Textbox = 1,
            Label = 2,
            Form = 3,
            Column = 4,
            ColumnButton = 5,
            ColumnPK = 6
        }

        public enum Patient
        {
            FirstName = 0,
            LastName = 1,
            Sex = 3,
            DOB = 4
        }


        public enum ItemPrefix
        {
            Specimen = 1,
            Block = 2,
            Slide = 3
        }

        public enum TemplateTypes
        {
            ICD9 = 1,
            ChargeCode = 2,
            Gross = 3,
            Micro = 4,
            Final = 5
        }

        public enum UserTypes
        {
            Pathologist = 1
        }

        public enum UserCreationType
        {
            Badge = 1,
            UserID = 2,
            Login = 3,
            EmployeeNumber = 4
        }

        public enum ItemGroupItemTypes
        {
            Parent = 1,
            Child = 2,
            GrandChild = 3
        }

        public enum MachineAttribtues
        {
            Emebed = 5,
            Cut = 6,
            Distribution = 7,
            Pathologist = 8,
            Admin = 9,
            BlockPrint = 10,
            ManualDistribute = 11,
            AutoLogin = 12,
            Library = 13,
            Worklist = 14
        }

        public enum ItemStatus
        {
            Available = 100,
            EmbedComplete = 125,
            CutComplete = 135,
            Ready = 200,
            ConfiguringShipment = 300,
            ReadyForPickup = 400
        }

        public enum ItemTypes
        {
            Slide = 5,
            Specimen = 6,
            Tray = 7,
            Block = 8
        }


        public enum Mode
        {
            None = 0,
            Embed = 20,
            Cut = 19,
            Login,
            Logout,
            Distribute,
            Pathologist = 14,
            Print,
            Edit,
            EditTray,
            EditSlide,
            EditPath,
            EditOverride,
            EditDest,
            BlockPrint = 99, //this is how andre fixes things. - Nathan
            Delete = 100,
            IHC = 101,
            New = 102,
            InProcess = 103,
            Complete = 104,
            Case = 105,
            Scan = 106,
            ordered_date = 107,
            accession_no = 108,
            lab_procedure_description = 109,
            History = 110,
            FilterNew = 112,
            FilterInProcess = 113,
            SearchWorklist = 114,
            SearchEverything = 115,
            FilterNone = 116,
            Report = 117,
            Expand = 118,
            Collappse = 119
        }

        public enum TicketRecType
        {//the order of these is important. They match the order of the database and this ordering is assumed in some functions.
            Specimens = 1,
            Blocks,
            Slides,
            None
        }
        public enum PrinterTypes
        {
            Specimen = 1,
            Slide = 7,
            BlockPrint = 9,
            Report = 4
        }


        public enum Priority
        {
            None = 0,
            Normal = 'N',
            Priority = 'P',
            Rush = 'R'
        }


        public enum Options
        {
            None = 0,
            PrintBlocksOnLoad = 1,
            PrintBlocksOnDemand = 2
        }

        public enum Textboxes
        {
            Clinical = 1,
            Gross = 2,
            Micro = 3,
            Final = 0
        }


        public enum Materials
        {
            None = 0,
            Specimen = 1,
            Block = 2,
            Slide = 3,
            ICD9 = 4,
            Charges = 5
        }

        public enum Steps
        {
            None = 0,
            Gross = 100,
            DermPath = 200
        }
        public enum CaseImageScanners
        {
            None = -1,
            ManualUpload = 0
        }

        public enum CaseImageTypes
        {
            None = 0,
            Req = 3,
            Micro = 2
        }

        public enum Roles
        {
            HistologyLead = 107,
            DistributionPath = 111
        }

        public enum ICD9
        {
            None = 0,
            Insert = 'A',
            Delete = 'D'
        }

        public enum Charge
        {
            None = 0,
            Insert = 'A',
            Delete = 'D'
        }

        public enum Note
        {
            None = 0,
            Insert = 'A',
            Update = 'U',
            Delete = 'D'
        }

        /// <summary>
        /// A = Add – Requires the @specimen_id and @lab_proc_code
        /// D = Delete – requires the @block_id
        /// U = Update – requires the @block_id and @pieces
        /// </summary>
        public enum Block
        {
            None = 0,
            Insert = 'A',
            Update = 'U',
            Delete = 'D'
        }

        public enum AppForms
        {
            None = 0,
            frmAdd,
            frmAutoText,
            frmBlock,
            frmCaseNotes,
            frmCommands,
            frmEditICD9,
            frmHome,
            frmPieces,
            frmQueue,
            frmRemoveICD9,
            frmSPecimen,
            frmTicket,
            frmViewImge,
            frmWorkflow
        }

        public enum PromptTypes : int
        {
            None = 0,
            Textbox = 1,
            ChecklistBox = 2,
            Specimens = 3,
            Blocks = 4,
            Slides = 5,
            PatientName = 6,
            DataGridView = 7
        }

        public enum CodeType
        {
            None = 0,
            ICD9 = 1,
            Charge = 2
        }

        public enum AutoTextOtherDataTypes
        {
            None = 0,
            ICD = 1,
            CPT = 2
        }

    }
}
