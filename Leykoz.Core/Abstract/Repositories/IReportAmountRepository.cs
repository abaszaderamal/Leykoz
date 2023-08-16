using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Core.Entities;

namespace Leykoz.Core.Abstract.Repositories
{
    public interface IReportAmountRepository : IRepository<ReportAmount>
    {
        Task<List<ReportAmount>> GetAllPaginatedAsync(int page);
        Task<List<ReportAmount>> GetAllExcelAsync();
        Task<int> GetPageCountAsync(int take);
        Task<List<ReportAmount>> GetAllByDateAsync(DateTime dateTime);

    }
}