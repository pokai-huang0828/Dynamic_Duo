<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineLibrarySystemWeb._Default" EnableEventValidation="False" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron my-2 py-3 px-3">

        <h1 class="my-3">Welcome <%=Session["FirstName"]%></h1>
        <hr />

        <h6><i class="bi bi-wallet"></i> Search Library Resources</h6>
        <div class="form-inline my-4">

            <div class="form-group inline mr-2">
                <asp:TextBox ID="searchText" CssClass="form-control" runat="server" placeholder="Search Resources" />
            </div>

            <div class="form-group inline mr-2">
                <asp:DropDownList ID="ddlSearchType" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Search by" Value="" />
                    <asp:ListItem Text="Resource Name" Value="name" />
                    <asp:ListItem Text="Resource ID" Value="resourceId" /> 
                    <asp:ListItem Text="Author" Value="author" />
                </asp:DropDownList>
            </div>

            <div class="form-group inline mr-2">
                <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Choose a Category" Value="" />
                    <asp:ListItem Text="Reading" Value="reading" />
                    <asp:ListItem Text="Audio" Value="audio" />
                    <asp:ListItem Text="Video" Value="video" />
                </asp:DropDownList>
            </div>

            <div class="form-group inline">
                <asp:Button ID="searchButton" CssClass="btn btn-primary" Text="Go" runat="server" OnClick="searchButton_Click" />
            </div>
        </div>

        <% if (Session["Role"] == "Manager") { %>
        <h6><i class="bi bi-people-fill"></i> Search Library Users</h6>
        <div class="form-inline my-4">

            <div class="form-group inline mr-2">
                <asp:TextBox ID="userSearchText" CssClass="form-control" runat="server" placeholder="Search Users" />
            </div>

            <div class="form-group inline mr-2">
                <asp:DropDownList ID="DDLUserSearchBy" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Search by" Value="" />
                    <asp:ListItem Text="Name" Value="name" />
                    <asp:ListItem Text="User ID" Value="userId" />
                </asp:DropDownList>
            </div>

            <div class="form-group inline mr-2">
                <asp:DropDownList ID="DDLUserByCategory" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Choose a Category" Value="" />
                    <asp:ListItem Text="Customer" Value="customer" />
                    <asp:ListItem Text="Manager" Value="manager" />
                </asp:DropDownList>
            </div>

            <div class="form-group inline">
                <asp:Button ID="UserSearchBtn" CssClass="btn btn-primary" Text="Go" runat="server" OnClick="UserSearchBtn_Click" />
            </div>
        </div>
        <% } %>

        <hr />

        <div style="overflow-y: hidden;">
            <asp:Repeater ID="resourceRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table table-info table-striped table-hover" border="0" style="overflow: auto;">
                        <tr>
                            <td><b>Resource ID</b></td>
                            <td><b>Resource Name</b></td>
                            <td><b>Category</b></td>
                            <td><b>Copies In Stock</b></td>
                            <% if (Session["Role"] != "Manager") { %>
                            <td><b>Add to Bag</b></td>
                            <% } %>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "ResourceID") %> </td>
                        <td><a href="details?resourceId=<%# DataBinder.Eval(Container.DataItem, "ResourceID") %>"><%# DataBinder.Eval(Container.DataItem, "Title") %></a></td>
                         <td><%# Container.DataItem.GetType().GetInterfaces()[0].Name.Remove(0,1) %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "CopyInStock") %> </td>

                         <% if (Session["Role"] != "Manager") { %>
                        <td id="<%# DataBinder.Eval(Container.DataItem, "ResourceID") %>">

                            <asp:Button 
                            runat="server"
                            Text="Add to Bag"
                            CommandName=<%# DataBinder.Eval(Container.DataItem, "ResourceID") %>
                            CssClass="btn btn-success" 
                            OnClick="AddToCartBtn_Click" 
                            CausesValidation="False" 
                            Visible =<%# (int)DataBinder.Eval(Container.DataItem, "CopyInStock") != 0 %>
                            />

                            <asp:Button 
                            runat="server"
                            Text="Add to Wist List"
                            CommandName=<%# DataBinder.Eval(Container.DataItem, "ResourceID") %>
                            CssClass="btn btn-primary" 
                            OnClick="AddToWistListBtn_Click" 
                            CausesValidation="False" 
                            Visible =<%# (int)DataBinder.Eval(Container.DataItem, "CopyInStock") == 0 %>
                            />
                        
                        </td>
                        <% } %>

                    </tr>        
                        
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <asp:Repeater ID="userRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table table-info table-striped table-hover" border="0">
                        <tr>
                            <td><b>User ID</b></td>
                            <td><b>Role</b></td>
                            <td><b>First Name</b></td>
                            <td><b>Last Name</b></td>
                            <td><b>Email</b></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "UserID") %> </td>
                        <td><%# Container.DataItem.GetType().Name %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "FirstName") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "LastName") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Email") %> </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

    </div>

</asp:Content>
