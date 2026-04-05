using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Domain.Entities
{
    public class OrderItem: BaseEntity
    {
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
