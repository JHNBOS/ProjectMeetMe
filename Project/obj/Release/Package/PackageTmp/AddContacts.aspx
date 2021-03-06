﻿<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddContacts.aspx.cs" Inherits="Project.Contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            

            <div class="col-sm-3"></div>
            <div class="col-sm-6" id="contactdiv" runat="server">
                <h2><%: Title %>.</h2>
                <h3>Add contacts to your group.</h3>

                <br />
                <br />
                <br />


                <h5>Select one or more contacts you wish to add to your group.</h5>
                <asp:CheckBoxList ID="ContaxtCheckBoxList" runat="server">
                </asp:CheckBoxList>

                <br />
                <br />

                <asp:Button ID="AddContactButton" runat="server" Text="Add Contact(s) to Group" />
            </div>
            <div class="col-sm-3"></div>
        </div>
    </div>
</asp:Content>
