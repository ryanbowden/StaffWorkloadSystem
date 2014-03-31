<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDutyConnection.aspx.cs" Inherits="StaffWorkloadSystem.StaffDutyConnection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Staff to Duty Connection!
    </h1>
    <p>
        Here you are able to connect a staff member to a duty and the hours it will take for the year.</p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    </p>
    <p>
        Staff Name:
        <asp:DropDownList ID="StaffID" runat="server" DataSourceID="SqlData_Staff" DataTextField="Name" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlData_Staff" runat="server" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" SelectCommand="SELECT [Name], [ID] FROM [StaffDetails]"></asp:SqlDataSource>
    </p>
    <p>
        Duty :
        <asp:DropDownList ID="DutyID" runat="server" DataSourceID="SqlData_Duties" DataTextField="Name" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlData_Duties" runat="server" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" SelectCommand="SELECT [ID], [Name] FROM [Duties]"></asp:SqlDataSource>
    </p>
    <p>
        Hours :
        <asp:TextBox ID="Hours" runat="server"></asp:TextBox><asp:RequiredFieldValidator runat="server"
      id="regDesc" ControlToValidate="Hours"
      ErrorMessage = "You must Provide the hours this duty will take the staff member over the year.!"
      display="Dynamic" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" BorderStyle="None" ControlToValidate="Hours" ErrorMessage="Please only enter Numbers" ForeColor="#FF3300" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Button ID="CompleteConnection" runat="server" OnClick="CompleteConnection_Click" Text="Connect" />
    </p>

</asp:Content>
