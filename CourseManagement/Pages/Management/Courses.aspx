<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CourseMaster.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="CourseManagement.Pages.Management.Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/ManagementStyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color: crimson">Courses Manager Page </h1>

    <div class="active_buttons" runat="server">
        <input type="button" value="Show All Courses" class="admin-button" onserverclick="RenderCourses" runat="server" />
        <button type="button" value="Add Course" class="admin-button" onserverclick="ShowAddCourses" runat="server">Add Course</button>
        <button type="button" value="Delete Course" class="admin-button" onserverclick="ShowDeleteCourse" runat="server">Delete Course</button>
    </div>
    <div id="List" runat="server"></div>

    <%--Add Insert part--%>

    <div id="active_input" runat="server">
        <input type="text" id="newCourseName" class="input_field" placeholder="Course Name" runat="server" />
        <input type="text" id="newCourseNumber" class="input_field" placeholder="Course Number" runat="server" />
        <input type="text" id="newCourseTeacher" class="input_field" placeholder="Teacher" runat="server" />
    </div>
    <div runat="server">
        <input type="button" value="Insert" id="submitNewButton" onserverclick="InsertCourse" runat="server" />
        <span id="insertMSG" style="color: red; font-size: 1.5em; position: absolute" runat="server"></span>
    </div>

    <%--Delete part--%>

    <div id="delete_input" runat="server">
        <input type="text" id="deleteCourseName" class="input_field" placeholder="Course Name to Remove" runat="server" />
        <input type="text" id="deleteCourseNumber" class="input_field" placeholder="Course Number to Remove" runat="server" />
        <input type="text" id="deleteCourseTeacher" class="input_field" placeholder="Teacher to Remove" runat="server" />
    </div>
    <div runat="server">
        <input type="button" value="Delete" id="deleteButton" onserverclick="DeleteCourse" runat="server" />
        <span id="deleteMSG" style="color: red; font-size: 1.5em; position: absolute" runat="server"></span>
    </div>
</asp:Content>
