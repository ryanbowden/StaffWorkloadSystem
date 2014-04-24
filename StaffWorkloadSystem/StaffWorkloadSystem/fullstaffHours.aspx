<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="fullstaffHours.aspx.cs" Inherits="StaffWorkloadSystem.fullstaffHours" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Full Staff Hours</h1>
    <p>
        The table Below Shows Every Staff member With their Full working Hours they have.
    </p>
    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>  
    <asp:GridView ID="StaffFullHours" runat="server" AutoGenerateColumns="false" AllowPaging="false">
        <Columns>
            <asp:BoundField DataField="StaffName" HeaderText="Name" />
            <asp:BoundField DataField="ResearchLeave" HeaderText="Reseach" />
            <asp:BoundField DataField="Initialyear" HeaderText="Initial Year" />
            <asp:BoundField DataField="DeliveryandTeaching" HeaderText="Total Delivery and Teaching" />
            <asp:BoundField DataField="TotalDuty" HeaderText="Total Duty" />
            <asp:BoundField DataField="TotalHours" HeaderText="TOTAL HOURS" />
        </Columns>
    </asp:GridView>
</asp:Content>
