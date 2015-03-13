using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using APKO.Helpers;
using APKO.Resources.Models.Admin;

namespace APKO.Models
{
    [MetadataType(typeof(MenuValidation))]
    public partial class Menu{}


    [Bind(Exclude = "Id")]
    public class MenuValidation
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationStrings))]
        [LocalizedDisplayName("Name", NameResourceType = typeof(FieldNames))]
        public string Name { get; set; }

        [LocalizedDisplayName("Body", NameResourceType = typeof(FieldNames))]
        public string Body { get; set; }
    }
}