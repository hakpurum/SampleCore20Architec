using LiteDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleCoreArch.Business.Concrete;
using SampleCoreArch.Business.Interfaces;
using SampleCoreArch.Core.Interfaces;
using SampleCoreArch.Core.Utility;
using SampleCoreArch.DataLayer.Concrete.EntityFramework;
using SampleCoreArch.DataLayer.Concrete.LiteDb;
using SampleCoreArch.DataLayer.Interfaces;

namespace SampleCoreArch.Business
{
    public static class BusinessServiceModule
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IEventLogService, EventLogManager>();
            services.AddScoped<ILogger, EventLogManager>();

            return services;
        }
    }

    public static class DataLayerServiceModule
    {
        public static IServiceCollection AddDataLayerServices(this IServiceCollection services)
        {
            services.AddScoped(liteRepository => new LiteRepository(new ConnectionString(SampleUtility.LiteDbConnStr)));
            services.AddDbContext<SampleDbContext>(options => options.UseSqlServer(SampleUtility.SqlDbConnStr));

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IUserDal, EfUserDal>();
            //services.AddScoped<IEventLogDal, LdbEventLogDal>();
            services.AddScoped<IEventLogDal, EfEventLogDal>();

            return services;
        }
    }
}