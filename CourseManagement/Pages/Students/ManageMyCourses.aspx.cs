using CourseManagement.Mapping;
using CourseManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagement.Pages.Students
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            insertMSG.InnerHtml = "";
            deleteMSG.InnerHtml = "";
        }
        public void RenderCourses(object sender, EventArgs e)
        {
            active_input.Style.Add("display", "none");
            submitNewButton.Style.Add("display", "none");
            List.Style.Add("display", "block");
            delete_input.Style.Add("display", "none");
            deleteButton.Style.Add("display", "none");

            string studentName = Session["Name"].ToString();

            IndividualStudentDB db = new IndividualStudentDB(studentName);
            List.InnerHtml = db.RenderAllCourses();
        }
        public void ShowAddCourses(object sender, EventArgs e)
        {
            List.Style.Add("display", "none");
            active_input.Style.Add("display", "block");
            submitNewButton.Style.Add("display", "block");
            delete_input.Style.Add("display", "none");
            deleteButton.Style.Add("display", "none");
        }
        public void ShowDeleteCourse(object sender, EventArgs e)
        {
            List.Style.Add("display", "none");
            active_input.Style.Add("display", "none");
            submitNewButton.Style.Add("display", "none");
            delete_input.Style.Add("display", "block");
            deleteButton.Style.Add("display", "block");
        }
        public void InsertCourse(object sender, EventArgs e)
        {
            Course newCourse = new Course();
            CoursesDB db = new CoursesDB();
            newCourse.CourseName = newCourseName.Value;
            newCourse.CourseNumber = newCourseNumber.Value;
            newCourse.Name = newCourseTeacher.Value;

            int records = db.Insert(newCourse);
            if (records == 1) { insertMSG.InnerHtml = "</br>Course Added Successfuly"; }
            else { insertMSG.InnerHtml = "</br>Could Not Add Course !!!"; };
        }

        public void DeleteCourse(object sender, EventArgs e)
        {
            Course deleteCourse = new Course();
            CoursesDB db = new CoursesDB();
            deleteCourse.CourseName = deleteCourseName.Value;
            deleteCourse.CourseNumber = deleteCourseNumber.Value;
            deleteCourse.Name = deleteCourseTeacher.Value;

            int records = db.DeleteCourse(deleteCourse);
            if (records == 1) { deleteMSG.InnerHtml = "</br>Course Deleted Successfuly"; }
            else { deleteMSG.InnerHtml = "</br>Could Not Delete Course !!!"; };
        }
    }
}