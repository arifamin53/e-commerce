using E_Commerce.Application.RRModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Cart
{
    public class CartRequest
    {
        public Guid ProductId { get; set; } 
        public int Quantity { get; set; } = 1;
        public int UnitPrice { get; set; }
    }

    public class CartCompactRequest 
    {
        public List<CartRequest> Item { get; set; } = new();
    }
}
