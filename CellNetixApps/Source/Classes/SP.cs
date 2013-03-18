using CellNetixApps.Source.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraGrid;
using IDAutomation.Windows.Forms.DataMatrixBarcode;
using System.Windows.Forms;

namespace CellNetixApps.Source.Classes
{
    public class SP
    {
        public class PowerPath
        {




            public static void stp_Get_Case_Materials_List(string acc_id)
            {
                List<cSlide> myArrList = new List<cSlide>();

                List<cSpecimen> lSpecimen = new List<cSpecimen>();

                string ConnectionString = "server=cel-lis-001; database=powerpath_prod; uid=sa;pwd=mp789@i;";
                System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();

                try
                {


                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();

                    SqlDataReader myReader = null;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "stp_Get_Case_Materials_List";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = objConn;
                    cmd.Parameters.AddWithValue("@CaseID", acc_id);
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {
                        string rec_type = myReader["rec_type"].ToString();

                        switch (rec_type)
                        {
                            case "S":
                                cSpecimen sp = new cSpecimen();
                                sp.SpecimenID = Convert.ToInt32(myReader["acc_specimen_id"]);
                                sp.Description = myReader["description"].ToString();
                                lSpecimen.Add(sp);
                                break;
                            case "B":
                                break;
                            case "L":
                                cSlide sl = new cSlide();
                                sl.AccID = Convert.ToInt32(acc_id);
                                sl.AccSpecimenID = Convert.ToInt32(myReader["acc_specimen_id"]);
                                sl.SlideID = Convert.ToInt32(myReader["rec_id"].ToString());
                                sl.Label = myReader["full_label"].ToString();
                                sl.Description = myReader["description"].ToString();
                                if (myReader["acc_order_id"] != null)
                                {
                                    sl.AccOrderID = Convert.ToInt32(myReader["acc_order_id"]);

                                }
                                if (myReader["source_rec_id"] != null)
                                {
                                    sl.BlockID = Convert.ToInt32(myReader["source_rec_id"]);
                                }
                                sl.AccessionNo = Program.Acc.AccessionNo;
                                myArrList.Add(sl);
                                break;
                            default:
                                break;
                        }
                    }

                    foreach (cSlide sl in myArrList)
                    {
                        int specimenID = sl.AccSpecimenID;
                        foreach (cSpecimen sp in lSpecimen)
                        {
                            if (sp.SpecimenID == specimenID)
                            {
                                sl.SpecimenDescription = sp.Description;
                                break;
                            }
                        }
                    }

                    Program.Slides = myArrList;

                }
                catch (Exception)
                {

                }
                finally
                {
                    objConn.Close();
                }

            }

            public static void GetCtraxDetailsList()
            {


                string list = string.Join(",", (from l in Program.Slides select l.SlideID).ToArray());

                if (list == string.Empty)
                    return;

                string ConnectionString = "server=cel-sql-011; database=cellapps; uid=sa;pwd=mp789@i;";
                System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();
                try
                {


                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();
                    SqlDataReader myReader = null;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_Get_Slide_History_List";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = objConn;
                    cmd.Parameters.AddWithValue("@slideList", list);
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {


                        int Item_ID = Convert.ToInt32(myReader["Item_ID"]);
                        int Item_Group_ID = Convert.ToInt32(myReader["Item_Group_ID"]);
                        int External_ID = Convert.ToInt32(myReader["External_ID"]);

                        cSlide sl = Program.Slides.Where(x => x.SlideID == External_ID).First();
                        if (sl != null)
                        {
                            sl.ItemID = Item_ID;
                            sl.ItemGroupID = Item_Group_ID;
                            if (myReader["Item_Status_ID"] != null && myReader["Item_Status_ID"] != DBNull.Value)
                            {
                                int Item_Status_ID = Convert.ToInt32(myReader["Item_Status_ID"]);
                                if (Item_Status_ID == (int)Enums.ItemStatus.CutComplete)
                                {
                                    string Name = myReader["Name"].ToString();
                                    int User_ID = Convert.ToInt32(myReader["User_ID"]);
                                    DateTime Time_Stamp = Convert.ToDateTime(myReader["Time_Stamp"]);

                                    sl.CutBy = Name;
                                    sl.CutByID = User_ID;
                                    sl.CutTime = Time_Stamp;
                                    sl.CutComplete = true;

                                }
                                string Status_Description = myReader["Status_Description"].ToString();
                                sl.CtraxStatus = Status_Description;

                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    objConn.Close();
                }

            }

            public static void GetCtraxDetailsListBlock()
            {


                string list = string.Join(",", (from l in Program.Blocks select l.BlockID).ToArray());

                if (list == string.Empty)
                    return;

                string ConnectionString = "server=cel-sql-011; database=cellapps; uid=sa;pwd=mp789@i;";
                System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();
                try
                {


                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();
                    SqlDataReader myReader = null;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_Get_Block_History_List";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = objConn;
                    cmd.Parameters.AddWithValue("@blockList", list);
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {


                        int Item_ID = Convert.ToInt32(myReader["Item_ID"]);
                        int Item_Group_ID = Convert.ToInt32(myReader["Item_Group_ID"]);
                        int External_ID = Convert.ToInt32(myReader["External_ID"]);

                        cBlock bl = Program.Blocks.Where(x => x.BlockID == External_ID).First();
                        if (bl != null)
                        {
                            bl.ItemID = Item_ID;
                            bl.ItemGroupID = Item_Group_ID;
                            if (myReader["Item_Status_ID"] != null && myReader["Item_Status_ID"] != DBNull.Value)
                            {
                                int Item_Status_ID = Convert.ToInt32(myReader["Item_Status_ID"]);
                                if (Item_Status_ID == (int)Enums.ItemStatus.EmbedComplete)
                                {
                                    string Name = myReader["Name"].ToString();
                                    int User_ID = Convert.ToInt32(myReader["User_ID"]);
                                    DateTime Time_Stamp = Convert.ToDateTime(myReader["Time_Stamp"]);

                                    bl.EmbedBy = Name;
                                    bl.EmbedByID = User_ID;
                                    bl.EmbedTime = Time_Stamp;
                                    bl.EmbedComplete = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    objConn.Close();
                }

            }

            public static void GetAllSlideCtraxDetailsList()
            {

                string list = string.Join(",", (from l in Program.Slides select l.SlideID).ToArray());

                if (list == string.Empty)
                    return;

                string ConnectionString = "server=cel-sql-011; database=cellapps; uid=sa;pwd=mp789@i;";
                System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();
                try
                {


                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();

                    SqlDataReader myReader = null;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_Get_All_Slide_History_List";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = objConn;
                    cmd.Parameters.AddWithValue("@slideList", list);
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {


                        int Item_ID = Convert.ToInt32(myReader["Item_ID"]);
                        int Item_Group_ID = Convert.ToInt32(myReader["Item_Group_ID"]);
                        int External_ID = Convert.ToInt32(myReader["External_ID"]);

                        cSlide sl = Program.Slides.Where(x => x.SlideID == External_ID).First();
                        if (sl != null)
                        {
                            if (myReader["Item_Status_ID"] != null && myReader["Item_Status_ID"] != DBNull.Value)
                            {
                                int Item_Status_ID = Convert.ToInt32(myReader["Item_Status_ID"]);
                                if (Item_Status_ID == (int)Enums.ItemStatus.CutComplete)
                                {
                                    string Name = myReader["Name"].ToString();
                                    DateTime Time_Stamp = Convert.ToDateTime(myReader["Time_Stamp"]);

                                    string date = Time_Stamp.ToString("MM/dd/yy HH:mm");
                                    sl.CutHistory += date.PadRight(20) + Name + "\n";

                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    objConn.Close();
                }

            }

            public static void GetSlideCtraxDetails(cSlide sl)
            {
                // GetCodeAndStatus(sl);
                string ConnectionString = "server=cel-sql-011; database=cellapps; uid=sa;pwd=mp789@i;";
                System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();
                try
                {


                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();

                    SqlDataReader myReader = null;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_Get_Slide_History";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = objConn;
                    cmd.Parameters.AddWithValue("@External_ID", sl.SlideID);
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {
                        int Item_Status_ID = Convert.ToInt32(myReader["Item_Status_ID"]);
                        int Item_ID = Convert.ToInt32(myReader["Item_ID"]);
                        int Item_Group_ID = Convert.ToInt32(myReader["Item_Group_ID"]);
                        // string EncodedBarcode = myReader["EncodedBarcode"].ToString();

                        sl.ItemID = Item_ID;
                        sl.ItemGroupID = Item_Group_ID;
                        //  sl.EncodedValue = EncodedBarcode;
                        //  sl.Barcode = value;
                        if (Item_Status_ID == (int)Enums.ItemStatus.CutComplete)
                        {
                            string Name = myReader["Name"].ToString();
                            int User_ID = Convert.ToInt32(myReader["User_ID"]);
                            DateTime Time_Stamp = Convert.ToDateTime(myReader["Time_Stamp"]);
                            string Status_Description = myReader["Status_Description"].ToString();
                            int External_ID = Convert.ToInt32(myReader["External_ID"]);
                            sl.CutBy = Name;
                            sl.CutByID = User_ID;
                            sl.CutTime = Time_Stamp;
                            sl.CutComplete = true;
                            break;
                        }
                    }
                }
                catch (Exception)
                {


                }
                finally
                {
                    objConn.Close();
                }

            }

            public static string stp_format_accession_no(string InAccessionNo)
            {
                string strRetVal = "";
                string ConnectionString = "server=cel-lis-001; database=powerpath_prod; uid=sa;pwd=mp789@i;";
                SqlConnection objConn = new SqlConnection();
                try
                {

                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();
                    SqlCommand sqlCommand1 = new SqlCommand();

                    var _with1 = sqlCommand1;

                    _with1.CommandText = "stp_format_accession_no";
                    _with1.CommandType = CommandType.StoredProcedure;
                    _with1.Connection = objConn;

                    SqlParameter p1 = sqlCommand1.Parameters.Add("@InAccessionNo", SqlDbType.VarChar, 40);
                    p1.Value = InAccessionNo;
                    SqlParameter p2 = sqlCommand1.Parameters.Add("@OutAccessionNo", SqlDbType.VarChar, 40);
                    p2.Direction = ParameterDirection.Output;

                    sqlCommand1.ExecuteNonQuery();

                    strRetVal = p2.Value.ToString();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    objConn.Close();
                }
                return strRetVal;
            }
        }

        public class Tools
        {
            private static string ConnectionString = "server=cel-lis-001; database=Tools; uid=sa;pwd=mp789@i;";
            public static void PopulateGridControl(GridControl grd, string SPName, string p1, string p1value)
            {
                System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();
                try
                {
                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();
                    SqlCommand cmd = objConn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = SPName;
                    SqlParameter pData1 = cmd.Parameters.Add(p1, SqlDbType.NVarChar);
                    pData1.Value = p1value;
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    SqlCommandBuilder CB = new SqlCommandBuilder(DA);
                    DA.Fill(DS);
                    grd.DataSource = DS.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    objConn.Close();
                }
            }


            public static List<cSlide> SP_PP_Get_Slide_Details_List(string list, List<cBarcode> lBarcodes, CellappsDataContext db)
            {

                List<cSlide> lSlides = new List<cSlide>();
                System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();
                try
                {

                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand();

                    myCommand.CommandText = "SP_PP_Get_Slide_Details_List";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Connection = objConn;
                    myCommand.Parameters.AddWithValue("@slideList", list);
                    myReader = myCommand.ExecuteReader();

                    db.ExecuteCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                    var queryItems = from i in db.Items
                                     where i.Item_Type_ID == (int)Enums.ItemTypes.Slide
                                     select i;

                    var queryUsers = from u in db.Users
                                     select u;




                    while (myReader.Read())
                    {
                        cSlide sl = new cSlide();
                        sl.SlideID = Convert.ToInt32(myReader["slide_id"].ToString());
                        sl.AccessionNo = myReader["accession_no"].ToString();
                        sl.Description = myReader["Description"].ToString();
                        sl.Code = myReader["procedure_label_desc"].ToString();
                        sl.Label = myReader["full_label"].ToString();
                        sl.Instructions = myReader["instructions"].ToString();
                        sl.PP_Assigned_To_ID = Convert.ToInt32(myReader["assigned_to_id"].ToString());
                        sl.Priority = myReader["case_priority"].ToString();
                        sl.Ordered_By = myReader["ordered_by"].ToString();
                        sl.PP_Ordered_By_ID = Convert.ToInt32(myReader["ordered_by_id"].ToString());






                        var queryUser = from u in queryUsers
                                        where u.PowerPath_ID == sl.PP_Assigned_To_ID
                                        select u;
                        if (queryUser != null && queryUser.Count() > 0)
                        {
                            Source.Database.User user = queryUser.FirstOrDefault();
                            sl.Assigned_To = user.Last_Name;
                            sl.Assigned_To_ID = user.User_ID;
                        }


                        int itemid = queryItems.Where(x => x.External_ID == sl.SlideID).First().Item_ID;

                        var queryItem = from qi in queryItems
                                        where qi.External_ID == sl.SlideID && qi.Item_Type_ID == (int)Enums.ItemTypes.Slide
                                        select qi;
                        sl.ItemID = itemid;

                        if (lBarcodes != null)
                        {
                            var querySlot = from s in lBarcodes
                                            where s.DecodedValue == sl.SlideID
                                            select s;
                            if (querySlot != null && querySlot.Count() > 0)
                                sl.Rectangle = querySlot.FirstOrDefault().Rectangle;
                        }
                        lSlides.Add(sl);
                    }
                }
                catch (Exception)
                {

                    System.Media.SystemSounds.Asterisk.Play();

                }
                finally
                {
                    objConn.Close();
                }

                return lSlides;
            }




            public static cSlide SP_PP_Get_Slide_Details(int slideID)
            {
                cSlide sl = new cSlide();
                System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();
                try
                {

                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand();

                    myCommand.CommandText = "SP_PP_Get_Slide_Details";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Connection = objConn;
                    myCommand.Parameters.AddWithValue("@slide_id", slideID);
                    myReader = myCommand.ExecuteReader();



                    while (myReader.Read())
                    {

                        sl.SlideID = Convert.ToInt32(myReader["slide_id"].ToString());
                        sl.AccessionNo = myReader["accession_no"].ToString();
                        sl.Description = myReader["Description"].ToString();
                        sl.Code = myReader["code"].ToString();
                        sl.Label = myReader["full_label"].ToString();
                        sl.Instructions = myReader["instructions"].ToString();
                        sl.PP_Assigned_To_ID = Convert.ToInt32(myReader["assigned_to_id"].ToString());
                        sl.Priority = myReader["case_priority"].ToString();
                        sl.Ordered_By = myReader["ordered_by"].ToString();
                        sl.PP_Ordered_By_ID = Convert.ToInt32(myReader["ordered_by_id"].ToString());



                    }
                }
                catch (Exception)
                {

                    System.Media.SystemSounds.Asterisk.Play();

                }
                finally
                {
                    objConn.Close();
                }

                return sl;
            }


            public static List<cSlide> SP_PP_Get_Slide_Details_Case(int accID)
            {
                List<cSlide> lSlide = new List<cSlide>();
                System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();
                try
                {

                    objConn.ConnectionString = ConnectionString;
                    objConn.Open();

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand();

                    myCommand.CommandText = "SP_PP_Get_Slide_Details_Case";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Connection = objConn;
                    myCommand.Parameters.AddWithValue("@acc_id", accID);
                    myReader = myCommand.ExecuteReader();



                    while (myReader.Read())
                    {
                        cSlide sl = new cSlide();
                        sl.AccID = Convert.ToInt32(myReader["acc_id"].ToString());
                        sl.SlideID = Convert.ToInt32(myReader["slide_id"].ToString());
                        sl.AccessionNo = myReader["accession_no"].ToString();
                        sl.Description = myReader["Description"].ToString();
                        sl.Code = myReader["procedure_label_desc"].ToString();
                        sl.Label = myReader["full_label"].ToString();
                        sl.Instructions = myReader["instructions"].ToString();
                        sl.PP_Assigned_To_ID = Convert.ToInt32(myReader["assigned_to_id"].ToString());
                        sl.Priority = myReader["case_priority"].ToString();
                        sl.Ordered_By = myReader["ordered_by"].ToString();
                        sl.PP_Ordered_By_ID = Convert.ToInt32(myReader["ordered_by_id"].ToString());
                        sl.Procedure = myReader["procedure_label_desc"].ToString();
                        if (cMethods.IsDate(myReader["spec_coll_date"]))
                            sl.CollectionDate = Convert.ToDateTime(myReader["spec_coll_date"]).ToShortDateString();
                        sl.PatientName = myReader["pt_name"].ToString();
                        sl.Levels = myReader["level_info"].ToString();
                        if (cMethods.isNumeric(myReader["start_level"].ToString()))
                            sl.StartLevel = Convert.ToInt32(myReader["start_level"]);
                        if (cMethods.isNumeric(myReader["total_levels"].ToString()))
                            sl.EndLevel = Convert.ToInt32(myReader["total_levels"]);
                        sl.RevCenter = myReader["rev_center_code"].ToString();
                        sl.EncodedValue = myReader["EncodedValue"].ToString();
                        sl.SpecimenDescription = myReader["specimen_description"].ToString();
                        if (myReader["source_rec_id"] != DBNull.Value)
                            sl.BlockID = Convert.ToInt32(myReader["source_rec_id"]);
                        sl.Consult_Accession_No = myReader["consult_accession_no"].ToString();
                        if (cMethods.isNumeric(myReader["slide_no"].ToString()))
                            sl.Slide_No = Convert.ToInt32(myReader["slide_no"]);
                        if (cMethods.isNumeric(myReader["acc_order_id"].ToString()))
                            sl.AccOrderID = Convert.ToInt32(myReader["acc_order_id"]);


                        lSlide.Add(sl);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;

                }
                finally
                {
                    objConn.Close();
                }

                return lSlide;
            }

        }


    }
}
