using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SampleCoreArch.Business.Interfaces;
using SampleCoreArch.Web.Models;
using SampleCoreArch.Core.Logging;
using SampleCoreArch.Web.Filters;
using SampleCoreArch.Web.Infrastructure;

namespace SampleCoreArch.Web.Controllers
{
    [TypeFilter(typeof(LoggingFilter))]
    public class HomeController : BaseController
    {
        private ICategoryService _categoryService;
        private IEventLogService _eventLogService;
        private readonly ILogger _logger;


        public HomeController(ICategoryService categoryService, ILogger logger, IEventLogService eventLogService)
        {
            _categoryService = categoryService;
            _logger = logger;
            _eventLogService = eventLogService;
        }

        public IActionResult Register()
        {
            var user = ApplicationUser
            SignInManager<>
            return null;
        }

        public IActionResult Index()
        {
            var result = _categoryService.GetList();
            //_logger.LogError(JsonConvert.SerializeObject(new EventLog()
            //{
            //    CreatedTime = DateTime.Now,
            //    EventId = 1,
            //    HostName = "test",
            //    IpAdress = "1",
            //    LogLevel = "Info",
            //    Message = "mesaj"
            //}));

            //var loglist = _eventLogService.GetList().ResultObject.Select(l=> new EventLog()
            //{
            //    CreatedTime = l.CreatedTime,
            //    EventId = l.EventId,
            //    HostName = l.HostName,
            //    IpAdress = l.IpAdress,
            //    LogLevel = l.LogLevel,
            //    Message = l.Message
            //});
            //_eventLogService.AddRange(loglist);
            //_eventLogService.DeleteAll();
            return View();
        }

        [FormatReponseFilter]
        public IActionResult EventLogList()
        {
            var result = _eventLogService.GetList();
            return PartialView("EventLogList", result.ResultObject.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
