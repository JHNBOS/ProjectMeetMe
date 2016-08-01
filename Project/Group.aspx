<%@ Page Title="Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="Project.Group1" %>
<asp:Content ID="GroupContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />

    <h2><%: Title %>.</h2>
    <h3>List of groups you joined</h3>
    <div id="groupdiv" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-3" id="groupbuttondiv" runat="server">

                </div>
                <div class="col-sm-3" id="deletebuttondiv" runat="server">

                </div>
            </div>
        </div>
        
    </div>
    <br />
    <a href="CreateGroup.aspx"><b>Create new group</b></a>
    <br />
    <a href="Contacts.aspx"><b>Add members to group</b></a>
</asp:Content>
