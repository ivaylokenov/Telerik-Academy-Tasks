<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Search.aspx.cs" Inherits="WebFormsTemplate.Search" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h1>Search Results</h1>
    <ul>
    <asp:Repeater runat="server" ID="ResultsRepeater" ItemType="WebFormsTemplate.Models.Book">
        <ItemTemplate>
            <li>
                <a href="/BookDetails/<%#Item.Id %>">"<%#Server.HtmlEncode(Item.Title) %>" by <%#Server.HtmlEncode(Item.Authors) %></a>
                <span>(Category: <%#Server.HtmlEncode(Item.Category.Name) %>)</span>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    </ul>
    <br />
    <a href="/">Back to books</a>
</asp:Content>