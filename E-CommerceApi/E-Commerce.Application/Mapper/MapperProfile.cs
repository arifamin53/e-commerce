using AutoMapper;
using E_commerce.Domain.Entities;
using E_Commerce.Application.RRModels.Auth;
using E_Commerce.Application.RRModels.Cart;
using E_Commerce.Application.RRModels.CartItem;
using E_Commerce.Application.RRModels.Categry;
using E_Commerce.Application.RRModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Mapper;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<SignupRequest, User>();
        CreateMap<User, SignupResponse>().ReverseMap();
    }
}

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryRequest, Category>();
        CreateMap<CategoryResponse, Category>().ReverseMap();
        CreateMap<CategoryUpdateRequest, Category>();
        CreateMap<Category, CategoryUpdateResponse>();
    }
}

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<ProductUpdateRequest, Product>();
        CreateMap<Product, ProductResponse>().ReverseMap().ReverseMap();

    }
}

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<Cart, CartResponse>().ReverseMap();
        CreateMap<Cart, CartResponse>().ReverseMap();
    }
}


public class CartItemProfile : Profile
{
    public CartItemProfile()
    {
        CreateMap<CartItem,CartItemResponse>().ReverseMap();
    }
}

