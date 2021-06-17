using System;
using System.Web.Mvc;

namespace SitemaUnicesumar.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsAuthenticated
        {
            get
            {
                return Session["userId"] != null;
            }
        }

        protected int UserId
        {
            get
            {
                return Convert.ToInt32(Session["userId"]);
            }
        }

        protected void LoadViewBags(string pageKey) 
        {
            ViewBag.SideMenu = true;
            ViewBag.LogoutMenu = true;
            ViewBag.PageKey = pageKey;
        }
    }
}