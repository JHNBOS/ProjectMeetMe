﻿<%@ Page Title="Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupCalendars.aspx.cs" Inherits="Project.GroupCalendars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
    <link rel="stylesheet" type="text/css" href="Content/dhtmlxScheduler/dhtmlxscheduler-responsive.css" />
    <script type="text/javascript" src="Scripts/dhtmlxScheduler/dhtmlxscheduler-responsive.js"></script>
    <script>
        function ChangeIcon() {
            var button = document.getElementById("buttonspan");
            if (button.className == "glyphicon glyphicon-chevron-up") {
                button.className = "glyphicon glyphicon-chevron-down";

            }
            else {
                button.className = "glyphicon glyphicon-chevron-up";
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <div class="container-fluid" id="maindiv">
        <div class="row">
            <div class="col-md-2" id="GroupList" runat="server">
                <asp:Table ID="GroupListTable" runat="server" BackColor="White" CellPadding="3" CellSpacing="3"
                     HorizontalAlign="Center" Width="100%">
                </asp:Table>
            </div>
            <div class="col-md-10" style="border-left: 5px solid #cccbcb;">

                <h2 id="GroupTitle" runat="server"></h2>
                <asp:LinkButton ID="AddMemberLink" runat="server" OnClick="Link_Click" Visible="false" Font-Size="Medium" Font-Bold="true" ForeColor="#0066ff">Add Member</asp:LinkButton>
                                
                <hr id="divider" runat="server" visible="false" />

                <div id="scheduler_here" runat="server" style="height:480px;width:100%;"></div>

            </div>
        </div>
    </div>
</asp:Content>

