<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CourseMaster.Master" AutoEventWireup="true" CodeBehind="AdminMainPage.aspx.cs" Inherits="CourseManagement.Pages.AdminMainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="active-area">
        <div >
            <label for="searchUser" class="search-label">SEARCH</label>
            <input type="text"  class="search_input"  id="searchUser" name="searchUser" placeholder="User Name to seacrch" />

        </div>
        <div class="active_buttons">
            <input id="search" type="button" value="Search"  onserverclick="SearchName" runat="server" />

            <button type="submit" class="admin-button"  onserverclick="searchRecords" >Edit</button>
            <button type="submit" class="admin-button"  onserverclick="editRecord" >Edit</button>
            <button type="submit" class="admin-button"  onserverclick="changeToUser" >Make User</button>
            <button type="submit" class="admin-button"  onserverclick="changeToAdmin" >Make Admin</button>
            <button type="submit" class="admin-button"  onserverclick="deleteUser" >Delete</button>
        </div>
    </div>
    <div>
        <p id ="mainTable" runat="server"></p>
    </div>
</asp:Content>
