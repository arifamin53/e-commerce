using E_commerce.Domain.Entities;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.Abstraction.IUnitOfWord;
using E_Commerce.Persistence.Data;
using E_Commerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Persistence
{
    public static class AssemblyRefrence
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<E_CommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(E_CommerceDbContext))));
            services.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IAuthRepository,AuthRepository>()
            .AddScoped<ICategoryRepository,CategoryRepository>()
            .AddScoped<IAppFileRepository,AppFileRepository>()
            .AddScoped<IProductRepository,ProductRepository>()
            .AddScoped<ICartRepository,CartRepository>()
            .AddScoped<ICartItemRepository,CartItemRepository>()
            .AddScoped<IOrderRepository,OrderRepository>()
            .AddScoped<IOrderItemRepository,OrderItemRepository>();
            return services;
        }
    }
}
