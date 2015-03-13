using APKO.Models;
using Ninject.Modules;

namespace APKO.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataRepository>().To<DataRepository>();
            Bind<IFormsAuthenticationService>().To<FormsAuthenticationService>();
            Bind<IMembershipService>().To<AccountMembershipService>(); 
        }
    }
}