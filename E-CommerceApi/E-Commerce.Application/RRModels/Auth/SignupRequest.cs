using E_commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Auth
{
    public class SignupRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsEmailconfirmed { get; set; } = false;
        public bool IsActive { get; set; } = false;
    }


    public class SignupResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
       
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public AppEnums.UserRole UserRole { get; set; }
        public bool IsEmailconfirmed { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public DateTimeOffset CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool UpdatedAt { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }

}
