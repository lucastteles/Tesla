﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Repo.Context;

namespace Tesla.Infra.Ioc
{
    namespace Tesla.Infra.Ioc
    {
        public static class DependencyInjection
        {
            public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                IConfiguration configuration)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
                ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

                return services;
            }
        }
    }
}
