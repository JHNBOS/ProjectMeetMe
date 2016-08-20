<%@ Page Title="Contacts" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Project.Contacts1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to delete this contact?")) {
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
        <!-- BEGIN OF ROW ONE -->
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-6" id="searchdiv" runat="server">
                <h2><%: Title %>.</h2>
                <h3>View all your contacts or add new ones.</h3>

                <br />
                <br />

                <asp:Label ID="Label2" runat="server" Text="Fill in a (partial) email address."></asp:Label>

                <br />

                <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox><asp:Button ID="SearchButton" BorderColor="#e5e5e5" BackColor="#18BC9C" ForeColor="White" Height="27" BorderWidth="1" BorderStyle="Solid" Font-Bold="true" runat="server" Text="Search" />

                <br />
                <br />
                <br />

                <asp:Label ID="SearchTitle" runat="server" Font-Size="Large" Text="Label"></asp:Label>

                <br />

                <asp:GridView ID="ContactGridView" runat="server" CellPadding="5" CellSpacing="5" Width="100%" BorderColor="#c5c5c5" BorderWidth="1" HeaderStyle-BackColor="#18BC9C" HeaderStyle-ForeColor="White" AllowSorting="True" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="First Name" DataField="First Name" />
                        <asp:BoundField HeaderText="Last Name" DataField="Last Name" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                    </Columns>
                </asp:GridView>

                <br />

                <asp:Button ID="AddContactsButton" runat="server" Text="Add Contacts" BorderColor="#e5e5e5" BackColor="#18BC9C" ForeColor="White" Height="27" BorderWidth="1" BorderStyle="Solid" Font-Bold="true" />

                <br />
                <br />

            </div>
            <div class="col-sm-3"></div>
            </div>
            <!-- END OF ROW ONE -->
            

            <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-6">
                    <hr id="line" style="background: #c5c4c4; height: 2px;" />
                </div>
                <div class="col-sm-3"></div>
            </div>


            <!-- BEGIN OF ROW THREE -->
            <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-6">
                    <h4>List of contacts.</h4>

                    <asp:Table ID="ListedContactsTable" runat="server" CellPadding="5" CellSpacing="5" Width="100%">
                        <asp:TableHeaderRow BackColor="#18BC9C" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle">
                            <asp:TableHeaderCell>First Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Last Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Delete</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
                <div class="col-sm-3"></div>
            </div>
            <!-- END OF ROW THREE -->

        </div>

    <br />
    <br />

</asp:Content>
