<%@ Page Title="Modules" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modules.aspx.cs" Inherits="StaffWorkloadSystem.Modules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Modules
    </h1>
    <p>
        Here are all the modules in the system.
    </p>
    <p>
        Select level you wish to view:
    </p>
    <label>Level: </label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
        <asp:ListItem Selected="True" Value="1">Level 1</asp:ListItem>
        <asp:ListItem Value="2">Level 2</asp:ListItem>
        <asp:ListItem Value="3">Level 3</asp:ListItem>
        <asp:ListItem Value="4">Level 4</asp:ListItem>
</asp:DropDownList>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1_Modules">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="ModuleCode" HeaderText="ModuleCode" SortExpression="ModuleCode" />
                <asp:BoundField DataField="LectureLenthMinutes" HeaderText="LectureLenthMinutes" SortExpression="LectureLenthMinutes" />
                <asp:BoundField DataField="WorkShopLenthMinutes" HeaderText="WorkShopLenthMinutes" SortExpression="WorkShopLenthMinutes" />
                <asp:BoundField DataField="WorkShopNumbers" HeaderText="WorkShopNumbers" SortExpression="WorkShopNumbers" />
                <asp:BoundField DataField="Semesters" HeaderText="Semesters" SortExpression="Semesters" />
                <asp:BoundField DataField="StudentNumbers" HeaderText="StudentNumbers" SortExpression="StudentNumbers" />
                <asp:BoundField DataField="Assessments" HeaderText="Assessments" SortExpression="Assessments" />
                <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1_Modules" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:staffwoAJ4TKlNRsConnectionString %>" DeleteCommand="DELETE FROM [Modules] WHERE [ID] = @original_ID AND [Name] = @original_Name AND [ModuleCode] = @original_ModuleCode AND [LectureLenthMinutes] = @original_LectureLenthMinutes AND [WorkShopLenthMinutes] = @original_WorkShopLenthMinutes AND (([WorkShopNumbers] = @original_WorkShopNumbers) OR ([WorkShopNumbers] IS NULL AND @original_WorkShopNumbers IS NULL)) AND (([Semesters] = @original_Semesters) OR ([Semesters] IS NULL AND @original_Semesters IS NULL)) AND (([StudentNumbers] = @original_StudentNumbers) OR ([StudentNumbers] IS NULL AND @original_StudentNumbers IS NULL)) AND (([Assessments] = @original_Assessments) OR ([Assessments] IS NULL AND @original_Assessments IS NULL)) AND (([Level] = @original_Level) OR ([Level] IS NULL AND @original_Level IS NULL))" InsertCommand="INSERT INTO [Modules] ([Name], [ModuleCode], [LectureLenthMinutes], [WorkShopLenthMinutes], [WorkShopNumbers], [Semesters], [StudentNumbers], [Assessments], [Level]) VALUES (@Name, @ModuleCode, @LectureLenthMinutes, @WorkShopLenthMinutes, @WorkShopNumbers, @Semesters, @StudentNumbers, @Assessments, @Level)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Modules] WHERE ([Level] = @Level)" UpdateCommand="UPDATE [Modules] SET [Name] = @Name, [ModuleCode] = @ModuleCode, [LectureLenthMinutes] = @LectureLenthMinutes, [WorkShopLenthMinutes] = @WorkShopLenthMinutes, [WorkShopNumbers] = @WorkShopNumbers, [Semesters] = @Semesters, [StudentNumbers] = @StudentNumbers, [Assessments] = @Assessments, [Level] = @Level WHERE [ID] = @original_ID AND [Name] = @original_Name AND [ModuleCode] = @original_ModuleCode AND [LectureLenthMinutes] = @original_LectureLenthMinutes AND [WorkShopLenthMinutes] = @original_WorkShopLenthMinutes AND (([WorkShopNumbers] = @original_WorkShopNumbers) OR ([WorkShopNumbers] IS NULL AND @original_WorkShopNumbers IS NULL)) AND (([Semesters] = @original_Semesters) OR ([Semesters] IS NULL AND @original_Semesters IS NULL)) AND (([StudentNumbers] = @original_StudentNumbers) OR ([StudentNumbers] IS NULL AND @original_StudentNumbers IS NULL)) AND (([Assessments] = @original_Assessments) OR ([Assessments] IS NULL AND @original_Assessments IS NULL)) AND (([Level] = @original_Level) OR ([Level] IS NULL AND @original_Level IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_ModuleCode" Type="String" />
                <asp:Parameter Name="original_LectureLenthMinutes" Type="Int32" />
                <asp:Parameter Name="original_WorkShopLenthMinutes" Type="Int32" />
                <asp:Parameter Name="original_WorkShopNumbers" Type="Int32" />
                <asp:Parameter Name="original_Semesters" Type="Int32" />
                <asp:Parameter Name="original_StudentNumbers" Type="Int32" />
                <asp:Parameter Name="original_Assessments" Type="Int32" />
                <asp:Parameter Name="original_Level" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="ModuleCode" Type="String" />
                <asp:Parameter Name="LectureLenthMinutes" Type="Int32" />
                <asp:Parameter Name="WorkShopLenthMinutes" Type="Int32" />
                <asp:Parameter Name="WorkShopNumbers" Type="Int32" />
                <asp:Parameter Name="Semesters" Type="Int32" />
                <asp:Parameter Name="StudentNumbers" Type="Int32" />
                <asp:Parameter Name="Assessments" Type="Int32" />
                <asp:Parameter Name="Level" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Level" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="ModuleCode" Type="String" />
                <asp:Parameter Name="LectureLenthMinutes" Type="Int32" />
                <asp:Parameter Name="WorkShopLenthMinutes" Type="Int32" />
                <asp:Parameter Name="WorkShopNumbers" Type="Int32" />
                <asp:Parameter Name="Semesters" Type="Int32" />
                <asp:Parameter Name="StudentNumbers" Type="Int32" />
                <asp:Parameter Name="Assessments" Type="Int32" />
                <asp:Parameter Name="Level" Type="Int32" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_ModuleCode" Type="String" />
                <asp:Parameter Name="original_LectureLenthMinutes" Type="Int32" />
                <asp:Parameter Name="original_WorkShopLenthMinutes" Type="Int32" />
                <asp:Parameter Name="original_WorkShopNumbers" Type="Int32" />
                <asp:Parameter Name="original_Semesters" Type="Int32" />
                <asp:Parameter Name="original_StudentNumbers" Type="Int32" />
                <asp:Parameter Name="original_Assessments" Type="Int32" />
                <asp:Parameter Name="original_Level" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>

</asp:Content>
