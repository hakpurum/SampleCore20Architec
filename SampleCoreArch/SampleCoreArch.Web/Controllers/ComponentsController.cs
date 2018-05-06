using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleCoreArch.Web.Controllers
{
    public class ComponentsController : Controller
    {
        public IActionResult EventLog()
        {
            // works: this component's view is in Views/Shared
            return ViewComponent("EventLog");
        }
    }
}