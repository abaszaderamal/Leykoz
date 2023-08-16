using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface ISlideService
    {
        Task<List<Slide>> GetAllAsync();
        //   Task<Slide> GetAsync(int id);
        Task Create(SlidePostVM slideVm );
        ///  Task Update(int id, Slide);
        Task Remove(int id);
    }
}