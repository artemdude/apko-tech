using System;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using APKO.Models;
using APKO.Resources.Models.Account;

namespace APKO.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        private readonly IDataRepository dataRepository;
        public IMembershipService MembershipService { get; set;}
        public IFormsAuthenticationService FormsService { get; set; }

       // public AccountController() : this(new DataRepository()) { }

        public AccountController(IFormsAuthenticationService formsService, IMembershipService membershipService, IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;

            FormsService = formsService ?? new FormsAuthenticationService();
            MembershipService = membershipService ?? new AccountMembershipService();
        }


        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                        return RedirectToAction("Index", "Home");

                }
                    //будет показано через ValidationSummary
                    ModelState.AddModelError("", ValidationStrings.IncorrectPasswordOrLogin);

            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }


        //ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    //Succes
                    //ModelState.AddModelError("", "Success");
                    return View();
                }
                    //будет показано через ValidationSummary
                    ModelState.AddModelError("", ValidationStrings.IncorrectPasswords);

            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false);

                    CreateProfile(model.UserName);

                    return RedirectToAction("Index", "Home");
                }

                    //будет показано через ValidationSummary
                    ModelState.AddModelError("", CreateUserErrors.GetError(createStatus));

            }

            return View(model);
        }


        private void CreateProfile(string userName)
        {
            MembershipUser newUser;

            if(userName != null)
            {
                newUser = Membership.GetUser(userName);
            }
            else
            {
                throw new Exception("user name can't be null");
            }

            if (newUser != null)
            {
                Profile profile = new Profile();
                profile.Name = userName;
                profile.Guid = (Guid)newUser.ProviderUserKey;

                dataRepository.AddProfile(profile);

                dataRepository.Save();
            }
            else
            {
                throw new Exception(string.Format("no user exist with name {0}", userName));
            }
        }


        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}
