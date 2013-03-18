using CellNetixApps.Source.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace CellNetixApps.Source.Classes
{
    public class cCase
    {
        public Organization Organization { get; set; }
        public int PatientID { get; set; }
        public string Prefix { get; set; }
        public string CaseType { get; set; }
        public List<object> RefMDs { get; set; }
        public List<object> DeliveryLocations { get; set; }
        public string RevCenter { get; set; }
        public string Facility { get; set; }
        public string FeeSchedule { get; set; }
        public List<object> ReqData { get; set; }
        public string MRN { get; set; }
        public string BillingAccount { get; set; }
        public string VisitNumber { get; set; }
        public List<object> Specimens { get; set; }
        public string OrderNumber { get; set; }
        public string PatientType { get; set; }
        public List<object> LabProcedures { get; set; }
        public List<object> ICDcodes { get; set; }
    }

    public class cWebsite
    {
        public string Description { get; set; }
        public string URL { get; set; }
    }

    public class cPatient
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Mid_name { get; set; }
        public string Full_name { get; set; }
        public string Sex { get; set; }
        public string SSN { get; set; }
        public string DOB { get; set; }
        public string MRN { get; set; }
        public string Order_Number { get; set; }
        public string Facility { get; set; }
        public string Service_Code { get; set; }
        public DateTime? Created_Date { get; set; }
    }

    public class cTemplate
    {
        public int TemplateID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class cTemplateData
    {
        public int TemplateID { get; set; }
        public int TemplateTypeID { get; set; }
        public string TypeDescription { get; set; }
        public string Data { get; set; }
    }

    public class cForms
    {
        public Form Form { get; set; }
        public bool OkToDispose { get; set; }
    }
    public class cTime
    {
        public string Action { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public string Value { get; set; }
    }

    public class cOverride
    {
        public bool Required { get; set; }
        public string Description { get; set; }
    }

    public class cMachine
    {
        public int MachineID { get; set; }
        public int PrinterID { get; set; }
        public int LocationID { get; set; }
        public string Description { get; set; }
        public List<int> Attributes { get; set; }
    }
    public class cRole
    {
        public int RoleID { get; set; }
        public string Description { get; set; }
    }
    public class cPrinter
    {
        public int PrinterID { get; set; }
        public string Description { get; set; }
        public string UNC { get; set; }
    }
    public class cFileName
    {
        public string TrayFileName { get; set; }
        public string TrayFileNameArchive { get; set; }
    }

    public class cTray
    {
        public string Name { get; set; }
        public int ItemID { get; set; }
        public int ItemGroupID { get; set; }
        public int ManifestItemID { get; set; }
        public cUser AssignedTo { get; set; }
        public cLocation Desination { get; set; }
        public cOverride Override { get; set; }
    }

    public class cTrayDetails
    {
        public string Tray { get; set; }
        public string AssignedTo { get; set; }
        public string Destination { get; set; }
        public string Override { get; set; }
        public string OverrideReason { get; set; }
    }

    public class cBarcode
    {
        public string Value { get; set; }
        public Rectangle Rectangle { get; set; }
        public int DecodedValue { get; set; }
    }

    public class cTraySlot
    {
        public Rectangle Rectangle { get; set; }
        public bool HasBarcode { get; set; }
        public int Slot { get; set; }
        public string Text { get; set; }
    }

    public class cRectangle
    {
        public int count { get; set; }
        public int topX { get; set; }
        public int topY { get; set; }
        public int bottomX { get; set; }
        public int bottomY { get; set; }
        public List<cTraySlot> slotList { get; set; }
    }

    public class cUser
    {
        public int UserID { get; set; }
        public int PPuserID { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public int BadgeNumber { get; set; }
        public cPrinter Printer { get; set; }
        public cMachine Machine { get; set; }
        public List<cRole> Roles { get; set; }
        public string Email { get; set; }
        public int DivisionID { get; set; }
        public int UserTypeID { get; set; }
    }

    public class cAutoText
    {
        public int AutoTextID { get; set; }
        public int UserID { get; set; }
        public string Code { get; set; }
        public string VoiceCommand { get; set; }
        public string FinalDiagnosis { get; set; }
        public string MicroDescription { get; set; }
        public string ICD_Codes { get; set; }
        public string CPT_Codes { get; set; }
    }

    public class cPhoneNumbers
    {
        public int PhoneNumberID { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string WorkNumber { get; set; }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
        public bool Editable { get; set; }
        public string Email { get; set; }
        public int DivisionID { get; set; }
    }

    public class cEmbeddingInstructions
    {
        public int id { get; set; }
        public string description { get; set; }
    }

    public class cICD9
    {
        public int ICD_ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class cAccResult
    {
        public string Header { get; set; }
        public string Note { get; set; }
        public int Acc_Header_ID { get; set; }
    }

    public class cAutoTextOtherData
    {
        public int AutoTextOtherDataID { get; set; }
        public int AutoTextID { get; set; }
        public int AutoTextOtherDataTypeID { get; set; }
        public string TypeDescription { get; set; }
        public string Description { get; set; }
    }



    class cCaseNote
    {
        public string Note { get; set; }
        public string Topic { get; set; }
        public string By { get; set; }
        public string LastEdit { get; set; }
        public int AuthorID { get; set; }
        public int NoteID { get; set; }
    }

    public class cCharge
    {
        public int ChargeID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    class cGross
    {
        public string Full { get; set; }
        public string Brief { get; set; }
        public string Short { get; set; }
    }

    class cImage
    {
        public int AccID { get; set; }
        public string Description { get; set; }
        public int AccImageID { get; set; }
        public int AccImageTypeID { get; set; }
        public Byte[] Image { get; set; }
        public Byte[] ImageThubnail { get; set; }
        public Bitmap bmpImage { get; set; }
        public Image imgImage { get; set; }
    }

    public class cNoteTopic
    {
        public int NoteTopicID { get; set; }
        public string Description { get; set; }
    }

    public class cOrder
    {
        public int labProcedureID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    class cPrompt
    {
        public int PromptID { get; set; }
        public int AnswerID { get; set; }
        public int PromptTypeID { get; set; }
        public string PromptDescription { get; set; }
        public string AnswerDescription { get; set; }
        public bool Active { get; set; }
        public int MinChoices { get; set; }
        public int MaxChoices { get; set; }
        public int xSubStepID { get; set; }
    }


    public class cSpecimen
    {
        public int SpecimenID { get; set; }
        public string Label { get; set; }
        public string code { get; set; }
        public string Description { get; set; }
        public bool GrossComplete { get; set; }
        public int AccID { get; set; }
    }

    public class cBlock
    {
        public int BlockID { get; set; }
        public string Block { get; set; }
        public string SpecimenLabel { get; set; }
        public string BlockName { get; set; }
        public string Pieces { get; set; }
        public int SpecimenID { get; set; }
        public string SpecimenDescription { get; set; }
        public string EmbeddingInstruction { get; set; }
        public int AccID { get; set; }
        public bool EmbedComplete { get; set; }
        public DateTime EmbedTime { get; set; }
        public string EmbedBy { get; set; }
        public int EmbedByID { get; set; }
        public int ItemID { get; set; }
        public int ItemGroupID { get; set; }
        public string OrderInstructions { get; set; }
    }

    public class cSlide
    {
        public int SlideID { get; set; }
        public int BlockID { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int AccOrderID { get; set; }
        public int AccID { get; set; }
        public int AccSpecimenID { get; set; }
        public char PPstatus { get; set; }
        public string CtraxStatus { get; set; }
        public bool CutComplete { get; set; }
        public DateTime CutTime { get; set; }
        public string CutBy { get; set; }
        public int CutByID { get; set; }
        public string Instructions { get; set; }
        public string SpecimenDescription { get; set; }
        public string Procedure { get; set; }
        public string CollectionDate { get; set; }
        public string PatientName { get; set; }
        public string RevCenter { get; set; }
        public int StartLevel { get; set; }
        public int EndLevel { get; set; }
        public string Levels { get; set; }
        public int ItemID { get; set; }
        public int ItemGroupID { get; set; }
        public string EncodedValue { get; set; }
        public string Barcode { get; set; }
        public string AccessionNo { get; set; }
        public int PP_Assigned_To_ID { get; set; }
        public string Priority { get; set; }
        public string Ordered_By { get; set; }
        public int PP_Ordered_By_ID { get; set; }
        public string Assigned_To { get; set; }
        public int Assigned_To_ID { get; set; }
        public Rectangle Rectangle { get; set; }
        public Rectangle ParentRectangle { get; set; }
        public int TraySlot { get; set; }
        public string CutHistory { get; set; }
        public bool DistributeComplete { get; set; }
        public string Consult_Accession_No { get; set; }
        public int Slide_No { get; set; }
    }



    public class cTicketError
    {
        public int ticketErrorID { get; set; }
        public String source { get; set; }
        public String description { get; set; }
        public int ticketSourceID { get; set; }
        public int sourceOwnerID { get; set; }
        public string OwnerEmail { get; set; }
    }


    //not to be confused with cTicket. This is the base of the ticket types. E.G., IT, Grossing, Embedding and ect.
    //the things on http://tickets/Tickets/ShowStages.aspx
    public class cTicketStage
    {
        public int stageID { get; set; }
        public String description { get; set; }
        public int ownerID { get; set; }
    }

    class cStep
    {
        public int StepID { get; set; }
        public string Description { get; set; }
        public int AccTypeID { get; set; }
        public string AccProcedureCode { get; set; }
    }

    public class cSubStep
    {
        public int SubStepID { get; set; }
        public int StepID { get; set; }
        public string Description { get; set; }
        public int FieldID { get; set; }
        public int PromptID { get; set; }
        public int NextFormID { get; set; }
        public int SortOrder { get; set; }
        public int PromptTypeID { get; set; }
        public string StepDescription { get; set; }
        public bool Completed { get; set; }
        public bool CloseCurrentForm { get; set; }
        public DateTime DateCompleted { get; set; }
    }

    public class cBench
    {
        public int Slide_Location_ID { get; set; }
        public int Bench_Location_ID { get; set; }
        public string Day { get; set; }
        public string Location_Description { get; set; }
        public int Percent_Available { get; set; }
        public string Destination { get; set; }
        public int Destination_ID { get; set; }
    }
    public class cLocation
    {
        public int locationID { get; set; }
        public String description { get; set; }
        public int organizationID { get; set; }
        public String note { get; set; }
        public int area { get; set; }
        public String plNumber { get; set; }
    }

    public class cAccSmall
    {
        public int AccID { get; set; }
        public string AccessionNo { get; set; }
        public string[] Characters { get; set; }
    }

   public class cAcc
    {

        public int AccID { get; set; }
        public int PatientID { get; set; }
        public string AccessionNo { get; set; }
        public int AccTypeID { get; set; }
        public string AccType { get; set; }
        public char Priority { get; set; }
        public Enums.Priority Priority_Name { get; set; }
        public int currentSpecimenID { get; set; }
        public int currentBlockID { get; set; }
        public int currentSlideID { get; set; }
        public bool isFinal { get; set; }
        public bool isLocked { get; set; }
        public bool accessionNumScanned = false;
   
        /// <summary>
        /// Accession No in any form, or a slide
        /// </summary>
        /// <param name="sText"></param>
        public cAcc(string sText)
        {
            Program.LastAction = DateTime.Now;
            if (sText.Length == 0) return;
            string prefix = sText.Substring(0, 1);
            PowerPathDataContext p = new PowerPathDataContext();
            if (prefix == "1")
            {
                int specimen_id = cMethods.ConvertAmp(sText);
                var query = from s in p.acc_specimens
                            join acc in p.accession_2s on s.acc_id equals acc.id
                            where s.id == specimen_id
                            select acc;
                if (query != null && query.Count() > 0)
                {
                    AccID = query.FirstOrDefault().id;
                    AccessionNo = query.FirstOrDefault().accession_no;
                    currentSpecimenID = specimen_id;
                }
                //cMethods.db.InsertAudit(AccID, specimen_id, (int)Enum.Materials.Specimen, "Specimen Scanned");
            }
            else if (prefix == "2")
            {
                int block_id = cMethods.ConvertAmp(sText);
                var queryB = from bl in p.acc_blocks
                             join acc3 in p.accession_2s on bl.acc_id equals acc3.id
                             where bl.id == block_id
                             select acc3;
                if (queryB != null && queryB.Count() > 0)
                {
                    AccID = queryB.FirstOrDefault().id;
                    AccessionNo = queryB.FirstOrDefault().accession_no;
                    currentBlockID = block_id;
                }
                //  cMethods.db.InsertAudit(AccID, block_id, (int)Enum.Materials.Block, "Block Scanned");
            }
            else if (prefix == "3")
            {
                int slide_id = cMethods.ConvertAmp(sText);

                var slide = from sl in p.acc_slides
                            join acc in p.accession_2s on sl.acc_id equals acc.id
                            join ao in p.acc_orders on sl.acc_order_id equals ao.id
                            where sl.id == slide_id
                            select new
                            {
                                accession_no = acc.accession_no,
                                acc_id = acc.id,
                                slide_id = sl.id,
                                block_id = ao.source_rec_id
                            };
                if (slide != null && slide.Count() > 0)
                {
                    AccessionNo = slide.FirstOrDefault().accession_no;
                    AccID = slide.FirstOrDefault().acc_id;
                    currentSlideID = slide_id;
                    currentBlockID = slide.FirstOrDefault().block_id;
                }
                //  cMethods.db.InsertAudit(AccID, slide_id, (int)Enum.Materials.Slide, "Block Scanned");
            }
            else
            {
                AccessionNo = SP.PowerPath.stp_format_accession_no(sText);
                accessionNumScanned = true;
            }

            var acc2 = from acc in p.accession_2s
                       join typ in p.acc_types on acc.acc_type_id equals typ.id
                       where acc.accession_no == AccessionNo
                       select new
                       {
                           acc.accession_no,
                           acc.id,
                           acc.patient_id,
                           acc.acc_type_id,
                           typ.name,
                           acc.case_priority,
                           acc.status_final
                       };

            foreach (var ac in acc2)
            {
                AccessionNo = ac.accession_no;
                AccID = ac.id;
                PatientID = ac.patient_id;
                AccTypeID = Convert.ToInt32(ac.acc_type_id);
                AccType = ac.name;
                Priority = Convert.ToChar(ac.case_priority);
                switch (ac.case_priority)
                {
                    case (char)Enums.Priority.Normal:
                        Priority_Name = Enums.Priority.Normal;
                        break;
                    case (char)Enums.Priority.Rush:
                        Priority_Name = Enums.Priority.Rush;
                        break;
                    case (char)Enums.Priority.Priority:
                        Priority_Name = Enums.Priority.Priority;
                        break;
                    default:
                        Priority_Name = Enums.Priority.Normal;
                        break;
                }

                switch (ac.status_final)
                {
                    case 'Y':
                        isFinal = true;
                        break;
                    case 'N':
                        isFinal = false;
                        break;
                }
            }

            if (accessionNumScanned)
            {
                //  cFunctions.db.InsertAudit();
            }

            var aLocked = from acc in p.acc_locks
                          where acc.acc_id == AccID
                          select acc;
            int count = aLocked.Count();

            if (count != 0)
            {
                isLocked = true;
            }
            else
            {
                isLocked = false;
            }

 
        }

    }

}
