using E_Commerce.Application.Abstraction.Identity;
using E_Commerce.Infrastructure.JwtProvider;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure.Identity
{
    internal class HttpcontextService(IHttpContextAccessor httpContext) : IHttpContextService
    {
        string IHttpContextService.GetCurrentClientUrl()
        {
            throw new NotImplementedException();
        }

        string IHttpContextService.GetCurrentUrl()
        {
            throw new NotImplementedException();
        }

        string IHttpContextService.GetUserName()
        {
            var email=httpContext.HttpContext?.User?.Claims?.FirstOrDefault(x=>x.Type==UserClaims.UserName)?.Value;
            return email;
        }

        string IHttpContextService.HttpcontextCurrentClientUrl()
        {
            throw new NotImplementedException();
        }

        string IHttpContextService.HttpcontextCurrentUrl()
        {
            throw new NotImplementedException();
        }

        Guid IHttpContextService.UserId()
        {
            var userId=httpContext.HttpContext?.User?.Claims?.FirstOrDefault(x=>x.Type==UserClaims.UserId)?.Value;
            if (Guid.TryParse(userId, out Guid id)) return id;
            return Guid.Empty;
        }
    }
}
