<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupCalendars.aspx.cs" Inherits="Project.GroupCalendars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
    <link rel="stylesheet" type="text/css" href="Content/dhtmlxScheduler/dhtmlxscheduler-responsive.css" />
    <script type="text/javascript" src="Scripts/dhtmlxScheduler/dhtmlxscheduler-responsive.js"></script>
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
            <div class="col-md-10" style="border-left: 4px solid #f2f2f2;">
                <h2 id="GroupTitle" runat="server"></h2>
                <div id="scheduler_here" runat="server" style="height:480px;width:100%;">

                </div>
            </div>
        </div>
    </div>
</asp:Content>

