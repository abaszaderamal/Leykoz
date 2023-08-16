using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Core.Entities;

namespace Leykoz.Core.Abstract.Repositories
{
    public interface ISaviorRepository : IRepository<Savior>
    {
        Task<List<Savior>> GetAllPaginatedFastAsync(int page, int size);

        Task<int> GetPageCountFast(int take);
        Task<List<Savior>> GetAllPaginatedSearchAsync(string search, int page, int size);
        Task<int> GetPageCountSearchAsync(int take, string search);
    }
}