<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<APKO.Models.ViewModels.Site.IndexViewModel>" %>

<asp:Content ID="MetaTagsContent" ContentPlaceHolderID="MetaTagsContent" runat="server">
    <title>
        <%= Model.Category.MetaTitle %></title>
    <meta name="keywords" content="<%= Model.Category.MetaKeywords %>" />
    <meta name="description" content="<%= Model.Category.MetaDescription %>" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-text">
        <%= Model.Category.Body %>
    </div>
</asp:Content>
