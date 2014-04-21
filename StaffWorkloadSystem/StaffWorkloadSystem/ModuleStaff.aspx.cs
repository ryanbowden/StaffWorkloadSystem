using System;
using System.Collections.Generic;
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

        public bool AddStaffToModule()
        {
            //To add staff member to the module
            return true;
        }
    }
}