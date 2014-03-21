<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addstaff.aspx.cs" Inherits="StaffWorkloadSystem.addstaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add a Staff member!</h1>
<p>&nbsp;</p>
<p>
    <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="Id" DataSourceID="SqlDataSource_addStaff">
        <EditItemTemplate>
            Id:
            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            FirstName:
            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
            <br />
            LastName:
            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
            <br />
            MaxHours:
            <asp:TextBox ID="MaxHoursTextBox" runat="server" Text='<%# Bind("MaxHours") %>' />
            <br />
            InitialYear:
            <asp:TextBox ID="InitialYearTextBox" runat="server" Text='<%# Bind("InitialYear") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            Id:
            <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
            <br />
            FirstName:
            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
            <br />
            LastName:
            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
            <br />
            MaxHours:
            <asp:TextBox ID="MaxHoursTextBox" runat="server" Text='<%# Bind("MaxHours") %>' />
            <br />
            InitialYear:
            <asp:TextBox ID="InitialYearTextBox" runat="server" Text='<%# Bind("InitialYear") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            FirstName:
            <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>' />
            <br />
            LastName:
            <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>' />
            <br />
            MaxHours:
            <asp:Label ID="MaxHoursLabel" runat="server" Text='<%# Bind("MaxHours") %>' />
            <br />
            InitialYear:
            <asp:Label ID="InitialYearLabel" runat="server" Text='<%# Bind("InitialYear") %>' />
            <br />

        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource_addStaff" runat="server" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" SelectCommand="SELECT * FROM [StaffDetails]"></asp:SqlDataSource>
</p>
</asp:Content>
