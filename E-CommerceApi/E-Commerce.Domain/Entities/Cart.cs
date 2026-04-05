using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_commerce.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}
