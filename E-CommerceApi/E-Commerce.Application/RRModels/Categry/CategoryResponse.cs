using E_Commerce.Application.RRModels.Appfile;
using E_Commerce.Application.RRModels.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Categry
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedOn { get; set; } 
        public bool IsDeleted { get; set; } = false;
        public string? FilePath { get; set; }
        public bool UpdatedAt { get; set; } = false;
    }

    public class CategoryCompactResponse 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProductCompactResponse> Products { get; set; } = new List<ProductCompactResponse>();

    }

    public class CategoryJsonCompact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Products { get; set; }
    }



}
