<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%= Html.ActionLink("En", "ChangeCulture", "Account", 
   new { lang = "en", returnUrl = this.Request.RawUrl }, null)%> |
<%= Html.ActionLink("Ру", "ChangeCulture", "Account", 
   new { lang = "ru", returnUrl = this.Request.RawUrl }, null)%>