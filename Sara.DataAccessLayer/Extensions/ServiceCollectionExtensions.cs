using System;
using ClassLibrary1.EF;
using ClassLibrary1.Entities;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Object = ClassLibrary1.Entities.Object;

namespace ClassLibrary1.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgresSyncContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainInfoContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultDbConnection"),
                    builder => builder.SetPostgresVersion(new Version("12.0")));
            });

            services.AddScoped<IRepository<Object>, InfoRepository>();
            
//            services.AddScoped<ICompanyQueries, CompanyQueries>();

            return services;
        }
    }
}