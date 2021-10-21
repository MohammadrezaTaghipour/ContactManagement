using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Peekage.ContactManagement.Service.Application.Contacts;
using Peekage.ContactManagement.Service.Framework;

namespace Peekage.ContactManagement.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
               .SetCompatibilityVersion(CompatibilityVersion.Latest)
               .AddMvcOptions(x =>
               {
                   x.EnableEndpointRouting = false;
               });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Contact management Api",
                    Version = "v1"
                });
            });
            services.AddRepositories();
            services.AddCommandBus();
            services.AddQueryServices();
            services.AddCommandHandlers(typeof(ContactCommandHandler).Assembly);
            services.AddMongoDB(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Mng API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
