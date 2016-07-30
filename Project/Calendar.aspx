<%@ Page Title="Calendar" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Calendar.aspx.cs" Inherits="Project.Calendar" %>
<asp:Content ID="CalendarContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
    <br />

    <div id="scheduler_here" style="height:509px; width: 100%;">
        <%= this.Scheduler.Render()%>
    </div>	
</asp:Content>
