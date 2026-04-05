using E_Commerce.Application.RRModels.Product;
using E_Commerce.Application.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.IService
{
    public interface IProductService
    {
        Task<Result<ProductResponse>> Add(ProductRequest model);
        Task<Result<IEnumerable<ProductResponse>>> ProductsByCategoryId(Guid id);
        Task <Result<ProductResponse>> ProductById(Guid id);
        Task <Result<ProductResponse>> DeleteProduct(Guid id);
        Task <Result<ProductResponse>> UpdateProduct(ProductUpdateRequest model);
    }
}
