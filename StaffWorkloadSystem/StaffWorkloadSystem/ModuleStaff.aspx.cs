using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffWorkloadSystem
{
    public partial class ModuleStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Clear any Labels
            ((Label)LoginView1.FindControl("lblError")).Text = "";
            //Check Weather it is a ispostback
            if(!IsPostBack)
            {
                //Check whether Module Id has been sent
                if(Request.QueryString["ID"] !=  "")
                {
                    //Lets save the varible 
                    int ModuleID = Convert.ToInt32(Request.QueryString["ID"]);
                    //Now need to start setting up the page.
                    //First need to get this module details 
                    GetModuleDetails(ModuleID);
                }
                else
                {
                    ((Label)LoginView1.FindControl("lblError")).Text = "Something Has gone wrong";
                }
            }
        }

        public void GetModuleDetails(int ID)
        {
            //Need to get the details of this Module and Display it on the Page
            //Query to get data
            string ModuleDetailsQuery = "SELECT * FROM Modules WHERE ID="+ID;
            //Connection string
            string connstr = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection ModuleSelectConn = new SqlConnection(connstr);

            try
            {
                //Set the command up
                SqlCommand cmd = new SqlCommand(ModuleDetailsQuery, ModuleSelectConn);
                //open reader
                SqlDataReader reader;
                //Open Connection
                ModuleSelectConn.Open();
                //Execute reader
                reader = cmd.ExecuteReader();
                //open reader
                reader.Read();
                //get the Data that's needed
                string ModuleName = reader["Name"].ToString();
                string ModuleCode = reader["ModuleCode"].ToString();
                //Close Reader
                reader.Close();
                ((Label)LoginView1.FindControl("ModuleName")).Text = ModuleName;
                ((Label)LoginView1.FindControl("ModuleCode")).Text = ModuleCode;

            }
            catch
            {

            }
            finally
            {
                //Close the Connections
                ModuleSelectConn.Close();
            }
        }

        public void GetModuleStaff(int ModuleID)
        {
            //Will be used to get the staff that are part of the module
        }

        public bool AddStaffToModule(int StaffID, int ModuleID, int Coordinator, decimal Weighting)
        {
            //connection string that will be required for connecting to the database
            string ConnectionString = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection con = new SqlConnection(ConnectionString);
            //Need to add it to the staffDuties database

            //Now need to connect to the database
            try
            {
                string Query = "INSERT INTO [StaffModules] (ModuleID,StaffID,Weighting,Coordinator) values (@Module,@staff,@Weighting,@Coordinator)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = Query;
                        comm.Parameters.AddWithValue("@Module", ModuleID);
                        comm.Parameters.AddWithValue("@staff", StaffID);
                        comm.Parameters.AddWithValue("@Weighting", Weighting);
                        comm.Parameters.AddWithValue("@Coordinator", Coordinator);
                        try
                        {
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch
                        {
                            ((Label)LoginView1.FindControl("ModuleName")).Text = "An issue has happened when connecting to the database";
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        protected void but_SubmitStaff_Click(object sender, EventArgs e)
        {
            //Clean labels 
            ((Label)LoginView1.FindControl("lblStatus")).Text = "";
            ((Label)LoginView1.FindControl("lblError")).Text = "";
            //When a user Click this button we need to add the staff member to this module.
            //First check everything has been passed through.
            if ((((DropDownList)LoginView1.FindControl("ddl_Coordinator")).SelectedValue == "") || (((DropDownList)LoginView1.FindControl("ddl_StaffMember")).SelectedValue == ""))
            {
                ((Label)LoginView1.FindControl("lblError")).Text = "Something has gone wrong";
                return;
            }
            int ModuleID = Convert.ToInt32(Request.QueryString["ID"]);
            int Coordinator = Convert.ToInt32(((DropDownList)LoginView1.FindControl("ddl_Coordinator")).SelectedValue);
            int StaffID = Convert.ToInt32(((DropDownList)LoginView1.FindControl("ddl_StaffMember")).SelectedValue);
            //Now get the weighting
            string oldWeighting = ((TextBox)LoginView1.FindControl("txtbox_Weighting")).Text.ToString();
            //Now convert it.
            decimal Weighting = 0.0M;
            //now turn it to a decimal
            if(!decimal.TryParse(oldWeighting, out Weighting))
            {
                //If it fails need to run this and stop the code
                ((Label)LoginView1.FindControl("lblError")).Text = "Weight is in the Wrong Format! Needs to be 0.00 - 1. Staff workload weightings are usally 0.25/0.33/0.50/1 Please change yours correctly.";
                //This will stop the function running
                return;
            }
            //Now everything is check and working we can now start putting it into the database.
            //First need to check that a staff member is not already part of this module.
            bool StaffCheck = CheckStaffAlreadyOnModule(StaffID, ModuleID);
            //now check it it worked.
            if (StaffCheck == true)
            {
                //Module Not already added so need to add it then.
                bool addstaff = AddStaffToModule(StaffID, ModuleID, Coordinator, Weighting);
                if (addstaff == true)
                {
                    ((Label)LoginView1.FindControl("lblStatus")).Text = "Staff Member added sucessfully";
                }
                else
                {
                    ((Label)LoginView1.FindControl("lblError")).Text = "Something went wrong!";
                }
            }
            else
            {
                return;
            }
        }

        protected bool CheckStaffAlreadyOnModule(int StaffID, int ModuleID)
        {

            //This will be used to check if a staff member is already part of that module
            //connection string that will be required for connecting to the database
            string ConnectionString = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection con = new SqlConnection(ConnectionString);
            //now a query
            // a simple select query will do here just to see if there one row
            string _StaffDutiesQuery = "SELECT * FROM StaffModules ";
            _StaffDutiesQuery += "WHERE StaffID='" + StaffID + "' AND ModuleID = '" + ModuleID + "'";
            //Need to run the query and then put the reader onlin we will use the HASROWS feature to check
            try
            {
                SqlCommand cmd = new SqlCommand(_StaffDutiesQuery, con);
                SqlDataReader reader;
                //open connection
                con.Open();
                //run the commmand
                reader = cmd.ExecuteReader();
                //Check for rows
                if (reader.HasRows)
                {
                    //Data returns rows
                    reader.Close();
                    return false;
                }
                reader.Close();
            }
            catch
            {
                ((Label)LoginView1.FindControl("lblError")).Text = "When Checking Staff Modules something went wrong";
                return false;
            }
            finally
            {
                //close the database connection
                con.Close();
            }
            return true;
        }
    }
}