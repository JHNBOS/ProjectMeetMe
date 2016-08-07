<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Project.Contacts1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
        <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>View all your contacts or add new ones.</h3>

    <br />

    <div id="contactform" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Fill an email address in to add a contact"></asp:Label>
        
        <br />

        <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox>

        <asp:Button ID="SearchButton" runat="server" Text="Add" />

        <br />
        <hr />

    </div>

    <div id="contactlist" runat="server">
        <asp:Table ID="ContactTable" runat="server" Width="400" CellPadding="5"
            CellSpacing="5">
            <asp:TableHeaderRow BackColor="DodgerBlue" ForeColor="White">
                <asp:TableHeaderCell>First Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Last Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Email</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        <br />
    </div>
</asp:Content>
