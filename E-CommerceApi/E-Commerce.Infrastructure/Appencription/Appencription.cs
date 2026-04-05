using E_Commerce.Application.Abstraction.Appencription;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure.Appencription
{
    public class Appencription : IAppencription
    {
        public string GenerateSalt()
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            return salt;
        }

        public string HashPassword(string password,string salt)
        {
            var hash= BCrypt.Net.BCrypt.HashPassword(password,salt);
            return hash;

        }
        
        public bool VerifyPaasword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
