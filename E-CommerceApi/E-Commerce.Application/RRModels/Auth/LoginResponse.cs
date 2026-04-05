using E_commerce.Domain.Entities;
using E_commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Auth
{
    public class LoginResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public AppEnums.UserRole UserRole { get; set; } = AppEnums.UserRole.Customer;
        public bool IsEmailconfirmed { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public string Token { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
