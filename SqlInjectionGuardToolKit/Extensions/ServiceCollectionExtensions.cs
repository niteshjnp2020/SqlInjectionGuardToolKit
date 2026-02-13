using Microsoft.Extensions.DependencyInjection;
using SqlInjectionGuardToolKit.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlInjectionGuard(
            this IServiceCollection services)
        {
            services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(options =>
            {
                options.Filters.Add<SqlInjectionSanitizeFilter>();
            });

            return services;
        }
    }
}
