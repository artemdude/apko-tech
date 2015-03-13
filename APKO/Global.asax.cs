using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using APKO.Modules;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace APKO
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "Index", // Route name
                "", // URL with parameters
                new {controller = "Home", action = "Category", categoryUrl = "Index"} // Parameter defaults
                );


            routes.MapRoute(
                "Error", // Route name
                "Error/{action}/{id}", // URL with parameters
                new {controller = "Error", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );

            routes.MapRoute(
                "Home/Feedback", // Route name
                "Feedback", // URL with parameters
                new { controller = "Home", action = "Feedback" } // Parameter defaults
                );

            routes.MapRoute(
                "Account", // Route name
                "Account/{action}/{id}", // URL with parameters
                new {controller = "Account", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );

            routes.MapRoute(
                "Admin", // Route name
                "Admin/{action}/{id}/", // URL with parameters
                new {controller = "Admin", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );

            routes.MapRoute(
                "Category", // Route name
                "{categoryUrl}", // URL with parameters
                new {controller = "Home", action = "Category", categoryUrl = ""} // Parameter defaults
                );


            routes.MapRoute(
                "Article", // Route name
                "{categoryUrl}/{articleUrl}", // URL with parameters
                new {controller = @"Home", action = @"Article", categoryUrl = "", articleUrl = ""} // Parameter defaults
                );

            routes.MapRoute(
               "Menu", // Route name
               "Menu/{action}/{name}", // URL with parameters
               new { controller = "Home", action = "", name = "" } // Parameter defaults
               );
        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);

            //Routing debug
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var modules = new INinjectModule[]
                              {
                                  new ServiceModule()
                              };

            return new StandardKernel(modules);
        }


        //localization
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //*********** Установить культуру по умолчанию без переключателя **************************************************
            //CultureInfo ci = new CultureInfo("en");

            //System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            //System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);

            //*************************************************************


            //Очень важно проверять готовность объекта сессии
            if (HttpContext.Current.Session != null)
            {
                var ci = (CultureInfo) Session["Culture"];
                //Вначале проверяем, что в сессии нет значения
                //и устанавливаем значение по умолчанию
                //это происходит при первом запросе пользователя
                if (ci == null)
                {
                    //todo: to web.config
                    //Устанавливает значение по умолчанию - базовый английский
                    string langName = "en";
                    //Пытаемся получить значения с HTTP заголовка
                    if (HttpContext.Current.Request.UserLanguages != null &&
                        HttpContext.Current.Request.UserLanguages.Length != 0)
                    {
                        //Получаем список 
                        langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
                    }
                    ci = new CultureInfo(langName);
                    Session["Culture"] = ci;
                }
                //Устанавливаем культуру для каждого запроса
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
        }

        //Cache and localization
        public override string GetVaryByCustomString(HttpContext context, string value)
        {
            if (value.Equals("lang"))
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
            return base.GetVaryByCustomString(context, value);
        }
    }
}