﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<CategoriesViewModel>" %>
<%@ Import Namespace="APKO.Models.ViewModels.Admin"%>

<%@ Import Namespace="APKO.Resources.Views.Admin" %>
<%@ Import Namespace="APKO.Resources.Views.Admin.Shared" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Categories.PageTitle %>
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
                <div class="adm-title-icon adm-title-category">
                </div>
                <h2>
                    <%= Categories.PageTitle %>
                    <a href="<%= Url.Action("CategoryManage") %>">
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
                    <%= Html.DropDownList("state", Model.State, new { @class = "singleTextBox", @onchange = "SubmitForm(this)" })%>
                </div>
                <div class="clear">
                </div>
            </div>
          <% if(Model.Categories.Count() != 0){ %>
            <table class="DataTable">
                <thead>
                    <tr>
                        <th>
                            Id
                        </th>
                        <th>
                            <%= Categories.Title %>
                        </th>
                        <th>
                            <%= Categories.Created%>
                        </th>
                        <th>
                            <%= Categories.Author%>
                        </th>
                        <th>
                            <%= Categories.Manage%>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var item in Model.Categories)
                       {%>
                    <tr>
                        <td style="width: 1%;" align="center">
                            <%= item.Id %>
                        </td>
                        <td>
                    
                        
                            <%= Html.ActionLink(item.Title, "CategoryManage", new { id = item.Id })%>
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
                                "DeleteCategory", 
    new { id = item.Id }, 
    new { @class= "delete-link", onclick = "return confirm('Strings.DeleteConfirmation')" }) %>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
            <div class="page-counter">
                <%= Strings.Display %>
                <%= Html.DropDownList("itemsCount", (IEnumerable<SelectListItem>)Model.ItemCount, new { @class = "select", @onchange = "SubmitForm(this)" })%>
            </div>
              <% } else { %>
            <div class="nodata"><%= Strings.NoData %></div>
            <% }%>  
            
            <% } %>
        </div>
    </div>
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContent" runat="server">
<table id="extraMenuTable" width="100%">
        <tr>
            <td>
                <b>
                    <%= Categories.CategoryPublishedCount%>
                </b>
            </td>
            <td>
                <%=  Model.Categories.Count(m => m.IsPublish == false) %>
            </td>
        </tr>
                <tr>
            <td>
                <b>
                    <%= Categories.CategoryDraftCount%>
                </b>
            </td>
            <td>
                <%=  Model.Categories.Count(m => m.IsPublish)%>
            </td>
        </tr>
</table>
</asp:Content>
