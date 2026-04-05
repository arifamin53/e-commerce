using Carter;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.RRModels.Auth;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.EndPoints
{
    public class User : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder builder)
        {
            var app = builder.MapGroup("api/user").WithTags("user");

            app.MapPost("signup", async (IAuthService authService,SignupRequest model) =>
            {
               return await authService.Signup(model);
            }).DisableAntiforgery();


            app.MapPost("login", async (IAuthService authservice,LoginRequest model) =>
            {
                return await authservice.Login(model);
            }).DisableAntiforgery();


            app.MapPost("changePassword", async (IAuthService authservice, ChangePasswordRequest model) =>
            {
                return await authservice.ChangePassword(model);
            }).DisableAntiforgery();


            app.MapPost("Block_user", async (IAuthService authservice, Guid id) =>
            {
                return await authservice.BlockUser(id);
            }).DisableAntiforgery();
        }
    }
}
