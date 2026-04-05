using Carter;
using E_Commerce.Application;
using E_Commerce.Infrastructure;
using E_Commerce.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_Commerce.Api
{
    public static  class AssemblyReference
    {
        public static IServiceCollection AddAPiServices(this IServiceCollection services,IConfiguration configuration,IWebHostEnvironment enveronment)
        {
            services.AddPersistenceService(configuration);
            services.AddApplicationServices();
            services.AddHttpContextAccessor();
            services.AddInfrastructureServices(configuration,enveronment.WebRootPath);
            services.AddCarter();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", options =>
                {
                    options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents()
              {
                    OnChallenge=context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync("{\"error\":\"you are not authorized to access this resource. please login again.\"}");
                    }
                };
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = configuration["JWT:Audience"],
                    ValidateAudience = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateIssuer = true,
                    RequireExpirationTime=true,
                   ValidateIssuerSigningKey= true,
                   IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!))
                };


            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = 88888888;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = 88888888;
            });

            services.AddAuthorization();
            return services;
        }
    }
}
