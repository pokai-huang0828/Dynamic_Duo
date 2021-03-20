<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OnlineLibrarySystemWeb.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <div class="jumbotron my-4">

        <h1>Register</h1>

        <div class="message mb-3" style="color:red;">
        <asp:Literal Id="ErrorMessage" runat="server" />
        </div>
        <div class="mb-3">
        <label for="role" class="form-label">Role:</label>
        <asp:RadioButton CssClass="mr-2" id="customer" Text="Customer" Checked="True" GroupName="role" runat="server" />
        <asp:RadioButton id="manager" Text="Manager" GroupName="role" runat="server" />
        </div>
        <div class="mb-3">
        <label for="firstName" class="form-label">First Name</label>
        <asp:TextBox runat=server type="text" CssClass="form-control" name="firstName" id="firstName" placeholder="First Name"/>
        <asp:RequiredFieldValidator 
        ControlToValidate="firstName"
        Display="Dynamic"
        ForeColor="red" 
        ErrorMessage="First name is required."
        runat="server" />
        </div>
        <div class="mb-3">
        <label for="lastName" class="form-label">Last Name</label>
        <asp:TextBox runat=server type="text" CssClass="form-control" name="lastName" id="lastName" placeholder="Last Name"/>
        <asp:RequiredFieldValidator 
        ControlToValidate="lastName"
        Display="Dynamic"
        ForeColor="red" 
        ErrorMessage="Last name is required."
        runat="server" />
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
        <div class="mb-0">
        <label for="password" class="form-label">Confirm Password</label>
        <asp:TextBox runat=server type="password" CssClass="form-control" name="confirmPassword" id="confirmPassword" placeholder="******"/>
        <asp:RequiredFieldValidator 
        ControlToValidate="confirmPassword"
        Display="Dynamic"
        ForeColor="red" 
        ErrorMessage="Password is required."
        runat="server" />
        <asp:CompareValidator
        ControlToValidate="confirmPassword" 
        ControlToCompare="password"
        operator="Equal"
        ForeColor="red" 
        Type="String" 
        ErrorMessage="Passwords do not match."
        runat="server"/>
        </div>

        <div class="mb-3">
        <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server"  OnClick="btnSubmit_Click" Text="Submit" />
        </div>

    </div>

</asp:Content>
