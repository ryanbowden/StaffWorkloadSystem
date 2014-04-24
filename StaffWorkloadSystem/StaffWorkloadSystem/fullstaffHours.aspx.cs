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
    public partial class fullstaffHours : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FullStaffHours();
        }

        //Works out staff full work hours
        public void FullStaffHours()
        {
            //Create a datatable for Staff Hours to go in
            DataTable StaffHoursTable = new DataTable();

            //Set the Colums up.
            DataColumn StaffHoursColumns = new DataColumn();

            //(Name of staff)    
            StaffHoursColumns.ColumnName = "StaffName";
            StaffHoursColumns.DataType = System.Type.GetType("System.String");
            StaffHoursTable.Columns.Add(StaffHoursColumns);

            //(Research Leave)    
            StaffHoursColumns = new DataColumn();
            StaffHoursColumns.ColumnName = "ResearchLeave";
            StaffHoursColumns.DataType = System.Type.GetType("System.Int32");
            StaffHoursTable.Columns.Add(StaffHoursColumns);

            //(Initial Year)    
            StaffHoursColumns = new DataColumn();
            StaffHoursColumns.ColumnName = "Initialyear";
            StaffHoursColumns.DataType = System.Type.GetType("System.Int32");
            StaffHoursTable.Columns.Add(StaffHoursColumns);

            //(Delivery and Teaching)    
            StaffHoursColumns = new DataColumn();
            StaffHoursColumns.ColumnName = "DeliveryandTeaching";
            StaffHoursColumns.DataType = System.Type.GetType("System.Int32");
            StaffHoursTable.Columns.Add(StaffHoursColumns);

            //(Total Duty)  
            StaffHoursColumns = new DataColumn();
            StaffHoursColumns.ColumnName = "TotalDuty";
            StaffHoursColumns.DataType = System.Type.GetType("System.Int32");
            StaffHoursTable.Columns.Add(StaffHoursColumns);

            //(Total Hours)    
            StaffHoursColumns = new DataColumn();
            StaffHoursColumns.ColumnName = "TotalHours";
            StaffHoursColumns.DataType = System.Type.GetType("System.Int32");
            StaffHoursTable.Columns.Add(StaffHoursColumns);

            //Now need to get all Staff Id's and Name
            string staffdetailsquery = "SELECT * FROM StaffDetails";
            string constr = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
     
            SqlConnection staffselectconnection = new SqlConnection(constr);
            //try and connect to the database
            try
            {
                SqlCommand cmd = new SqlCommand(staffdetailsquery, staffselectconnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable StaffIDs = new DataTable();
                da.Fill(StaffIDs);
                //Now need to go through each staff member
                foreach (DataRow dr in StaffIDs.Rows)
                {
                    //Get Staff Details Required
                    string StaffName = dr["Name"].ToString();
                    int StaffID = Convert.ToInt32(dr["ID"]);
                    int InitialYear = dr["InitialYear"].ToString() == "True" ? 74 : 0;
                    int ResearchLeave = dr["ResearchLeave"].ToString() == "True" ? 400 : 0;
                    int MaxHours = Convert.ToInt32(dr["MaxHours"]);


                    //Get Staff Module Hours
                    int ModuleHours = StaffModulesHours(StaffID);

                    //Get Staff DutyHours
                    int DutyHours = StaffDutyHours(StaffID);

                    //Do any maths
                    int TotalHours = InitialYear + ResearchLeave + DutyHours + ModuleHours;

                    //Add to row all data
                    DataRow StaffFullHoursRow = StaffHoursTable.NewRow();
                    StaffFullHoursRow["StaffName"] = StaffName;
                    StaffFullHoursRow["ResearchLeave"] = ResearchLeave;
                    StaffFullHoursRow["Initialyear"] = InitialYear;
                    StaffFullHoursRow["DeliveryandTeaching"] = ModuleHours;
                    StaffFullHoursRow["TotalDuty"] = DutyHours;
                    StaffFullHoursRow["TotalHours"] = TotalHours;
                    StaffHoursTable.Rows.Add(StaffFullHoursRow);


                }
                //Bind to GridView
                StaffFullHours.DataSource = StaffHoursTable;
                StaffFullHours.DataBind();

            }
            catch(Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
            finally
            {

            }


        }

        //This will calculate a staff members work hours for modules
        public int StaffModulesHours(int StaffID)
        {

            string constr = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            //Now need to get all the module information and get all the hours and pass back the full hours.
            //Int to hold all the Hours
            int ModuleHours = 0;
            //query to get modules
            string StaffModules = "SELECT * FROM StaffModules WHERE StaffID=" + StaffID;

            try
            {
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
                    if (databaseSemester == 1)
                    {
                        DeliveryWeeks = 12;
                    }
                    else if (databaseSemester == 2)
                    {
                        DeliveryWeeks = 12;
                    }
                    else if (databaseSemester == 3)
                    {
                        DeliveryWeeks = 24;
                    }
                    int CohortSize = Convert.ToInt32(ModuleInfo["StudentNumbers"]);


                    //for the rest calculation needs to be done. 
                    //first lets look at Total Delivery
                    decimal TotalDelivery = (WorkshopLenth * WorkshopNum) + LectureLenth;
                    //Now we have the weekly for the whole module 
                    //What it is it for this staff member
                    TotalDelivery = TotalDelivery * Weighting;
                    //now for the whole semester
                    TotalDelivery = TotalDelivery * DeliveryWeeks;
                    //now send that to the rows

                    //Now need to work out the prep time
                    decimal prepTime = (TotalDelivery * 15) / 10;

                    //Now to work out hours 
                    int Hours = Convert.ToInt32(prepTime + TotalDelivery);
                    //now add it to the Total
                    ModuleHours = Hours;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {

            }
            return ModuleHours;
        }

        //This will Calculate a Staff members Work Hours for duty
        public int StaffDutyHours(int StaffID)
        {
            string constr = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            int TotalDutyHours = 0;
            //Now a string to select all the duties for that satff member
            string StaffDutiesSelect = "SELECT * FROM StaffDuties WHERE StaffID='" + StaffID + "'";
            try
            {

                SqlConnection StaffDutiesSelectconn = new SqlConnection(constr);
                SqlCommand staffdutiesCMD = new SqlCommand(StaffDutiesSelect, StaffDutiesSelectconn);
                SqlDataAdapter staffDutiesDA = new SqlDataAdapter(staffdutiesCMD);
                DataTable StaffDutiesDT = new DataTable();
                staffDutiesDA.Fill(StaffDutiesDT);
                foreach (DataRow sd in StaffDutiesDT.Rows)
                {
                    //now get the ID of the duty!
                    //And the Hours
                    int staffDtuyHours = Convert.ToInt32(sd["Hours"]);


                    /*DataRow StaffDataRows = staffDetails.NewRow();
                    StaffDataRows["StaffName"] = StaffName;
                    StaffDataRows["Title"] = DutyName;
                    StaffDataRows["Hours"] = staffDtuyHours;
                    staffDetails.Rows.Add(StaffDataRows);*/
                    TotalDutyHours = staffDtuyHours;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {

            }
            return TotalDutyHours;
        }
    }
}