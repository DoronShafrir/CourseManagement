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
    public partial class LogUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (IsPostBack)
            {
                // בדיקה אם קיים שם משתמש
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Physics.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                // בניית פקודת SQL
                string SQLStr = $"SELECT * FROM Physics1 WHERE userName = '{Request.Form["userName"]}'";
                SqlCommand cmd = new SqlCommand(SQLStr, con);

                // בניית DataSet
                DataSet ds = new DataSet();

                // טעינת הנתונים
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "names");

                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    umsg.Style.Add("color", "red");
                    umsg.InnerHtml = "User Name has been taken, try another one";
                }
                else
                {

                    // בניית השורה להוספה
                    DataRow dr = ds.Tables["names"].NewRow();

                    try
                    {

                        dr["FirstName"] = Request.Form["firstName"];
                        dr["LastName"] = Request.Form["lastName"];
                        dr["UserName"] = Request.Form["userName"];
                        dr["Password"] = Request.Form["password"];
                        dr["BirthDate"] = Request.Form["birth"];
                        dr["Email"] = Request.Form["email"];
                        dr["Admin"] = 0;
                        ds.Tables["names"].Rows.Add(dr);


                        // עדכון הדאטה סט בבסיס הנתונים
                        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                        adapter.UpdateCommand = builder.GetInsertCommand();
                        adapter.Update(ds, "names");
                        string localHost = Request.Url.ToString().Substring(0, 23);
                        Response.Redirect(localHost + "HTML/Physics.aspx");
                    }
                    catch { }
                }
            }
        }
    }
}
