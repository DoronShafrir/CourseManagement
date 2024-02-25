<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CourseMaster.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="CourseManagement.Pages.Management.Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/ManagementStyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h1 style="color: crimson">Students Manager Page </h1>

<div class="active_buttons" runat="server">
    <input type="button" value="Show All Students" class="admin-button" onserverclick="RenderList" runat="server" />
    <input type="button" value="Add Student" class="admin-button" onserverclick="ShowInsertPart" runat="server" />
    <input type="button" value="Delete Student" class="admin-button" onserverclick="ShowDeletePart" runat="server" />
</div>
<div id="List" runat="server"></div>

<%----Add Insert part--%>

<div id="active_input" runat="server">
    <span id="insertStudentList" class="selectList" runat="server"></span>
    <span id="insertCourseList" class="selectList" runat="server"></span>
    <%--<input type="text" id="newStudentName" class="input_field" placeholder="Student Name" runat="server" />
    <input type="text" id="newCourseName" class="input_field" placeholder="Course Name" runat="server" />--%>
</div>

<div runat="server">
    <input type="button" value="Insert" id="submitNewButton" onserverclick="Insert" runat="server" />
    <span id="insertMSG" style="color: red; font-size: 1.5em; position: absolute" runat="server"></span>
</div>

<%----Add Insert part--%>

<div id="delete_input" runat="server">
    <div id="selectDelete" class="selectList" runat="server"></div>
    <input type="submit" value="Delete" id="deleteButton" onserverclick="Delete" runat="server" />
    <span id="deleteMSG" style="color: red; font-size: 1.5em; position: absolute" runat="server"></span>
</div>

</asp:Content>
