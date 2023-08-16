using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface IInfoSlideService
    {
         Task<List<InfoSlide>> GetSlides(int page, int skip);
        Task<InfoSlide> GetByIDAsync(int id);
        Task<Paginate<InfoSlide>> GetAllPaginatedAsync(int page);
        Task<int> getPageCount(int take);
        Task Create(InfoSlidePostVM infoSlideVm);
        Task Update(int id, InfoSlidePutVM infoSlideVm);
        Task DeleteAsync(int id);
        Task<List<InfoSlide>> GetAllAsync();
        Task<List<InfoSlide>> GetAllRadAsync();
    }
}