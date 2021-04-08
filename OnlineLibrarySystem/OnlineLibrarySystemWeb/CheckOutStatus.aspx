<%@ Page Title="Checkout ID:" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="CheckOutStatus.aspx.cs" CodeFile="CheckOutStatus.aspx.cs"
    Inherits="OnlineLibrarySystemWeb.CheckOutStatus" EnableEventValidation="False" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron my-2 py-3 px-3">

        <h2><%: Title + " " + Request.QueryString["checkOutId"] %></h2>
        <hr />
        <p><b>Delivery Status:</b> <span id="deliveryStatusText"><%= deliveryStatus %></span></p>
        <button class="btn btn-primary" id="UpdateBtn" data-checkoutid="<%:Request.QueryString["checkOutId"] %>">Refresh Status</button>

    </div>

    <script src="Scripts/CheckOutStatus.js" type="text/javascript"></script>

</asp:Content>

   

