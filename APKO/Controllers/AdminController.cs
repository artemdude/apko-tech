using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Authentication;
using System.Web.Mvc;
using System.Web.Security;

using APKO.Helpers;
using APKO.Helpers.Constants;
using APKO.Helpers.Enums;
using APKO.Helpers.Filters;
using APKO.Models;
using APKO.Models.ViewModels.Admin;
using APKO.Resources.Views.Admin.Shared;


namespace APKO.Controllers
{
    [HandleError, Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IDataRepository dataRepository;

        //Dependency Injection enabled constructors
       // public AdminController() : this(new DataRepository()){}  This function do Ninject

        public AdminController(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CategoryManage(int? id)
        {
            var model = new CategoryManageViewModel();

            if (id != null)
            {
                model.Category = dataRepository.GetCategory((int)id);

                if (model.Category != null)
                {
                    model.Created = DateFormatter.DateToShortStringDay(model.Category.Created);

                    if (model.Category.Modified == null)
                    {
                        model.Modified = Strings.NotModified;
                    }
                    else
                    {
                        model.Modified = DateFormatter.DateToShortStringDay((DateTime)model.Category.Modified);
                    }

                    model.Action = ManageValues.Edit;
                    model.FullUrl = GetFullUrl(model.Category.Url);
                    model.Author = model.Category.Profile.Name;
                }
                else
                {
                    throw new Exception("no category with Id = " + id);
                }
            }
            else
            {
                model.Action = ManageValues.New;

                model.Created = DateFormatter.DateToShortStringDay(DateTime.Now);
                model.Modified = Strings.NotModified;
                model.FullUrl = Strings.NoUrl;
                model.Author = Membership.GetUser().UserName;
            }

            return View(model);
        }


        [ValidateInput(false), HttpPost]
        public ActionResult CategoryManage(int? id, CategoryManageViewModel modifiedModel)
        {
            if(ModelState.IsValid)
            {
                if (id == null)
                {
                    modifiedModel.Category.Created = DateTime.Now;
                    modifiedModel.Category.Profile = GetProfile();

                    dataRepository.AddCategory(modifiedModel.Category);
                }
                else
                {
                    Category category = dataRepository.GetCategory((int)id);
                    category.Modified = DateTime.Now;

                    UpdateModel(category, "Category");
                }

                dataRepository.Save();

                return RedirectToAction("Categories");
            }


            return View(modifiedModel);
        }


        public ActionResult ContentManage(int? id)
        {
           var model = new ContentManageViewModel();

           model.Categories = dataRepository.GetCategories();

            if (id != null)
            {
                model.Content = dataRepository.GetContent((int)id);

                model.Created = DateFormatter.DateToShortStringDay(model.Content.Created);

                if (model.Content.Modified == null)
                {
                    model.Modified = Strings.NotModified;
                }
                else
                {
                    model.Modified = DateFormatter.DateToShortStringDay((DateTime)model.Content.Modified);
                }

                model.Action = ManageValues.Edit;
                model.FullUrl = GetFullUrl(model.Content.Category.Url + "/" + model.Content.Url);
            }
            else
            {
                model.Action = ManageValues.New;

                model.Created = DateFormatter.DateToShortStringDay(DateTime.Now);
                model.Modified = Strings.NotModified;
                model.FullUrl = Strings.NoUrl;
            }

            return View(model);
       
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult ContentManage(int? id, ContentManageViewModel modifiedModel)
        {

            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    modifiedModel.Content.Created = DateTime.Now;
                    modifiedModel.Content.Profile = GetProfile();

                    dataRepository.AddContent(modifiedModel.Content);
                }
                else
                {
                    modifiedModel.Content.Modified = DateTime.Now;
                    Content content = dataRepository.GetContent((int)id);
                    UpdateModel(content, "Content");
                }

                dataRepository.Save();

                return RedirectToAction("Contents");
            }

            modifiedModel.Categories = dataRepository.GetCategories();

            return View(modifiedModel);
        }


        public ActionResult MenuManage(int? id)
        {
            var model = new MenuManageViewModel();

            if (id != null)
            {
                model.Action = ManageValues.Edit;
                model.Menu = dataRepository.GetMenu((int)id);
            }
            else
            {
                model.Action = ManageValues.New;
            }
            return View(model);
        }



        [HttpPost, ValidateInput(false)]
        public ActionResult MenuManage(int? id, DataViewModel modifiedModel)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    modifiedModel.Menu.Profile = GetProfile();
                    dataRepository.AddMenu(modifiedModel.Menu);
                }
                else
                {
                    Menu menu = dataRepository.GetMenu((int)id);

                    UpdateModel(menu, "Menu");
                }

                dataRepository.Save();

                return RedirectToAction("Menus");
            }

            return View(modifiedModel);
        }

        public ActionResult Contents(string searchQuery, int? itemsCount, int? categoryId, string state, int? authorId)
        {
            ContentsViewModel model = new ContentsViewModel();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                model.Contents = dataRepository.GetContents(searchQuery);
                model.SearchQuery = searchQuery;
            }
            else
            {
                var transportContent = new TransportContent();

                switch (state)
                {
                    case "Published":
                        transportContent.IsPublish = State.Published;
                        break;
                    case "Unpublished":
                        transportContent.IsPublish = State.Unpublished;
                        break;
                    default:
                        transportContent.IsPublish = State.All;
                        break;
                }

                if(categoryId != null)
                {
                    transportContent.CategoryId = (int)categoryId;
                }

                if(authorId != null)
                {
                    transportContent.AuthorId = (int)authorId;
                }

                if (itemsCount == null)
                {
                    itemsCount = (int)ItemCountList.GetItemsCountList()[0].Value;
                }

                model.SearchQuery = string.Empty;

                model.Contents = dataRepository.GetContents(transportContent, (int)itemsCount);
            }
         
            //todo:add to cookies
            model.Profiles = dataRepository.GetProfiles();
            model.ItemCount = new SelectList(ItemCountList.GetItemsCountList(), "Value", "Text", ItemCountList.GetItemsCountList()[0].Value);
            model.State = new SelectList(new List<DropDownList> { new DropDownList() { Value = "All", Text = Filters.SelectState }, new DropDownList() { Value = "Published", Text = "published" }, new DropDownList() { Value = "Unpublished", Text = "template" } }, "Value", "Text");

            model.Categories = dataRepository.GetCategories();

            return View(model);
        }

        public ActionResult Categories(string searchQuery, int? itemsCount, string state, int? authorId)
        {
            var model = new CategoriesViewModel();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                model.Categories = dataRepository.GetCategories(searchQuery);
                model.SearchQuery = searchQuery;
            }
            else
            {
                var transportCategory = new TransportCategory();

                switch (state)
                {
                    case "Published":
                        transportCategory.IsPublish = State.Published;
                        break;
                    case "Unpublished":
                        transportCategory.IsPublish = State.Unpublished;
                        break;
                    default:
                        transportCategory.IsPublish = State.All;
                        break;
                }


                if (authorId != null)
                {
                    transportCategory.AuthorId = (int)authorId;
                }

                if (itemsCount == null)
                {
                    itemsCount = (int)ItemCountList.GetItemsCountList()[0].Value;
                }

                model.SearchQuery = string.Empty;

                model.Categories = dataRepository.GetCategories(transportCategory, (int)itemsCount);
            }

            //todo:add to cookies
            model.Profiles = dataRepository.GetProfiles();
            model.ItemCount = new SelectList(ItemCountList.GetItemsCountList(), "Value", "Text", ItemCountList.GetItemsCountList()[0].Value);
            model.State = new SelectList(new List<DropDownList> { new DropDownList() { Value = "All", Text = Filters.SelectState }, new DropDownList() { Value = "Published", Text = "published" }, new DropDownList() { Value = "Unpublished", Text = "template" } }, "Value", "Text");

            return View(model);
        }

        public ActionResult DeleteMenu(int id)
        {
            dataRepository.DeleteMenu(id);
            dataRepository.Save();

            return RedirectToAction("Menus");
        }

          public ActionResult DeleteContent(int id)
          {
              dataRepository.DeleteContent(id);
              dataRepository.Save();  

              return RedirectToAction("Contents");
          }

        public ActionResult Menus(string searchQuery, int? itemsCount, int? authorId)
        {
            var model = new MenusViewModel();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                model.Menus = dataRepository.GetMenues(searchQuery);
                model.SearchQuery = searchQuery;
            }
            else
            {
                var transportMenu = new Menu();

                if (authorId != null)
                {
                    transportMenu.AuthorId = (int)authorId;
                }

                if (itemsCount == null)
                {
                    itemsCount = (int)ItemCountList.GetItemsCountList()[0].Value;
                }

                model.SearchQuery = string.Empty;

                model.Menus = dataRepository.GetMenues(transportMenu, (int)itemsCount);
            }

            //todo:add to cookies
            model.Profiles = dataRepository.GetProfiles();
            model.ItemCount = new SelectList(ItemCountList.GetItemsCountList(), "Value", "Text", ItemCountList.GetItemsCountList()[0].Value);
    
            return View(model);
        }

        public ActionResult DeleteCategory(int id)
        {
            dataRepository.DeleteCategory(id);
            dataRepository.Save();

            return RedirectToAction("Categories");
        }

        private Profile GetProfile()
        {
            if (User.Identity.IsAuthenticated)
            {
                return dataRepository.GetPofile((Guid)Membership.GetUser().ProviderUserKey);
            }

            throw new AuthenticationException("No user"); 
        }


        private static string GetFullUrl(string parameters)
        {
            string link = GetUrl.Domain() + "/" + parameters;
            return string.Format("<a target=\"_blank\" href=\"{0}\">{1}</a>", link, link);
        }

    }
}
