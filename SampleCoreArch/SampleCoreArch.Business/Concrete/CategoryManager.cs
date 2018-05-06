using Microsoft.Extensions.Logging;
using SampleCoreArch.Business.Interfaces;
using SampleCoreArch.Core.Interfaces;
using SampleCoreArch.Core.Service;
using SampleCoreArch.DataLayer.Interfaces;
using SampleCoreArch.Entities.Concrete;

namespace SampleCoreArch.Business.Concrete
{
    public class CategoryManager : EntityService<Category>, ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IUnitOfWork _unitOfWork;
        readonly ILogger _logger;

        public CategoryManager(ICategoryDal categoryDal, ILogger logger, IEventLogDal eventLog, IUnitOfWork unitOfWork)
            : base(categoryDal, unitOfWork, logger)
        {
            _categoryDal = categoryDal;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
    }
}