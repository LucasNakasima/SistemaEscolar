using System;
using System.Web.Mvc;

namespace SitemaUnicesumar.Controllers
{
    public class HomeController : BaseController
    {
        #region Actions

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                LoadViewBags("Home");

                if (!IsAuthenticated)
                    return RedirectToAction("Login", "Account");

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}