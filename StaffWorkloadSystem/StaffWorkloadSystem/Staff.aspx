<%@ Page Title="Staff" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="StaffWorkloadSystem.Staff" %>
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
        <asp:SqlDataSource ID="StaffDetails" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" DeleteCommand="DELETE FROM [StaffDetails] WHERE [ID] = @original_ID AND [Name] = @original_Name AND [MaxHours] = @original_MaxHours AND (([CurrentHours] = @original_CurrentHours) OR ([CurrentHours] IS NULL AND @original_CurrentHours IS NULL)) AND (([InitialYear] = @original_InitialYear) OR ([InitialYear] IS NULL AND @original_InitialYear IS NULL))" InsertCommand="INSERT INTO [StaffDetails] ([Name], [MaxHours], [CurrentHours], [InitialYear]) VALUES (@Name, @MaxHours, @CurrentHours, @InitialYear)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [StaffDetails]" UpdateCommand="UPDATE [StaffDetails] SET [Name] = @Name, [MaxHours] = @MaxHours, [CurrentHours] = @CurrentHours, [InitialYear] = @InitialYear WHERE [ID] = @original_ID AND [Name] = @original_Name AND [MaxHours] = @original_MaxHours AND (([CurrentHours] = @original_CurrentHours) OR ([CurrentHours] IS NULL AND @original_CurrentHours IS NULL)) AND (([InitialYear] = @original_InitialYear) OR ([InitialYear] IS NULL AND @original_InitialYear IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_MaxHours" Type="Int32" />
                <asp:Parameter Name="original_CurrentHours" Type="Int32" />
                <asp:Parameter Name="original_InitialYear" Type="Boolean" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="MaxHours" Type="Int32" />
                <asp:Parameter Name="CurrentHours" Type="Int32" />
                <asp:Parameter Name="InitialYear" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="MaxHours" Type="Int32" />
                <asp:Parameter Name="CurrentHours" Type="Int32" />
                <asp:Parameter Name="InitialYear" Type="Boolean" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_MaxHours" Type="Int32" />
                <asp:Parameter Name="original_CurrentHours" Type="Int32" />
                <asp:Parameter Name="original_InitialYear" Type="Boolean" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>

</asp:Content>
