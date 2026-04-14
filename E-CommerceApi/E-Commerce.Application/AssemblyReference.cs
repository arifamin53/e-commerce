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
            services.AddScoped<IAuthService, AuthService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<ICartService, CartService>()
            .AddAutoMapper(cfg => { /* optional global config */ }, typeof(Mapper.UserProfile))
            .AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
