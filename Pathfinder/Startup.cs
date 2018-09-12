using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Pathfinder.Data.Context;
using Pathfinder.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Pathfinder
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddResponseCompression();
            services.AddScoped<DataContext, DataContext>();
            services.AddScoped<CategoryRepository, CategoryRepository>();
            services.AddScoped<ProductRepository, ProductRepository>();
            //Registrar o Swagger.
            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Info { Title = "API ASP.NET CORE", Version = "v1"}));
                
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET CORE"); });

        }
    }
}
