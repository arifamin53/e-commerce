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
            services.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IAppFileRepository,AppFileRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ICartRepository,CartRepository>();
            services.AddScoped<ICartItemRepository,CartItemRepository>();
            return services;
        }
    }
}
