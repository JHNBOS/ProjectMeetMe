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
    <asp:Button ID="CreateGroupButton" runat="server" Text="Create"  Width="100" Height="35" Font-Bold="true"
        BackColor="#539AF2" ForeColor="White" BorderWidth="1" BorderStyle="Solid" BorderColor="#e5e5e5"  />

</asp:Content>
