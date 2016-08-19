<%@ Page Title="Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupCalendars.aspx.cs" Inherits="Project.GroupCalendars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
    <link rel="stylesheet" type="text/css" href="Content/dhtmlxScheduler/dhtmlxscheduler-responsive.css" />
    <script type="text/javascript" src="Scripts/dhtmlxScheduler/dhtmlxscheduler-responsive.js"></script>
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
            </div>

            <div class="col-sm-10" id="schedulerdiv">
                <span style="text-align:center;display:block;">
                    <asp:Label ID="GroupTitle" Font-Bold="true" Font-Size="X-Large" runat="server" Text=""></asp:Label>
                </span>
                
                <span runat="server" id="menulinks" visible="false" style="text-align:center;display:block;font-size: 13px;">

                <asp:LinkButton ID="AddMemberLink" class="btn btn-default btn-sm"  runat="server" OnClick="Link_Click" Font-Size="13px" ForeColor="White">Add Member</asp:LinkButton>
                  
                <asp:LinkButton ID="DeleteLink" runat="server" class="btn btn-default btn-sm" Font-Size="13px" ForeColor="White" OnClick="DeleteLink_Click" >Delete Group</asp:LinkButton>
                  
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

