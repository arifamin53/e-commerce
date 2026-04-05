using AutoMapper;
using E_commerce.Domain.Entities;
using E_commerce.Domain.Enums;
using E_Commerce.Application.Abstraction.Appencription;
using E_Commerce.Application.Abstraction.Identity;
using E_Commerce.Application.Abstraction.IJWTProvider;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.Abstraction.IUnitOfWord;
using E_Commerce.Application.RRModels.Auth;
using E_Commerce.Application.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Services
{
    public class AuthService(IAuthRepository authRepository,IAppencription appencription,
        IUnitOfWork unitOfWork,IMapper mapper,IJWTProvider jWTProvider,
        IHttpContextService httpContextService,IHttpContextAccessor httpContext,ICartRepository cartRepository) : IAuthService
    {
        public async Task<Result<SignupResponse>> BlockUser(Guid id)
        {
            var transection = unitOfWork.BeignTranction();
            var user=await authRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null) return Result<SignupResponse>.Failure("not found", StatusCodes.Status404NotFound);
            var currentId = httpContextService.UserId();
            var currentUser=await authRepository.FirstOrDefaultAsync(x=>x.Id == currentId);
            if (currentUser.Id == id)
            {
                return Result<SignupResponse>.Failure("You can not block your own account", StatusCodes.Status400BadRequest);
            }

            user.IsActive = user.IsActive ? false : true;
            await authRepository.UpdateBYIdAsync(user.Id);
            var returnValue = await unitOfWork.SaveChanegeAsync();
            if(returnValue > 0)
            {
                transection.Commit();
                var res=mapper.Map<SignupResponse>(user);
                return Result<SignupResponse>.Success(res,user.IsActive?"user UnBlocked successfully": "User blocked successfully");
            }
            return Result<SignupResponse>.Failure("SomeThing went wrong please try aftersome time", StatusCodes.Status500InternalServerError);
        }


        public async Task<Result<SignupResponse>> ChangePassword(ChangePasswordRequest model)
        {
            var transection = unitOfWork.BeignTranction();
            var id = httpContextService.UserId();
            if (id == null) return Result<SignupResponse>.Failure("user not found",StatusCodes.Status404NotFound);
            var user=await authRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (appencription.HashPassword(model.OldPassword, user.Salt) != user.HashedPassword)
            {
                return Result<SignupResponse>.Failure("Old password is Incorrect", StatusCodes.Status403Forbidden);
            }
            var newHashPassword=appencription.HashPassword(model.NewPassword, user.Salt);
            if(newHashPassword == user.HashedPassword)
            {
                return Result<SignupResponse>.Failure("Old password matchs new password please enter different password", StatusCodes.Status403Forbidden);
            }

            user.HashedPassword = newHashPassword;
            await authRepository.UpdateBYIdAsync(user.Id);
            var returnValue = await unitOfWork.SaveChanegeAsync();
            if(returnValue > 0)
            {
                transection.Commit();
               var res= mapper.Map<SignupResponse>(user);
                return Result<SignupResponse>.Success(res, "password changed successfully");
            }

            return Result<SignupResponse>.Failure("someThing went wrong please try after some time");
        }



        public async Task<Result<LoginResponse>> Login(LoginRequest model)
        {
            var user=await authRepository.FirstOrDefaultAsync(x=>x.Email==model.Email);
            if(user is null)
            {
                return Result<LoginResponse>.Failure("You are new user i think please signup", StatusCodes.Status400BadRequest);
            }

            var comparedPassword = appencription.HashPassword(model.Password, user.Salt);
            //var hashPassword1 = appencription.HashPassword(model.HashPassword, user.Salt);
            if (!comparedPassword.Equals(user.HashedPassword))
            {
                return Result<LoginResponse>.Failure("Email or Password is Incorrect", StatusCodes.Status400BadRequest);
            }
            if (!user.IsActive)
            {
                return Result<LoginResponse>.Failure("Your account has been blocked contact admin", StatusCodes.Status400BadRequest);
            }

            var loginresponse = new LoginResponse()
            {
                Email = user.Email,
                ContactNo = user.ContactNo,
                IsActive = user.IsActive,
                Name = user.Name,
                IsEmailconfirmed = user.IsEmailconfirmed,
                UserRole = user.UserRole,
                CreatedOn = user.CreatedOn,
                Token = jWTProvider.GenerateAuthToken(user)

            };

            return Result<LoginResponse>.Success(loginresponse, "Login Succussfully");

        }

        public async Task<Result<SignupResponse>> Signup(SignupRequest model)
        {
            var users = await authRepository.FirstOrDefaultAsync(x => x.Email == model.Email);
            if(users is not null)
            {
                return Result<SignupResponse>.Failure("email already exist please enter valid email",StatusCodes.Status300MultipleChoices);
            }
            var transection = unitOfWork.BeignTranction();
            var salt = appencription.GenerateSalt();
         
            var hashPassword=appencription.HashPassword(model.Password,salt);
            var user = mapper.Map<User>(model);
            
            user.HashedPassword = hashPassword;
            user.Salt= salt;
            user.IsActive = true;
            user.IsEmailconfirmed = true;
            await authRepository.AddAsync(user);

            var cart = new Cart()
            { 
                UserId=user.Id,
            };

            await cartRepository.AddAsync(cart);
            
            var returnValue = await unitOfWork.SaveChanegeAsync();
            if(returnValue > 0)
            {
                transection.Commit();
                var signupResponse = mapper.Map<SignupResponse>(user);
                return Result<SignupResponse>.Success(signupResponse,"Signup successfully");
            }

            return Result<SignupResponse>.Failure("something went wrong please try after some time",StatusCodes.Status500InternalServerError);
        }
    }
}
