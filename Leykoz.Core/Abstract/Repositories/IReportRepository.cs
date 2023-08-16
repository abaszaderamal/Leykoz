using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Core.Entities;

namespace Leykoz.Core.Abstract.Repositories
{
    public interface IReportRepository:IRepository<Report>
    {
        Task<List<Report>> GetAllPaginatedAsync(int page);
        Task<int> GetPageCountAsync(int take);
        Task<List<Report>> GetAllByDateAsync(DateTime dateTime);
        Task<Report> GetById(int id);
        Task<int> GetCountByDateAsync(DateTime dateTime);
        Task<int> GetLastId();
    }
}