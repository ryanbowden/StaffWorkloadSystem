<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectModule.aspx.cs" Inherits="StaffWorkloadSystem.AddModulesToStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView id="LoginView1" runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <h1>You need to LogIn</h1>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h1>Module Slection</h1>
            <p>
                Please Select a Module From this List.
            </p>

        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
