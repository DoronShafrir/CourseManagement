using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagement.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                //string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\USER\OneDrive\DSH\Doron\sources\repos\task#12\task#12\App_Data\Physics.mdf;Integrated Security=True";
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Physics.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                // בניית פקודת SQL
                string SQLStr = $"SELECT * FROM Person WHERE UserName = '{Request.Form["userName"]}' AND Password = '{Request.Form["password"]}'";
                SqlCommand cmd = new SqlCommand(SQLStr, con);

                // בניית DataSet
                DataSet ds = new DataSet();

                // טעינת הנתונים
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "names");

                int count = ds.Tables[0].Rows.Count;
                if (count > 0)

                {
                    /**********Update Log Ins counters*************/

                    /***********Get the entrie informtion for the loged in **************/
                    Session["Name"] = ds.Tables[0].Rows[0]["Name"];
                    Session["LastName"] = ds.Tables[0].Rows[0]["FName"];
                    Session["UserName"] = ds.Tables[0].Rows[0]["UserName"];
                    Session["Admin"] = ds.Tables[0].Rows[0]["Admin"];
                    Session["Teacher"] = ds.Tables[0].Rows[0]["Teacher"];
                    Session["Password"] = ds.Tables[0].Rows[0]["Password"];
                    

                    string check1 = Session["Name"].ToString();
                    string check2 = Session["LastName"].ToString();

                    Application["globalCounterLogedIn"] = (int)Application["globalCounterLogedIn"] + 1;
                    Application["inSiteLogedIn"] = (int)Application["inSiteLogedIn"] + 1;

                    /***********Redirect to main  **************/
                    string localHost = Request.Url.ToString().Substring(0, 23);
                    Response.Redirect(localHost + "/Pages/WelcomePage.aspx");


                }
                else
                {
                    umsg.Style.Add("color", "red");
                    umsg.InnerHtml = "User Name or Paswword are not recognized";
                    pmsg.Style.Add("color", "red");
                    pmsg.InnerHtml = "User Name or Paswword are not recognized";
                }

            }
        }
    }
}