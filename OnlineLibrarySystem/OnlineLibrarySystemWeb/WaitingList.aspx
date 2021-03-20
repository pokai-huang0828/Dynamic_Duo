<%@ Page Title="Waiting List" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="WaitingList.aspx.cs" 
    Inherits="OnlineLibrarySystemWeb.WaitingList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron my-2 py-3 px-3">

        <h2><%: Title %></h2>

        <table class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">1</th>
                    <td>Mark</td>
                    <td>Otto</td>
                </tr>
                <tr>
                    <th scope="row">2</th>
                    <td>Jacob</td>
                    <td>Thornton</td>
                </tr>
            </tbody>
        </table>

    </div>

</asp:Content>