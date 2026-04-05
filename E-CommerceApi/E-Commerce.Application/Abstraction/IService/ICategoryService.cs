using E_Commerce.Application.RRModels.Categry;
using E_Commerce.Application.Utility;

namespace E_Commerce.Application.Abstraction.IService
{
    public interface ICategoryService
    {
        public Task<Result<CategoryResponse>> Add(CategoryRequest response);
        public Task<Result<IEnumerable<CategoryResponse>>> GetCategories();
        public Task<Result<CategoryResponse>> GetCategorieById(Guid id);
        public Task<Result<CategoryUpdateResponse>> UpdateCategory(CategoryUpdateRequest model);
        public Task<Result<CategoryResponse>> DeleteCategory(Guid id);
        public Task<Result<CategoryCompactResponse>> CategoryCompactProducts(int pageNo,int PageSize,string name);
    }
}
