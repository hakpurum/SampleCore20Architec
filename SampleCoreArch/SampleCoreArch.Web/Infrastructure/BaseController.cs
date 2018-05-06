using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters.Xml.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SampleCoreArch.Web.Infrastructure
{
    public class BaseController : Controller
    {
        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    base.OnActionExecuted(context);
        //}

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //}

        //public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    return base.OnActionExecutionAsync(context, next);
        //}
    }
}
