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
    public partial class AddModules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitModule_Click(object sender, EventArgs e)
        {
            //When a user click the submit form we need to to check everythign has been sent and then add it to the database.
            //first clear the two status labels to empty them
            lblErrorStatus.InnerText = "";
            lblStatus.InnerText = "";

            //now they are empty need to check all the forms submitted are full if not need to stop the whole system
            if (moduleName.Text == "" || moduleCode.Text == "" || studentNumbers.Text == "")
            {
                //One of them forms is empty can't continue.
                lblErrorStatus.InnerText = "One of the forms is empty please fill it in.";
            }
            else
            {
                //the forms are filled in we need to get all the data form the form to use. 
                string _moduleName = moduleName.Text;
                string _moduleCode = moduleCode.Text;
                //other Varibles that will be in try/catches
                int _studentNumbers = 0;
                int _lectureLenth = 0;
                int _workshopLenth = 0;
                int _numWorkshops = 0;
                int _semesters = 0;
                int _assessments = 0;
                int _level = 0;

                try
                {
                    //there should never have letters in them.
                    //However there is a chance soemone may change the web code to allow letters in. and try and catch shoudl work to protect the server and database

                    _lectureLenth = Convert.ToInt32(lectureLenth.SelectedValue);
                    _workshopLenth = Convert.ToInt32(workshopLenth.SelectedValue);
                    _numWorkshops = Convert.ToInt32(workshopNumbers.SelectedValue);
                    _semesters = Convert.ToInt32(semesters.SelectedValue);
                    _assessments = Convert.ToInt32(assessments.SelectedValue);
                    _level = Convert.ToInt32(level.SelectedValue);
                }
                catch
                {
                    //Let the user know we caught them playing with the code
                    lblErrorStatus.InnerText = "Good try trying to play with the code ;) If you didnt please contact us!";
                }
                
                try
                {
                    //Check As a person could type letters in here!
                    _studentNumbers = Convert.ToInt32(studentNumbers.Text);
                }
                catch
                {
                    lblErrorStatus.InnerText = "Student Numbers needs to be only Numbers!!!";
                }
                //Now we have all the data required we need to add it to the database
                addModuleToDatabase(_moduleName,_moduleCode,_lectureLenth,_workshopLenth,_numWorkshops,_semesters,_studentNumbers,_assessments,_level);
            }
            //First check all form are filled in correctly
            
            //Then add the the data to the database.
        }

        public bool addModuleToDatabase(string ModuleName, string ModuleCode, int LectureLenth, int WorkshopLenth, int NoWorkshops, int Semesters, int StudentNumbers, int Assessments, int Level)
        {
            //database Connection
            string ConnectionString = "Data Source=y2x8tstejy.database.windows.net;Initial Catalog=staffwoAJ4TKlNRs;User ID=RyanBowden;Password=Molly_10";
            SqlConnection con = new SqlConnection(ConnectionString);

            //Now to add it to the database
            //keep it all in a try incase a fail
            try
            {
                //query for inserting into the database
                string AddModuleQuery = "INSERT INTO [Modules] (Name,ModuleCode,LectureLenthMinutes,WorkShopLenthMinutes,WorkshopNumbers,Semesters,StudentNumbers,Assessments,Level) VALUES (@Name,@ModuleCode,@LectureLenthMinutes,@Work";
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}