using System;
using System.Web.Mvc;
using System.Web.Security;
using Social_Network.Core.Entities;
using Social_Network.Core.Interfaces.IRepositories;
using Social_Network.Web.Models.Account;

namespace Social_Network.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public AccountController(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        [HttpGet]
        public ActionResult LogOn(string returnUrl)
        {
            LogOnModel model = new LogOnModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Login, true);

                if (String.IsNullOrWhiteSpace(model.ReturnUrl))
                {
                    model.ReturnUrl = FormsAuthentication.DefaultUrl;
                }

                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogOn");
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegisterModel model = new RegisterModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User(model.Login, model.Password);

                this._usersRepository.Add(user);
                this._usersRepository.SaveChanges();

                if (String.IsNullOrWhiteSpace(model.ReturnUrl))
                {
                    return RedirectToAction("RegisterSuccess");
                }

                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }
    }
}
