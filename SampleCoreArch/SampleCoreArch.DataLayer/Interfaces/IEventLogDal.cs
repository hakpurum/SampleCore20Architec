using System;
using System.Collections.Generic;
using System.Text;
using SampleCoreArch.Core.Interfaces;
using SampleCoreArch.Core.Logging;

namespace SampleCoreArch.DataLayer.Interfaces
{
    public interface IEventLogDal : IEntityRepository<EventLog>
    {
    }
}
