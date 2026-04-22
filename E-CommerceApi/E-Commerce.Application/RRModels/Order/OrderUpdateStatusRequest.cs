using E_commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Order
{
    public class OrderUpdateStatusRequest
    {
        public Guid Id { get; set; }
        public AppEnums.Status OrderStatus { get; set; }
    }
}
