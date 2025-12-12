using AITech.Business.Services.BannerServices;
using AITech.Business.Services.CategoryServices;
using AITech.Business.Services.ProjectServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
          services.AddScoped<ICategoryService, CategoryService>();
          services.AddScoped<IProjectService, ProjectService>();
          services.AddScoped<IBannerService, BannerService>();
        }
    }
}
