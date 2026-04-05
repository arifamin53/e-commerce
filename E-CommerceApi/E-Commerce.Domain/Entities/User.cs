using E_commerce.Domain.Enums;

namespace E_commerce.Domain.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;  
        public string Salt { get; set; } = string.Empty;  
        public AppEnums.UserRole UserRole { get; set; } = AppEnums.UserRole.Customer;
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public bool IsEmailconfirmed { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public IEnumerable<Order> Orders { get; set; } = new List<Order>(); 
        public Cart Cart { get; set; } = null!;    

    }
}
