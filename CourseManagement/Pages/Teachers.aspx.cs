using CourseManagement.Mapping;
using CourseManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagement.Pages.Management
{
    public partial class Teachers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            insertMSG.InnerHtml = "";
            deleteMSG.InnerHtml = "";
        }
        public void RenderList(object sender, EventArgs e)
        {
            active_input.Style.Add("display", "none");
            submitNewButton.Style.Add("display", "none");
            List.Style.Add("display", "block");
            delete_input.Style.Add("display", "none");
            deleteButton.Style.Add("display", "none");

            TeachersDB db = new TeachersDB();
            List.InnerHtml = db.RenderAll();
        }
        public void ShowAddPart(object sender, EventArgs e)
        {
            List.Style.Add("display", "none");
            active_input.Style.Add("display", "block");
            submitNewButton.Style.Add("display", "block");
            delete_input.Style.Add("display", "none");
            deleteButton.Style.Add("display", "none");
        }
        public void ShowDeletePart(object sender, EventArgs e)
        {
            List.Style.Add("display", "none");
            active_input.Style.Add("display", "none");
            submitNewButton.Style.Add("display", "none");
            delete_input.Style.Add("display", "block");
            deleteButton.Style.Add("display", "block");
        }
        public void Insert(object sender, EventArgs e)
        {
            Teacher newTeacher = new Teacher();
            TeachersDB db = new TeachersDB();
            newTeacher.Name = newName.Value;
            newTeacher.CourseName = newCourseName.Value;

            int records = db.Insert(newTeacher);
            if (records == 1) { insertMSG.InnerHtml = "</br>Teacher Added Successfuly"; }
            else { insertMSG.InnerHtml = "</br>Could Not Add Student !!!"; };
        }

        public void Delete(object sender, EventArgs e)
        {
            Teacher deleteTeacher = new Teacher();
            TeachersDB db = new TeachersDB();
            deleteTeacher.Name = deleteName.Value;
            deleteTeacher.CourseName = deleteCourseName.Value;

            int records = db.Delete(deleteTeacher);
            if (records == 1) { deleteMSG.InnerHtml = "</br>Course Deleted Successfuly"; }
            else { deleteMSG.InnerHtml = "</br>Could Not Delete Course !!!"; };
        }
    }
}
