using System.Linq;

namespace APKO.Models
{
    public class DataViewModel
    {
        public Content Content { get; set; }
        public Category Category { get; set; }
        public Menu Menu { get; set; }

        public IQueryable<Content> Contents { get; set; }
        public IQueryable<Category> Categories { get; set; }
        public IQueryable<Menu> Menues { get; set; }
        public IQueryable<Profile> Profiles { get; set; }
    }
}