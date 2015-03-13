using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Mvc;
using APKO.Helpers;
using APKO.Helpers.Filters;
using APKO.Models;
using APKO.Models.ViewModels.Site;

namespace APKO.Controllers
{
    [HandleError, SiteMenues]
    public class HomeController : Controller
    {
        private readonly IDataRepository dataRepository;

        public HomeController(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public ActionResult Menu(string name)
        {
            return Content(dataRepository.GetMenu(name).Body);
        }

        public ActionResult Article(string categoryUrl, string articleUrl)
        {
            var model = new ArticleViewModel
                            {
                                Content = dataRepository.GetContent(categoryUrl, articleUrl)
                            };


            if (model.Content == null)
            {
                throw new HttpException(404, "Article not found");
            }

            return View(model);
        }

        public ActionResult Category(string categoryUrl)
        {
            var model = new CategoryViewModel();

            model.Category = dataRepository.GetCategoryByUrl(categoryUrl);

            if (model.Category == null)
            {
                throw new HttpException(404, "Article not found");
            }

            return View(model);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Feedback(string name,string mail, string phone, string message)
        {
            const string subject = "ARKO feedback";
            var body = string.Format("<div><b>Имя</b> {0}</div> <div><b>Телефон</b> {1}</div> <div><b>Сообщение</b>: {2}</div><div><b>Email</b>: {3}</div>", string.IsNullOrEmpty(name) ? "anonimus" : name, phone, string.IsNullOrEmpty(message) ? "-" : message, mail);
            var recipiens = new[] { ConfigurationManager.AppSettings["Mailbox"] };
            var sender = string.Format("{0} <{1}>", "www.arkotech.com.ua", "noreplay@arkotech.com.ua");

            //Thread.Sleep(10000); //just for test

            var errorMessage = new StringBuilder();

            //if (string.IsNullOrEmpty(message))
            //{
            //    errorMessage.Append("- Введите сообщение!");
            //}

            if (string.IsNullOrEmpty(phone))
            {
                errorMessage.Append("- Вы не ввели телефон!");
            }

            if (errorMessage.Length != 0)
            {
                return Json(new Dictionary<string, string> { { "Result", "Error" }, { "Message", errorMessage.ToString() } });
            }
            //if (string.IsNullOrEmpty(name))
            //{
            //    errorMessage.Append("- Введите имя!");
            //}


            try
            {
                Mail.Send(subject, body, sender, recipiens, null);
                return Json(new Dictionary<string, string> { { "Result", "Success" } });
            }
            catch
            {
                return Json(new Dictionary<string, string>{{"Result","Error"}});
            }

        }

    }

}