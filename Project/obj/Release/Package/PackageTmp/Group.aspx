<%@ Page Title="Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="Project.Group1" %>
<asp:Content ID="GroupContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />

    <h2><%: Title %>.</h2>
    <h3>List of groups you joined</h3>

    <br />

    <div class="container">
    <div class="row groupheader">
        <div class="col-md-3" id="grouptitle"></div>
        <div class="col-md-6"></div>
        <div class="col-md-3"></div>
    </div>
    <div class="row groupcontent">
        <div class="col-md-1"></div>
        <div class="col-md-6" id="groupbuttondiv" runat="server"></div>
        <div class="col-md-2" id="deletebuttondiv" runat="server"></div>
        <div class="col-md-3"></div>
    </div>
</div>

</asp:Content>