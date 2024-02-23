<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CourseMaster.Master" AutoEventWireup="true" CodeBehind="Teachers.aspx.cs" Inherits="CourseManagement.Pages.Management.Teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/ManagementStyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color: crimson">Teachers Manager Page </h1>

    <div class="active_buttons" runat="server">
        <input type="button" value="Show All Teachers" class="admin-button" onserverclick="RenderList" runat="server" />
        <input type="button" value="Add Teacher" class="admin-button" onserverclick="ShowAddPart" runat="server" />
        <input type="button" value="Delete Teacher" class="admin-button" onserverclick="ShowDeletePart" runat="server" />
    </div>
    <div id="List" runat="server"></div>

    <%--    <%--Add Insert part--%>

    <div id="active_input" runat="server">
        <input type="text" id="newName" class="input_field" placeholder="Teacher Name" runat="server" />
        <input type="text" id="newCourseName" class="input_field" placeholder="Course Name" runat="server" />
    </div>

    <div runat="server">
        <input type="button" value="Insert" id="submitNewButton" onserverclick="Insert" runat="server" />
        <span id="insertMSG" style="color: red; font-size: 1.5em; position: absolute" runat="server"></span>
    </div>

    <%--Delete part--%>

    <div id="delete_input" runat="server">
        <input type="text" id="deleteName" class="input_field" placeholder="Student Name to Remove" runat="server" />
        <input type="text" id="deleteCourseName" class="input_field" placeholder="Course Name  to Remove" runat="server" />
    </div>
    <div runat="server">
        <input type="button" value="Delete" id="deleteButton" onserverclick="Delete" runat="server" />
        <span id="deleteMSG" style="color: red; font-size: 1.5em; position: absolute" runat="server"></span>
    </div>
</asp:Content>
