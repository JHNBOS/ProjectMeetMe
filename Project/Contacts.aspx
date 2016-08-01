<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="Project.Contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Add contacts to your group.</h3>
    <br />
    <div id="contactdiv" runat="server">
        <h4>Contacts</h4>
        <asp:CheckBoxList ID="ContaxtCheckBoxList" runat="server">
        </asp:CheckBoxList>
        <br />
    </div>
    <div>
        <br />
        <asp:DropDownList ID="GroupDropDownList" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="AddContactButton" runat="server" Text="Add To Group" />
    </div>
</asp:Content>
