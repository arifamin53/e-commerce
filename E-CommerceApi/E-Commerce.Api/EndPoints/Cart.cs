using Carter;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.RRModels.Cart;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.EndPoints
{
    public class Cart : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder appBulder)
        {
            var app = appBulder.MapGroup("api/carts").WithTags("carts");

            app.MapPost("", async (ICartService cartService, [FromBody]CartCompactRequest model) =>
            {
                return await cartService.AddCart(model);
            }).DisableAntiforgery();
        }
    }
}
