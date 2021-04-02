<%@ Page Title="History" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="History.aspx.cs" CodeFile="History.aspx.cs"
    Inherits="OnlineLibrarySystemWeb.History" EnableEventValidation="False" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron my-2 py-3 px-3">

        <h2><%: Title %></h2>

        <div style="overflow-y: hidden;">
        <asp:Repeater ID="historyRepeater" runat="server">
            <HeaderTemplate>
                <table class="table table-info table-striped table-hover" border="0">
                    <tr>
                        <td><b>Resource ID</b></td>
                        <td><b>Title</b></td>
                        <td><b>Check Out Date</b></td>
                        <td><b>Due Date</b></td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "resourceID") %> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "title") %> </td>
                    <td><%# ((DateTime)DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToShortDateString() %> </td>
                    <td><%# ((DateTime)DataBinder.Eval(Container.DataItem, "dueDate")).ToShortDateString() %> </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>
    </div>

</asp:Content>
