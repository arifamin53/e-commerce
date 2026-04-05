namespace E_commerce.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}