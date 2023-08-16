using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Implementations
{
    public class ReportYearService : IReportYearService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportYearService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(ReportYearVM reportYearVm)
        {
            ReportYear report = new ReportYear
            {
                Title = reportYearVm.Title,
                HeadTitle = reportYearVm.HeadTitle,
                Year = reportYearVm.Year
            };
            await _unitOfWork.ReportYearRepository.CreateAsync(report);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ReportYear reportYear = await _unitOfWork.ReportYearRepository.GetAsync(p => p.Id == id);
            reportYear.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ReportYear>> GetAllAsync()
        {
            return await _unitOfWork.ReportYearRepository.GetAllAsync(p => p.IsDeleted == false);
        }

        public async Task UpdateAsync(int id, ReportYearVM reportYearVm)
        {
            ReportYear reportYear = await _unitOfWork.ReportYearRepository.GetAsync(p => p.Id == id);
            reportYear.Title = reportYearVm.Title;
            reportYear.Year = reportYearVm.Year;
            reportYear.HeadTitle = reportYearVm.HeadTitle;

            await _unitOfWork.SaveAsync();
        }

        public async Task<ReportYearVM> GetByIdAsync(int id)
        {
            var reportYear = await _unitOfWork.ReportYearRepository
                .GetAsync(p => p.Id == id && p.IsDeleted == false);
            ReportYearVM reportYearVM = new ReportYearVM
            {
                Title = reportYear.Title,
                Year = reportYear.Year,
                HeadTitle = reportYear.HeadTitle
            };
            return reportYearVM;
        }

        public async Task<List<ReportYearVMPlus>> GetAllReportYearWithAllCount()
        {
            List<ReportYearVMPlus> reportYearVmPlusList = new List<ReportYearVMPlus>();
            List<ReportYear> dbREports = await GetAllAsync();
            foreach (var item in dbREports)
            {
                reportYearVmPlusList.Add(new ReportYearVMPlus()
                {
                    id = item.Id,
                    Title = item.Title,
                    Year = item.Year,
                    HeadTitle = item.HeadTitle,
                    ReportCount = await _unitOfWork.ReportRepository.GetCountByDateAsync(item.Year)
                });
            }

            return reportYearVmPlusList;
        }
    }
}