namespace E_commerce.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public bool IsDeleted { get; set; } = false;    
        public bool UpdatedAt { get; set; } = false;
    }
}
