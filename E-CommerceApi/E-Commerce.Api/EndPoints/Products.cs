using Carter;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.RRModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.EndPoints
{
    public class Products : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder appBulder)
        {
           var app=appBulder.MapGroup("api/products").WithTags("products");

            app.MapPost("", async ([FromForm]ProductRequest model, IProductService productService) =>
            {
                return await productService.Add(model);
            }).DisableAntiforgery();



            app.MapGet("{id:guid}", async (Guid id, IProductService productService) =>
            {
                return await productService.ProductsByCategoryId(id);
            }).DisableAntiforgery();



            app.MapGet("get/{id:guid}", async (Guid id, IProductService productService) =>
            {
                return await productService.ProductById(id);
            }).DisableAntiforgery();



            app.MapPut("", async (ProductUpdateRequest model, IProductService productService) =>
            {
                return await productService.UpdateProduct(model);
            }).DisableAntiforgery();


            app.MapDelete("{id:guid}", async (Guid id, IProductService productService) =>
            {
                return await productService.DeleteProduct(id);
            }).DisableAntiforgery();
        }
    }
}
