<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LibraryWebsite.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtBoxEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBoxEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBoxEmail"
                    CssClass="text-danger" ErrorMessage="The email field is required." Display="Dynamic" />
            </div>
                                          <asp:CustomValidator runat="server" ID="emailValidator" OnServerValidate="emailValidator_ServerValidate" Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="Email is already exist." />
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtBoxFirstName" CssClass="col-md-2 control-label" >First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBoxFirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBoxFirstName"
                    CssClass="text-danger" ErrorMessage="The First Name field is required." />
            </div>
        </div>
                 <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtBoxLastName" CssClass="col-md-2 control-label" >Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBoxLastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBoxLastName"
                    CssClass="text-danger" ErrorMessage="The Last Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtBoxPhone" CssClass="col-md-2 control-label" >Phone</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBoxPhone" CssClass="form-control" TextMode="Phone"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBoxPhone"
                    CssClass="text-danger" ErrorMessage="The Phone field is required." />
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
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
