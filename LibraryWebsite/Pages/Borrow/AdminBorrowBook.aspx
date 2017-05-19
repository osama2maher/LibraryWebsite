<%@ Page Title="Borrow Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminBorrowBook.aspx.cs" Inherits="LibraryWebsite.Pages.Borrow.WebForm1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    


      <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Borrow a Book From the Library </h4>
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
                <asp:DropDownList runat="server" ID="dropDownBoxBookTitle" Width="80%" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="dropDownBoxBookTitle" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The Book Title field is required." />
            </div>
        </div>

         <div class="form-group">
             <asp:Label runat="server" AssociatedControlID="lblBorrowDate" CssClass="col-md-2 control-label">Borrow Date</asp:Label>
            <div class="col-md-10">
               <asp:Label runat="server" ID="lblBorrowDate" Width="80%" CssClass="form-control">
                   <%= System.DateTime.Now.ToString("dd/MM/yyyy") %>
               </asp:Label>
            </div>
        </div>

        <div class="form-group">
             <asp:Label runat="server" AssociatedControlID="txtBoxBorrowPeriod" CssClass="col-md-2 control-label">Borrow Period</asp:Label>
            <div class="col-md-10">
               <asp:TextBox runat="server" ID="txtBoxBorrowPeriod" Width="80%" CssClass="form-control" placeholder="Period must be in range 1:15 days" />
                 <asp:RequiredFieldValidator runat="server" ID="validatorBorrowPeriod" ControlToValidate="txtBoxBorrowPeriod" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The Borrow Period field is required." />
                <asp:RangeValidator runat="server" ControlToValidate="txtBoxBorrowPeriod" Display="Dynamic"
                    CssClass="text-danger" Type="Integer" MinimumValue="1" MaximumValue="15"  Width="80%" ErrorMessage="Borrow Period must be in range of 1:15 day." />
            </div>
        </div>
            <div class="form-group">
             <asp:Label runat="server" AssociatedControlID="dropDownBoxEmails" CssClass="col-md-2 control-label">User Email</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="dropDownBoxEmails" Width="80%" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server"  ControlToValidate="dropDownBoxEmails" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The User Email field is required." />
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtBoxPassword" CssClass="col-md-2 control-label" >Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBoxPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Your Password."/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBoxPassword" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
                <asp:CustomValidator runat="server" ID="password" OnServerValidate="password_ServerValidate" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="Password is Invalid." />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID ="btnBorrow"  Text="Borrow" CssClass="btn btn-default" OnClick="btnBorrowClick"/>
            </div>
        </div>
    </div>

</asp:Content>
