using System;
using System.Linq;

namespace APKO.Models
{
    public interface IDataRepository
    {
        IQueryable<Content> GetContents();
        IQueryable<Content> GetContentsByCategory(int categoryId);
        Content GetContent(int id);
        Content GetContent(string articleUrl);
        Content GetContent(string categoryUrl, string articleUrl);
        IQueryable<Content> GetContents(string text);
        IQueryable<Content> GetContents(TransportContent content, int number);
        void AddContent(Content content);
        void DeleteContent(int id);


        IQueryable<Category> GetCategories();
        IQueryable<Category> GetCategories(TransportCategory category, int number);
        Category GetCategoryByUrl(string url);
        Category GetCategoryByName(string name);
        Category GetCategory(int id);
        IQueryable<Category> GetCategories(string text);
        void AddCategory(Category category);
        void DeleteCategory(int id);


        Menu GetMenu(string name);
        Menu GetMenu(int id);
        IQueryable<Menu> GetMenues(string text);
        IQueryable<Menu> GetMenues();
        IQueryable<Menu> GetMenues(Menu menu, int number);
        void AddMenu(Menu menu);
        void DeleteMenu(int id);

        Profile GetProfile(int id);
        Profile GetPofile(Guid guid);
        IQueryable<Profile> GetProfiles();
        void AddProfile(Profile profile);

        void Save();
    }
}