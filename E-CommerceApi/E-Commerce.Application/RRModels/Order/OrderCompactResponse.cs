using E_commerce.Domain.Enums;


namespace E_Commerce.Application.RRModels.Order
{
    public class OrderCompactResponse:OrderResponse
    {
        public AppEnums.Status Status { get; set; }
        public DateTime OrderDate { get;set; }
    }
}
