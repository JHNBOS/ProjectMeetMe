<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="Project.Contacts1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
        <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>View all your contacts or add new ones.</h3>

    <br />

    <div id="contactform" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Enter the name of the contact you want to add."></asp:Label>
        
        <br />

        <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox>

        <br />
        <br />

        <asp:Button ID="SearchButton" runat="server" Text="Search" />

        <br />
        <hr />

    </div>

    <div id="contactlist" runat="server">
        <asp:Table ID="ContactTable" runat="server" Width="400" CellPadding="5"
            CellSpacing="5">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>First Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Last Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Email</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
</asp:Content>
