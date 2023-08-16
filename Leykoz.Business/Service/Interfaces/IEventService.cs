using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface IEventService
    {
        Task<EventUpdateVM> GetByIdAsync(int id);
        Task<List<Event>> GetAllAsync();
        Task AddAsync(EventVM eventVm);
        Task UpdateAsync(int Id, EventUpdateVM eventVm);
        Task DeleteAsync(int id);

    }
}