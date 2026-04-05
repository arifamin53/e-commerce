using E_commerce.Domain.Entities;
using E_Commerce.Application.RRModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.IRepository
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        Task<IEnumerable<ProductResponse>> ProductsByCategoryId(Guid id);
        Task<ProductResponse> ProductsById(Guid id);
    }
}
