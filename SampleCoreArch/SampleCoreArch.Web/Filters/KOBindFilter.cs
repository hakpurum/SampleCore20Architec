using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SampleCoreArch.Web.Filters
{
    public class KoBindFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            ((Controller)(filterContext.Controller)).ViewBag.KOBind = $"<script src=\'/js/Views/{controller}/{actionName}.js\'></script>";

        }
        
    }
}
