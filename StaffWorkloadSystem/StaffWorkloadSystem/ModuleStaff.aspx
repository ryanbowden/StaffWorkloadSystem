<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModuleStaff.aspx.cs" Inherits="StaffWorkloadSystem.ModuleStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView id="LoginView1" runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <h2>Sorry there been a error</h2>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h1 runat="server">Module - </h1>

            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
