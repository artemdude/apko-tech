<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
    <title>404: Page Not Found</title>
    <link href="<%= ResolveUrl("~/Css/Error/404.css") %>" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="error">
    <span id="title">404</span>
    <div style="height:30px;"></div>
        <div style="font-size:17px">
        Sorry, the page
       <b><%= Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host + ViewData["error_path"] %></b> not found :(
        </div>
    </div>

</body>
</html>
