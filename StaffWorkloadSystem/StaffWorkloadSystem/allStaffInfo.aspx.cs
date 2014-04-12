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

            //First new column (Name of staff)
            
            StaffColumns.ColumnName = "StaffName";
            StaffColumns.DataType = System.Type.GetType("System.String");
            staffDetails.Columns.Add(StaffColumns);

            //Second Column (Module Code)
            //Wont be used to start of with!
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "ModuleCode";
            StaffColumns.DataType = System.Type.GetType("System.String");
            staffDetails.Columns.Add(StaffColumns);

            //Third Column (Title)
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "Title";
            StaffColumns.DataType = System.Type.GetType("System.String");
            staffDetails.Columns.Add(StaffColumns);

            //Third Column (Deliver Semester)
            //Wont be used Until module is set up
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "DeliverySemester";
            StaffColumns.DataType = System.Type.GetType("System.String");
            staffDetails.Columns.Add(StaffColumns);

            //the rest of the coloums ofr module will be added later

            //Forth Column
            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "Hours";
            StaffColumns.DataType = System.Type.GetType("System.Int32");
            staffDetails.Columns.Add(StaffColumns);

            //Now the columns are set up lets get the data we need
            //Create the row that will add the data to the gridview
            //DataRow StaffDataRows = new DataRow();

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

        public void test()
        {
            
        }
    }
}