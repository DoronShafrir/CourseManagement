<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CourseMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="CourseManagement.Pages.Admom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="flex-container">
        <div>
            <input id="searchText" name="searchText"   type="text" placeholder="name or last name" />
        </div>
        <div>
            <input id="search" type="button" value="Search"  onserverclick="Search_Name" runat="server" />
        </div>
    </div>
    <div class="flex-container">
        <div>
            <input id="deleteText" name="deleteText"   type="text" placeholder="UserName to delete" />
        </div>
        <div>
            <input id="delete" type="button" value="Delete"  onserverclick="Delete_User" runat="server" />
        </div>
    </div>
    <div id="tableDiv" runat="server">
    </div>
</asp:Content>
