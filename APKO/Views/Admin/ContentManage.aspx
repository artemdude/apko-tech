<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<APKO.Models.ViewModels.Admin.ContentManageViewModel>" %>

<%@ Import Namespace="APKO.Resources.Views.Admin" %>
<%@ Import Namespace="APKO.Resources.Views.Admin.Shared" %>
<%@ Import Namespace="APKO.Helpers" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ContentManage.PageTitle%>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <script src="<%= ResolveUrl("~/Scripts/RichTextEditors/CKeditor/ckeditor.js") %>"
        type="text/javascript"></script>

    <script language="javascript">
        $(document).ready(function() {
            $('.help-tooltip ').tipsy({ gravity: 's', delayIn: 500, delayOut: 500 });
        });
    </script>

    <script src="<%= ResolveUrl("~/Scripts/plugins/tooltips/tipsy/tipsy.js") %>" type="text/javascript"></script>

    <link href="<%= ResolveUrl("~/Scripts/plugins/tooltips/tipsy/tipsy.css") %>" rel="stylesheet"
        type="text/css" />
    <div id="content">
        <div id="body" class="block corners-top">
            <div id="title" class="">
                <div class="adm-title-icon adm-title-article">
                </div>
                <h2>
                    <%= ContentManage.PageTitle %></h2>
            </div>
            <div id="menuStarter" class="space15">
            </div>
            <% Html.EnableClientValidation(); %>
            <% using (Html.BeginForm())
               {%>
            <%= Html.TextBoxFor(m => Model.Content.Title, new { @class = "textbox textbox-big" })%>
            <%= Html.ValidationMessageFor(m => Model.Content.Title)%>
            <br />
            <%= Html.TextAreaFor(m => Model.Content.Body, new { id = "Body" })%>
            <%= Html.ValidationMessageFor(m => Model.Content.Body)%>

            <% Html.RenderPartial("controls/CKEditor"); %>

            <br />
            <table class="body-table">
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Content.Url)%><span class="fill-star">*</span>
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Content.Url, new { @class = "singleTextBox" })%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Content.Url)%>
                    </td>
                    <td style="width: 20px;">
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.Url %>'
                            class="help-tooltip" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Content.CategoryId)%> <span class="fill-star">*</span>
                    </td>
                    <td>
                        <%= Html.DropDownListFor(m => m.Content.CategoryId, new SelectList(Model.Categories, "id", "Name"), Filters.SelectCategory, new { @class = "singleTextBox" })%>
                    <br />
                        <%= Html.ValidationMessageFor(m => Model.Content.CategoryId)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.Category %>'
                            class="help-tooltip" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Content.MetaTitle)%>
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Content.MetaTitle, new { @class = "singleTextBox" })%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Content.MetaTitle)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.MetaTitle %>'
                            class="help-tooltip" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Content.MetaKeywords)%>
                    </td>
                    <td>
                        <%= Html.TextAreaFor(m => Model.Content.MetaKeywords, new { @class = "singleTextBox" })%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Content.MetaKeywords)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.MetaKey %>'
                            class="help-tooltip" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Content.MetaDescription)%>
                    </td>
                    <td>
                        <%= Html.TextAreaFor(m => Model.Content.MetaDescription, new { @class = "singleTextBox" })%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Content.MetaDescription)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.MetaDesc %>'
                            class="help-tooltip" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Content.IsPublish)%>
                    </td>
                    <td>
                        <%= Html.CheckBoxFor(m => Model.Content.IsPublish, new { Title = Strings.IsPublishCheckBox })%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Content.IsPublish)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.IsPublish %>'
                            class="help-tooltip" />
                    </td>
                </tr>
            </table>
            <div id="manageButtons">
                <a href="<%= Url.Action("Contents") %>">
                <input type="button" class="button-gray" name="btnSubmit" value="<%= Buttons.Cancel %>" /></a>
                <input type="submit" class="button-blue" name="btnSubmit" value="<%= PublishOrEdit.GetValue(Model.Action) %>" />
            </div>
            
                 <%-- Что бы оставить данные после срабатывания серверной валидации--%>
            
             <%= Html.HiddenFor(m => m.Created)%>
             <%= Html.HiddenFor(m => m.Modified)%>
             <%= Html.HiddenFor(m => m.Content.Profile.Name)%>
             <%= Html.HiddenFor(m => m.FullUrl)%>
             <%= Html.HiddenFor(m => m.Action)%>
            <% } %>
        </div>
    </div>
</asp:Content>
              <asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContent" runat="server">
    <table id="extraMenuTable" width="100%">
        <tr>
            <td>
                <b>
                    <%= Strings.Created %>
                </b>
            </td>
            <td>
                <%= Model.Created %>
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <%= Strings.Modified %>
                </b>
            </td>
            <td>
                <%= Model.Modified %>
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <%= Strings.FullUrl %></b>
            </td>
            <td>
                    <%= Model.FullUrl %>
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <%= Strings.Author %></b>
            </td>
            <td>
                <%= Html.DisplayTextFor(m => m.Content.Profile.Name) %>
            </td>
        </tr>
    </table>
</asp:Content>