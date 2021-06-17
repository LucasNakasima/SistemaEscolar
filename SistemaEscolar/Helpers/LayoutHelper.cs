using System.IO;
using System.Text;
using System.Web.Mvc;

namespace SitemaUnicesumar.Helpers
{
    public class LayoutHelper : Controller
    {
        public static string ActivePageMenu(string pageKey, string menu) 
        {
            return pageKey == menu ? "active-menu" : "";
        }

        public static string ActivePageMenuText(string pageKey, string menu)
        {
            return pageKey == menu ? "text-white" : "";
        }

        public static StringBuilder GetPartialViewData(string partial, ControllerContext controllerContext, ViewDataDictionary viewData, TempDataDictionary tempData, object model = null)
        {
            ViewEngineResult ViewEngineResult = ViewEngines.Engines.FindPartialView(controllerContext, partial);

            if (model != null)
                controllerContext.Controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(controllerContext, ViewEngineResult.View, viewData, tempData, sw);
                ViewEngineResult.View.Render(ctx, sw);
                return sw.GetStringBuilder();
            }
        }
    }
}