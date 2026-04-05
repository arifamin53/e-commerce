using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.RRModels.Appfile;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Persistence.Repositories
{
    public class AppFileRepository(E_CommerceDbContext context) : BaseRepository<AppFile>(context), IAppFileRepository
    {
        public async Task<int> DeleteAppFilesBYEntityId(Guid id)
        {
            string query = $@"Delete From Appfiles where entityId=@id";
            return await ExecuteAsync(query,new {id});
        }

        public async Task<IEnumerable<AppFileResponse>> GetFileByEntityId(Guid entityId)
        {
            string sql = $@"select * from AppFiles where entityId=@entityId";
            return await ExecuteStoredProcedureAsync<AppFileResponse>(sql,new {entityId});
        }
    }
}
