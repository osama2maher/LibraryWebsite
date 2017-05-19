<%@ Page Title="Books Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminViewAllBooks.aspx.cs" Inherits="LibraryWebsite.Pages.Books.ViewAllBooksAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>View all Books in the Library</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger"  ID="validationSummary"/>

        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="dropDownBoxCategory" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="dropDownBoxCategory" Width="80%" CssClass="form-control" OnSelectedIndexChanged="dropDownBoxCategorySelectionChanged" AutoPostBack="true"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="dropDownBoxCategory" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The Category field is required." />
            </div>
        </div>

        <div class="form-group">
           <asp:Label runat="server" AssociatedControlID="dropDownBoxBookTitle" CssClass="col-md-2 control-label">Book Title</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="dropDownBoxBookTitle" Width="80%" CssClass="form-control"  OnSelectedIndexChanged="dropDownBoxBookTitle_SelectedIndexChanged" AutoPostBack="true"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="dropDownBoxBookTitle" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The Book Title field is required." />
            </div>
        </div>

         <div class="form-group" >
            <asp:Label runat="server"  AssociatedControlID="gridview" CssClass="col-md-2 control-label">All Books</asp:Label>
            <div class="col-md-10">
                <asp:GridView  runat="server"  ID="gridview" CellPadding="4" ForeColor="#333333" GridLines="None" Width="80%" ShowHeaderWhenEmpty="true">
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

        

       

        <div class="row">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID ="btnDelete"  Text="Delete" CssClass="btn btn-default"  OnClick="btnDelete_Click"/>
            </div>
            <br />
            <div class="col-md-offset-2 col-md-10" style="margin-top:10px">
                <a runat="server" class="btn btn-default"  href="~/Pages/Books/AdminAddBook.aspx"> Add Book </a>
            </div>
        </div>
    </div>
</asp:Content>
