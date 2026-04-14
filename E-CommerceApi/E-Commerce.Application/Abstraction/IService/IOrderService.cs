using E_Commerce.Application.RRModels.Order;
using E_Commerce.Application.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.IService
{
    public interface IOrderService
    {
        Task<Result<OrderResponse>> AddOrderAsync(OrderRequest model);
    }
}
