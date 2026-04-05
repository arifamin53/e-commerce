using Carter;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.RRModels.Categry;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.EndPoints
{
    public class Category : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder appBuilder)
        {
           var app= appBuilder.MapGroup("api/categories").WithTags("categories");

            app.MapPost("", async ([FromForm]CategoryRequest model, ICategoryService categoryService) =>
            {
               return await categoryService.Add(model);    
            }).DisableAntiforgery();

            app.MapGet("{id:guid}", async (Guid id, ICategoryService categoryService) =>
            {
                var result= await categoryService.GetCategorieById(id);
                return Results.Ok(result);
                
            }).DisableAntiforgery();

            app.MapGet("", async (ICategoryService categoryService) =>
            {
                return await categoryService.GetCategories();
               
            }).DisableAntiforgery();

            app.MapPut("", async (CategoryUpdateRequest model,ICategoryService categoryService) =>
            {
                return await categoryService.UpdateCategory(model);

            }).DisableAntiforgery();

            app.MapDelete("{id:guid}", async (Guid id, ICategoryService categoryService) =>
            {
                return await categoryService.DeleteCategory(id);

            }).DisableAntiforgery();

            app.MapGet("compact/{pageNo:int}/{pageSize:int}/{name}", async (int pageNo,int pageSize,string name, ICategoryService categoryService) =>
            {
                return await categoryService.CategoryCompactProducts(pageNo,pageSize,name);

            }).DisableAntiforgery();

        }
    }
}
