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
            //first check that all sections are filled in
            if (Hours.Text == null)
            {
                //Not all things added, Post a message
                lblError.Text = "A Field Was left empty :(";
            }
            else
            {
                //everything is filled in so now need to add it to the database.
                
                //need to convert all the strings to ints
                int _StaffID = Convert.ToInt32(StaffID.SelectedValue);
                int _DutyId = Convert.ToInt32(DutyID.SelectedValue);
                int _hours = Convert.ToInt32(Hours.Text);



                //Now need to connect to the database
                //try
                //{
                    string ConnectionString = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
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
                            //try
                            //{
                                conn.Open();
                                comm.ExecuteNonQuery();
                            //}
                            //catch
                            //{
                            //    lblError.Text = "An issue has happened when connecting to the database";
                            //}
                        }
                    }
                //}
                //catch
                //{

                //}
            }
        }
    }
}