using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface IReportAmountService
    {
        Task CreateAsync(int id,ReportAmountVM reportAmountVm);
        Task DeleteAsync(int id);
        Task<List<ReportAmount>> GetAllAsync();
        Task<List<ReportAmount>> GetAllByDateAsync(DateTime dateTime);
        Task<Paginate<ReportAmount>> GetPasinateAllAsync(int page,int size);
        



    }
}