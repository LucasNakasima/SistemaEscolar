using SitemaUnicesumar.Services;
using System;
using System.Web.Mvc;

namespace SitemaUnicesumar.Controllers
{
    public class RegistryClassController : BaseController
    {
        #region Properties
        private readonly RegistryClassService _registryClassService = null;

        public RegistryClassController()
        {
            _registryClassService = new RegistryClassService();
        }
        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (!IsAuthenticated)
                    return RedirectToAction("Login", "Account");
               
                LoadViewBags("RegistryClass");

                var viewModel = _registryClassService.GetListRegistersClass(UserId);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetRegistryClass(int registryId)
        {
            try
            {
                if (!IsAuthenticated)
                    return RedirectToAction("Login", "Account");

                LoadViewBags("RegistryClass");

                var viewModel = _registryClassService.GetRegistryClass(registryId);

                return View("~/Views/RegisterPresence/PresenceList.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}