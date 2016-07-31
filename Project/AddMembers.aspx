<%@ Page Title="Add Members" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMembers.aspx.cs" Inherits="Project.AddMembers" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <h3>Add a member to your group.</h3>
    <br />
    <asp:Label ID="groupLabel" runat="server" Text="Select a group to add a new member to."></asp:Label>
    <br />
    <asp:DropDownList ID="GroupsDropDown" runat="server"></asp:DropDownList>

    <br />
    <br />

    <asp:Label ID="userLabel" runat="server" Text="Select a user to add to the group."></asp:Label>
    <br />
    <asp:DropDownList ID="UsersDropDown" runat="server"></asp:DropDownList>

    <br />
    <br />

    <asp:Button ID="memberButton" runat="server" Text="Add Member to Group" />

</asp:Content>