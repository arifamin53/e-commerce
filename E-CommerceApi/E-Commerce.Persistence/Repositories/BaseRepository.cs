using Dapper;
using E_commerce.Domain.Entities;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Persistence.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace E_Commerce.Persistence.Repositories
{
    public class BaseRepository<T>(E_CommerceDbContext context) : IBaseRepository<T> where T : BaseEntity,new()

    {
        public async Task AddAsync(T model)
        {
            await context.AddAsync(model);
        }

        public async Task AddRangeAsync(IEnumerable<T> models)
        {
            await context.AddRangeAsync(models);
        }

        public async Task DeleteAsync(T model)
        {
            await Task.Run(() => context.Remove(model));
        }

        public async Task DeleteRangeAasync(IEnumerable<T> models)
        {
            await Task.Run(()=> context.RemoveRange(models));
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity=context.Set<T>().Find(id);
            await Task.Run(() => context.Remove(entity));
        }

       

        public Task UpdateASync(T model)
        {
            return Task.Run(() => context.Update(model));   
        }

        public async Task UpdateBYIdAsync(Guid id)
        {
            var entity = context.Set<T>().Find(id);
            await Task.Run(()=>context.Update(entity));
        }

        public Task UpdateRangeASync(IEnumerable<T> models)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await context.Set<T>().ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T?> GetBYIdAsync(Guid id)
        {
            return (await context.Set<T>().FindAsync(id))!;
        }

        #region Dapper Methods

        public async Task<int> ExecuteAsync(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? dbTransaction=null)
        {
            SqlConnection connection = new(context.Database.GetConnectionString());

            return await connection.ExecuteAsync(sql, param,dbTransaction,null,commandType);
        }
        public async Task<TEntity?> FirstOrDefaultAsync<TEntity>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            SqlConnection connection = new(context.Database.GetConnectionString());
            return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, transaction, null, commandType);
        }

        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedureAsync<TEntity>(string sql, object? parameter = null)
        {
            SqlConnection connection = new(context.Database.GetConnectionString());

            return await connection.QueryAsync<TEntity>(sql, parameter);
        }

        public async Task<int> CountAsync(Expression<Func<T,bool>> expression)
        {
            return await context.Set<T>().CountAsync(expression);
               
        }


        #endregion
    }
}
