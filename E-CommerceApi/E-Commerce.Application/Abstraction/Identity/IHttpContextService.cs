using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.Identity
{
    public interface IHttpContextService
    {
        Guid UserId();
        public string GetUserName();
        public string GetCurrentClientUrl();
        public string GetCurrentUrl();
        public string HttpcontextCurrentUrl();
        public string HttpcontextCurrentClientUrl();


    }
}
