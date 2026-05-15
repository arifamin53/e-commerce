using E_commerce.Domain.Entities;
using E_commerce.Domain.Enums;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.RRModels.Order;
using E_Commerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Persistence.Repositories
{
    public class OrderRepository(E_CommerceDbContext context) : BaseRepository<Order>(context), IOrderRepository
    {
        public async Task<IEnumerable<OrderCompactResponse>> GetOrderByStatus()
        {
            var result = await context.Orders
                .Include(o => o.User)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new OrderCompactResponse
                {
                    Id = o.Id,
                    TotalAmount = o.TotalAmount,
                    Name = o.User.Name,
                    Email = o.User.Email,
                    ContactNo = o.User.ContactNo,
                    City = o.User.City,
                    Country = o.User.Country,
                    State = o.User.State,
                    Status = o.OrderStatus,
                    Street = o.User.Street,
                    ZipCode = o.User.ZipCode,
                    OrderDate = o.OrderDate
                })
                .ToListAsync();

            return result;
        }
    }
}
