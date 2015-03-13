using System.Linq;
using System.Web.Mvc;

namespace APKO.Models.ViewModels.Admin
{
    public class ContentsViewModel
    {
        public IQueryable<Content> Contents { get; set; }
        public IQueryable<Category> Categories { get; set; }
        public IQueryable<Profile> Profiles { get; set; }

        public SelectList State { get; set; }
        public SelectList ItemCount { get; set; }
        public string SearchQuery { get; set; }
    }
}