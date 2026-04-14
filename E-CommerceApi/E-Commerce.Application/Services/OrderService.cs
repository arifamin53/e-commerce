using AutoMapper;
using E_commerce.Domain.Entities;
using E_Commerce.Application.Abstraction.Appencription;
using E_Commerce.Application.Abstraction.Identity;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.Abstraction.IUnitOfWord;
using E_Commerce.Application.RRModels.Order;
using E_Commerce.Application.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;



namespace E_Commerce.Application.Services
{
    public class OrderService(IAppencription appencription,IMapper mapper,
        IOrderRepository orderRepository,IHttpContextService httpContext,
        IAuthRepository authRepository,ICartItemRepository cartItemRepository,
        ICartRepository cartRepository,
        IOrderItemRepository orderItemRepository,IUnitOfWork unitOfWork) : IOrderService
    {
        public async Task<Result<OrderResponse>> AddOrderAsync(OrderRequest model)
        {
            var transection = unitOfWork.BeignTranction();
            var userId = httpContext.UserId();
            if(userId == Guid.Empty)
            {
                return Result<OrderResponse>.Failure("you are not authorized to this resource please login", StatusCodes.Status401Unauthorized);
            }
            var user = await authRepository.GetBYIdAsync(userId);
            if(user is not null)
            {

                user.Name = model.Name;
                user.Email = model.Email;
                user.ContactNo = model.ContactNo;
                user.City = model.City;
                user.State = model.State;
                user.Country = model.Country;
                user.ZipCode = model.ZipCode;
                user.Street = model.Street;

                await authRepository.UpdateBYIdAsync(user.Id);

                var order = await orderRepository.FirstOrDefaultAsync(x =>x.UserId == userId);
               

                var o = new Order()
                {
                    TotalAmount = model.TotalAmount,
                    UserId = user.Id,
                };
                await orderRepository.AddAsync(o);

                var cart = await cartRepository.FirstOrDefaultAsync(x => x.UserId == userId);

                var cartItems = await cartItemRepository
                    .Queryble()
                    .Where(x => x.CartId == cart.Id)
                    .ToListAsync();
                var totalPrice = cartItems.Sum(x => x.UnitPrice * x.Quantity);

                List<OrderItem> items = new List<OrderItem>();

                foreach(var item in cartItems)
                {
                    var orderItem = new OrderItem()
                    {
                        OrderId = o.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = totalPrice,
                        
                    };
                    items.Add(orderItem);
                }

                await orderItemRepository.AddRangeAsync(items);
                await cartItemRepository.DeleteRangeAasync(cartItems);

                var returnvalue = await unitOfWork.SaveChanegeAsync();
                if(returnvalue > 0)
                {
                    transection.Commit();
                    var response = new OrderResponse()
                    { 
                        City=user.City,
                        ContactNo=user.ContactNo,
                        Country=user.Country,
                        Email=user.Email,
                        Id=order.Id,
                        Name=user.Name,
                        State=user.State,
                        Street=user.Street,
                        TotalAmount=order.TotalAmount,
                        ZipCode = user.ZipCode
                    };

                    return Result<OrderResponse>.Success(response, "Your Order Has been received");

                }
                return Result<OrderResponse>.Failure("SomeThing went wrong please try after someTime",StatusCodes.Status500InternalServerError);
            }
            return Result<OrderResponse>.Failure("Not Found ", StatusCodes.Status404NotFound);

        }
    }
}
