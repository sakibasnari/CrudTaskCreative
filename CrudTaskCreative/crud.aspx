<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crud.aspx.cs" Inherits="CrudTaskCreative.crud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Product List</h1>
        <asp:TextBox ID="userName" runat="server" placeholder="Search by User Name"></asp:TextBox>
        <asp:TextBox ID="category" runat="server" placeholder="Search by User Category"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="Search" OnClick="search_Click" />
        <br />
        <asp:GridView ID="products" runat="server" AutoGenerateColumns="false" DataKeyNames="ProductId"
            AllowPaging="true" PageSize="5" OnPageIndexChanging="products_PageIndexChanging"
            OnRowDeleting="products_rowDeleting" OnRowEditing="products_RowEditing" OnRowUpdating="products_RowUpdating"
             OnRowCancelingEdit="products_RowCancelingEdit">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="Product ID" ReadOnly="true" />
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Description">
                    <ItemTemplate>
                        <asp:Label ID="lblProductDescription" runat="server" Text='<%# Eval("ProductDescription") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProductDescription" runat="server" Text='<%# Bind("ProductDescription") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CategoryName" HeaderText="Product Category" ReadOnly="true"  />
                <asp:BoundField DataField="UserName" HeaderText="User Name" ReadOnly="true" />
                <asp:CommandField ShowEditButton="true" HeaderText="Action" />
                <asp:CommandField ShowDeleteButton="true" HeaderText="Action" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
