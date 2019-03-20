using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Proyecto.Api.GraphQL.InputTypes;
using Proyecto.Api.GraphQL.Mutations;
using Proyecto.Api.GraphQL.Queries;
using Proyecto.Api.GraphQL.Schemas;
using Proyecto.Api.GraphQL.Types;
using Proyecto.Core;
using Proyecto.Persistence;

namespace Proyecto.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ProyectoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Singleton);

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            // services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            // preparar la inyección de dependencias
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<ProyectoQuery>();
            services.AddSingleton<ProyectoMutation>();
            services.AddSingleton<TareaType>();
            services.AddSingleton<ModuloType>();
            services.AddSingleton<ModuloInputType>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            // services.AddSingleton<ISchema>(s => new ProyectoSchema(new FuncDependencyResolver(type => (IGraphType)s.GetService(type))));
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ProyectoSchema(new FuncDependencyResolver(type => sp.GetService(type))));
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // agregar acceso CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .Build());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<IConfiguration>(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseGraphiQl();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
