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
    public partial class StaffDutyConnection : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void CompleteConnection_Click(object sender, EventArgs e)
        {
            //First Clean the Labels as this is a new one
            lblError.Text = "";
            lblStatus.Text = "";
            //connection string that will be required for connecting to the database
            string ConnectionString = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection con = new SqlConnection(ConnectionString);
                

            //first check that all sections are filled in
            if (Hours.Text == null)
            {
                //Not all things added, Post a message
                lblError.Text = "A Field Was left empty :(";
            }
            else
            {
                //everything is filled in so now need to add all the information to the database
                //Information that will need to be added
                // The staff member account will need they current hours updated and checked they are not being over worked.
                //And the duty information and staff information to the database to connec thte staff member to the duty.

                //First we need to convert all the strings to integer for using 
                int _StaffID = Convert.ToInt32(StaffID.SelectedValue);
                int _DutyId = Convert.ToInt32(DutyID.SelectedValue);
                int _hours = Convert.ToInt32(Hours.Text);

                //need to find out how many hours the staff member currently has.

                bool staffHoursOkay = StaffMaxHoursCheck(_hours, _StaffID);
                if (staffHoursOkay == true)
                {
                    //need to check if a staff member already has this duty added
                    bool StaffCheck = dutyAlreadyAdded(_StaffID, _DutyId);
                    if (StaffCheck == false)
                    {
                        //Either Something went wrong or staff already have that duty added
                        lblStatus.Text = "Staff Member already has this duty added to them.";
                    }
                    else
                    {
                        //Staff Member does not already have this duty added 
                        //lets add it
                        addStaffDutiesToDatabase(_hours, _StaffID, _DutyId);
                    }
                }
                else
                {
                    //staff member hours will be over reachead with this therfor dont continue 
                    lblStatus.Text = "Staff Workload will be over reached!";
                }
            }
        }

        //Need to check staff members work load
        public bool StaffMaxHoursCheck(int dutyHours, int StaffID)
        {
            //connection string that will be required for connecting to the database
            string ConnectionString = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection con = new SqlConnection(ConnectionString);

            //query to get data
            string _queryStaffHours = "SELECT * FROM StaffDetails ";
            _queryStaffHours += "WHERE ID='" + StaffID + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(_queryStaffHours, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                //Define Variables
                int MaxHours;
                int CurrentHours;
                //now have information need to see what the person currectn hours and Max hours are. 
                 MaxHours = Convert.ToInt32(reader["MaxHours"]);
                //A bug will happen if we try to convert the CurrentHours if it is null so need to check first.
                if (reader.IsDBNull(reader.GetOrdinal("CurrentHours")))
                {
                     CurrentHours = 0;
                }
                else
                {
                     CurrentHours = Convert.ToInt32(reader["CurrentHours"]);
                }
                
                reader.Close();
                //now we have that infoartion need to check if they will put there current hours over their max hours.
                CurrentHours = CurrentHours + dutyHours;
                //now a simple if statement to see if they are over.
                if (CurrentHours > MaxHours)
                {
                    //Staff is being over worked!
                    //return Flase
                    return false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Something went wrong when checking staff hours - " + ex.Message;
                return false;
            }
            finally
            {
                //close the database connection
                con.Close();

            }
            //well everything seams find so return true.
            return true;
        }

        //Need to check the correct duty has not already been added to the staff member
        public bool dutyAlreadyAdded(int StaffId, int DutyID)
        {
            //connection string that will be required for connecting to the database
            string ConnectionString = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection con = new SqlConnection(ConnectionString);

            //now a query
            // a simple select query will do here just to see if there one row
            string _StaffDutiesQuery = "SELECT * FROM StaffDuties ";
            _StaffDutiesQuery += "WHERE DutyID='" + DutyID + "' AND StaffID = '" + StaffId + "'";

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
                if(reader.HasRows)
                {
                    //Data returns rows
                    //Need to update current hours if anything.
                    reader.Close();
                    return false;
                }
                reader.Close();

            }
            catch
            {
                lblError.Text = "When Checking Staff Duties something went wrong";
                return false;
            }
            finally
            {
                //close the database connection
                con.Close();

            }


            return true;
        }

        //Need to add the information to the database
        public void addStaffDutiesToDatabase(int Hours, int StaffID, int DutyID)
        {
            //connection string that will be required for connecting to the database
            string ConnectionString = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection con = new SqlConnection(ConnectionString);
            //Need to add it to the staffDuties database

            //Now need to connect to the database
            try
            {
                string Query = "INSERT INTO [StaffDuties] (DutyID,StaffID,Hours) values (@duty,@staff,@hours)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = Query;
                        comm.Parameters.AddWithValue("@duty", DutyID);
                        comm.Parameters.AddWithValue("@staff", StaffID);
                        comm.Parameters.AddWithValue("@hours", Hours);
                        try
                        {
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch
                        {
                            lblError.Text = "An issue has happened when connecting to the database";
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            //need to update the staff members account with their new current hours. 
            //First need to get the staff Current Hours
            //Query for select that staff member
            string _getStaffCurrentHours = "SELECT * FROM StaffDetails ";
            _getStaffCurrentHours += "WHERE ID='" + StaffID + "'";


            //Define Varibles
            int CurrentHours = 0;
            //First Lets get the staff members current Hours AGAIN *In The Future can we remember this as we already dio this? No way to pass it back. *
            try
            {
                SqlCommand cmd = new SqlCommand(_getStaffCurrentHours, con);
                SqlDataReader reader;
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();

                //A bug will happen if we try to conver the CurrentHours if it is null so need to check first.
                if (reader.IsDBNull(reader.GetOrdinal("CurrentHours")))
                {
                    CurrentHours = 0;
                }
                else
                {
                    CurrentHours = Convert.ToInt32(reader["CurrentHours"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = "Something went wrong when checking staff hours - " + ex.Message;
            }
            finally
            {
                //close the database connection
                con.Close();
            }

            //We should Now have the Current Hour we need to update the Value to include the new duty after which need to then Update it to the database.
            CurrentHours += Hours;
            //Now the Query to Update the Staff Profile
            string _UpdateStaffCurrentHours = "UPDATE StaffDetails SET CurrentHours=@CurrentHours WHERE ID=@StaffID";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = _UpdateStaffCurrentHours;
                        comm.Parameters.AddWithValue("@CurrentHours", CurrentHours);
                        comm.Parameters.AddWithValue("@StaffID", StaffID);
                        try
                        {
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                        catch
                        {
                            lblError.Text = "An issue has happened when connecting to the database";
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}