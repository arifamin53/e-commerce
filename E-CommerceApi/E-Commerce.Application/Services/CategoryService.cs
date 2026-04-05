using AutoMapper;
using E_commerce.Domain.Entities;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.Abstraction.IStorageService;
using E_Commerce.Application.Abstraction.IUnitOfWord;
using E_Commerce.Application.RRModels.Categry;
using E_Commerce.Application.Utility;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices.Marshalling;
using static E_commerce.Domain.Enums.AppEnums;

namespace E_Commerce.Application.Services
{
    public class CategoryService(IUnitOfWork unitOfWork,IMapper mapper,ICategoryRepository categoryRepository,IStorageService storageService,IAppFileRepository appFileRepository) : ICategoryService
    {
        public async Task<Result<CategoryResponse>> Add(CategoryRequest model)
        {
            var transection = unitOfWork.BeignTranction();
            var category = mapper.Map<Category>(model);
            if(category is not null)
            {
                await categoryRepository.AddAsync(category);
                var (filePath, fileName) = await storageService.SaveFileAsync(model.File);
                var aapfile = new AppFile() 
                {
                    FileName=fileName,
                    FilePath=filePath,
                    EntityId=category.Id,
                    AppModule=AppModule.Category
                };
                await appFileRepository.AddAsync(aapfile);
                var returnValue = await unitOfWork.SaveChanegeAsync();
                if(returnValue > 0)
                {
                    transection.Commit();
                    var res = mapper.Map<CategoryResponse>(category);
                    return Result<CategoryResponse>.Success(res, "Category Added Successfully");
                }
                return Result<CategoryResponse>.Failure("someThing went wrong please try after sometime", StatusCodes.Status500InternalServerError);


            }
            return Result<CategoryResponse>.Failure("not Found", StatusCodes.Status404NotFound);
        }

        public async Task<Result<CategoryCompactResponse>> CategoryCompactProducts(int pageNo,int pageSize,string name)
        {
            var result = await categoryRepository.GetCategory(pageNo, pageSize, name);
            if (result is not null) return Result<CategoryCompactResponse>.Success(result, "Fetched Successfully");
            return Result<CategoryCompactResponse>.Failure("not found", StatusCodes.Status404NotFound);
        }

        public async Task<Result<CategoryResponse>> DeleteCategory(Guid id)
        {
            var transection = unitOfWork.BeignTranction();
            var category = await categoryRepository.FirstOrDefaultAsync(x => x.Id == id);
            if(category is not null)
            {
                category.IsDeleted = true;
                await categoryRepository.DeleteByIdAsync(category.Id);
                int returnValue = await unitOfWork.SaveChanegeAsync();
                if(returnValue > 0)
                {
                    transection.Commit();
                    var response = mapper.Map<CategoryResponse>(category);
                    return Result<CategoryResponse>.Success(response, "Deleted Successfully");
                }
                return Result<CategoryResponse>.Failure("something went wrong please try after some time",StatusCodes.Status500InternalServerError);
            }
            return Result<CategoryResponse>.Failure("not found", StatusCodes.Status404NotFound);
        }

        public async Task<Result<CategoryResponse>> GetCategorieById(Guid id)
        {
            var category = await categoryRepository.GetCategoryById(id);
            if (category is null) return Result<CategoryResponse>.Failure("not Found", StatusCodes.Status404NotFound);
            
            var res = mapper.Map<CategoryResponse>(category);
            
            return Result<CategoryResponse>.Success(res, "Data Fetched successfully");
        }



        public async Task<Result<IEnumerable<CategoryResponse>>> GetCategories()
        {
            var categories = await categoryRepository.GetCategories();
            if(categories is not null)
            {
                var res = mapper.Map<IEnumerable<CategoryResponse>>(categories);
                return Result<IEnumerable<CategoryResponse>>.Success(res, "Categories Fetched Successfully");
            }
            return Result<IEnumerable<CategoryResponse>>.Failure("something went wrong please try after sometime");
        }

        public async Task<Result<CategoryUpdateResponse>> UpdateCategory(CategoryUpdateRequest model)
        {
            var transection = unitOfWork.BeignTranction();

            var mapedResponse = mapper.Map<Category>(model);
            if (model is not null)
            {
                mapedResponse.UpdatedAt =true;
                await categoryRepository.UpdateASync(mapedResponse);
                int returnvalue = await unitOfWork.SaveChanegeAsync();
                if(returnvalue > 0)
                {
                    transection.Commit();
                    var mappedCategoryUpdateResponse = mapper.Map<CategoryUpdateResponse>(mapedResponse);

                    return Result<CategoryUpdateResponse>.Success(mappedCategoryUpdateResponse, "Updated Successfully");
                }
                return Result<CategoryUpdateResponse>.Failure("some thing went wrong please try after some time", StatusCodes.Status500InternalServerError);
            }
            return Result<CategoryUpdateResponse>.Failure("Not Found ", StatusCodes.Status404NotFound);
        }
    }
}
