<%@ Page Title="Delete Members" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteMembers.aspx.cs" Inherits="Project.DeleteMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Site.css" />
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to remove this member from this group?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-6">
                <h2><%: Title %>.</h2>
                <h3>Remove members from <%= this.group %></h3>

                <br />
                <br />

                <asp:Table ID="MemberTable" runat="server" CellPadding="2" CellSpacing="2" Width="100%">
                    <asp:TableHeaderRow BackColor="#18BC9C" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle">
                        <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Remove</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>


            </div>
            <div class="col-sm-3"></div>
        </div>
    </div>
</asp:Content>

