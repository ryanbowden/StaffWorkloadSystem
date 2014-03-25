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
                //query to get data
                string _queryStaffHours = "SELECT * FROM StaffDetails ";
                _queryStaffHours += "WHERE ID='" + _StaffID + "'";

                try
                {
                    SqlCommand cmd = new SqlCommand(_queryStaffHours, con);
                    SqlDataReader reader;
                    con.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    //now have information need to see what the person currectn hours and Max hours are. 
                    int MaxHours = Convert.ToInt32(reader["MaxHours"]);
                    int CurrentHours = Convert.ToInt32(reader["CurrentHours"]);

                    //now we have that infoartion need to check if they will put there current hours over their max hours.
                    CurrentHours = CurrentHours + _hours;
                    //now a simple if statement to see if they are over.
                    if (CurrentHours > MaxHours)
                    {
                        //Staff is being over worked!

                    }
                    else
                    {
                        //Staff memewber is not being over worked lets give them some more work.

                    }
                    reader.Close();
                }
                catch
                {

                }
                finally
                {
                    con.Close();
                }
                // if the number is over the max hours they are allows need to do an error message
               

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
                            comm.Parameters.AddWithValue("@duty", _StaffID);
                            comm.Parameters.AddWithValue("@staff", _DutyId);
                            comm.Parameters.AddWithValue("@hours", _hours);
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
            }
        }
    }
}