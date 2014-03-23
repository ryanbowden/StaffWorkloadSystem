﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addstaff.aspx.cs" Inherits="StaffWorkloadSystem.addstaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add a Staff member!</h1>
<p>
    <asp:FormView ID="FormView2" runat="server" DataKeyNames="ID" DataSourceID="SqlDataSource_addStaff">
        <EditItemTemplate>
            ID:
            <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
            <br />
            FirstName:
            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
            <br />
            LastName:
            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
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
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <EmptyDataTemplate>
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
        </EmptyDataTemplate>
        <InsertItemTemplate>
            First Name:
            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' /><asp:RequiredFieldValidator runat="server"
      id="reqFName" ControlToValidate="FirstNameTextBox"
      ErrorMessage = "You must Provide a First Name!"
      display="Dynamic" />
            <br />
            Last Name:
            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' /><asp:RequiredFieldValidator runat="server"
      id="reqLName" ControlToValidate="LastNameTextBox"
      ErrorMessage = "You must Provide a Last Name!"
      display="Dynamic" />
            <br />
            MaxHours:
            <asp:TextBox ID="MaxHoursTextBox" runat="server" Text='<%# Bind("MaxHours") %>' /><asp:RequiredFieldValidator runat="server"
      id="regMaxHours" ControlToValidate="MaxHoursTextBox"
      ErrorMessage = "You must Provide the Max Hours the staff member should have!"
      display="Dynamic" /><asp:RegularExpressionValidator runat="server"
      id="regexpMaxHours" ControlToValidate="MaxHoursTextBox"
      ValidationExpression="^\d{1,3}$"
      ErrorMessage = "Must Only Contain Numbers!"
      Display="Dynamic" ForeColor="Red" />
            <br />
            InitialYear:
            <asp:CheckBox ID="InitialYearCheckBox" runat="server" Checked='<%# Bind("InitialYear") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
&nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
&nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
    </p>
<p>
    <asp:SqlDataSource ID="SqlDataSource_addStaff" runat="server" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" SelectCommand="SELECT * FROM [StaffDetails]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [StaffDetails] WHERE [ID] = @original_ID AND [FirstName] = @original_FirstName AND [LastName] = @original_LastName AND [MaxHours] = @original_MaxHours AND (([CurrentHours] = @original_CurrentHours) OR ([CurrentHours] IS NULL AND @original_CurrentHours IS NULL)) AND (([InitialYear] = @original_InitialYear) OR ([InitialYear] IS NULL AND @original_InitialYear IS NULL))" InsertCommand="INSERT INTO [StaffDetails] ([FirstName], [LastName], [MaxHours], [CurrentHours], [InitialYear]) VALUES (@FirstName, @LastName, @MaxHours, @CurrentHours, @InitialYear)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [StaffDetails] SET [FirstName] = @FirstName, [LastName] = @LastName, [MaxHours] = @MaxHours, [CurrentHours] = @CurrentHours, [InitialYear] = @InitialYear WHERE [ID] = @original_ID AND [FirstName] = @original_FirstName AND [LastName] = @original_LastName AND [MaxHours] = @original_MaxHours AND (([CurrentHours] = @original_CurrentHours) OR ([CurrentHours] IS NULL AND @original_CurrentHours IS NULL)) AND (([InitialYear] = @original_InitialYear) OR ([InitialYear] IS NULL AND @original_InitialYear IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_FirstName" Type="String" />
            <asp:Parameter Name="original_LastName" Type="String" />
            <asp:Parameter Name="original_MaxHours" Type="Int32" />
            <asp:Parameter Name="original_CurrentHours" Type="Int32" />
            <asp:Parameter Name="original_InitialYear" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="MaxHours" Type="Int32" />
            <asp:Parameter Name="CurrentHours" Type="Int32" />
            <asp:Parameter Name="InitialYear" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="MaxHours" Type="Int32" />
            <asp:Parameter Name="CurrentHours" Type="Int32" />
            <asp:Parameter Name="InitialYear" Type="Int32" />
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_FirstName" Type="String" />
            <asp:Parameter Name="original_LastName" Type="String" />
            <asp:Parameter Name="original_MaxHours" Type="Int32" />
            <asp:Parameter Name="original_CurrentHours" Type="Int32" />
            <asp:Parameter Name="original_InitialYear" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</p>
    
</asp:Content>
