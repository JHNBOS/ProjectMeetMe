<%@ Page Title="Calendar" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Calendar.aspx.cs" Inherits="Project.Calendar" %>
<asp:Content ID="CalendarContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
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
    	
    <br />

    <!-- Row with buttons -->
    <div class="container">
    <div class="row" id="settings">
        <h4>Members of this group.</h4>
        <div class="col-md-3" id="groupmembers" runat="server"></div>
        <div class="col-md-2" id="deletebuttondiv" runat="server"></div>
        <div class="col-md-2"></div>
        <div class="col-md-2"></div>
        <div class="col-md-3" id="addmembersdiv" runat="server">
        </div>
    </div>



     <!-- Row with collapsebutton -->
    <div class="row">
        <div class="col-md-5"></div>
        <div class="col-md-2">
            <a id="collapsebutton" class="btn btn-default btn-sm" data-toggle="collapse" data-target="#settings" onclick="ChangeIcon()">
                <span id="buttonspan" class="glyphicon glyphicon-chevron-up button"></span>
            </a>
        </div>
        <div class="col-md-5"></div>
    </div>

    <hr />

    <!-- Row with calendar -->
    <div class="row">
        <div class="col-xs-12" id="scheduler_here" runat="server" style="height:700px;width:100%;">
            <h2 id="GroupTitle" runat="server"></h2>
            <%= this.Scheduler.Render()%>
        </div>
    </div>

</div>
</asp:Content>
