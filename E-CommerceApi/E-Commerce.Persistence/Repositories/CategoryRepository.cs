using E_commerce.Domain.Entities;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.RRModels.Categry;
using E_Commerce.Application.RRModels.Product;
using E_Commerce.Persistence.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace E_Commerce.Persistence.Repositories
{
    public class CategoryRepository(E_CommerceDbContext context) : BaseRepository<Category>(context), ICategoryRepository
    {
        public async Task<IEnumerable<CategoryResponse>> GetCategories()
        {
            var sql = $@" select c.id,c.name,c.description,c.updatedAt,c.isDeleted,c.createdon,f.filePath
                          From Categories c
                          inner join AppFiles f
                          on f.entityId=c.id
                           ";
            return await ExecuteStoredProcedureAsync<CategoryResponse>(sql);
        }

        public async Task<CategoryCompactResponse> GetCategory(int pageNo, int Pagesize, string name)
        {
            var raw= await FirstOrDefaultAsync<CategoryJsonCompact>("sp_GetCategoryCompact", new {pageNo,Pagesize,name},System.Data.CommandType.StoredProcedure);
             if(raw is null)
            {
                return null;
            }

            var Product = string.IsNullOrWhiteSpace(raw.Products)
            ? new List<ProductCompactResponse>()
            : JsonSerializer.Deserialize<List<ProductCompactResponse>>(raw.Products,
             new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return new CategoryCompactResponse()
            {
                Id=raw.Id,
                Name=raw.Name,
                Products= Product!
            };

        }

        public async Task<CategoryResponse> GetCategoryById(Guid id)
        {
            string sql = $@" select c.id,c.name,c.description,c.CreatedOn,c.IsDeleted,c.UpdatedAt ,
                         (select f.filePath,f.FileName from AppFiles f where f.entityId=c.id For Json Path) as Files
                          From categories c
                           where c.id=@id";

            return await FirstOrDefaultAsync<CategoryResponse>(sql, new { id });
        }
    }
}
