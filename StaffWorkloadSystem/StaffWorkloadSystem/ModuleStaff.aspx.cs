using System;
using System.Collections.Generic;
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
                if(Request.QueryString["ID"] ==  "")
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

        }
    }
}