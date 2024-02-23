<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CourseMaster.Master" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="CourseManagement.Pages.General.WelcomPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../CSS/StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainContainer">
    <div class="mainPic">
        <img id="einstein" src="../../Img/Welcome.jpg" alt="Welcome" height="300" style="align-content:space-around" />
    </div>

    <div class="mainVid" height="400" style="scroll-padding-block-end:100px">
        <iframe width="560" height="500" src="https://www.youtube.com/embed/TTHazQeM8v8" title="YouTube video player" frameborder="0"
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>
    </div>
</div>
</asp:Content>
