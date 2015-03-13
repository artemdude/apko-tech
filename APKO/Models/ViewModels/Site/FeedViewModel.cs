using System.Linq;

namespace APKO.Models.ViewModels.Site
{
    public class FeedViewModel
    {
        public IQueryable<Content> Contents { get; set; }
    }
}
