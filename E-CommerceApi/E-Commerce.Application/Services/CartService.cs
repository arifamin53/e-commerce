using AutoMapper;
using E_commerce.Domain.Entities;
using E_Commerce.Application.Abstraction.Identity;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.Abstraction.IUnitOfWord;
using E_Commerce.Application.RRModels.Cart;
using E_Commerce.Application.RRModels.CartItem;
using E_Commerce.Application.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.Application.Services;

public class CartService(IUnitOfWork unitOfWork, ICartRepository cartRepository,
    ICartItemRepository cartItemRepository, IHttpContextService httpContextService,
    IProductRepository productRepository, IMapper mapper) : ICartService

{
    //public async Task<Result<List<CartItemResponse>>> AddCart(CartCompactRequest model)
    //{
    //    var userId = httpContextService.UserId();
    //    if(userId == Guid.Empty)
    //    {
    //        return Result<List<CartItemResponse>>.Failure("you are not authorized to access this resource please login ", StatusCodes.Status401Unauthorized);
    //    }
    //    var cart = await cartRepository.FirstOrDefaultAsync(x => x.UserId == userId);
    //    List<CartItem> cartItem = new();

    //    foreach (var pro in model.Item)
    //    {
    //        var cartItems = new CartItem()
    //        {
    //            CartId = cart.Id,
    //            ProductId = pro.ProductId,
    //            Quantity = pro.Quantity,
    //            UnitPrice = pro.UnitPrice,

    //        };

    //        cartItem.Add(cartItems);
    //    }

    //    await cartItemRepository.AddRangeAsync(cartItem);

    //    int returnValue = await unitOfWork.SaveChanegeAsync();
    //    if(returnValue > 0)
    //    {
    //        var maped=mapper.Map<List<CartItemResponse>>(cartItem);
    //        return Result<List<CartItemResponse>>.Success(maped, "cartItem added successfully");
    //    }
    //    return Result<List<CartItemResponse>>.Failure("someThing  went wrong please try after some time", StatusCodes.Status500InternalServerError);

    //}

    public async Task<Result<List<CartItemResponse>>> AddCart(CartCompactRequest model)
    {
        var userId = httpContextService.UserId();

        if (userId == Guid.Empty)
        {
            return Result<List<CartItemResponse>>.Failure(
                "you are not authorized to access this resource please login",
                StatusCodes.Status401Unauthorized);
        }

        var cart = await cartRepository.FirstOrDefaultAsync(x => x.UserId == userId);

        if (cart is null)
        {
            return Result<List<CartItemResponse>>.Failure(
                "Cart not found",
                StatusCodes.Status404NotFound);
        }

      
        var productIds = model.Item.Select(x => x.ProductId).ToList();

       
        var products = await productRepository
                     .Query()
                     .Where(p => productIds.Contains(p.Id))
                     .ToListAsync();

        
        var productDict = products.ToDictionary(p => p.Id);

        List<CartItem> cartItems = new();

        foreach (var pro in model.Item)
        {
            if (!productDict.TryGetValue(pro.ProductId, out var product))
            {
                return Result<List<CartItemResponse>>.Failure(
                    $"Product not found: {pro.ProductId}",
                    StatusCodes.Status404NotFound);
            }

            var cartItem = new CartItem()
            {
                CartId = cart.Id,
                ProductId = pro.ProductId,
                Quantity = pro.Quantity,
                UnitPrice = product.Price*pro.Quantity 
            };

            cartItems.Add(cartItem);
        }

        await cartItemRepository.AddRangeAsync(cartItems);

        int returnValue = await unitOfWork.SaveChanegeAsync();

        if (returnValue > 0)
        {
            var mapped = mapper.Map<List<CartItemResponse>>(cartItems);

            return Result<List<CartItemResponse>>.Success(
                mapped,
                "Cart items added successfully");
        }

        return Result<List<CartItemResponse>>.Failure(
            "Something went wrong, please try again later",
            StatusCodes.Status500InternalServerError);
    }
}