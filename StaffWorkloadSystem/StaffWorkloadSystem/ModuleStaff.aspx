<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModuleStaff.aspx.cs" Inherits="StaffWorkloadSystem.ModuleStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView id="LoginView1" runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <h2>Sorry there been a error</h2>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h1 runat="server">Module - Add Staff</h1>
            <h2>Module Details</h2>
            <label>Module Name -&nbsp</label><asp:Label ID="ModuleName" runat="server" Text=""></asp:Label>
            <label>  |  Module Code -&nbsp</label><asp:Label ID="ModuleCode" runat="server" Text=""></asp:Label>
            <h2>Add staff</h2>
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Underline="True" Font-Bold="True" Font-Size="Large"></asp:Label>
            <h2>Current Staff</h2>
            
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
