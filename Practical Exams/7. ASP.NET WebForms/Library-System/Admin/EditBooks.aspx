<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditBooks.aspx.cs" Inherits="WebFormsTemplate.Admin.EditBooks" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h1>Edit Books</h1>
    <asp:GridView
        runat="server"
        ID="BooksGrid"
        PageSize="5"
        AllowPaging="true"
        AllowSorting="true"
        AutoGenerateColumns="false"
        DataKeyNames="Id"
        ItemType="WebFormsTemplate.Models.BookViewModel"
        SelectMethod="BooksGrid_GetData">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Authors" HeaderText="Authors" SortExpression="Authors" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
            <asp:BoundField DataField="WebSite" HeaderText="Web Site" SortExpression="WebSite" />
            <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="Edit" runat="server" Text="Edit" OnClick="Edit_Click" CssClass="btn" />
                    <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" CssClass="btn" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="CreateBook" runat="server" Text="Create book" OnClick="CreateBook_Click" CssClass="btn" />

    <asp:FormView ID="BookCreate" runat="server" ItemType="WebFormsTemplate.Models.Book" DataKeyNames="Id">
        <ItemTemplate>
            <div class="row">
                <div class="span5">
                    <h2>Create book</h2>
                    <asp:Label runat="server" AssociatedControlID="BookTitle">Title</asp:Label>
                    <asp:TextBox runat="server" ID="BookTitle" Text="<%#Item.Title %>" ></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookAuthors">Authors</asp:Label>
                    <asp:TextBox runat="server" ID="BookAuthors" Text="<%#Item.Authors %>" ></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookIsbn">ISBN</asp:Label>
                    <asp:TextBox runat="server" ID="BookIsbn" Text="<%#Item.ISBN %>" ></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookSite">Web site</asp:Label>
                    <asp:TextBox runat="server" ID="BookSite" Text="<%#Item.WebSite %>" ></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookDescription">Description</asp:Label>
                    <asp:TextBox runat="server" ID="BookDescription" Text="<%#Item.Description %>" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookCategory">Category</asp:Label>
                    <asp:DropDownList runat="server" ID="BookCategory" SelectMethod="BooksCategoris_GetData" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                    <div>
                        <asp:Button runat="server" ID="SaveCreate" Text="Create" OnClick="SaveCreate_Click" CssClass="btn" />
                        <asp:Button runat="server" ID="CancelCreate" Text="Cancel" OnClick="CancelCreate_Click" CssClass="btn" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:FormView ID="BookEdit" runat="server" ItemType="WebFormsTemplate.Models.Book" DataKeyNames="Id">
        <ItemTemplate>
            <div class="row">
                <div class="span5">
                    <h2>Edit book</h2>
                    <asp:Label runat="server" AssociatedControlID="BookTitle">Title</asp:Label>
                    <asp:TextBox runat="server" ID="BookTitle" Text="<%#Item.Title %>" ></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookAuthors">Authors</asp:Label>
                    <asp:TextBox runat="server" ID="BookAuthors" Text="<%#Item.Authors %>" ></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookIsbn">ISBN</asp:Label>
                    <asp:TextBox runat="server" ID="BookIsbn" Text="<%#Item.ISBN %>" ></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookSite">Web site</asp:Label>
                    <asp:TextBox runat="server" ID="BookSite" Text="<%#Item.WebSite %>" ></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookDescription">Description</asp:Label>
                    <asp:TextBox runat="server" ID="BookDescription" Text="<%#Item.Description %>" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label runat="server" AssociatedControlID="BookCategory">Category</asp:Label>
                    <asp:DropDownList runat="server" ID="BookCategory" SelectMethod="BooksCategoris_GetData" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                    <div>
                        <asp:Button runat="server" ID="SaveEdit" Text="Edit" OnClick="SaveEdit_Click" CssClass="btn" />
                        <asp:Button runat="server" ID="CancelEdit" Text="Cancel" OnClick="CancelEdit_Click" CssClass="btn" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:FormView ID="BookDelete" runat="server" ItemType="WebFormsTemplate.Models.Book" DataKeyNames="Id">
        <ItemTemplate>
            <div class="row">
                <div class="span5">
                    <h2>Confirm book deletion</h2>
                    <asp:Label runat="server" AssociatedControlID="BookTitle">Title</asp:Label>
                    <asp:TextBox runat="server" ID="BookTitle" Text="<%#Item.Title %>" Enabled="false" ></asp:TextBox>
                    <div>
                        <asp:Button runat="server" ID="SaveDelete" Text="Delete" OnClick="SaveDelete_Click" CssClass="btn" />
                        <asp:Button runat="server" ID="CancelDelete" Text="Cancel" OnClick="CancelDelete_Click" CssClass="btn" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>
