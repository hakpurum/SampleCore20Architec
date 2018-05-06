using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCoreArch.Business.Interfaces;
using SampleCoreArch.Core.Common;
using SampleCoreArch.Core.Enums;
using SampleCoreArch.Core.Logging;
using SampleCoreArch.Web.Filters;

namespace SampleCoreArch.Web.Controllers
{
    [FormatReponseFilter]
    public class EventLogController : Controller
    {
        private readonly IEventLogService _eventLogService;

        public EventLogController(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService;
        }
        // GET: EventLog
        public ActionResult Index()
        {
            var result = _eventLogService.GetList();
            return View(result);
        }

        // GET: EventLog/Details/5
        public ActionResult Details(int id)
        {
            var result = _eventLogService.Get(f => f.Id == id);
            return View(result);
        }

        // GET: EventLog/Create
        public ActionResult Create()
        {
            var result = new Result<EventLog>() { ResultCode = (int)ResultStatusCode.Ok, ResultStatus = true, ResultObject = new EventLog() { CreatedTime = DateTime.Now } };
            return View(result);
        }

        // POST: EventLog/Create
        [HttpPost]
        public ActionResult Create(EventLog eventLog)
        {
            var result = _eventLogService.Add(eventLog);
            return View(result);
        }

        // GET: EventLog/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _eventLogService.Get(f => f.Id == id);
            return View(result);
        }

        // POST: EventLog/Edit/5
        [HttpPost]
        public ActionResult Edit(Result<EventLog> eventLog)
        {
            var result = _eventLogService.Update(eventLog.ResultObject);
            return View(result);
        }


        // POST: EventLog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = _eventLogService.Delete(new EventLog() { Id = id });
            return View(result);
        }
    }
}