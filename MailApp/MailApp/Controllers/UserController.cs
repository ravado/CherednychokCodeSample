using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailApp.ViewModels;
using System.Web.Security;
using MailApp.ViewModels.User;

namespace MailApp.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            UserLoginViewModel viewModel = new UserLoginViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel viewModel)
        {
            if (TryUpdateModel(viewModel)) {
                bool result = Membership.ValidateUser(viewModel.Username, viewModel.Password);
                if (result) FormsAuthentication.SetAuthCookie(viewModel.Username, false);

                return RedirectToAction("SelectCustomers","Mail");
            }
            
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Logout() {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            UserRegisterViewModel viewModel = new UserRegisterViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel viewModel)
        {
            try
            {
                if (TryUpdateModel(viewModel))
                {
                    MembershipUser user = Membership.CreateUser(viewModel.Username, viewModel.Password, viewModel.Email);
                    bool result = Membership.ValidateUser(viewModel.Username, viewModel.Password);
                    if (result) FormsAuthentication.SetAuthCookie(viewModel.Username, false);
                    return View("SuccessRegister", new UserSuccessRegisterViewModel());
                }

                return View(viewModel);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult CheckUsername(string username)
        {
            var result = Membership.FindUsersByName(username).Count == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}
