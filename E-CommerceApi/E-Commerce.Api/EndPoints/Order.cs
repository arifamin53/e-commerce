using Carter;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.RRModels.Order;

namespace E_Commerce.Api.EndPoints
{
    public class Order : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/orders").WithTags("orders");

            group.MapPost("", async (OrderRequest model,IOrderService orderService) =>
            {
                return await orderService.AddOrderAsync(model);
            });

            group.MapGet("", async (IOrderService orderService) =>
            
            {
                return await orderService.GetOrderByStatus();
            });
            
            group.MapGet("count", async (IOrderService orderService) => 
            {
                return await orderService.OrderCount();
            });


            group.MapPut("", async (IOrderService orderservice,OrderUpdateStatusRequest model) =>
            {
                return await orderservice.UpdateOrderStatus(model);
            });
        }
    }
}
