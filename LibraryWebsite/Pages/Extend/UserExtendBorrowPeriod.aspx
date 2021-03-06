﻿<%@ Page Title="Extend Borrow Period" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserExtendBorrowPeriod.aspx.cs" Inherits="LibraryWebsite.Pages.Extend.UserExtendBorrowPeriod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Extend the Borrow Period for a period in range of 1:3 days</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="dropDownBoxBookTitle" CssClass="col-md-2 control-label">Book Title</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="dropDownBoxBookTitle" Width="80%" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropDownBoxBookTitle_SelectedIndexChanged" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="dropDownBoxBookTitle" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The Book Title field is required." />
            </div>
        </div>

         <div class="form-group">
             <asp:Label runat="server" AssociatedControlID="txtBoxExtendPeriod" CssClass="col-md-2 control-label">Extend Period</asp:Label>
            <div class="col-md-10">
               <asp:TextBox runat="server" ID="txtBoxExtendPeriod" Width="80%" CssClass="form-control" placeholder="Extend Period must be in range 1:3 days" />
                 <asp:RequiredFieldValidator runat="server"  ControlToValidate="txtBoxExtendPeriod" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The Borrow Extend field is required." />
                <asp:RangeValidator runat="server" ControlToValidate="txtBoxExtendPeriod" Display="Dynamic"
                    CssClass="text-danger" Type="Integer" MinimumValue="1" MaximumValue="3"  Width="80%" ErrorMessage="Extend Period must be in range of 1:3 day." />
            </div>
        </div>

        <div class="form-group" >
            <asp:Label runat="server"  AssociatedControlID="gridview" CssClass="col-md-2 control-label">Borrowed Books</asp:Label>
            <div class="col-md-10">
                <asp:GridView  runat="server"  ID="gridview" CellPadding="4" ForeColor="#333333" GridLines="None" Width="80%"  ShowHeaderWhenEmpty="true">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#696969" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
        </div>

         <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID ="extendPeriod"  Text="Extend" CssClass="btn btn-default" OnClick="extendPeriod_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
