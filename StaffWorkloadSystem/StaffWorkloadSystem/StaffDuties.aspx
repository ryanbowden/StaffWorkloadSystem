<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDuties.aspx.cs" Inherits="StaffWorkloadSystem.StaffDuties" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add staff to Duties</h1>
    <p>This is where you will be able to edit and see what a satff member already have.</p>
    <a href="Connect a staff member to a duty" class="btn btn-primary btn-large">Connect a staff member to a duty</a>

    <p>
        <asp:DropDownList ID="StaffMember" runat="server" DataSourceID="SqlDataStaff" DataTextField="Name" DataValueField="ID">
        </asp:DropDownList>


        <asp:SqlDataSource ID="SqlDataStaff" runat="server" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" SelectCommand="SELECT [ID], [Name] FROM [StaffDetails]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataDutiesConnection">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="StaffID" HeaderText="StaffID" SortExpression="StaffID" />
                <asp:BoundField DataField="DutyID" HeaderText="DutyID" SortExpression="DutyID" />
                <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataDutiesConnection" runat="server" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" SelectCommand="SELECT * FROM [StaffDuties] WHERE ([Id] = @Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="StaffMember" Name="Id" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>

</asp:Content>
