<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddModules.aspx.cs" Inherits="StaffWorkloadSystem.AddModules" %>
<asp:content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Add a Module
    </h1>
    <p>Here you can enter a module into the system. Please make sure everythign is correct before submitting. </p>
    <label>Name: </label>
    <asp:TextBox ID="moduleName" runat="server"></asp:TextBox>
    <br />
    <label>Module Code: </label>
    <asp:TextBox ID="moduleCode" runat="server"></asp:TextBox>
    <br />
    <label>Lecture Lenth: </label>
    <asp:DropDownList ID="lectureLenth" runat="server">
        <asp:ListItem Value="0">0 Mintues</asp:ListItem>
        <asp:ListItem Value="60">60 Mintues</asp:ListItem>
        <asp:ListItem Value="120">120 Mintues</asp:ListItem>
    </asp:DropDownList>
    <br />
    <label>WorkShop Lenth: </label>
    <asp:DropDownList ID="workshopLenth" runat="server">
        <asp:ListItem Value="0">0 Mintues</asp:ListItem>
        <asp:ListItem Value="60">60 Mintues</asp:ListItem>
        <asp:ListItem Value="120">120 Mintues</asp:ListItem>
    </asp:DropDownList>
    <br />
    <label>Number of Workshopes a week: </label>
    <asp:DropDownList ID="workshopNumbers" runat="server">
        <asp:ListItem Value="0">None per week</asp:ListItem>
        <asp:ListItem Value="1">1 Per Week</asp:ListItem>
        <asp:ListItem Value="2">2 Per Week</asp:ListItem>
        <asp:ListItem Value="3">3 Per Week</asp:ListItem>
    </asp:DropDownList>
    <br />
    <label>Semesters: </label>
    <asp:DropDownList ID="semesters" runat="server">
        <asp:ListItem Value="1">Semester 1</asp:ListItem>
        <asp:ListItem Value="2">Semester 2</asp:ListItem>
        <asp:ListItem Value="3">Semester 1 and 2</asp:ListItem>
    </asp:DropDownList>
    <br />
    <label>Student Numbers: </label>
    <asp:TextBox ID="studentNumbers" runat="server"></asp:TextBox>
    <br />
    <label>Assessments: </label>
    <asp:DropDownList ID="assessments" runat="server">
        <asp:ListItem Value="0">No Assessments</asp:ListItem>
        <asp:ListItem Value="1">1 Assessment</asp:ListItem>
        <asp:ListItem Value="2">2 Assessments</asp:ListItem>
        <asp:ListItem Value="3">3 Assessments</asp:ListItem>
    </asp:DropDownList>
    <br />
    <label>Level: </label>
    <asp:DropDownList ID="level" runat="server">
        <asp:ListItem Value="1">Level 1</asp:ListItem>
        <asp:ListItem Value="2">Level 2</asp:ListItem>
        <asp:ListItem Value="3">Level 3</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Button ID="submitModule" runat="server" OnClick="submitModule_Click" Text="Submit Module" />
</asp:content>
