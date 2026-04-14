using E_commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace E_Commerce.Application.Abstraction.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
       public Task AddAsync(T model);
        public Task AddRangeAsync(IEnumerable<T> models);
        public Task UpdateASync(T model);
        public Task UpdateBYIdAsync(Guid id);
        public Task UpdateRangeASync(IEnumerable<T> models);
        public Task DeleteAsync(T model);
        public Task DeleteByIdAsync(Guid id);
        public Task DeleteRangeAasync(IEnumerable<T> models);
        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetBYIdAsync(Guid id);

        #region DapperMethods
        public Task<int> ExecuteAsync(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? dbTransaction = null);
        public  Task<TEntity?> FirstOrDefaultAsync<TEntity>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);
        public Task<IEnumerable<TEntity>> ExecuteStoredProcedureAsync<TEntity>(string storedProcedure, object? parameter=null);
        #endregion
    }
}
