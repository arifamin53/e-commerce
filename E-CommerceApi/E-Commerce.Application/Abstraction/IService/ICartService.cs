using E_Commerce.Application.RRModels.Cart;
using E_Commerce.Application.RRModels.CartItem;
using E_Commerce.Application.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.IService
{
    public interface ICartService
    {
        Task<Result<List<CartItemResponse>>> AddCart(CartCompactRequest model);
    }
}
