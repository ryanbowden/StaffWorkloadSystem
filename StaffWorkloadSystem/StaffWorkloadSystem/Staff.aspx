﻿<%@ Page Title="Staff" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="StaffWorkloadSystem.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Staff</h1>
    <p><a href="addstaff" class="btn btn-primary btn-large">Add a staff member</a></p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="StaffDetails">
            <Columns>
                
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="MaxHours" HeaderText="MaxHours" SortExpression="MaxHours" />
                <asp:BoundField DataField="CurrentHours" HeaderText="CurrentHours" SortExpression="CurrentHours" />
                <asp:CheckBoxField DataField="InitialYear" HeaderText="InitialYear" SortExpression="InitialYear" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="StaffDetails" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" DeleteCommand="DELETE FROM [StaffDetails] WHERE [Id] = @original_Id AND (([FirstName] = @original_FirstName) OR ([FirstName] IS NULL AND @original_FirstName IS NULL)) AND (([LastName] = @original_LastName) OR ([LastName] IS NULL AND @original_LastName IS NULL)) AND (([MaxHours] = @original_MaxHours) OR ([MaxHours] IS NULL AND @original_MaxHours IS NULL)) AND (([InitialYear] = @original_InitialYear) OR ([InitialYear] IS NULL AND @original_InitialYear IS NULL))" InsertCommand="INSERT INTO [StaffDetails] ([Id], [FirstName], [LastName], [MaxHours], [InitialYear]) VALUES (@Id, @FirstName, @LastName, @MaxHours, @InitialYear)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [StaffDetails]" UpdateCommand="UPDATE [StaffDetails] SET [FirstName] = @FirstName, [LastName] = @LastName, [MaxHours] = @MaxHours, [InitialYear] = @InitialYear WHERE [Id] = @original_Id AND (([FirstName] = @original_FirstName) OR ([FirstName] IS NULL AND @original_FirstName IS NULL)) AND (([LastName] = @original_LastName) OR ([LastName] IS NULL AND @original_LastName IS NULL)) AND (([MaxHours] = @original_MaxHours) OR ([MaxHours] IS NULL AND @original_MaxHours IS NULL)) AND (([InitialYear] = @original_InitialYear) OR ([InitialYear] IS NULL AND @original_InitialYear IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_FirstName" Type="String" />
                <asp:Parameter Name="original_LastName" Type="String" />
                <asp:Parameter Name="original_MaxHours" Type="Int32" />
                <asp:Parameter Name="original_InitialYear" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="First Name" Type="String" />
                <asp:Parameter Name="Last Name" Type="String" />
                <asp:Parameter Name="Max Hours" Type="Int32" />
                <asp:Parameter Name="Initial Year" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="MaxHours" Type="Int32" />
                <asp:Parameter Name="InitialYear" Type="String" />
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_FirstName" Type="String" />
                <asp:Parameter Name="original_LastName" Type="String" />
                <asp:Parameter Name="original_MaxHours" Type="Int32" />
                <asp:Parameter Name="original_InitialYear" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>

</asp:Content>
