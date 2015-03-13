<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="APKO.Resources.Views.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Index.Title %>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div id="body" style=" padding:45px 40px;" class="block corners-top center">
          <h3><%= Index.Welcome %></h3>  
        </div>
    </div>
</asp:Content>
