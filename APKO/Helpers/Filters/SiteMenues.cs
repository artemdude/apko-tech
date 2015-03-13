using System.Web.Mvc;
using APKO.Models;

namespace APKO.Helpers.Filters
{
    public class SiteMenues : ActionFilterAttribute
    {
        private readonly IDataRepository dataRepository;

         // Dependency Injection enabled constructors
        public SiteMenues() : this(new DataRepository())
        {
        }

        public SiteMenues(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }


        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;

            if(viewResult != null)
            {
                var leftMenu = dataRepository.GetMenu("News");
                var mainMenuService = dataRepository.GetMenu("Service");
                var mainMenuLaw = dataRepository.GetMenu("Law");
                var mainMenuCase = dataRepository.GetMenu("Case");
                //var mainMenuContacts = dataRepository.GetMenu("Contacts");

                viewResult.ViewData["News"] = leftMenu == null ? "Need to exist menu 'News'" : leftMenu.Body;
                viewResult.ViewData["Service"] = mainMenuService == null ? "Need to exist menu 'Service'" : mainMenuService.Body;
                //viewResult.ViewData["Law"] = mainMenuLaw == null ? "Need to exist menu 'Law'" : mainMenuLaw.Body;
                viewResult.ViewData["Case"] = mainMenuCase == null ? "Need to exist menu 'Case'" : mainMenuCase.Body;
                //viewResult.ViewData["Contacts"] = mainMenuContacts == null ? "Need to exist menu 'Contacts'" : mainMenuContacts.Body;
            }
        }

        private void AddMenuBodyToViewData(Menu menu)
        {
            
        }

    }
}