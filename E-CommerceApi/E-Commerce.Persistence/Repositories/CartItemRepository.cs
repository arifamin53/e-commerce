using E_commerce.Domain.Entities;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Persistence.Repositories
{
    public class CartItemRepository(E_CommerceDbContext context):BaseRepository<CartItem>(context),ICartItemRepository
    {
    }
}
