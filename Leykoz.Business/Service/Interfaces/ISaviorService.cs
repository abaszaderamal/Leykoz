using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Interfaces
{
    public interface ISaviorService
    {
        Task CreateAsync(SaviorVM saviorVm);
        Task DeleteAsync(int id);

        Task<Paginate<Savior>> GetAllAsync(int page, int size);

        // Task<List<Savior>> GetAllAsync(string search);
        Task<PaginateFast<Savior>> GetAllPaginatedSAsync(string search, int page, int size);
    }
}