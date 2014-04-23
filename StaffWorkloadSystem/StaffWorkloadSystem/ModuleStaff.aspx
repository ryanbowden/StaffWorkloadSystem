<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModuleStaff.aspx.cs" Inherits="StaffWorkloadSystem.ModuleStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView id="LoginView1" runat="server" ViewStateMode="Enabled">
        <AnonymousTemplate>
            <h2>Sorry there been a error</h2>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h1 runat="server">Module - Add Staff</h1>


            <h2>Module Details</h2>
            <!-- Display the Module Details -->
            <label>Module Name -&nbsp</label><asp:Label ID="ModuleName" runat="server" Text=""></asp:Label>
            <label>  |  Module Code -&nbsp</label><asp:Label ID="ModuleCode" runat="server" Text=""></asp:Label>


            <h2>Add staff</h2>
            <!--Add Staff form-->
            <p>Add a staff Member to this Module</p>
            <p><asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red" Font-Underline="True" Font-Bold="True" Font-Size="Large"></asp:Label></p>
            <p><asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Underline="True" Font-Bold="True" Font-Size="Large"></asp:Label></p>
            <Label>Staff member: </Label>
            <asp:DropDownList ID="ddl_StaffMember" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
            <label>Weighting: </label> 
            <asp:TextBox ID="txtbox_Weighting" runat="server"></asp:TextBox>
            <label>Coordinator: </label>
            <asp:DropDownList ID="ddl_Coordinator" runat="server">
                <asp:ListItem Value="1">True</asp:ListItem>
                <asp:ListItem Selected="True" Value="0">False</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="but_SubmitStaff" runat="server" Text="Add staff member to module" OnClick="but_SubmitStaff_Click" />


            <h2>Current Staff</h2>
            <!---Shows Current Staff in this Module -->
             <asp:GridView ID="StaffModulesDetails" runat="server" AutoGenerateColumns="false" AllowPaging="false">
                <Columns>
                    <asp:BoundField DataField="StaffName" HeaderText="Name"  />
                    <asp:BoundField DataField="Weighting" HeaderText="Weighting" />
                    <asp:BoundField DataField="Coordinator" HeaderText="Coordinator" />
                    <asp:BoundField DataField="ExtraHours" HeaderText="Extra Hours" />
                    <asp:BoundField DataField="Edit" HeaderText="Edit" />
                    <asp:BoundField DataField="Delete" HeaderText="Delete" />
                </Columns>
            </asp:GridView>
            
        </LoggedInTemplate>
    </asp:LoginView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" SelectCommand="SELECT [ID], [Name] FROM [StaffDetails]"></asp:SqlDataSource>
</asp:Content>
