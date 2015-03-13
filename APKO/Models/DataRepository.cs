using System;
using System.Linq;
using APKO.Helpers.Enums;

namespace APKO.Models
{
    public class DataRepository : IDataRepository
    {
        private readonly DataLinqDataContext db = new DataLinqDataContext();


        public IQueryable<Content> GetContents()
        {
            return db.Contents;
        }

        public Content GetContent(int id)
        {
            return db.Contents.SingleOrDefault(c => c.Id == id);
        }

        public Content GetContent(string articleUrl)
        {
            return db.Contents.SingleOrDefault(c => c.Url == articleUrl);
        }

        public Content GetContent(string categoryUrl, string articleUrl)
        {
            return db.Contents.SingleOrDefault(c => c.Url == articleUrl && c.Category.Url == categoryUrl);
        }

        public IQueryable<Content> GetContents(string text)
        {
            return db.Contents.Where(t => t.Body.Contains(text) || t.Title.Contains(text));
        }

        public IQueryable<Content> GetContentsByCategory(int categoryId)
        {
            return db.Contents.Where(c => c.CategoryId == categoryId);
        }

        public IQueryable<Content> GetContents(TransportContent transportContent, int number)
        {
            IQueryable<Content> contents = db.Contents;

            if (transportContent.CategoryId != 0)
            {
                contents = contents.Where(c => c.CategoryId == transportContent.CategoryId);
            }

            switch (transportContent.IsPublish)
            {
                case State.Published:
                    contents = contents.Where(c => c.IsPublish == false);
                    break;
                case State.Unpublished:
                    contents = contents.Where(c => c.IsPublish);
                    break;
            }

            if (transportContent.AuthorId != 0)
            {
                contents = contents.Where(a => a.AuthorId == transportContent.AuthorId);
            }

            if (number != 0)
            {
                return contents.Take(number);
            }
            return contents;
        }

        public Content GetContentByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void AddContent(Content content)
        {
            db.Contents.InsertOnSubmit(content);
        }

        public void DeleteContent(int id)
        {
            db.Contents.DeleteOnSubmit(GetContent(id));
        }

        public IQueryable<Category> GetCategories(TransportCategory transportCategory, int number)
        {
            IQueryable<Category> categories = db.Categories;

            switch (transportCategory.IsPublish)
            {
                case State.Published:
                    categories = categories.Where(c => c.IsPublish == false);
                    break;
                case State.Unpublished:
                    categories = categories.Where(c => c.IsPublish);
                    break;
            }

            if (transportCategory.AuthorId != 0)
            {
                categories = categories.Where(a => a.AuthorId == transportCategory.AuthorId);
            }

            if (number != 0)
            {
                return categories.Take(number);
            }
            return categories;
        }

        public Category GetCategoryByUrl(string url)
        {
            return db.Categories.SingleOrDefault(c => c.Url == url);
        }

        public Category GetCategoryByName(string name)
        {
            return db.Categories.SingleOrDefault(c => c.Name == name);
        }

        public Category GetCategory(int id)
        {
            return db.Categories.SingleOrDefault(c => c.Id == id);
        }

        public IQueryable<Category> GetCategories(string text)
        {
            return db.Categories.Where(t => t.Body.Contains(text) || t.Title.Contains(text));
        }

        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        public void AddCategory(Category category)
        {
            db.Categories.InsertOnSubmit(category);
        }


        public void DeleteCategory(int id)
        {
            db.Categories.DeleteOnSubmit(GetCategory(id));
        }

        public Menu GetMenu(string name)
        {
            return db.Menus.SingleOrDefault(m => m.Name == name);
        }

        public Menu GetMenu(int id)
        {
            return db.Menus.SingleOrDefault(m => m.Id == id);
        }

        public IQueryable<Menu> GetMenues(string text)
        {
            return db.Menus.Where(t => t.Body.Contains(text) || t.Name.Contains(text));
        }

        public IQueryable<Menu> GetMenues()
        {
            return db.Menus;
        }

        public IQueryable<Menu> GetMenues(Menu transportMenu, int number)
        {
            IQueryable<Menu> menues = db.Menus;

            if (transportMenu.AuthorId != 0)
            {
                menues = db.Menus.Where(m => m.AuthorId == transportMenu.AuthorId);
            }

            if (number != 0)
            {
                return menues.Take(number);
            }

            return menues;
        }

        public void AddMenu(Menu menu)
        {
            db.Menus.InsertOnSubmit(menu);
        }

        public void DeleteMenu(int id)
        {
            db.Menus.DeleteOnSubmit(GetMenu(id));
        }

        public Profile GetProfile(int id)
        {
            return db.Profiles.SingleOrDefault(p => p.Id == id);
        }

        public Profile GetPofile(Guid guid)
        {
            return db.Profiles.SingleOrDefault(p => p.Guid == guid);
        }

        public IQueryable<Profile> GetProfiles()
        {
            return db.Profiles;
        }

        public void AddProfile(Profile profile)
        {
            db.Profiles.InsertOnSubmit(profile);
        }


        public void Save()
        {
            db.SubmitChanges();
        }

    }
}