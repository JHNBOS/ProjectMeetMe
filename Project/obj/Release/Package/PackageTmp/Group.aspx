﻿<%@ Page Title="Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="Project.Group1" %>
<asp:Content ID="GroupContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />

    <h2><%: Title %>.</h2>

    <br />

    <div class="container-fluid">
    <div class="row groupheader">
        <div class="col-md-3"></div>
        <div class="col-md-6" id="grouptitle">
            <h3>List of groups you joined</h3>
        </div>
        <div class="col-md-3"></div>
    </div>
        <br />
    <div class="row groupcontent">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <asp:Table ID="ButtonTable" runat="server" CellSpacing="5" CellPadding="5">
                
            </asp:Table>
            <div class="col-md-4 btn-group" id="groupbuttondiv" runat="server"></div>
            <div class="col-md-2" id="deletebuttondiv" runat="server"></div>
        </div>
        <div class="col-md-3"></div>
    </div>
        <br />
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <asp:LinkButton ID="CreateGroupLink" runat="server" ForeColor="#18bc9c" Font-Size="18px" Font-Bold="true">Create a group</asp:LinkButton>

        </div>
        <div class="col-md-3"></div>
    </div>
</div>

</asp:Content>