using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductAPI.Business;
using ProductAPI.Business.User;
using ProductAPI.DataLayer;
using ProductAPI.DataLayer.User;
using ProductAPI.Models.Security;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI
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
            JwtSettings settings = GetJwtSettings();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());

                options.AddPolicy("DomainSpecific",
                    builder => builder.WithOrigins(Configuration["CorsOrigins"].Split(","))
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters =
                          new TokenValidationParameters
                          {
                              ValidateIssuerSigningKey = true,
                              IssuerSigningKey = new SymmetricSecurityKey(
                              Encoding.UTF8.GetBytes(settings.Key)),
                              ValidateIssuer = true,
                              ValidIssuer = settings.Issuer,

                              ValidateAudience = true,
                              ValidAudience = settings.Audience,
                              ValidateLifetime = true,
                              ClockSkew = TimeSpan.FromMinutes(
                                     settings.MinutesToExpiration)
                          };
            });

            services.AddAuthorization();

            services.AddScoped<IProductBusiness, ProductBusiness>();
            //services.AddSingleton(IAuditLog, AuditLog());
            services.AddScoped<IProductRepository>(p =>
                new ProductRepository(Configuration["DbConnectionString"]));

            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddSingleton<IUserRepository>(p =>
                new UserRepository(Configuration["DbConnectionString"]));
            services.AddSingleton<ISecurityManager>(p => new SecurityManager(settings));


            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("productApiV1", new OpenApiInfo()
                {
                    Title = "ProductApi",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseExceptionHandler(
                options => {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Response.ContentType = "text/html";
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex != null)
                            {
                                var err = ex.Error.Message;
                                await context.Response.WriteAsync(err).ConfigureAwait(false);
                            }
                        });
                }
            );

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/productApiV1/swagger.json", "Product API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private JwtSettings GetJwtSettings()
        {
            JwtSettings settings = new JwtSettings
            {
                Key = Configuration["JwtSettings:key"],
                Audience = Configuration["JwtSettings:audience"],
                Issuer = Configuration["JwtSettings:issuer"],
                MinutesToExpiration = Convert.ToInt32(Configuration["JwtSettings:minutesToExpiration"])
            };

            return settings;
        }
    }
}
