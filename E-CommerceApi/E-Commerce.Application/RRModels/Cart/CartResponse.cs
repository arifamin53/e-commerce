using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Cart
{
    public class CartResponse
    {
        public Guid Id { get; set; }    
        public string UserName { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public bool UpdatedAt { get; set; } = false;

    }
}
