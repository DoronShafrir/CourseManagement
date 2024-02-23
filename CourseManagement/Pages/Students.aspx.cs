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
        public void ShowAddPart(object sender, EventArgs e)
        {
            active_input.Style.Add("display", "none");
            submitNewButton.Style.Add("display", "none");
            List.Style.Add("display", "block");
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
            Student deleteStudent = new Student();
            StudentsDB db = new StudentsDB();
            //DropDownList ddd = FindControl("delete_input1") as DropDownList;
            //Control ddd = FindControl("delete_input") as Control;
            string studentsToDelete = db.PrepareListToDelete();
            selectDelete.InnerHtml = studentsToDelete;


        }
        public void Insert(object sender, EventArgs e)
        {
            Student newStudent = new Student();
            StudentsDB db = new StudentsDB();
            newStudent.Name = newStudentName.Value;
            newStudent.CourseName = newCourseName.Value;

            int records = db.Insert(newStudent);
            if (records == 1) { insertMSG.InnerHtml = "</br>Student Added Successfuly"; }
            else { insertMSG.InnerHtml = "</br>Could Not Add Student !!!"; };
        }

        public void Delete(object sender, EventArgs e)
        {
            Student deleteStudent = new Student();
            StudentsDB db = new StudentsDB();
            string tmp = Request.Form["idToDelete"];
            //int records = db.DeleteStudent(5);
            //if (records == 1) { deleteMSG.InnerHtml = "</br>Course Deleted Successfuly"; }
            //else { deleteMSG.InnerHtml = "</br>Could Not Delete Course !!!"; };
        }
    }
}