<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script src="<%= ResolveUrl("~/Scripts/RichTextEditors/CKeditor/ckeditor.js") %>"
    type="text/javascript"></script>

<script type="text/javascript">
                        //<![CDATA[
                        CKEDITOR.replace('Body',
                {
                    skin: 'kama',
                    language: '<%= Session["Culture"] %>'
                });
                        //]]>
</script>

