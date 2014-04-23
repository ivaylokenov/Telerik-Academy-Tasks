<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsTemplate._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="span6 pull-left">
            <h1>Books</h1>
        </div>
        <div class="span6 form-search">
            <div class="input-append pull-right">
                <asp:TextBox ID="SearchText" runat="server" CssClass="span2 search-query"></asp:TextBox>
                <asp:Button ID="Search_Button" Text="Search" OnClick="Search_Button_Click" runat="server" CssClass="btn" />
            </div>
        </div>
    </div>

    <asp:ListView runat="server"
        ID="AllCategoriesList"
        ItemType="WebFormsTemplate.Models.Category" 
        SelectMethod="AllCategoriesList_GetData"
        GroupItemCount="3"
        GroupPlaceholderID="ContactRowContainer"
        ItemPlaceholderID="ContactItemContainer"
        >
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="ContactRowContainer" />
        </LayoutTemplate>
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="ContactItemContainer" />
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="span4">
                <h2>
                    <%#Server.HtmlEncode(Item.Name) %>
                </h2>
                <ul>
                    <asp:Repeater runat="server" ID="BookRepeater" DataSource="<%#Item.Books %>" ItemType="WebFormsTemplate.Models.Book">
                        <ItemTemplate>
                            <li>
                                <a href="BookDetails/<%#Item.Id %>"><%#Server.HtmlEncode(Item.Title) %> by <%#Server.HtmlEncode(Item.Authors) %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
