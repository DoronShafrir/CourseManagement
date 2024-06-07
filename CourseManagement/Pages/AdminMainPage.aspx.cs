using CourseManagement.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagement.Pages
{
    public partial class AdminMainPage : System.Web.UI.Page

    {
        public string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Physics.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!((bool)Session["Admin"]))
                {
                    string localHost = Request.Url.ToString().Substring(0, 23);
                    Response.Redirect(localHost + "HTML/Physics.aspx");
                }
                else
                {

                    /********Bring the full table*******************/

                    /*********** Builde SQL Command ****************/
                    string SQLStr = "SELECT * FROM Person";
                    

                    mainTable.InnerHtml = Helper.FetchTable(SQLStr, connectionString);
                }
            }
            catch
            {
                string localHost = Request.Url.ToString().Substring(0, 23);
                Response.Redirect(localHost + "Pages/WelcomePage.aspx");
            }           

        }
        protected void SearchName(object sender, EventArgs e)
        {
            string f_l_name = Request.Form["searchUser"];
            mainTable.InnerHtml =  Helper.Search_Name(f_l_name, connectionString);
        }
    }
}