<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<MenuManageViewModel>" %>
<%@ Import Namespace="APKO.Helpers.Constants"%>

<%@ Import Namespace="APKO.Models.ViewModels.Admin"%>
<%@ Import Namespace="APKO.Resources.Views.Admin" %>
<%@ Import Namespace="APKO.Resources.Views.Admin.Shared" %>
<%@ Import Namespace="APKO.Helpers" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    <%= MenuManage.PageTitle %>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

  
 
  

    <div id="content">
        <div id="body" class="block corners-top">
            <div id="title" class="">
                <div class="adm-title-icon adm-title-menu">
                </div>
                <h2>
                    <%= MenuManage.PageTitle %></h2>
            </div>
            <div id="menuStarter" class="space15">
            </div>
            <% Html.EnableClientValidation(); %>
            <% using (Html.BeginForm())
               {%>
            <%= Html.TextBoxFor(m => Model.Menu.Name, new { @class = "textbox textbox-big" })%>
            <%= Html.ValidationMessageFor(m => Model.Menu.Name)%>
            <br />
            <%= Html.TextAreaFor(m => Model.Menu.Body, new { id="Body"})%>
            
            <%= Html.ValidationMessageFor(m => Model.Menu.Body)%>

                    
               <% Html.RenderPartial("controls/CKEditor"); %>
            
      

            <div id="manageButtons">
                <a href="<%= Url.Action("Menues") %>">
                    <input type="button" class="button-gray" name="btnSubmit" value="<%= Buttons.Cancel %>" /></a>
                <input type="submit" class="button-blue" name="btnSubmit" value="<%= PublishOrEdit.GetValue(Model.Action) %>" />
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>
