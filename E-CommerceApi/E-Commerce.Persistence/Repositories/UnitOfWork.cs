using E_Commerce.Application.Abstraction.IUnitOfWord;
using E_Commerce.Persistence.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace E_Commerce.Persistence.Repositories
{
    public class UnitOfWork(E_CommerceDbContext context):IUnitOfWork
    {
        public IDbTransaction BeignTranction()
        {
           return context.Database.BeginTransaction().GetDbTransaction();   
        }

        public async Task<int> SaveChanegeAsync()
        {
           return await context.SaveChangesAsync(); 
        }
    }
}
