using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface INewsService
    {
        Task Create(NewsPostVM newsPostVm);
        Task Update(int id, NewsPutVM newsPutVm);
        Task DeleteAsync(int id);
        Task<News> DetailAsync(int id);
        Task<Paginate<News>> GetAllPaginatedAsync(int page,int size);

        Task<News> GetByIdAsync(int id);
        Task<List<News>> GetLastNews(int count);
    }
}