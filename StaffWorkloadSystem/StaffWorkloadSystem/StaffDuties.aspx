<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDuties.aspx.cs" Inherits="StaffWorkloadSystem.StaffDuties" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <p>You need to be logged in to view this</p>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h1>Add staff to Duties</h1>
            <a href="StaffDutyConnection" class="btn btn-primary btn-large">Connect a staff member to a duty</a><br />
            <br />
            View A Staff Members Duties already assigned!

            <p>
                <asp:DropDownList ID="StaffMemberID" runat="server" DataSourceID="SqlDataStaff" DataTextField="Name" DataValueField="ID" AutoPostBack="True">
                </asp:DropDownList>


                <asp:SqlDataSource ID="SqlDataStaff" runat="server" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" SelectCommand="SELECT [ID], [Name] FROM [StaffDetails]"></asp:SqlDataSource>
            </p>
            <p>
                &nbsp;</p>
            <p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_GetStaffDuties">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="DutyID" HeaderText="DutyID" SortExpression="DutyID" />
                        <asp:BoundField DataField="StaffID" HeaderText="StaffID" SortExpression="StaffID" />
                        <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource_GetStaffDuties" runat="server" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" SelectCommand="SELECT * FROM [StaffDuties] WHERE ([StaffID] = @StaffID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="StaffMemberID" Name="StaffID" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </p>
        </LoggedInTemplate>
    </asp:LoginView>

    

</asp:Content>
