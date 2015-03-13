using System.Linq;

namespace APKO.Models.ViewModels.Admin
{
    public class ContentManageViewModel
    {
        public Content Content { get; set; }
        public IQueryable<Category> Categories { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string Action { get; set; }
        public string FullUrl { get; set; }
        public string Author { get; set; }
    }
}