using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Profile.Logic;
using Profile.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LogicServiceExtensions
    {

        public static IServiceCollection AddLogic(this IServiceCollection services, IConfiguration configuration) 
            => services.AddDbContext<AppDbContext>(config 
                => config.UseSqlServer(configuration.GetConnectionString("sqlDb"),
                                    x => x.MigrationsAssembly("Profile.AdminWebsite")))
                        .AddScoped<IProjectsRepository, ProjectsRepository>()
                        .AddScoped<ISkillsRepository, SkillsRepository>()
                        .AddScoped<IProfileLinkRepository, ProfileLinkRepository>();
    }
}
