using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleCoreArch.Business.Interfaces;
using SampleCoreArch.Core.Common;
using SampleCoreArch.Core.Enums;
using SampleCoreArch.Core.Logging;
using SampleCoreArch.Entities.Concrete;
using SampleCoreArch.Web.Filters;

namespace SampleCoreArch.Web.Controllers
{
    [FormatReponseFilter]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public CategoryController(ICategoryService categoryService, ILogger logger, IUserService userService)
        {
            _categoryService = categoryService;
            _logger = logger;
            _userService = userService;
        }
        // GET: EventLog
        public ActionResult Index()
        {
            var result = _categoryService.GetList();
            var test = _userService.GetList();

            return View(result);
        }
        

        // GET: EventLog/Details/5
        public ActionResult Details(int id)
        {
            var result = _categoryService.Get(f => f.CategoryId == id);
            return View(result);
        }

        // GET: EventLog/Create
        public ActionResult Create()
        {
            var result = new Result<Category>() { ResultCode = (int)ResultStatusCode.Ok, ResultStatus = true, ResultObject = new Category() };
            return View(result);
        }

        // POST: EventLog/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            var result = _categoryService.Add(category);
            return View(result);
        }

        // GET: EventLog/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _categoryService.Get(f => f.CategoryId == id);
            return View(result);
        }

        // POST: EventLog/Edit/5
        [HttpPost]
        public ActionResult Edit(Result<Category> category)
        {
            var result = _categoryService.Update(category.ResultObject);
            return View(result);
        }


        // POST: EventLog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = _categoryService.Delete(new Category() { CategoryId = id });
            return View(result);
        }
    }
}