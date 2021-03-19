<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineLibrarySystemWeb.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">

        <h1>Login</h1>

        <div class="message">
        <asp:Literal Id="ItMessage" runat="server" />
        </div>

        <div class="mb-3">
        <label for="email" class="form-label">Email address</label>
        <asp:TextBox runat=server type="email" CssClass="form-control" name="email" id="email" placeholder="name@example.com"/>
        </div>
        <div class="mb-3">
        <label for="password" class="form-label">Password</label>
        <asp:TextBox runat=server type="password" CssClass="form-control" name="password" id="password" placeholder="******"/>
        </div>
        <div class="mb-3">
        <asp:Button ID="btnSubmit" runat="server"  OnClick="btnSubmit_Click" Text="Submit" />
        </div>

    </div>

</asp:Content>
