using CourseManagement.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseManagement.Mapping;
using CourseManagement.Model;

namespace CourseManagement.Pages
{
    public partial class People : System.Web.UI.Page
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

            PeopleDB db = new PeopleDB();
            List.InnerHtml = db.RenderAllPeople();
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
            Person newPerson = new Person();
            PeopleDB db = new PeopleDB();
            newPerson.Name = newPersonName.Value;
            newPerson.FName = newPersonFamily.Value;
            newPerson.UserName = newUserName.Value;
            newPerson.Password = newPassword.Value;
            newPerson.Admin = Admin.Checked ? true : false;
            newPerson.Teacher = Teacher.Checked ? true : false;

            int records = db.Insert(newPerson);
            if (records == 1) { insertMSG.InnerHtml = "</br>Person Added Successfuly"; }
            else { insertMSG.InnerHtml = "</br>Could Not Add Person !!!"; };
        }

        public void Delete(object sender, EventArgs e)
        {
            Person deletePerson = new Person();
            PeopleDB db = new PeopleDB();
            deletePerson.Name = deletePersonName.Value;
            deletePerson.FName = deletePersonFamily.Value;
            deletePerson.UserName = deleteUserName.Value;


            int records = db.DeletePerson(deletePerson);
            if (records == 1) { deleteMSG.InnerHtml = "</br>Course Deleted Successfuly"; }
            else { deleteMSG.InnerHtml = "</br>Could Not Delete Course !!!"; };
        }
    }
}