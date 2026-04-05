using E_commerce.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public AppEnums.PaymentStatus PaymentStatus { get; set; } = AppEnums.PaymentStatus.Failed;
        public string TransactionId { get; set; } =Guid.CreateVersion7().ToString();
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow; 


    }
}
