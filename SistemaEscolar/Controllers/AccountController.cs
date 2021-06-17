using SitemaUnicesumar.Models;
using System.Web.Mvc;
using SitemaUnicesumar.Services;
using System;

namespace SitemaUnicesumar.Controllers
{
    public class AccountController : BaseController
    {
        #region Properties
        private readonly AccountService _accountService = null;

        public AccountController()
        {
            _accountService = new AccountService();
        }
        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Login()
        {
            try
            {
                if (IsAuthenticated)
                    return RedirectToAction("Index", "Home");

                return View(new LoginViewModel());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            try
            {
                var userData = _accountService.AuthUser(viewModel);

                if (userData == null)
                {
                    viewModel.ErrorMenssage = "Nome de usuário ou senha inválidos";
                    return View(viewModel);
                }

                Session["userId"] = userData.Id.ToString();
                Session["userEmail"] = userData.Email;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                Session["userId"] = null;
                Session["userEmail"] = null;

                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}