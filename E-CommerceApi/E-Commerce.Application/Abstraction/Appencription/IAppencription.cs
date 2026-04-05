using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.Appencription
{
    public interface IAppencription
    {
        public string GenerateSalt();
        public string HashPassword(string password,string salt);
        //public bool VerifyPaasword(string password, string hashedPassword);
    }
}
