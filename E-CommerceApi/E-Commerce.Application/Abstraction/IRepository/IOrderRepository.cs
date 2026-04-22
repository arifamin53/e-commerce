using E_commerce.Domain.Entities;
using E_Commerce.Application.RRModels.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.IRepository
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        Task<IEnumerable<OrderCompactResponse>> GetOrderByStatus();
    }
}
