using E_Commerce.Application.Abstraction.IJWTProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using E_Commerce.Application.Abstraction.Appencription;
using E_Commerce.Application.Abstraction.Identity;
using E_Commerce.Infrastructure.Identity;
using E_Commerce.Application.Abstraction.IStorageService;
using E_Commerce.Infrastructure.StorageService;
namespace E_Commerce.Infrastructure;

public static class AssemblyReference
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration,string webRootPath)
    {
        services.AddScoped<IJWTProvider,JwtProvider.JWTProvider>();
        services.AddScoped<IAppencription,Appencription.Appencription>();
        services.AddScoped<IHttpContextService,HttpcontextService>();
        services.AddSingleton<IStorageService>(new StorageService.StroageService(webRootPath));
        return services;
    }
}
