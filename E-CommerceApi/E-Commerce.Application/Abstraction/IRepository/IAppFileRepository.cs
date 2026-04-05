using E_Commerce.Application.RRModels.Appfile;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.IRepository
{
    public interface IAppFileRepository:IBaseRepository<AppFile>
    {
        public Task<IEnumerable<AppFileResponse>> GetFileByEntityId(Guid entityId);

        public Task<int> DeleteAppFilesBYEntityId(Guid id);
    }
}
