<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<CategoryManageViewModel>" %>
<%@ Import Namespace="APKO.Models.ViewModels.Admin"%>

<%@ Import Namespace="APKO.Resources.Views.Admin" %>
<%@ Import Namespace="APKO.Resources.Views.Admin.Shared" %>
<%@ Import Namespace="APKO.Helpers" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= CategoryManage.PageTitle %>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
            <div id="title">
                <div class="adm-title-icon adm-title-category">
                </div>
                <h2>
                    <%= CategoryManage.PageTitle %></h2>
            </div>
            <div id="menuStarter" class="space15">
            </div>
                  <% Html.EnableClientValidation(); %>
            <% using (Html.BeginForm())
               {%>
            <%= Html.TextBoxFor(m => Model.Category.Title, new { @class = "textbox textbox-big" })%>
            <br />
            <%= Html.ValidationMessageFor(m => Model.Category.Title)%>
            <br />
            <%= Html.TextAreaFor(m => Model.Category.Body, new { id="Body"})%>
            <br />
            <%= Html.ValidationMessageFor(m => Model.Category.Body)%>
            <br />

           <% Html.RenderPartial("controls/CKEditor"); %>

            <table class="body-table">
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Category.Name)%><span class="fill-star">*</span>
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Category.Name, new { @class = "singleTextBox" })%>
                        <%= Html.ValidationMessageFor(m => Model.Category.Name)%>
                    </td>
                    <td style="width: 20px;">
                        <img class="help-tooltip" original-title='<%= HelpTooltip.Name %>' src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Category.Url)%><span class="fill-star">*</span>
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Category.Url, new {@class = "singleTextBox" })%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Category.Url)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.Url %>'
                            class="help-tooltip" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Category.MetaTitle)%>
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Category.MetaTitle, new {@class = "singleTextBox" })%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Category.MetaTitle)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.MetaTitle %>'
                            class="help-tooltip" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Category.MetaKeywords)%>
                    </td>
                    <td>
                        <%= Html.TextAreaFor(m => Model.Category.MetaKeywords, new {@class = "singleTextBox" })%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Category.MetaKeywords)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.MetaKey %>'
                            class="help-tooltip" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Category.MetaDescription)%>
                    </td>
                    <td>
                        <%= Html.TextAreaFor(m => Model.Category.MetaDescription, new { @class = "singleTextBox" })%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Category.MetaDescription)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.MetaDesc %>'
                            class="help-tooltip" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.LabelFor(m => Model.Category.IsPublish)%>
                    </td>
                    <td>
                        <%= Html.CheckBoxFor(m => Model.Category.IsPublish, new {Title = Strings.IsPublishCheckBox})%>
                        <br />
                        <%= Html.ValidationMessageFor(m => Model.Category.IsPublish)%>
                    </td>
                    <td>
                        <img src="<%= ResolveUrl("~/Images/Admin/bg_cicle_help.png") %>" original-title='<%= HelpTooltip.IsPublish %>'
                            class="help-tooltip" />
                    </td>
                </tr>
            </table>
            <div id="manageButtons">
                <a href="<%= Url.Action("Categories") %>">
                    <input type="button" class="button-gray" name="btnSubmit" value="<%= Buttons.Cancel %>" /></a>
                <input type="submit" class="button-blue" name="btnSubmit" value="<%= PublishOrEdit.GetValue(Model.Action) %>" />
            </div>
            
           <%-- Что бы оставить данные после срабатывания серверной валидации--%>
            
             <%= Html.HiddenFor(m => Model.Created)%>
             <%= Html.HiddenFor(m => Model.Modified)%>
             <%= Html.HiddenFor(m => m.Category.Profile.Name)%>
             <%= Html.HiddenFor(m => Model.FullUrl)%>
             <%= Html.HiddenFor(m => Model.Action)%>
            
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
                <%=  Model.Created %>
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
                <%=  Model.Author %>
            </td>
        </tr>
    </table>
    
    
</asp:Content>
