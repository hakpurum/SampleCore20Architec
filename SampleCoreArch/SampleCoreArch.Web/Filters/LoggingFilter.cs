using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SampleCoreArch.Core.Logging;

namespace SampleCoreArch.Web.Filters
{
    public class LoggingFilter : Attribute, IActionFilter, IExceptionFilter
    {
        private readonly ILogger _logger;

        public LoggingFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var message = string.Format("Controller {0} generated an error.", controllerName);
            _logger.LogError(context.Exception, message);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            _logger.LogInformation(new EventId(1, "OnActionExecuted"), JsonConvert.SerializeObject(new
            {
                CreatedTime = DateTime.Now,
                EventId = 1,
                HostName = "test",
                IpAdress = "1",
                LogLevel = "OnActionExecuted",
                Message = string.Format("controllerName : {0}-actionName : {1}", controllerName, actionName)
            }));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            _logger.LogInformation(new EventId(1, "OnActionExecuted"), JsonConvert.SerializeObject(new
            {
                CreatedTime = DateTime.Now,
                EventId = 1,
                HostName = "test",
                IpAdress = "1",
                LogLevel = "OnActionExecuting",
                Message = string.Format("controllerName : {0}-actionName : {1}", controllerName, actionName)
            }));
        }
    }
}
