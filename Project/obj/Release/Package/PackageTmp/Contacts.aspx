﻿<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="Project.Contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Add contacts to your group.</h3>
    <br />
    <div id="contactdiv" runat="server">
        <h5>Select one or more contacts you wish to add to your group.</h5>
        <asp:CheckBoxList ID="ContaxtCheckBoxList" runat="server">
        </asp:CheckBoxList>
        <br />
    </div>
    <div>
        <h5>Select a group you want to add the selected contact(s) to.</h5>
        <asp:DropDownList ID="GroupDropDownList" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="AddContactButton" runat="server" Text="Add Contact(s) to Group" />
    </div>
</asp:Content>
