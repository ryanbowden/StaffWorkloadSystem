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
    public partial class AddModulesToStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This Page will display all the modules with a Link to the edit page so they can be edited to change staff on the module.

            //First Need a datatable
            DataTable ModulesDT = new DataTable();

            //Need to set up datacoloum
            DataColumn ModulesColoum = new DataColumn();

            //First new column (Name of staff)

            ModulesColoum.ColumnName = "ModuleCode";
            ModulesColoum.DataType = System.Type.GetType("System.String");
            ModulesDT.Columns.Add(ModulesColoum);

            //Second Column (Module Code)
            //Wont be used to start of with!
            ModulesColoum = new DataColumn();
            ModulesColoum.ColumnName = "ModuleName";
            ModulesColoum.DataType = System.Type.GetType("System.String");
            ModulesDT.Columns.Add(ModulesColoum);

            //Third Column (Title)
            ModulesColoum = new DataColumn();
            ModulesColoum.ColumnName = "DetailsLink";
            ModulesColoum.DataType = System.Type.GetType("System.String");
            ModulesDT.Columns.Add(ModulesColoum);

            //now the 3 colloums are set up need to get the information from the database. 
            //Query
            string ModuleSelect = "SELECT * FROM Modules";
            //Connection String
            string constr = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection ModuleSelectConn = new SqlConnection(constr);
            //Try and Ctahc to cathc and errors
            try
            {
                //Run the Command
                SqlCommand cmd = new SqlCommand(ModuleSelect, ModuleSelectConn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //Make a new DataTable
                DataTable ModulesInfo = new DataTable();
                //Fill DataTable
                da.Fill(ModulesInfo);
                
                //Now Information is here use a for each loop to put the module sin the table with a link.
                foreach (DataRow dr in ModulesInfo.Rows)
                {

                    //First Make a new Row in the data table to add the module
                    DataRow ModuleRow = ModulesDT.NewRow();
                    //get data required
                    int _ModuleID = Convert.ToInt32(dr["ID"]);
                    string _ModuleName = dr["Name"].ToString();
                    string _ModuleCode = dr["ModuleCode"].ToString();
                    string link = GetURL(_ModuleID);

                    //Now to add the 3 rows ModuleCode/ Module Name and a link to the edit page.
                    ModuleRow["ModuleCode"] = _ModuleCode;
                    ModuleRow["ModuleName"] = _ModuleName;
                    ModuleRow["DetailsLink"] = HttpUtility.HtmlDecode(link);  
                    ModulesDT.Rows.Add(ModuleRow);

                    
                }
                ((GridView)LoginView1.FindControl("Modules")).DataSource = ModulesDT;
                ((GridView)LoginView1.FindControl("Modules")).DataBind();
            }
            catch(Exception ex)
            {
                ((Label)LoginView1.FindControl("lblErrors")).Text = ex.Message;
            }
            finally
            {
                ModuleSelectConn.Close();
            }
        }

        private string GetURL(int ID)  
        {   
            return "<a href=\"ModuleStaff.aspx?ID="+ID+"\">Edit / Modify</a>";  
        }  

    }
}