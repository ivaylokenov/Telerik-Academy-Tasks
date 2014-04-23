<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BookDetails.aspx.cs" Inherits="WebFormsTemplate.BookDetails" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h1>Book Details</h1>
    <asp:FormView runat="server" ItemType="WebFormsTemplate.Models.Book" ID="BookDetail">
        <ItemTemplate>
            <h2>
                <%#Server.HtmlEncode(Item.Title) %>
            </h2>
            <div>
                by <%#Server.HtmlEncode(Item.Authors) %>
            </div>
            <%if (!string.IsNullOrEmpty((this.BookDetail.DataItem as WebFormsTemplate.Models.Book).ISBN))
                  { %>
                    <div>
                        ISBN <%#Server.HtmlEncode(Item.ISBN) %>
                    </div>
               <% } %>
                <%if (!string.IsNullOrEmpty((this.BookDetail.DataItem as WebFormsTemplate.Models.Book).WebSite))
                  { %>
                    <div>
                        Web site: <a href="<%#Server.HtmlEncode(Item.WebSite) %>"><%#Server.HtmlEncode(Item.WebSite) %></a>
                    </div>
                <% } %>
            <%if (!string.IsNullOrEmpty((this.BookDetail.DataItem as WebFormsTemplate.Models.Book).Description))
                  { %>
                    <br />
                    <div>
                        <%#Server.HtmlEncode(Item.Description) %>
                    </div>
                <% } %>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <a href="/">Back to books</a>
</asp:Content>