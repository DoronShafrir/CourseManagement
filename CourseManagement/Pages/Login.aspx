<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CourseMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CourseManagement.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../CSS/StyleSheet1.css" rel="stylesheet" />
 <script src="../JS/LogIn.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Registration Form</h1>

<table id="login">
  <tr>
        <td>User Name</td>
        <td id="lName"><input   type="text" name="userName" onkeyup="checkLogInValidity(this, 'umsg')" /> </td> 
        <td id="umsg" class="messages" runat="server" > </td>
    </tr>
    <tr>
        <td>Password</td>
        <td id="pName"><input type="password" name="password" onkeyup="checkLogInValidity(this, 'pmsg')"  /> </td>
        <td id="pmsg" class="messages" runat="server"  > </td>
    </tr>
    </table>
<table class="buttons1">
    <tr>
        <td><input type="submit" name="submit" class="login" value="&nbsp&nbsp&nbsp LogIn&nbsp&nbsp&nbsp" onclick="return login1()" /></td>
        <td><input type="reset" class="reset" value=" RESET&nbsp&nbsp&nbsp" onclick="reset2()" /></td>
    </tr>
    </table>
</asp:Content>
