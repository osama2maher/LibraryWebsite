<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserMain.aspx.cs" Inherits="LibraryWebsite.Pages.Main.UserMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row" >
        <div class="col-md-6" >
            <h2>Account Info</h2>
            <p>
                You can view your Account & Edit.
            </p>
            <p>
                <a class="btn btn-default" href="../Accounts/UserViewAccount.aspx">Learn more &raquo;</a>
            </p>
        </div>

        <div class="col-md-6" >
            <h2>Books Info</h2>
            <p>
               You can view all Categories & Books.
            </p>
            <p>
                <a class="btn btn-default" href="../Books/UserViewAllBooks.aspx">Learn more &raquo;</a>
            </p>
        </div>
    </div>

    <div class="row"> 
        <div class="col-md-6">
            <h2>Extend Borrow Period</h2>
            <p>
                You can Extend Borrow Period for a specific borrowed Book
            </p>
            <p>
                <a class="btn btn-default" href="../Extend/UserExtendBorrowPeriod.aspx">Learn more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
