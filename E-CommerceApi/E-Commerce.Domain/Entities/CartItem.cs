using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Domain.Entities
{
    public class CartItem: BaseEntity
    {
        public Guid CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }  
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}