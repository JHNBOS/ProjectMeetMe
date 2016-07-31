<%@ Page Title="Calendar" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Calendar.aspx.cs" Inherits="Project.Calendar" %>
<asp:Content ID="CalendarContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
    <script>
        function showhide() {
            var div = document.getElementById("scheduler_here");
            var button = document.getElementById("collapsebutton");
            if (div.style.display !== "none") {
                div.style.display = "none";
                button.innerText = "+";

            }
            else {
                div.style.display = "block";
                button.innerText = "-";
            }
        }
    </script>
    <br />
    <div id="membersdiv" runat="server">
        <h4>Members of this group.</h4>
    </div>

    <a href="#" id="collapsebutton" onclick="showhide()">-</a>
   
    <div style="clear:both;margin-top: 50px;"><hr /></div>

    <h2 id="GroupTitle" runat="server"></h2>

    <div id="contentDiv">
        <div id="scheduler_here" style="height:509px; width: 100%;">
        <%= this.Scheduler.Render()%>
        </div>
    </div>
    	
</asp:Content>
