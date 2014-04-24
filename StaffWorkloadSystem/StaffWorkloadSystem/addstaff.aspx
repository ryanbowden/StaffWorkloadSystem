<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addstaff.aspx.cs" Inherits="StaffWorkloadSystem.addstaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <h1>Error!</h1>
            <p>You must be login in</p>
       </AnonymousTemplate>
        <LoggedInTemplate>
            <h1>Add a Staff member!</h1>
                <p>
                    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" DataSourceID="SqlDataSource1_addstaff">
                        <EditItemTemplate>
                            ID:
                            <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                            <br />
                            Name:
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                            <br />
                            MaxHours:
                            <asp:TextBox ID="MaxHoursTextBox" runat="server" Text='<%# Bind("MaxHours") %>' />
                            <br />
                            CurrentHours:
                            <asp:TextBox ID="CurrentHoursTextBox" runat="server" Text='<%# Bind("CurrentHours") %>' />
                            <br />
                            InitialYear:
                            <asp:CheckBox ID="InitialYearCheckBox" runat="server" Checked='<%# Bind("InitialYear") %>' />
                            <br />
                            ResearchLeave:
                            <asp:CheckBox ID="ResearchLeaveCheckBox" runat="server" Checked='<%# Bind("ResearchLeave") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            Name:
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                            <br />
                            MaxHours:
                            <asp:TextBox ID="MaxHoursTextBox" runat="server" Text='<%# Bind("MaxHours") %>' />
                            <br />
                            CurrentHours:
                            <asp:TextBox ID="CurrentHoursTextBox" runat="server" Text='<%# Bind("CurrentHours") %>' />
                            <br />
                            InitialYear:
                            <asp:CheckBox ID="InitialYearCheckBox" runat="server" Checked='<%# Bind("InitialYear") %>' />
                            <br />
                            ResearchLeave:
                            <asp:CheckBox ID="ResearchLeaveCheckBox" runat="server" Checked='<%# Bind("ResearchLeave") %>' />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:SqlDataSource ID="SqlDataSource1_addstaff" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" DeleteCommand="DELETE FROM [StaffDetails] WHERE [ID] = @original_ID AND [Name] = @original_Name AND [MaxHours] = @original_MaxHours AND (([CurrentHours] = @original_CurrentHours) OR ([CurrentHours] IS NULL AND @original_CurrentHours IS NULL)) AND (([InitialYear] = @original_InitialYear) OR ([InitialYear] IS NULL AND @original_InitialYear IS NULL)) AND (([ResearchLeave] = @original_ResearchLeave) OR ([ResearchLeave] IS NULL AND @original_ResearchLeave IS NULL))" InsertCommand="INSERT INTO [StaffDetails] ([Name], [MaxHours], [CurrentHours], [InitialYear], [ResearchLeave]) VALUES (@Name, @MaxHours, @CurrentHours, @InitialYear, @ResearchLeave)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [StaffDetails]" UpdateCommand="UPDATE [StaffDetails] SET [Name] = @Name, [MaxHours] = @MaxHours, [CurrentHours] = @CurrentHours, [InitialYear] = @InitialYear, [ResearchLeave] = @ResearchLeave WHERE [ID] = @original_ID AND [Name] = @original_Name AND [MaxHours] = @original_MaxHours AND (([CurrentHours] = @original_CurrentHours) OR ([CurrentHours] IS NULL AND @original_CurrentHours IS NULL)) AND (([InitialYear] = @original_InitialYear) OR ([InitialYear] IS NULL AND @original_InitialYear IS NULL)) AND (([ResearchLeave] = @original_ResearchLeave) OR ([ResearchLeave] IS NULL AND @original_ResearchLeave IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_ID" Type="Int32" />
                            <asp:Parameter Name="original_Name" Type="String" />
                            <asp:Parameter Name="original_MaxHours" Type="Int32" />
                            <asp:Parameter Name="original_CurrentHours" Type="Int32" />
                            <asp:Parameter Name="original_InitialYear" Type="Boolean" />
                            <asp:Parameter Name="original_ResearchLeave" Type="Boolean" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="MaxHours" Type="Int32" />
                            <asp:Parameter Name="CurrentHours" Type="Int32" />
                            <asp:Parameter Name="InitialYear" Type="Boolean" />
                            <asp:Parameter Name="ResearchLeave" Type="Boolean" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="MaxHours" Type="Int32" />
                            <asp:Parameter Name="CurrentHours" Type="Int32" />
                            <asp:Parameter Name="InitialYear" Type="Boolean" />
                            <asp:Parameter Name="ResearchLeave" Type="Boolean" />
                            <asp:Parameter Name="original_ID" Type="Int32" />
                            <asp:Parameter Name="original_Name" Type="String" />
                            <asp:Parameter Name="original_MaxHours" Type="Int32" />
                            <asp:Parameter Name="original_CurrentHours" Type="Int32" />
                            <asp:Parameter Name="original_InitialYear" Type="Boolean" />
                            <asp:Parameter Name="original_ResearchLeave" Type="Boolean" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </p>
                <p>
                    &nbsp;</p>
       </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
