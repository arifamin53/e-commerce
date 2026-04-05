using E_Commerce.Application.RRModels.Appfile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Product
{
    public class ProductRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFileCollection? Files { get; set; }
    }

    public class ProductResponse
    {
        public Guid Id {  get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public bool UpdatedAt { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string? Files { get; set; }
    }

    public class ProductUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool UpdatedAt { get; set; }
    }

    public class ProductCompactResponse 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? FilePath {  get; set; } 
        public DateTimeOffset CreatedOn { get; set; }
    }


}
