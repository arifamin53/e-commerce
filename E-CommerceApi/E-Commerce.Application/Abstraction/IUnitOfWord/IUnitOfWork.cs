using E_Commerce.Application.Abstraction.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace E_Commerce.Application.Abstraction.IUnitOfWord
{
    public interface IUnitOfWork
    {
        IDbTransaction  BeignTranction();
        public Task<int> SaveChanegeAsync();
    }
}
