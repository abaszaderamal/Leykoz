using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Implementations
{
    public class ReportAmountService : IReportAmountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportAmountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(int id, ReportAmountVM reportAmountVm)
        {
            await _unitOfWork
                .ReportAmountRepository
                .CreateAsync(
                    new ReportAmount() { Amount = reportAmountVm.Amount, CreatedAt = DateTime.Now, ReportId = id });
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ReportAmount dbReport = await _unitOfWork.ReportAmountRepository.GetAsync(r => r.Id == id);
            dbReport.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ReportAmount>> GetAllAsync()
        {
            return await _unitOfWork.ReportAmountRepository
                .GetAllExcelAsync();
        }

        public async Task<List<ReportAmount>> GetAllByDateAsync(DateTime dateTime)
        {
            return await GetAllByDateAsync(dateTime);
        }

        public async Task<Paginate<ReportAmount>> GetPasinateAllAsync(int page, int size)
        {
            Paginate<ReportAmount> paginate = new Paginate<ReportAmount>()
            {
                Items = await _unitOfWork.ReportAmountRepository.GetAllPaginatedAsync(page),
                CurrentPage = page,
                AllPageCount = await _unitOfWork.ReportAmountRepository.GetPageCountAsync(size)
            };
            return paginate;
        }
    }
}