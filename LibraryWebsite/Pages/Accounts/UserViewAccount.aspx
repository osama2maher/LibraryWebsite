<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserViewAccount.aspx.cs" Inherits="LibraryWebsite.Pages.Accounts.UserViewAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>View Your Profile Details</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger"  ID="validationSummary"/>

        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="lblEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:Label runat="server" ID="lblEmail" Width="80%" CssClass="form-control" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="lblFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:Label runat="server" ID="lblFirstName" Width="80%" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="lblLastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:Label runat="server" ID="lblLastName" Width="80%" CssClass="form-control" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="txtBoxPhone" CssClass="col-md-2 control-label">Phone</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBoxPhone" Width="80%" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtBoxPassword" CssClass="col-md-2 control-label" >Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBoxPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBoxPassword"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtBoxConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBoxConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBoxConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="txtBoxPassword" ControlToValidate="txtBoxConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        

       <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" Text="Update" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
