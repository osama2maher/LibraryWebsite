﻿<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminReports.aspx.cs" Inherits="LibraryWebsite.Pages.Report.AdminReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


          <h2><%: Title %>.</h2>
          <hr />

    <div class="form-horizontal">
     <div class="row">
        <div class="col-md-3">
            <h4>Number of User Accounts</h4>
            <p>
                <asp:Label runat="server" ID="lblUsersNumber" CssClass="col-md-2 control-label"/>
            </p>
        </div>

        <div class="col-md-3">
            <h4>Number of Books</h4>
            <p>
                <asp:Label runat="server" ID="lblBooksNumber"  CssClass="col-md-2 control-label"/>
            </p>
        </div>

         <div class="col-md-3">
            <h4> Number of Borrowed Books</h4>
            <p>
                <asp:Label runat="server" ID="lblBorrowedNumber" CssClass="col-md-2 control-label"/>
            </p>
        </div>

         <div class="col-md-3">
            <h4> Number of Returned Books</h4>
            <p>
                <asp:Label  runat="server" ID="lblReturnedNumber"  CssClass="col-md-2 control-label"/>
            </p>
        </div>
    </div>

    <div class="row">
       <div class="col-md-3">
            <h4>Number of Admin Accounts</h4>
            <p>
                <asp:Label runat="server" ID="lblAdminNumber" CssClass="col-md-2 control-label"/>
            </p>
        </div>

         <div class="col-md-3">
            <h4>Number of Book Categories</h4>
            <p>
                <asp:Label runat="server" ID="lblBookCategoriesNumber" CssClass="col-md-2 control-label"/>
            </p>
        </div>

         <div class="col-md-3">
            <h4>Number of Currently Borrowed</h4>
            <p>
                <asp:Label runat="server" ID="lblCurrentlyBorrowedNumber" CssClass="col-md-2 control-label"/>
            </p>
        </div>

         <div class="col-md-3">
            <h4>Number of Fined Users</h4>
            <p>
                <asp:Label runat="server" ID="lblFinedNumber" CssClass="col-md-2 control-label"/>
            </p>
        </div>
    </div>
    <br />
    <br />
    <br />
    <div class="row">
        <div class="col-md-6">
             <cc1:PieChart ID="PieChart1"  runat="server" ChartTitle="Book in Category" ChartType="Column"/>
        </div>
        <div class="col-md-6">
                     <cc1:PieChart ID="PieChart2"  runat="server" ChartTitle="Book Availability" ChartType="Column"  />
        </div>
    </div>
        </div>
</asp:Content>

