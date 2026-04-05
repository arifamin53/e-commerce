using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Categry
{
    public class CategoryUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? UpdatedAt { get; set; }
    }

    public class CategoryUpdateResponse()
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }

}
