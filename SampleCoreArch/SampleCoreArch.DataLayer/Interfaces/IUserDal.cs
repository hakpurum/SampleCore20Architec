using System;
using System.Collections.Generic;
using System.Text;
using SampleCoreArch.Core.Interfaces;
using SampleCoreArch.Entities.Concrete;

namespace SampleCoreArch.DataLayer.Interfaces
{
    public interface IUserDal : IEntityRepository<User>
    {

    }
}
