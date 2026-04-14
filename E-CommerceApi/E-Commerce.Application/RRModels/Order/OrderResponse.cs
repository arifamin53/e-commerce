using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Order
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
    }
}
