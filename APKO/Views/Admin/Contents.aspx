<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<ContentsViewModel>" %>

<%@ Import Namespace="APKO.Models.ViewModels.Admin"%>
<%@ Import Namespace="APKO.Resources.Views.Admin" %>
<%@ Import Namespace="APKO.Resources.Additional" %>
<%@ Import Namespace="APKO.Resources.Views.Admin.Shared" %>
<%@ Import Namespace="APKO.Resources.Views.Admin" %>
<%@ Import Namespace="APKO.Helpers" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Contents.PageTitle %>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <script language="javascript">
        function SubmitForm(element) {
            $(element).parents('form').submit();
        }

    </script>

    <div id="content">
        <div id="body" class="block corners-top">
            <div id="title" class="">
                <div class="adm-title-icon adm-title-article">
                </div>
                <h2>
                    <%= Contents.PageTitle %>
                    <a href="<%= Url.Action("ContentManage") %>">
                        <input type="button" class="button-gray" name="btnSubmit" value="<%= Buttons.CreateNew %>" /></a></h2>
            </div>
            <div id="menuStarter" class="space15">
            </div>
            <% using (Html.BeginForm())
               {%>
            <div id="filtersPanel">
                <div class="f-left">
                    <%= Html.TextBox("searchQuery", Model.SearchQuery, new { @class = "singleTextBox search" })%>
                </div>
                <div class="f-right">
                    <%= Html.DropDownList("authorId", new SelectList(Model.Profiles, "id", "Name"), Filters.SelectAuthor, new { @class = "singleTextBox", @onchange = "SubmitForm(this)" })%>
                    <%= Html.DropDownList("categoryId", new SelectList(Model.Categories, "id", "Name"), Filters.SelectCategory, new { @class = "singleTextBox", @onchange = "SubmitForm(this)" })%>
                    <%= Html.DropDownList("state", Model.State, new { @class = "singleTextBox", @onchange = "SubmitForm(this)" })%>
                </div>
                <div class="clear">
                </div>
            </div>
            <% if(Model.Contents.Count() != 0){ %>
            <table class="DataTable">
                <thead>
                    <tr>
                        <th>
                            Id
                        </th>
                        <th>
                            <%= Contents.Title %>
                        </th>
                        <th>
                            <%= Contents.Category %>
                        </th>
                        <th>
                            <%= Contents.Created %>
                        </th>
                        <th>
                            <%= Contents.Author %>
                        </th>
                        <th>
                            <%= Contents.Manage %>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var item in Model.Contents)
                       {%>
                    <tr>
                        <td style="width: 1%;" align="center">
                            <%= item.Id %>
                        </td>
                        <td>
                            <%= Html.ActionLink(item.Title, "ContentManage", new { id = item.Id })%>
                        </td>
                        <td width="1%" nowrap="nowrap">
                            <%= Html.ActionLink(item.Category.Name, "CategoryManage", new { id = item.CategoryId })%>
                        </td>
                        <td width="1%" nowrap="nowrap">
                            <%= APKO.Helpers.DateFormatter.DateToShort(item.Created)%>
                        </td>
                        <td width="1%" nowrap="nowrap">
                            <%= item.Profile.Name %>
                        </td>
                        <td width="1%" align="center">
                        
                         <%= Html.ActionLink(
                                Buttons.Delete,
                               "DeleteContent", 
    new { id = item.Id }, 
    new { @class= "delete-link", onclick = "return confirm('Strings.DeleteConfirmation')" }) %>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
            <div class="page-counter">
                <%= Strings.Display %>
                <%= Html.DropDownList("itemsCount", Model.ItemCount, new { @class = "select", @onchange = "SubmitForm(this)" })%>
            </div>
           
            <% } else { %>
            <div class="nodata"><%= Strings.NoData %></div>
            <% }%>  
              
              
       
            <% } %>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuContent" runat="server">
<table id="extraMenuTable" width="100%">
        <tr>
            <td>
                <b>
                    <%= Contents.ContentPublishedCount%>
                </b>
            </td>
            <td>
                <%=  Model.Contents.Count(m => m.IsPublish == false)%>
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <%= Contents.ContentDraftCount%>
                </b>
            </td>
            <td>
                <%=  Model.Contents.Count(m => m.IsPublish)%>
            </td>
        </tr>
</table>
</asp:Content>
