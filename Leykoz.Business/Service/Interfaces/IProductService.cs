using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface IProductService
    {
        Task Create(ProductVM productVm);
        Task Update(int id, ProductUpdateVM productVm);
        Task DeleteAsync(int id);
        Task<Paginate<Product>> GetAllPaginatedAsync(int page);
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllRadAsync();
        
    }
}