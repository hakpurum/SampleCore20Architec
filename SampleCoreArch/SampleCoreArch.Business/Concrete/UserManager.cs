using Microsoft.Extensions.Logging;
using SampleCoreArch.Business.Interfaces;
using SampleCoreArch.Core.Interfaces;
using SampleCoreArch.Core.Service;
using SampleCoreArch.DataLayer.Interfaces;
using SampleCoreArch.Entities.Concrete;

namespace SampleCoreArch.Business.Concrete
{
    public class UserManager : EntityService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserDal _UserDal;
        readonly ILogger _logger;

        public UserManager(IUserDal UserDal, ILogger logger, IEventLogDal eventLog, IUnitOfWork unitOfWork) : base(
            UserDal, unitOfWork, logger)
        {
            _UserDal = UserDal;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
    }
}