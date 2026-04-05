using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Auth
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
