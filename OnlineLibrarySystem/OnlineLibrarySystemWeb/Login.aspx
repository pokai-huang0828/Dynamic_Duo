<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineLibrarySystemWeb.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron my-4">

        <h1>Login</h1>

        <div class="message" style="color:red;">
        <asp:Literal Id="ErrorMessage" runat="server" />
        </div>

        <div class="mb-3">
        <label for="email" class="form-label">Email address</label>
        <asp:TextBox runat=server type="email" CssClass="form-control" name="email" id="email" placeholder="name@example.com"/>
        <asp:RequiredFieldValidator 
        ControlToValidate="email"
        Display="Dynamic"
        ForeColor="red" 
        ErrorMessage="Email is required."
        runat="server" />
        </div>
        <div class="mb-3">
        <label for="password" class="form-label">Password</label>
        <asp:TextBox runat=server type="password" CssClass="form-control" name="password" id="password" placeholder="******"/>
        <asp:RequiredFieldValidator 
        ControlToValidate="password"
        Display="Dynamic"
        ForeColor="red" 
        ErrorMessage="Password is required."
        runat="server" />
        </div>
        <div class="mb-3">
        <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server"  OnClick="btnSubmit_Click" Text="Login" />
        </div>
        <asp:HyperLink CssClass=""
        NavigateUrl="~/register"
        runat="server" Font-Underline="True">Sign me up!</asp:HyperLink>

        </div>

</asp:Content>
