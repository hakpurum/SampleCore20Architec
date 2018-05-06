using SampleCoreArch.Core.DataAccess;
using SampleCoreArch.DataLayer.Interfaces;
using SampleCoreArch.Entities.Concrete;

namespace SampleCoreArch.DataLayer.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SampleDbContext context) : base(context)
        {
        }
    }
}