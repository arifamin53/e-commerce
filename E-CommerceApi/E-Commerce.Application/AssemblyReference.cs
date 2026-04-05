using AutoMapper;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_Commerce.Application
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddAutoMapper(cfg => { /* optional global config */ }, typeof(Mapper.UserProfile));
            return services;
        }
    }
}
