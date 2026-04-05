using E_commerce.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public decimal TotalAmount { get; set; }
        public AppEnums.Status OrderStatus { get; set; } = AppEnums.Status.Pending;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public List<OrderItem> OrderItems = new List<OrderItem>();
        public Payment Payment { get; set; } = null!;
    }
}
