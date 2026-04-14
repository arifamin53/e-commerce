using E_commerce.Domain.Entities;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.RRModels.Product;
using E_Commerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace E_Commerce.Persistence.Repositories
{
    public class ProductRepository(E_CommerceDbContext context) : BaseRepository<Product>(context), IProductRepository
    {
        

        public async Task<IEnumerable<ProductResponse>> GetProducts()
        {
            var response = await context.Products.Select(p => new ProductResponse() 
            {
                 Id=p.Id,
                 Description=p.Description,
                 Price=p.Price,
                 Name=p.Name,
                 StockQuantity=p.StockQuantity,
                 Category=p.Category.Name,
                 CreatedOn=p.CreatedOn,
                 IsDeleted=p.IsDeleted,
                 UpdatedAt= p.UpdatedAt,
                 Files= context.AppFiles
                 .Where(f => f.EntityId == p.Id)
                 .Select(f => f.FilePath)
                 .FirstOrDefault()
            }).ToListAsync();

            return response;
        }

        public async Task<IEnumerable<ProductResponse>> ProductsByCategoryId(Guid id)
        {
            return await ExecuteStoredProcedureAsync<ProductResponse>("sp_ProductsByCategoryId", new {id} );
        }

        public async Task<ProductResponse> ProductsById(Guid id)
        {
            return await FirstOrDefaultAsync<ProductResponse>("sp_ProductBYId", new { id }, CommandType.StoredProcedure);
        }

        public IQueryable<Product> Query()
        {
          return context.Products;  
        }
    }
}
