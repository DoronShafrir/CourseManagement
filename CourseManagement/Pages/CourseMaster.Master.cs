using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagement.Pages
{
    public partial class CourseMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            {

                if (Session["UserName"] != null)
                {
                    /***********User Name On above the NavBar  **************/
                    CurrentUserName.InnerHtml = "Welcome " + Session["FirstName"] + " " + Session["LastName"];
                    /***************open the entire nav bar****************/
                }
                else
                {
                    Li3.Style.Add("display", "none");
                    Li4.Style.Add("display", "none");
                    Li5.Style.Add("display", "none");
                    Li5.Style.Add("display", "none");
                }
                if ((bool)Session["Admin"])
                {

                    Li3.Style.Add("display", "block");
                    Li4.Style.Add("display", "block");
                    Li5.Style.Add("display", "block");
                    Li6.Style.Add("display", "block");
                }
                if (!(bool)Session["Admin"] && (bool)Session["Teacher"])
                {

                    Li3.Style.Add("display", "block");
                    Li4.Style.Add("display", "none");
                    Li5.Style.Add("display", "none");
                    Li5.Style.Add("display", "none");
                }
                if (!(bool)Session["Admin"] && !(bool)Session["Teacher"])
                {
                    {
                        Li3.Style.Add("display", "none");
                        Li4.Style.Add("display", "block");
                        Li5.Style.Add("display", "none");
                        Li5.Style.Add("display", "none");
                    }
                }

            }
        }

        protected void Exit(object sender, EventArgs e)
        {
            /***************Redirect to the LogOut Page****************/
            string localHost = Request.Url.ToString().Substring(0, 23);
            Response.Redirect(localHost + "Pages/LogOut.aspx");

        }
    }
}
