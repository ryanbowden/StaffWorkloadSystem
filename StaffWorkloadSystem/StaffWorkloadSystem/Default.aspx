<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StaffWorkloadSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Staff Workload System</h1>
        <p>School Of Computer Science - University of Lincoln</p>
        <p class="lead">Welcome to the staff workload system..</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>All Staff Information</h2>
            <p>
                A table with every staff members duties and hours
            </p>
            <p>
                <a class="btn btn-default" href="/allStaffInfo">All Staff info</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Full Staff Hours</h2>
            <p>
                A table with every staff members Full Hours
            </p>
            <p>
                <a class="btn btn-default" href="/fullstaffHours">Full Staff Hours</a>
            </p>
        </div>
        <!--<div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>-->
    </div>

</asp:Content>
