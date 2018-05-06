using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters.Xml.Extensions;
using Newtonsoft.Json;
using System;

namespace SampleCoreArch.Admin.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class FormatReponseFilterAttribute : Attribute, IActionFilter
    {
        private enum FormatResponseType { Json, Xml, Unknown }
        private FormatResponseType RequestedType { get; set; }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            switch (RequestedType)
            {
                case FormatResponseType.Json:
                    filterContext.Result = new JsonResult(ModelFromActionResult(filterContext.Result),new JsonSerializerSettings(){Formatting = Formatting.Indented, MissingMemberHandling = MissingMemberHandling.Ignore });
                    break;
                case FormatResponseType.Xml:
                    filterContext.Result = new XmlResult(ModelFromActionResult(filterContext.Result));
                    break;
                case FormatResponseType.Unknown:
                    filterContext.Result = filterContext.Result;
                    break;
                default:
                    filterContext.Result = filterContext.Result;
                    break;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var format = filterContext.HttpContext.Request.Query["format"];

            switch (format)
            {
                case "json":
                    RequestedType = FormatResponseType.Json;
                    break;
                case "xml":
                    RequestedType = FormatResponseType.Xml;
                    break;
                default:
                    RequestedType = FormatResponseType.Unknown;
                    break;
            }
        }

        public object ModelFromActionResult(IActionResult actionResult)
        {
            object model;
            if (actionResult.GetType() == typeof(ViewResult))
            {
                var viewResult = (ViewResult)actionResult;
                model = viewResult.Model;
            }
            else if (actionResult.GetType() == typeof(PartialViewResult))
            {
                var partialViewResult = (PartialViewResult)actionResult;
                model = partialViewResult.Model;
            }
            else
            {
                throw new InvalidOperationException(string.Format("Actionresult of type {0} is not supported by ModelFromResult extractor.", actionResult.GetType()));
            }

            return model;
        }
    }
}
