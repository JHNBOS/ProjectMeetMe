<%@ Page Title="Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="Project.Group1" %>
<asp:Content ID="GroupContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>List of groups you joined</h3>
    <div id="groupdiv" runat="server">
    </div>
    <br />
    <a href="CreateGroup.aspx"><b>Create new group</b></a>
    <br />
    <a href="Contacts.aspx"><b>Add members to group</b></a>
</asp:Content>
