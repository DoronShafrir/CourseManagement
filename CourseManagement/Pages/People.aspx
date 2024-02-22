<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CourseMaster.Master" AutoEventWireup="true" CodeBehind="People.aspx.cs" Inherits="CourseManagement.Pages.People" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../CSS/AdminStyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="color: crimson">People Manager Page </h1>


 <div class="active_buttons" runat="server">
     <input type="button" value="Show All People" class="admin-button" onserverclick="RenderList" runat="server" />
     <button type="button" value="Add Person" class="admin-button" onserverclick="ShowAddPart" runat="server">Add Person</button>
     <button type="button" value="Delete Person" class="admin-button" onserverclick="ShowDeletePart" runat="server">Delete Person</button>
 </div>
 <div id="List" runat="server"></div>

 <%--    <%--Add Insert part--%>

 <div id="active_input"  runat="server">
     <input type="text" id="newPersonName" class="input_field" placeholder="Person Name" runat="server" />
     <input type="text" id="newPersonFamily" class="input_field" placeholder="Family Name" runat="server" />
     <input type="text" id="newUserName" class="input_field" placeholder="User Name" runat="server" />
     <input type="text" id="newPassword" class="input_field" placeholder="Password" runat="server" />
     <label for="Admin"  class="input_field">
         <input type="radio" name="admin" value="Admin" id="Admin" runat="server" />Admin</label>
     <label for="Admin"class="input_field">
         <input type="radio" name="admin" value="NotAdmin" id="NotAdmin" runat="server" checked/>Regular</label>
     <label class="input_field">
         <input type="radio" name="teacher" value="Teacher" id="Teacher" runat="server" />Teacher</label>
     <label class="input_field">
         <input type="radio" name="teacher" value="Student" id="Student"  runat="server" checked/>Student</label>
 </div>

 <div runat="server">
     <input type="button" value="Insert" id="submitNewButton" onserverclick="Insert" runat="server" />
     <span id="insertMSG" style="color: red; font-size: 1.5em; position: absolute" runat="server"></span>
 </div>

 <%--Delete part--%>

 <div id="delete_input" runat="server">
     <input type="text" id="deletePersonName" class="input_field" placeholder="Person Name to Remove" runat="server" />
     <input type="text" id="deletePersonFamily" class="input_field" placeholder="Family Name  to Remove" runat="server" />
     <input type="text" id="deleteUserName" class="input_field" placeholder="UserName to Remove" runat="server" />
 </div>
 <div runat="server">
     <input type="button" value="Delete" id="deleteButton" onserverclick="Delete" runat="server" />
     <span id="deleteMSG" style="color: red; font-size: 1.5em; position: absolute" runat="server"></span>
 </div>
</asp:Content>
