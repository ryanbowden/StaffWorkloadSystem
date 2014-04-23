using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffWorkloadSystem
{
    public partial class allStaffInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This page will show a table of every! duty and module for every staff member
            //First need to build the datatable
            DataTable staffDetails = new DataTable();

            //Need to set up datacoloum
            DataColumn StaffColumns = new DataColumn();

            //(Name of staff)    
            StaffColumns.ColumnName = "StaffName";
            StaffColumns.DataType = System.Type.GetType("System.String");
            staffDetails.Columns.Add(StaffColumns);
            //(Module Code)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "ModuleCode";
            StaffColumns.DataType = System.Type.GetType("System.String");
            staffDetails.Columns.Add(StaffColumns);
            //(Title)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "Title";
            StaffColumns.DataType = System.Type.GetType("System.String");
            staffDetails.Columns.Add(StaffColumns);
            //(Deliver)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "DeliverySemester";
            StaffColumns.DataType = System.Type.GetType("System.String");
            staffDetails.Columns.Add(StaffColumns);
            //(Tutor Split)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "TutorSplit";
            StaffColumns.DataType = System.Type.GetType("System.Decimal");
            staffDetails.Columns.Add(StaffColumns);
            //(CohortSize)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "CohortSize";
            StaffColumns.DataType = System.Type.GetType("System.Int32");
            staffDetails.Columns.Add(StaffColumns);
            //(DeliveryWeeks)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "DeliveryWeeks";
            StaffColumns.DataType = System.Type.GetType("System.Int32");
            staffDetails.Columns.Add(StaffColumns);
            //(LectureHours)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "LectureHours";
            StaffColumns.DataType = System.Type.GetType("System.Int32");
            staffDetails.Columns.Add(StaffColumns);
            //(WorkShopLenth)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "WorkShopLenth";
            StaffColumns.DataType = System.Type.GetType("System.Int32");
            staffDetails.Columns.Add(StaffColumns);
            //(NoWorkshops)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "NoWorkshops";
            StaffColumns.DataType = System.Type.GetType("System.Int32");
            staffDetails.Columns.Add(StaffColumns);
            //(TotalDelivery)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "TotalDelivery";
            StaffColumns.DataType = System.Type.GetType("System.Decimal");
            staffDetails.Columns.Add(StaffColumns);
            //(PrepandAss)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "PrepandAss";
            StaffColumns.DataType = System.Type.GetType("System.Decimal");
            staffDetails.Columns.Add(StaffColumns);
            //(Hours)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "Hours";
            StaffColumns.DataType = System.Type.GetType("System.Int32");
            staffDetails.Columns.Add(StaffColumns);

            //Need to staff details and then create the row iformation to then keep running through

            string StaffSqlSelect = "SELECT ID,Name FROM StaffDetails";
            string constr = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";

            SqlConnection staffselectconnection = new SqlConnection(constr);
            //try and connect to the database
            try
            {
                SqlCommand cmd = new SqlCommand(StaffSqlSelect, staffselectconnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable StaffIDs = new DataTable();
                da.Fill(StaffIDs);
                //Now need to go through each staff member
                foreach (DataRow dr in StaffIDs.Rows)
                {
                    //Now to go through all the staff one by one to get all their duties and modules
                    string StaffName = dr["Name"].ToString();
                    int StaffID = Convert.ToInt32(dr["ID"]);

                    //Now a string to select all the duties for that satff member
                    string StaffDutiesSelect = "SELECT * FROM StaffDuties WHERE StaffID='" + StaffID + "'";
                    SqlConnection StaffDutiesSelectconn = new SqlConnection(constr);
                    SqlCommand staffdutiesCMD = new SqlCommand(StaffDutiesSelect, StaffDutiesSelectconn);
                    SqlDataAdapter staffDutiesDA = new SqlDataAdapter(staffdutiesCMD);
                    DataTable StaffDutiesDT = new DataTable();
                    staffDutiesDA.Fill(StaffDutiesDT);
                    foreach(DataRow sd in StaffDutiesDT.Rows)
                    {
                        //now get the ID of the duty!
                        //And the Hours
                        string StaffDutyId = sd["DutyID"].ToString();
                        int staffDtuyHours = Convert.ToInt32(sd["Hours"]);

                        //now need to get the information from that duty.
                        //Query requied
                        string DutyInformationSelect = "SELECT ID, Name FROM Duties WHERE ID='"+StaffDutyId+"'";
                        SqlConnection dutyinfoCONN = new SqlConnection(constr);
                        SqlCommand DutyInfoCMD = new SqlCommand(DutyInformationSelect, dutyinfoCONN);
                        SqlDataReader dutyInfo;
                        dutyinfoCONN.Open();
                        dutyInfo = DutyInfoCMD.ExecuteReader();
                        dutyInfo.Read();
                        //variable to store duty name
                        string DutyName = dutyInfo["Name"].ToString();
                        //need to get it off the reader

                        DataRow StaffDataRows = staffDetails.NewRow();
                        StaffDataRows["StaffName"] = StaffName;
                        StaffDataRows["Title"] = DutyName;
                        StaffDataRows["Hours"] = staffDtuyHours;
                        staffDetails.Rows.Add(StaffDataRows);
                        dutyInfo.Close();
                        dutyinfoCONN.Close();
                    }
                    //Now need to check the modules this staff member is on
                    //Will need to get the list they are on and then get the futher details from Modules database.
                    //query to get modules
                    string StaffModules = "SELECT * FROM StaffModules WHERE StaffID=" + StaffID;
                    SqlConnection StaffModulesConn = new SqlConnection(constr);
                    SqlCommand StaffModulesCMD = new SqlCommand(StaffModules, StaffModulesConn);
                    SqlDataAdapter StaffModulesDA = new SqlDataAdapter(StaffModulesCMD);
                    DataTable StaffModulesDT = new DataTable();
                    StaffModulesDA.Fill(StaffModulesDT);
                    foreach (DataRow SM in StaffModulesDT.Rows)
                    {
                        //Now to get the data it passes that we will need
                        int ModuleID = Convert.ToInt32(SM["ModuleID"]);
                        Decimal Weighting = Convert.ToDecimal(SM["Weighting"]);


                        //Now we need to get all the Data From the Module Database
                        string ModuleQuery = "SELECT * FROM Modules WHERE ID=" + ModuleID;
                        SqlConnection ModuleConn = new SqlConnection(constr);
                        SqlCommand ModuleCMD = new SqlCommand(ModuleQuery, ModuleConn);
                        SqlDataReader ModuleInfo;
                        ModuleConn.Open();
                        ModuleInfo = ModuleCMD.ExecuteReader();
                        ModuleInfo.Read();
                        //Now we are need to get all the data we have in one nice area 
                        string ModuleName = ModuleInfo["Name"].ToString();
                        string ModuleCode = ModuleInfo["ModuleCode"].ToString();
                        int LectureLenth = Convert.ToInt32(ModuleInfo["LectureLenthMinutes"]);
                        //Need Lecture Lent to be in Hours
                        LectureLenth = LectureLenth / 60;
                        int WorkshopLenth = Convert.ToInt32(ModuleInfo["WorkshopLenthMinutes"]);
                        //Need WorkShop lent in Hours not Minutes
                        WorkshopLenth = WorkshopLenth / 60;
                        int WorkshopNum = Convert.ToInt32(ModuleInfo["WorkshopNumbers"]);
                        //Semesters are in the database as eiht 1 / 2 or 3
                        //1 = Semester A 
                        //2 = Semester B
                        //3 = Both Semesters
                        int databaseSemester = Convert.ToInt32(ModuleInfo["Semesters"]);
                        int DeliveryWeeks = 0;
                        string DeliverySemester ="";
                        if (databaseSemester == 1)
                        {
                            DeliveryWeeks = 12;
                            DeliverySemester = "A";
                        }
                        else if (databaseSemester ==2)
                        {
                            DeliveryWeeks = 12;
                            DeliverySemester = "B";
                        }
                        else if (databaseSemester == 3)
                        {
                            DeliveryWeeks = 24;
                            DeliverySemester = "A&B";
                        }
                        int CohortSize = Convert.ToInt32(ModuleInfo["StudentNumbers"]);


                        
                        DataRow StaffDataRows = staffDetails.NewRow();
                        StaffDataRows["StaffName"] = StaffName;
                        StaffDataRows["ModuleCode"] = ModuleCode;
                        StaffDataRows["Title"] = ModuleName;
                        StaffDataRows["DeliverySemester"] = DeliverySemester;
                        StaffDataRows["TutorSplit"] = Weighting;
                        StaffDataRows["CohortSize"] = CohortSize;
                        StaffDataRows["DeliveryWeeks"] = DeliveryWeeks;
                        StaffDataRows["LectureHours"] = LectureLenth;
                        StaffDataRows["WorkShopLenth"] = WorkshopLenth;
                        StaffDataRows["NoWorkshops"] = WorkshopNum;
                        //for the rest calculation needs to be done. 
                        //first lets look at Total Delivery
                        decimal TotalDelivery = (WorkshopLenth * WorkshopNum) + LectureLenth;
                        //Now we have the weekly for the whole module 
                        //What it is it for this staff member
                        TotalDelivery = TotalDelivery * Weighting;
                        //now for the whole semester
                        TotalDelivery = TotalDelivery * DeliveryWeeks;
                        //now send that to the rows
                        StaffDataRows["TotalDelivery"] = TotalDelivery;
                        //Now need to work out the prep time
                        decimal prepTime = (TotalDelivery * 15) / 10;
                        StaffDataRows["PrepandAss"] = prepTime;

                        //Now to work out hours 
                        int Hours = Convert.ToInt32(prepTime + TotalDelivery);
                        StaffDataRows["Hours"] = Hours;
                        staffDetails.Rows.Add(StaffDataRows);




                       
                    }
                   
                }

                StaffDutiesDetails.DataSource = staffDetails;
                StaffDutiesDetails.DataBind();
            }
            catch(Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
            finally
            {
                staffselectconnection.Close();
            }
        }
    }
}