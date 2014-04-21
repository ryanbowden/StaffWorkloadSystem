<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddModulesToStaff.aspx.cs" Inherits="StaffWorkloadSystem.AddModulesToStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView id="LoginView1" runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <h1>You need to LogIn</h1>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h1>Add staff member to a Module</h1>
            <p>
                Information and form will go here!
            </p>

        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
