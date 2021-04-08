<%@ Page Title="Resource Details" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Details.aspx.cs" CodeFile="Details.aspx.cs"
    Inherits="OnlineLibrarySystemWeb.Details" EnableEventValidation="False" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron my-2 py-3 px-3">

        <h2><%: Title %></h2>

        <div class="row d-flex text-center" style="color: red; font-weight: bold;"><%= ErrorText %></div>

        <asp:Repeater ID="DetailPropertyRepeater" runat="server">
            <HeaderTemplate>
                <table class="table table-info table-striped table-hover" border="0" style="overflow: auto;">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "key") %> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "value")??"N/A" %> </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <% if (Session["Role"] == "Manager")
            { %>
        <h2>Borrowed By Users</h2>
        <asp:Repeater ID="BorrowedUsersRepeater" runat="server">
            <HeaderTemplate>
                <table class="table table-info table-striped table-hover" border="0" style="overflow: auto;">
                    <tr>
                        <td>User ID</td>
                        <td></td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Container.DataItem %> 
                    </td>
                    <td>
                        <a class="btn btn-primary" href="userdetails?userId=<%# Container.DataItem %> ">Details
                        </a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <%} %>
    </div>

</asp:Content>

