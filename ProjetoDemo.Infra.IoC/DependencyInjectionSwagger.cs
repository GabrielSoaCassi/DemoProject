using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Infra.IoC
{
    public static class DependencyInjectionSwagger
    {

        public static IServiceCollection AddInfrastuctureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoDemo.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    // definr configuracoes
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                { {
                    new OpenApiSecurityScheme
                    {
                         Reference = new OpenApiReference()
                         {
                             Type = ReferenceType.SecurityScheme,
                             Id="Bearer"
                         }
                    },
                    new string [] { }
                    }
                });
            });

            return services;
        }

    }
}
