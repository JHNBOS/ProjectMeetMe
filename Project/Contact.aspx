<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Project.Contacts1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%=Request.ApplicationPath%>Content/Site.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>View all your contacts or add new ones.</h3>

    <br />

    <div class="container-fluid">

        <!-- 1st Row  -->
        <div class="row">
            <div class="col-md-4" id="searchdiv" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Fill in a (partial) email address."></asp:Label>
                <br />
                <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox><asp:Button ID="SearchButton" BorderColor="#e5e5e5" BackColor="#539AF2" ForeColor="White" Height="27" BorderWidth="1" BorderStyle="Solid" Font-Bold="true" runat="server" Text="Search" />

                <br />

                <hr id="line" runat="server" style="background:#8c8686;height: 1px;" />

                <asp:Label ID="SearchTitle" runat="server" Font-Size="Large" Text="Label"></asp:Label>
                <br />
                <asp:GridView ID="ContactGridView" runat="server" CellPadding="5" CellSpacing="5" Width="100%" BorderColor="#c5c5c5" BorderWidth="1" HeaderStyle-BackColor="#539AF2" HeaderStyle-ForeColor="White" AllowSorting="True" AutoGenerateColumns="False">
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
                <br />
                <br />

                <asp:Button ID="AddContactsButton" runat="server" Text="Add Contacts" BorderColor="#e5e5e5" BackColor="#539AF2" ForeColor="White" Height="27" BorderWidth="1" BorderStyle="Solid" Font-Bold="true" />




            </div>
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <h4>List of contacts.</h4>
                <asp:GridView ID="ListedContactsGridView" runat="server" EnableTheming="true" HeaderStyle-Height="35" RowStyle-Height="30"
                    CellPadding="5" CellSpacing="5" Width="100%" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="true" BorderColor="#c5c5c5" BorderWidth="1" HeaderStyle-BackColor="#539AF2" HeaderStyle-ForeColor="White"
                    HeaderStyle-VerticalAlign="Middle">
                    <Columns>
                        <asp:BoundField HeaderText="First Name" DataField="First Name" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderText="Last Name" DataField="Last Name" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderText="Email" DataField="Email" ItemStyle-HorizontalAlign="Left" />
                    </Columns>
                </asp:GridView>

                <br />
                <br />

            </div>
        </div>

        <br />

        <!-- 2nd Row  -->
        <div class="row">
            <div class="col-md-4" id="gridviewdiv" runat="server">
                
            </div>
            <div class="col-md-4"></div>
            <div class="col-md-4"></div>
        </div>

        <br />

        <!-- 3rd and Last Row  -->
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-4"></div>
            <div class="col-md-3"></div>
            <div class="col-md-2"></div>
        </div>



    </div>

</asp:Content>
