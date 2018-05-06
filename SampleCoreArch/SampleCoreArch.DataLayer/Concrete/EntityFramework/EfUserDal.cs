using SampleCoreArch.Core.DataAccess;
using SampleCoreArch.DataLayer.Interfaces;
using SampleCoreArch.Entities.Concrete;

namespace SampleCoreArch.DataLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfRepository<User>, IUserDal
    {
        public EfUserDal(SampleDbContext context) : base(context)
        {
        }
    }
}