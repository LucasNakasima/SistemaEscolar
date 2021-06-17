using SitemaUnicesumar.Models;
using SitemaUnicesumar.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SitemaUnicesumar.Controllers
{
    public class RegisterPresenceController : BaseController
    {
        #region Properties
        private readonly RegisterPresenceService _registerPresenceService = null;

        public RegisterPresenceController()
        {
            _registerPresenceService = new RegisterPresenceService();
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

                LoadViewBags("RegisterPresence");

                var viewModel = _registerPresenceService.GetListClass();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult PresenceList(int classId)
        {
            try
            {
                if (!IsAuthenticated)
                    return RedirectToAction("Login", "Account");

                LoadViewBags("RegisterPresence");

                var viewModel = _registerPresenceService.LoadPresenceList(UserId ,classId);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveRegisterPresence(RegisterPresenceViewModel viewModel)
        {
            try
            {
                await _registerPresenceService.SaveRegisterPresenceAsync(viewModel, UserId);

                return RedirectToAction("Index", "RegistryClass");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}