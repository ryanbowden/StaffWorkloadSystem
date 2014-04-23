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
                    GetModuleStaff(ModuleID);
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

            //Need to make datatable for staff list to go in
            DataTable StaffModules = new DataTable();
            //Rows for the DataTable Need to be created
            DataColumn StaffColumns = new DataColumn();
            //Rows Needed StaffName / Weighting / Coordinator / ExtraHours
            StaffColumns.ColumnName = "StaffName";
            StaffColumns.DataType = System.Type.GetType("System.String");
            StaffModules.Columns.Add(StaffColumns);

            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "Weighting";
            StaffColumns.DataType = System.Type.GetType("System.Decimal");
            StaffModules.Columns.Add(StaffColumns);

            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "Coordinator";
            StaffColumns.DataType = System.Type.GetType("System.Boolean");
            StaffModules.Columns.Add(StaffColumns);

            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "ExtraHours";
            StaffColumns.DataType = System.Type.GetType("System.String");
            StaffModules.Columns.Add(StaffColumns);

            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "Edit";
            StaffColumns.DataType = System.Type.GetType("System.String");
            StaffModules.Columns.Add(StaffColumns);

            StaffColumns = new DataColumn();
            StaffColumns.ColumnName = "Delete";
            StaffColumns.DataType = System.Type.GetType("System.String");
            StaffModules.Columns.Add(StaffColumns);

            //Select query to select staff in that module
            string StaffModulesSelect = "SELECT * FROM StaffModules WHERE ModuleID="+ModuleID;
            string constr = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection conn = new SqlConnection(constr);

            try
            {
                SqlCommand cmd = new SqlCommand(StaffModulesSelect, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable StaffIDs = new DataTable();
                da.Fill(StaffIDs);
                //Foreach loop
                foreach (DataRow dr in StaffIDs.Rows)
                {
                    //Now get all the data we can from that row.
                    int StaffID = Convert.ToInt32(dr["StaffID"]);
                    decimal Weighting = Convert.ToDecimal(dr["Weighting"]);
                    bool Coordinator = dr["Weighting"].ToString() == "True" ? true : false;
                    int ExtraHours = Convert.ToInt32(dr["ExtraHours"]);
                    //Now we have the code we are missing one thing 
                    //Staff Name This will be really HelpFul to give. 

                    string StaffNameSelect = "SELECT Name FROM StaffDetails WHERE ID=" + StaffID;
                    SqlConnection connstaff = new SqlConnection(constr);
                    try
                    {
                        
                        SqlCommand cmdStaff = new SqlCommand(StaffNameSelect, connstaff);
                        SqlDataReader StaffNames;
                        connstaff.Open();
                        StaffNames = cmdStaff.ExecuteReader();
                        StaffNames.Read();
                        string staffName = StaffNames["Name"].ToString();

                        //Now we have all the data tiem to add it to a Row in the DataTable
                        DataRow StaffModuleRow = StaffModules.NewRow();
                        StaffModuleRow["StaffName"] = staffName;
                        StaffModuleRow["Weighting"] = Weighting;
                        StaffModuleRow["Coordinator"] = Coordinator;
                        StaffModuleRow["ExtraHours"] = ExtraHours;
                        StaffModules.Rows.Add(StaffModuleRow);
                        StaffNames.Close();

                    }
                    catch(Exception ex)
                    {
                        ((Label)LoginView1.FindControl("lblError")).Text = "Error when getting staff Details"+ex.Message;
                        return;
                    }
                    finally{
                        connstaff.Close();
                    }
                }
                //Bind to gridView
                ((GridView)LoginView1.FindControl("StaffModulesDetails")).DataSource = StaffModules;
                ((GridView)LoginView1.FindControl("StaffModulesDetails")).DataBind();
            }
            catch(Exception ex)
            {
                ((Label)LoginView1.FindControl("lblError")).Text = "Error when connecting to database"+ex.Message;
                return;
            }
            finally
            {
                conn.Close();
            }
            
            
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
                string Query = "INSERT INTO [StaffModules] (ModuleID,StaffID,Weighting,Coordinator,ExtraHours) values (@Module,@staff,@Weighting,@Coordinator,@ExtraHours)";
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
                        comm.Parameters.AddWithValue("@ExtraHours", 0);
                        try
                        {
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch(Exception ex)
                        {
                            ((Label)LoginView1.FindControl("lblError")).Text = "An issue has happened when connecting to the database = "+ex.Message;
                            return false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ((Label)LoginView1.FindControl("lblError")).Text = "Something Went Wrong = " + ex.Message;
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
                    GetModuleStaff(ModuleID);
                }
                else
                {
                    //((Label)LoginView1.FindControl("lblError")).Text = "Something went wrong!";
                }
            }
            else
            {
                ((Label)LoginView1.FindControl("lblError")).Text = "Staff member All ready Added!";
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