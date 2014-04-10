<%@ Page Title="Duties" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Duties.aspx.cs" Inherits="StaffWorkloadSystem.Duties" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <p>You must be logged in!</p>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h1>
                Duties
            </h1>
            <p><a href="addDuties" class="btn btn-primary btn-large">Add a duty</a>&nbsp;<a href="StaffDuties" class="btn btn-primary btn-large">Connect to staff</a> </p>
            <p>
                Here are all the duties in the system.
            </p>
            <p>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_duties" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataTemplate>
                        There Is not Duties in the system.
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
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
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
