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
            <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>  
            <asp:GridView ID="Modules" runat="server" AutoGenerateColumns="false" AllowPaging="false">
                <Columns>
                    <asp:BoundField DataField="ModuleCode" HeaderText="Module Code" />
                    <asp:BoundField DataField="ModuleName" HeaderText="Module Name" />
                    <asp:BoundField DataField="DetailsLink" HeaderText="Full Details" htmlencode="false"/>
                </Columns>
            </asp:GridView>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
