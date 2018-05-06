using Microsoft.AspNetCore.Mvc;
using SampleCoreArch.Business.Interfaces;
using System.Linq;

namespace SampleCoreArch.Web.Models.Shared
{
    public class EventLogViewComponent : ViewComponent
    {
        private readonly IEventLogService _eventLogService;
        public EventLogViewComponent(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService;
        }
        public IViewComponentResult Invoke(string viewName = "Default", int take = 999999999)
        {
            var result = _eventLogService.GetList().ResultObject.Take(take);
            return View(viewName, result.ToList());
        }
    }
}
