using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoDemo.Application.Mappings;
using ProjetoDemo.Application.Services;
using ProjetoDemo.Domain.Interfaces;
using ProjetoDemo.Infra.Data.Context;
using ProjetoDemo.Infra.Data.Identity;
using ProjetoDemo.Infra.Data.Repositories;
using System;

namespace ProjetoDemo.Infra.IoC
{
    public static class DependencyInjectionAPI
    {

        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options
                .UseSqlServer(
                    configuration
                    .GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddAutoMapper(typeof(DTOToCommandMappingProfile));
            var myHandlers = AppDomain.CurrentDomain.Load("ProjetoDemo.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));
            return services;
        }
    }
}
