<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineLibrarySystemWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<h1>Welcome to Online Library System</h1>

<div class="row d-flex">
<asp:TextBox runat="server" placeholder="search"/>
<asp:DropDownList ID="ddlSearchType" runat="server">
    <asp:ListItem Text="by name" Value="name" />
    <asp:ListItem Text="by resource ID" Value="resourceId" />
</asp:DropDownList>
<asp:DropDownList ID="ddlCategory" runat="server">
    <asp:ListItem Text="Reading" Value="reading" />
    <asp:ListItem Text="Audio" Value="audio" />
    <asp:ListItem Text="Video" Value="video" />
</asp:DropDownList>
    <asp:Button id="searchButton" Text="Go" runat="server" />
</div>



</asp:Content>
