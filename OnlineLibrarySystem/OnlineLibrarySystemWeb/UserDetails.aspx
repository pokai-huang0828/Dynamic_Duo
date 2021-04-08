<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" CodeFile="UserDetails.aspx.cs"
    Inherits="OnlineLibrarySystemWeb.UserDetails" EnableEventValidation="False" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron my-2 py-3 px-3">

        <h2><%: Title %></h2>

        <div class="row d-flex text-center" style="color: red; font-weight: bold;"><%= ErrorText %></div>

        <asp:Repeater ID="UserDetailPropertyRepeater" runat="server">
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

        <h2>User Checkout History</h2>

        <div style="overflow-y: hidden;">
            <asp:Repeater ID="historyRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table table-info table-striped table-hover" border="0">
                        <tr>
                            <td><b>Checkout ID</b></td>
                            <td><b>Resource ID</b></td>
                            <td><b>Title</b></td>
                            <td><b>Check Out Date</b></td>
                            <td><b>Due Date</b></td>
                            <td><b>Resource Status</b></td>
                            <td><b></b></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="checkoutstatus?checkOutId=<%# DataBinder.Eval(Container.DataItem, "checkOutID") %>">
                            <%# DataBinder.Eval(Container.DataItem, "checkOutID") %> 
                            </a>
                        </td>
                        <td>
                            <a href="details?resourceId=<%# DataBinder.Eval(Container.DataItem, "resourceID") %>">
                                <%# DataBinder.Eval(Container.DataItem, "resourceID") %> 
                            </a>
                        </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "title") %> </td>
                        <td><%# ((DateTime)DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToShortDateString() %> </td>
                        <td><%# ((DateTime)DataBinder.Eval(Container.DataItem, "dueDate")).ToShortDateString() %> </td>
                        <td>
                            <%#((Boolean)DataBinder.Eval(Container.DataItem, "isReturn"))? "Returned":  "<b>Borrowing</b>" %> 
                        </td> 
                        <td>
                            <asp:Button
                            runat="server"
                            CssClass="btn btn-primary"
                            CommandName='<%# DataBinder.Eval(Container.DataItem, "checkOutID")+" "+DataBinder.Eval(Container.DataItem, "resourceID") %>'
                            CausesValidation="False"
                            OnClick="ReturnBtn_Click"
                            Visible=<%# !Convert.ToBoolean(Eval("isReturn"))  %>
                            Text="Return Now" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

    </div>

</asp:Content>


