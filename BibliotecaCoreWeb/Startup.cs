using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaCore.Dal.Context;
using BibliotecaCore.Domain.Repository;
using BibliotecaCore.Service.Implementation;
using BibliotecaCore.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using log4net;
using BibliotecaCore.WebApi.Security;
using BibliotecaCore.Utilities.SettingsManager.Contract;
using BibliotecaCore.Utilities.SettingsManager;
using Swashbuckle.AspNetCore.Swagger;

namespace BibliotecaCoreWeb
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
            services.AddDbContext<DbLibraryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IConfigurationSettings, ConfigurationSettings>();


            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new  Info{ Title = "Api Biblioteca" });
                string filePathXmlDocumentation = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "BibliotecaCore.WebApi.xml");
                config.IncludeXmlComments(filePathXmlDocumentation);

                //Autenticacion de Swagger usando JWT apiKey
                config.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT Token usar Bearer {token}",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey" //se permite un string
                });

                config.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
            }

            );

            services.AddCors();
            ConfigurationJWT.AddService(services, Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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

            loggerFactory.AddLog4Net();

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(config =>
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "API Biblioteca")
            );

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
