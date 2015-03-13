using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using APKO.Helpers;
using APKO.Helpers.Attributes;
using APKO.Resources.Models.Admin;


namespace APKO.Models
{
    [MetadataType(typeof(ContentValidation))]
    public partial class Content{}

    [Bind(Exclude = "Id")]
    public class ContentValidation
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationStrings))]
        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ValidationStrings))]
        [LocalizedDisplayName("Title", NameResourceType = typeof(FieldNames))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationStrings))]
        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ValidationStrings))]
        [RegularExpression(@"[a-z0-9\-]*", ErrorMessageResourceName = "Alias", ErrorMessageResourceType = typeof(ValidationStrings))]
        [LocalizedDisplayName("Url", NameResourceType = typeof(FieldNames))]
        public string Url { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationStrings))]
        [LocalizedDisplayName("Category", NameResourceType = typeof(FieldNames))]
        public string CategoryId { get; set; }

        [LocalizedDisplayName("Body", NameResourceType = typeof(FieldNames))]
        public string Body { get; set; }

        [LocalizedDisplayName("MetaTitle", NameResourceType = typeof(FieldNames))]
        public string MetaTitle { get; set; }

        [LocalizedDisplayName("MetaKey", NameResourceType = typeof(FieldNames))]
        public string MetaKeywords { get; set; }

        [LocalizedDisplayName("MetaDesc", NameResourceType = typeof(FieldNames))]
        public string MetaDescription { get; set; }

        [LocalizedDisplayName("IsPublish", NameResourceType = typeof(FieldNames))]
        public string IsPublish { get; set; }
    }


   
}