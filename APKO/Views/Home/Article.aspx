<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<APKO.Models.ViewModels.Site.ArticleViewModel>" %>
<%@ Import Namespace="APKO.Controllers"%>

<asp:Content ID="MetaTagsContent" ContentPlaceHolderID="MetaTagsContent" runat="server">
    <title><%= Model.Content.MetaTitle %></title>
    
    <meta name="keywords" content="<%= Model.Content.MetaKeywords %>" />
    <meta name="description" content="<%= Model.Content.MetaDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
Hello worldf, andf 
    <div class="content-text">
    <%=  Html.DisplayTextFor(m => Model.Content.Body)%>
    </div>

</asp:Content>
