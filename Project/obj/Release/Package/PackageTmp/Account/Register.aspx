<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />

    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" TextMode="SingleLine" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>

        </div>

        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Choose Color</asp:Label>
            <div class="col-md-10">    
                <input type="color" id="colorpicker" value="#000000" list="color" CssClass="colorpicker" runat="server"/>
                <datalist id="color">
                    <option>#404040</option>
                    <option>#FF0000</option>
                    <option>#FF6A00</option>
                    <option>#FFD800</option>
                    <option>#B6FF00</option>
                    <option>#4CFF00</option>
                    <option>#00FF90</option>
                    <option>#00FFFF</option>
                    <option>#0094FF</option>
                    <option>#0026FF</option>
                    <option>#4800FF</option>
                    <option>#B200FF</option>
                    <option>#FF00DC</option>
                    <option>#FF006E</option>
                    <option>#808080</option>
                    <option>#7F0000</option>
                    <option>#7F3300</option>
                    <option>#7F6A00</option>
                    <option>#5B7F00</option>
                    <option>#267F00</option>
                    <option>#007F0E</option>
                    <option>#007F46</option>
                    <option>#007F7F</option>
                    <option>#004A7F</option>
                    <option>#00137F</option>
                    <option>#21007F</option>
                    <option>#57007F</option>
                    <option>#7F006E</option>
                    <option>#7F0037</option>
                </datalist>
            </div>
        </div>

        <br />

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-info" Width="120" />
            </div>
        </div>
    </div>
</asp:Content>
