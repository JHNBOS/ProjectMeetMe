<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Meet Me</h1>
        <p class="lead">Meet Me is a Web Application in which it is possible to share a calendar with a group of people, such as family, friends, colleagues and many more!</p>
        <p><a href="Account/Register.aspx" class="btn btn-primary btn-lg">Start using now &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Groups</h2>
            <p>
                You can easily create, view or delete groups you own. Add contacts to your group to share a calendar with.
            </p>
        </div>
        <div class="col-md-4">
            <h2>Contacts</h2>
            <p>
                Search, add and view all your contacts with which you can share groups with.
            </p>
        </div>
        <div class="col-md-4">
            <h2>Start Now</h2>
            <p>
                   Already have an account? Then login to start using MeetMe!
            </p>
            <p>
                <a class="btn btn-default" href="Account/Login.aspx">Login &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
