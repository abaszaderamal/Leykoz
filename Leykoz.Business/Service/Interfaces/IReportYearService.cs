using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface IReportYearService
    {
        Task CreateAsync(ReportYearVM reportYearVm);
        Task DeleteAsync(int id);
        Task<List<ReportYear>> GetAllAsync();

        Task UpdateAsync(int id, ReportYearVM reportYearVm);
        Task<ReportYearVM> GetByIdAsync(int id);
        Task<List<ReportYearVMPlus>> GetAllReportYearWithAllCount();
    }
}