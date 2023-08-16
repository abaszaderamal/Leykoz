using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface ITargetService
    {
        Task<List<Target>> GetAllAcync();
        Task DeleteAsync(int id);
        Task<Target> GetByIdAsync(int id);
        Task Add(TargetVM targetVm);
        Task Update(int id, TargetVM targetVm);
        Task<bool> IsExist(int id);
    }
}