﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminMain.aspx.cs" Inherits="LibraryWebsite.Pages.Main.AdminMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h2>User Accounts Info</h2>
            <p>
                You can view all Acounts, Add a new User, Edit or Remove.
            </p>
            <p>
                <a class="btn btn-default" href="../Accounts/AdminViewAllAccounts.aspx">Learn more &raquo;</a>
            </p>
        </div>

        <div class="col-md-6">
            <h2>Books Info</h2>
            <p>
               You can view all Categories & Books, Add a new Book, Edit or Remove.
            </p>
            <p>
                <a class="btn btn-default" href="../Books/AdminViewAllBooks.aspx">Learn more &raquo;</a>
            </p>
        </div>
    </div>

    <div class="row"> 
        <div class="col-md-6">
            <h2>Borrow Book</h2>
            <p>              
               You can initiate a borrow book operation.
            </p>
            <p>
                <a class="btn btn-default" href="../Borrow/AdminBorrowBook.aspx">Learn more &raquo;</a>
            </p>
        </div>

        <div class="col-md-6">
            <h2>Return Book</h2>
            <p>
                You can initiate a return book operation.
            </p>
            <p>
                <a class="btn btn-default" href="../Return/AdminReturnBook.aspx">Learn more &raquo;</a>
            </p>
        </div>
    </div>

    <div class="row"> 
        <div class="col-md-6">
            <h2>Reports</h2>
            <p>
                You can view Report about Library.
            </p>
            <p>
                <a class="btn btn-default" href="../Report/AdminReports.aspx">Learn more &raquo;</a>
            </p>
        </div>
     </div>
</asp:Content>
