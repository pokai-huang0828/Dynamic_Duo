<%@ Page Title="Waiting List" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="WaitingList.aspx.cs" 
    Inherits="OnlineLibrarySystemWeb.WaitingList" EnableEventValidation="False" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron my-2 py-3 px-3">

        <h2><%: Title %></h2>

            <asp:Repeater ID="wishListRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table table-info table-striped table-hover" border="0">
                        <tr>
                            <td><b>Resource ID</b></td>
                            <td><b>Title</b></td>
                            <td><b>Delete</b></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "resourceID") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "title") %> </td>
                        <td>
                            <asp:Button 
                                runat="server" 
                                CssClass="btn btn-danger" 
                                CommandName=<%# DataBinder.Eval(Container.DataItem, "resourceID") %>
                                CausesValidation="False"
                                OnClick="DeleteBtn_Click"
                                Text="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

    </div>

</asp:Content>