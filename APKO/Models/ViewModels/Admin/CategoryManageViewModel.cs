namespace APKO.Models.ViewModels.Admin
{
    public class CategoryManageViewModel
    {
        //public CategoryManageViewModel(Category category, string created, string modified, Manage action, string fullUrl, string author)
        //{
        //    Category = category;
        //    Created = created;
        //    Modified = modified;
        //    Action = action;
        //    FullUrl = fullUrl;
        //    Author = author;
        //}
        
        public Category Category { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string Action { get; set; }
        public string FullUrl { get; set; }
        public string Author { get; set; }
    }
}