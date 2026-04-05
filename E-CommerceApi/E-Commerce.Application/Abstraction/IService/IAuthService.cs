using E_Commerce.Application.RRModels.Auth;
using E_Commerce.Application.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.IService
{
    public interface IAuthService
    {
        public Task<Result<LoginResponse>> Login(LoginRequest model);
        public Task<Result<SignupResponse>> ChangePassword(ChangePasswordRequest model);
        public Task<Result<SignupResponse>> Signup(SignupRequest model);
        public Task<Result<SignupResponse>> BlockUser(Guid id);
    }
}
