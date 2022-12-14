using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Application.Interfaces;
using Tesla.Application.Mappings;
using Tesla.Application.Services;
using Tesla.Domain.Interfaces;
using Tesla.Repo.Context;
using Tesla.Repo.Repositories;

namespace Tesla.Infra.Ioc
{
    public static class DependencyInjectionMVC
    {
        public static IServiceCollection AddInfrastructureMVC(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("Tesla.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
