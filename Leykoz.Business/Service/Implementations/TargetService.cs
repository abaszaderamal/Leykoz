using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Implementations
{
    public class TargetService : ITargetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TargetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Target>> GetAllAcync()
        {
            return await _unitOfWork.TargetRepository.GetAllAsync(p => p.IsDeleted == false);
        }

        public async Task DeleteAsync(int id)
        {
            Target dbTarget = await _unitOfWork.TargetRepository.GetAsync(p => p.Id == id);
            dbTarget.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task<Target> GetByIdAsync(int id)
        {
            return await _unitOfWork.TargetRepository.GetAsync(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task Add(TargetVM targetVm)
        {
            await _unitOfWork.TargetRepository.CreateAsync(new Target() {Content = targetVm.Content});
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, TargetVM targetVm)
        {
            Target dbTarget = await _unitOfWork.TargetRepository.GetAsync(p => p.Id == id);
            dbTarget.Content = targetVm.Content;
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return (await _unitOfWork.TargetRepository.GetAsync(p => p.Id == id && p.IsDeleted == false)) is null
                ? false
                : true;
        }
    }
}