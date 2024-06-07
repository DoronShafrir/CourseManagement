using CourseManagement.App_Code;
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
    public partial class Admom : System.Web.UI.Page
    {
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

                    string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Physics.mdf;Integrated Security=True";
                    SqlConnection con = new SqlConnection(connectionString);
                    // בניית פקודת SQL
                    string SQLStr = "SELECT * FROM Person";
                    SqlCommand cmd = new SqlCommand(SQLStr, con);

                    // בניית DataSet
                    DataSet ds = new DataSet();

                    // טעינת הנתונים
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds, "users");
                    /***************Build the table and render it *************************/
                    DataTable dt = ds.Tables["users"];
                    string table = BuildUsersTable1(dt);
                    tableDiv.InnerHtml = table;
                }
            }
            catch
            {
                string localHost = Request.Url.ToString().Substring(0, 23);
                Response.Redirect(localHost + "HTML/Physics.aspx");
            }

        }


        public string BuildUsersTable1(DataTable dt)
        {
            string str = "<table id='users' align='center'>";
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<th>" + column.ColumnName + "</th>";
            }
            str += "</tr>";

            foreach (DataRow row in dt.Rows)
            {
                str += "<tr>";
                foreach (DataColumn column in dt.Columns)
                {
                    str += "<td>" + row[column] + "</td>";
                }
                str += "</tr>";
            }
            str += "</tr>";
            str += "</Table>";
            return str;
        }

        public DataTable FetchTable(string SQLStr)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Physics.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            // בניית פקודת SQL

            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // בניית DataSet
            DataSet ds = new DataSet();

            // טעינת הנתונים
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "users");
            DataTable dt = ds.Tables["users"];
            return dt;

        }

        public void Search_Name(object sender, EventArgs e)
        {
            {
                /********Search from the table*******************/
                string f_l_name = Request.Form["searchText"];

                string SQLStr = "SELECT * FROM Person WHERE" + $" Name LIKE '%{f_l_name}%' OR" + $" FName LIKE '%{f_l_name}%' ";
                DataTable dt = FetchTable(SQLStr);

                string table = BuildUsersTable1(dt);
                tableDiv.InnerHtml = table;
            }
        }
        public void Delete_User(object sender, EventArgs e)
        {
            {
                /******** delte the right UserName*******************/
                string d_User_Name = Request.Form["deleteText"];

                string SQLStr = $"DELETE FROM Person WHERE UserName = '{d_User_Name}'; ";
                DataTable dt = FetchTable(SQLStr);

                /*************Render the table again after the DELETE *************/
                SQLStr = "SELECT * FROM Person";
                dt = FetchTable(SQLStr);
                string table = Helper.BuildUsersTable(dt);
                tableDiv.InnerHtml = table;
            }
        }
    }
}