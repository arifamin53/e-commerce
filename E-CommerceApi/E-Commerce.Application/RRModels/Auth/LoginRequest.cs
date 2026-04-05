using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Auth
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
