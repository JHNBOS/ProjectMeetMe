<%@ Page Title="Create Group" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateGroup.aspx.cs" Inherits="Project.CreateGroup" %>
<asp:Content ID="CreateGroupContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Create a new group to share a calendar with.</h3>
    <br />
    <asp:Label ID="ExplainLabel" runat="server" Text="Enter a name for your group"></asp:Label>
    <br />
    <asp:TextBox ID="GroupNameBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="CreateGroupButton" runat="server" Text="Create" />

</asp:Content>
