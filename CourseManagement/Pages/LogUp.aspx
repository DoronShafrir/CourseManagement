<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CourseMaster.Master" AutoEventWireup="true" CodeBehind="LogUp.aspx.cs" Inherits="CourseManagement.Pages.LogUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/StyleSheet1.css" rel="stylesheet" />
    <script src="../JS/LogUp.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registration Form</h1>

    <table id="names">
        <tr>
            <td>User First Name</td>
            <td id="fName">
                <input type="text" name="firstName" onkeyup="checkName(this, 'fmsg')" />
            </td>
            <td id="fmsg" class="messages" runat="server"></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td id="lName">
                <input type="text" name="lastName" onkeyup="checkName(this, 'lmsg')" />
            </td>
            <td id="lmsg" class="messages"></td>
        </tr>
        <tr>
            <td>User Name</td>
            <td id="uName">
                <input type="text" name="userName" onkeyup="checkName(this, 'umsg')" />
            </td>
            <td id="umsg" class="messages" runat="server" style="color: red"></td>
        </tr>
        <tr>
            <td>Password</td>
            <td id="pName">
                <input type="password" name="password" onkeyup="checkPass(this)" />
            </td>
            <td id="pmsg" class="messages"></td>
            <tr>
                <td>E-Mail</td>
                <td id="email1">
                    <input type="email" id="email" name="email" onkeyup="checkEmail(this)" />
                </td>
                <td id="emsg" class="messages"></td>
            </tr>
        <tr>
            <td>Phone</td>
            <td id="tel">
                <input type="tel" name="phone" onkeyup="checkTel(this)" />
            </td>
            <td id="tmsg" class="messages"></td>
        </tr>
        <tr>
            <td>Gender</td>
            <td id="gender">
                <input type="radio" name="gender" value="Male" id="Male">
                <label for="male">Male</label><br>
                <input type="radio" name="gender" value="Female" id="Female">
                <label for="female">Female</label>
            </td>
            <td id="gmsg" class="messages"></td>
        </tr>
        <tr>
            <td>Hobbies</td>
            <td id="hName">
                <input type="text" name="hobbies" onkeyup="checkHobbies(this)" />
            </td>
            <td id="hmsg" class="messages"></td>
        </tr>
        <tr>
            <td>Birth Date</td>
            <td>
                <input type="date" id="dName" name="birth">
            </td>
            <td id="dmsg" class="messages"></td>
        </tr>
        <tr>
            <td>Confirmation</td>
            <td>
                <label for="cName">please confirm that all above is correct</label>
                <input id="cName" type="checkbox" name="confirmation" onclick="clearConfirm()" />
            </td>
            <td id="cmsg" class="messages"></td>

        </tr>
    </table>

    <table class="buttons1">
        <tr>
            <td>
                <input type="submit" class="register" value="REGISTER" onclick="return register1()" /></td>
            <td>
                <input type="reset" class="reset" value=" RESET&nbsp&nbsp&nbsp" onclick="reset1()" /></td>

        </tr>

    </table>



    <h2>System Messages</h2>
    <p id="SysMes" runat="server"></p>
    <p id="localHost" runat="server"></p>
</asp:Content>
