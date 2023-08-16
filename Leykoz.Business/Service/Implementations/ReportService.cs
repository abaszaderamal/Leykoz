using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(ReportVM reportVm)
        {
            int lastId = await _unitOfWork.ReportRepository.GetTotalCountAsync();
            //int lastId = 5;
            string resultPN = "LA";
            for (int i = 0; i < 6 - lastId.ToString().Length; i++)
            {
                resultPN += "0";
            }

            resultPN += (lastId + 1).ToString();

            Report report = new Report()
            {
                Name = reportVm.Name,
                SurName = reportVm.SurName,
                IsPublic = !reportVm.IsPublic,
                PrivateName = resultPN,
                CreatedAt = DateTime.Now,
            };
            await _unitOfWork.ReportRepository.CreateAsync(report);
            await _unitOfWork.SaveAsync();
        }

        // public async Task<bool> CheckUnique(string uniq)
        // {
        //     
        //     
        // }


        public async Task DeleteAsync(int id)
        {
            Report dbReport = await _unitOfWork.ReportRepository.GetAsync(r => r.Id == id);
            dbReport.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Report>> GetAllAsync()
        {
            return await _unitOfWork.ReportRepository.GetAllAsync(r => r.IsDeleted == false);
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await _unitOfWork.ReportRepository.GetById(id);
        }

        public async Task UpdateAsync(int id, ReportVM reportVm)
        {
            Report report = await _unitOfWork.ReportRepository.GetAsync(p => p.Id == id);
            report.Name = reportVm.Name;
            report.SurName = reportVm.SurName;
            report.IsPublic = !reportVm.IsPublic;


            await _unitOfWork.SaveAsync();
        }

        public async Task<Paginate<Report>> GetPasinateAllAsync(int page, int size)
        {
            // List<Report> reports = await _unitOfWork
            //     .ReportRepository
            //     .GetAllPaginatedAsync(page, size, p => p.IsDeleted == false && p.Savior.IsDeleted == false, "Savior");
            // Paginate<Report> paginate = new Paginate<Report>();
            // paginate.Items = reports;
            // paginate.CurrentPage = page;
            // paginate.AllPageCount = await getPageCount(size);

            Paginate<Report> paginate = new Paginate<Report>()
            {
                Items = await _unitOfWork.ReportRepository.GetAllPaginatedAsync(page),
                CurrentPage = page,
                AllPageCount = await _unitOfWork.ReportRepository.GetPageCountAsync(size)
            };
            return paginate;
        }

        public async Task<List<Report>> GetAllByDateAsync(DateTime dateTime)
        {
            return await _unitOfWork.ReportRepository.GetAllByDateAsync(dateTime);
        }
        // public async Task<int> getPageCount(int take)
        // {
        //     var products = await _unitOfWork
        //         .ReportRepository
        //         .GetAllAsync(p => p.IsDeleted == false && p.Savior.IsDeleted == false,
        //             "Savior");
        //     var productCount = products.Count;
        //     return (int) Math.Ceiling(((decimal) productCount / take));
        // }
    }
}