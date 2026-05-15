using AutoMapper;
using E_commerce.Domain.Entities;
using E_commerce.Domain.Enums;
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

               
                var cart = await cartRepository.FirstOrDefaultAsync(x => x.UserId == userId);

                var cartItems = await cartItemRepository
                    .Queryble()
                    .Where(x => x.CartId == cart.Id)
                    .ToListAsync();
                var totalPrice = cartItems.Sum(x => x.UnitPrice * x.Quantity);

                var o = new Order()
                {
                    TotalAmount = totalPrice,
                    UserId = user.Id,
                };
                await orderRepository.AddAsync(o);

               

                List<OrderItem> items = new List<OrderItem>();

                foreach(var item in cartItems)
                {
                    var orderItem = new OrderItem()
                    {
                        OrderId = o.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        
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
                        Id=o.Id,
                        Name=user.Name,
                        State=user.State,
                        Street=user.Street,
                        TotalAmount=totalPrice,
                        ZipCode = user.ZipCode
                    };

                    return Result<OrderResponse>.Success(response, "Your Order Has been received");

                }
                return Result<OrderResponse>.Failure("SomeThing went wrong please try after someTime",StatusCodes.Status500InternalServerError);
            }
            return Result<OrderResponse>.Failure("Not Found ", StatusCodes.Status404NotFound);

        }

        public async Task<Result<IEnumerable<OrderCompactResponse>>> GetOrderByStatus()
        {
            var orders = await orderRepository.GetOrderByStatus();
            if(orders  is null)
            {
                return Result<IEnumerable<OrderCompactResponse>>.Failure("no data found", StatusCodes.Status404NotFound); 
            }

            return Result<IEnumerable<OrderCompactResponse>>.Success(orders);

        }

        public async Task<Result<int>> OrderCount()
        {
            var count = await orderRepository.CountAsync(x => x.OrderStatus == AppEnums.Status.Pending);
            if(count == 0)
            {
                return Result<int>.Success(0, "No order is pending", StatusCodes.Status200OK);
            }
            return Result<int>.Success(1);
        }

        public async Task<Result<OrderCompactResponse>> UpdateOrderStatus(OrderUpdateStatusRequest model)
        {
            var order = await orderRepository.FirstOrDefaultAsync( x => x.Id == model.Id);
            if(order is null)
            {
                return Result<OrderCompactResponse>.Failure("Not found", StatusCodes.Status404NotFound);
            }

            order.OrderStatus = model.OrderStatus;
            order.UpdatedAt=true;

            await orderRepository.UpdateBYIdAsync(order.Id);
            var returnValue = await unitOfWork.SaveChanegeAsync();
            if(returnValue > 0)
            {
                var response = mapper.Map<OrderCompactResponse>(order);
                return Result<OrderCompactResponse>.Success(response,"Order Updated Successfully");
            }

            return Result<OrderCompactResponse>.Failure("someThing went wrong please try after someTime", StatusCodes.Status500InternalServerError);
        }
    }
}