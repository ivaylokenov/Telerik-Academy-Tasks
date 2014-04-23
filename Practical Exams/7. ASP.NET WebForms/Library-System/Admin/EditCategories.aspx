<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditCategories.aspx.cs" Inherits="WebFormsTemplate.Admin.EditCategories" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h1>Edit Categories</h1>
    <asp:GridView
        runat="server"
        ID="CategoriesGrid"
        PageSize="5"
        AllowPaging="true"
        AllowSorting="true"
        AutoGenerateColumns="false"
        DataKeyNames="Id"
        ItemType="WebFormsTemplate.Models.Category"
        SelectMethod="CategoriesGrid_GetData">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Category Name" SortExpression="Name" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="Edit" runat="server" Text="Edit" OnClick="Edit_Click" CssClass="btn" />
                    <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" CssClass="btn" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="CreateCategory" runat="server" Text="Create category" OnClick="CreateCategory_Click" CssClass="btn" />

    <asp:FormView ID="CategoryCreate" runat="server" ItemType="WebFormsTemplate.Models.Category" DataKeyNames="Id">
        <ItemTemplate>
            <div class="row">
                <div class="span5">
                    <h2>Create Category</h2>
                    <asp:Label runat="server" AssociatedControlID="CreateCategory">Category</asp:Label>
                    <asp:TextBox runat="server" ID="CreateCategory" Text="<%#Item.Name %>" ></asp:TextBox>
                    <div>
                        <asp:Button runat="server" ID="SaveCreate" Text="Create" OnClick="SaveCreate_Click" CssClass="btn" />
                        <asp:Button runat="server" ID="CancelCreate" Text="Cancel" OnClick="CancelCreate_Click" CssClass="btn" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:FormView ID="CategoryDetails" runat="server" ItemType="WebFormsTemplate.Models.Category" DataKeyNames="Id">
        <ItemTemplate>
            <div class="row">
                <div class="span5">
                    <h2>Edit Category</h2>
                    <asp:Label runat="server" AssociatedControlID="EditCategory">Category</asp:Label>
                    <asp:TextBox runat="server" ID="EditCategory" Text="<%#Item.Name %>"></asp:TextBox>
                    <div>
                        <asp:Button runat="server" ID="SaveEdit" Text="Save" OnClick="SaveEdit_Click" CssClass="btn" />
                        <asp:Button runat="server" ID="CancelEdit" Text="Cancel" OnClick="CancelEdit_Click" CssClass="btn" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:FormView ID="CategoryDelete" runat="server" ItemType="WebFormsTemplate.Models.Category" DataKeyNames="Id">
        <ItemTemplate>
            <div class="row">
                <div class="span5">
                    <h2>Confirm Category Deletion</h2>
                    <asp:Label runat="server" AssociatedControlID="DeleteCategory">Category</asp:Label>
                    <asp:TextBox runat="server" ID="DeleteCategory" Text="<%#Item.Name %>" Enabled="false"></asp:TextBox>
                    <div>
                        <asp:Button runat="server" ID="SaveDelete" Text="Delete" OnClick="SaveDelete_Click" CssClass="btn" />
                        <asp:Button runat="server" ID="CancelDelete" Text="Cancel" OnClick="CancelDelete_Click" CssClass="btn" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
