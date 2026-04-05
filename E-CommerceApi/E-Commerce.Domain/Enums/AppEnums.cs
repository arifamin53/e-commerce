namespace E_commerce.Domain.Enums
{
    public class AppEnums
    {
        public enum  Status
        {
            Pending = 1,
            Confirmed = 2,
            Cancelled = 3,
            Shipped = 4,
            Paid = 5
        }
        public enum PaymentStatus
        {
            Failed = 1,
            Successful = 2
        }
        public enum UserRole
        {
            Admin = 1,
            Customer = 2,
        }

        public enum AppModule
        {
            Category = 1,
            Product = 2,
            Cart=3,
            CartItem=4,
            Order=5,
            OrderItem=6,
            Payment=7,
        }
    }
}
