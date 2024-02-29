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
    public partial class Students : System.Web.UI.Page
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


            StudentsDB db = new StudentsDB();
            List.InnerHtml = db.RenderAllStudents();
        }
        public void ShowInsertPart(object sender, EventArgs e)
        {
            active_input.Style.Add("display", "block");
            submitNewButton.Style.Add("display", "block");
            List.Style.Add("display", "none");
            delete_input.Style.Add("display", "none");
            deleteButton.Style.Add("display", "none");

            StudentsDB dbS = new StudentsDB();
            CoursesDB dbC = new CoursesDB();
            insertStudentList.InnerHtml = dbS.PrepareStudenstsDropDownList();
            insertCourseList.InnerHtml = dbC.PrepareCoursestDropDownList();
        }

        public void Insert(object sender, EventArgs e)
        {
            int tmp1 = 0, tmp2 = 0 ;
            Student newStudent = new Student();
            StudentsDB db = new StudentsDB();
            try
            {
                 tmp1 = int.Parse(Request.Form["idStudentToSelect"]);
                 tmp2 = int.Parse(Request.Form["idCourseToSelect"]);
            }
            catch { }
            int records = db.Insert(tmp1, tmp2);
            if (records == 1) { insertMSG.InnerHtml = "</br>Student Added Successfuly"; }
            else { insertMSG.InnerHtml = "</br>Could Not Add Student !!!"; };
        }

        public void ShowDeletePart(object sender, EventArgs e)
        {
            List.Style.Add("display", "none");
            active_input.Style.Add("display", "none");
            submitNewButton.Style.Add("display", "none");
            delete_input.Style.Add("display", "block");
            deleteButton.Style.Add("display", "block");
            //Student deleteStudent = new Student();
            StudentsDB db = new StudentsDB();
            string studentsToDelete = db.PrepareStudenstsDropDownListToDelete();
            selectDelete.InnerHtml = studentsToDelete;

        }

        public void Delete(object sender, EventArgs e)
        {
            //Student deleteStudent = new Student();
            StudentsDB db = new StudentsDB();
            int tmp = int.Parse(Request.Form["idToDelete"]);
            int records = db.DeleteStudent(tmp);
            if (records == 1) { deleteMSG.InnerHtml = "</br>Student Removed  Successfuly"; }
            else { deleteMSG.InnerHtml = "</br>Sudent Not Deleted From Course !!!"; };
        }
    }
}