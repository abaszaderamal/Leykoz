using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Implementations
{
    public class DashBoardService:IDashBoardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashBoardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DashBoardVM> GetAllCountAsync()
        {
            DashBoardVM boardVm = new DashBoardVM()
            {
                ProductCount = await _unitOfWork.ProductRepository.GetTotalCountAsync(),
                InfoSliderCount = await _unitOfWork.InfoSlideRepository.GetTotalCountAsync(),
                SaviorCount =await _unitOfWork.SaviorRepository.GetTotalCountAsync(),
                NewsCount = await _unitOfWork.NewsRepository.GetTotalCountAsync()
            };
            return boardVm;
        }
    }
}