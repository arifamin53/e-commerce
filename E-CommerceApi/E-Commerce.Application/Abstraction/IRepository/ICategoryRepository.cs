using E_commerce.Domain.Entities;
using E_Commerce.Application.RRModels.Categry;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.IRepository
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        public Task<IEnumerable<CategoryResponse>> GetCategories();
        public Task<CategoryResponse> GetCategoryById(Guid id);
        public Task<CategoryCompactResponse> GetCategory(int pageNo,int Pagesize,string name);
        //public Task<CategoryResponse> AddCategory(CategoryRequest model);
    }
}
