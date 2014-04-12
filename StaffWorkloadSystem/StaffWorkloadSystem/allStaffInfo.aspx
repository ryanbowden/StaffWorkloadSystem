<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="allStaffInfo.aspx.cs" Inherits="StaffWorkloadSystem.allStaffInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Full Staff Details</h1>
    <p>Here is the full staff details.</p>
    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>  
    <asp:GridView ID="StaffDutiesDetails" runat="server" AutoGenerateColumns="false" AllowPaging="false">
        <Columns>
            <asp:BoundField DataField="StaffName" HeaderText="Name" />
            <asp:BoundField DataField="ModuleCode" HeaderText="Module" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="DeliverySemester" HeaderText="Semester" />
            <asp:BoundField DataField="Hours" HeaderText="Hours" />
        </Columns>
    </asp:GridView>
</asp:Content>
