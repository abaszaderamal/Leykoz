using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface IReportService
    {
        Task CreateAsync(ReportVM reportVm);
        Task<Paginate<Report>> GetPasinateAllAsync(int page,int size);
        Task DeleteAsync(int id);
        Task<List<Report>> GetAllAsync();
        Task<Report> GetByIdAsync(int id);
        Task<List<Report>> GetAllByDateAsync(DateTime dateTime);

        Task UpdateAsync(int id, ReportVM reportVm);
    }
}