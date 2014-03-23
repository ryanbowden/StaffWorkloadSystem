<%@ Page Title="Duties" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Duties.aspx.cs" Inherits="StaffWorkloadSystem.Duties" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Duties
    </h1>
    <p><a href="addDuties" class="btn btn-primary btn-large">Add a duty</a></p>
    <p>
        Here are all the duties in the system.
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_duties">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
            <EmptyDataTemplate>
                There Is not Duties in the system.
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_duties" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" DeleteCommand="DELETE FROM [Duties] WHERE [ID] = @original_ID AND [Name] = @original_Name AND [Description] = @original_Description" InsertCommand="INSERT INTO [Duties] ([Name], [Description]) VALUES (@Name, @Description)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Duties]" UpdateCommand="UPDATE [Duties] SET [Name] = @Name, [Description] = @Description WHERE [ID] = @original_ID AND [Name] = @original_Name AND [Description] = @original_Description">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_Description" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_Description" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
