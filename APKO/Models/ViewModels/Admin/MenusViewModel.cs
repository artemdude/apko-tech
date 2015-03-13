using System.Linq;
using System.Web.Mvc;

namespace APKO.Models.ViewModels.Admin
{
    public class MenusViewModel
    {
        public IQueryable<Menu> Menus { get; set; }
        public SelectList ItemCount { get; set; }
        public string SearchQuery { get; set; }
        public IQueryable<Profile> Profiles { get; set; }
    }
}