using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoDemo.Infra.IoC;

namespace ProjetoDemo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Opcao para Referência Ciclica
            //services.AddControllers()
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            //});

            //Usando Pacote NewtonSoft
            //services.AddControllers()
            //    .AddNewtonsoftJson(x => 
            //    x.JsonSerializerOptions.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //ativar autenticacao e validar o token
            services.AddInfrastructureJWT(Configuration);
            services.AddInfrastructureAPI(Configuration);
            services.AddControllers();
            //configurar api para o swagger aceitar o usuario via interface
            services.AddInfrastuctureSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoDemo.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
