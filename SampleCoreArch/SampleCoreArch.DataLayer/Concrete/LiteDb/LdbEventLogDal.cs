using LiteDB;
using SampleCoreArch.Core.DataAccess;
using SampleCoreArch.Core.Logging;
using SampleCoreArch.DataLayer.Interfaces;

namespace SampleCoreArch.DataLayer.Concrete.LiteDb
{
    public class LdbEventLogDal : LiteDbRepository<EventLog>, IEventLogDal
    {
        public LdbEventLogDal(LiteRepository liteRepository) : base(liteRepository)
        {

        }
    }
}