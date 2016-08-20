<%@ Page Title="Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupCalendars.aspx.cs" Inherits="Project.GroupCalendars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
    <link rel="stylesheet" type="text/css" href="Content/dhtmlxScheduler/dhtmlxscheduler-responsive.css" />
    <script type="text/javascript" src="Scripts/dhtmlxScheduler/dhtmlxscheduler-responsive.js"></script>
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to delete this group?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <div class="container" id="maindiv">
        <!-- BEGIN OF ROW ONE -->
        <div class="row">
           
            <div class="col-sm-2" id="GroupList" runat="server">
                <asp:Table ID="GroupListTable" runat="server" BackColor="White" CellPadding="2" CellSpacing="2"
                     HorizontalAlign="Center" Width="100%">
                </asp:Table>
            </div>

             <div class="col-sm-8 collapse" id="showmembers">
                <asp:Table ID="MemberTable" runat="server" CellPadding="2" CellSpacing="2"></asp:Table>
                 <br />
                 <asp:Button ID="DeleteMemberButton" runat="server" Text="Remove Members" BackColor="#18BC9C" ForeColor="White" BorderColor="#e5e5e5" BorderStyle="Solid" BorderWidth="1" OnClick="DeleteMemberButton_Click" />
            </div>

            <div class="col-sm-10" id="schedulerdiv">
                <span style="text-align:center;display:block;">
                    <asp:Label ID="GroupTitle" Font-Bold="true" Font-Size="X-Large" runat="server" Text=""></asp:Label>
                </span>
                
                <span runat="server" id="menulinks" visible="false" style="text-align:center;display:block;font-size: 13px;">

                <asp:LinkButton ID="AddMemberLink" class="btn btn-default btn-sm"  runat="server" OnClick="Link_Click" Font-Size="13px" ForeColor="White">Add Member</asp:LinkButton>
                  
                <asp:LinkButton ID="DeleteLink" runat="server" class="btn btn-default btn-sm" Font-Size="13px" ForeColor="White" OnClick="DeleteLink_Click" OnClientClick="Confirm()">Delete Group</asp:LinkButton>
                  
                <a id="showbutton" class="btn btn-default btn-sm" data-toggle="collapse" data-target="#showmembers" style="display:inline-block;">
                    Members &#x21C5;
                </a>
                </span>
                        
                <hr id="divider" runat="server" visible="false" />

                <div id="scheduler_here" runat="server" style="height:480px;width:100%;"></div>

            </div>
        </div>
        <!-- END OF ROW ONE -->


    </div>
</asp:Content>

