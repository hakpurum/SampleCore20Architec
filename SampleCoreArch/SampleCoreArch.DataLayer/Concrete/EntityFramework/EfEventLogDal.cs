using SampleCoreArch.Core.DataAccess;
using SampleCoreArch.Core.Logging;
using SampleCoreArch.DataLayer.Interfaces;

namespace SampleCoreArch.DataLayer.Concrete.EntityFramework
{
    public class EfEventLogDal : EfRepository<EventLog>, IEventLogDal
    {
        public EfEventLogDal(SampleDbContext context) : base(context)
        {
        }
    }
}