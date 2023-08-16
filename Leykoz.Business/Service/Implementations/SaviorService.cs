using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Implementations
{
    public class SaviorService : ISaviorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaviorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(SaviorVM saviorVm)
        {
            var savior = new Savior()
            {
                FullName = saviorVm.FullName,
                Email = saviorVm.Email,
                Phone = saviorVm.Phone,
                ApplyContent = saviorVm.ApplyContent,
                ApplyType = saviorVm.ApplyType,
                CreatedDate = DateTime.Now
            };
            await _unitOfWork.SaviorRepository.CreateAsync(savior);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Savior dbSavior = await _unitOfWork.SaviorRepository.GetAsync(p => p.Id == id);
            dbSavior.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

//done
        public async Task<Paginate<Savior>> GetAllAsync(int page, int size)
        {
            // List<Savior> dbSaviors = await _context
            //     .Saviors
            //     .OrderByDescending(p => p.Id)
            //     .AsNoTracking()
            //     .Where(p => p.IsDeleted == false)
            //     .Skip((page - 1) * size)
            //     .Take(size)
            //     .ToListAsync();
            // Paginate<Savior> paginateFast = new Paginate<Savior>()
            // {
            //     Items = dbSaviors,
            //     CurrentPage = page,
            //     AllPageCount = await getPageCount(size)
            // }; 

            Paginate<Savior> paginateFast = new Paginate<Savior>()
            {
                Items = await _unitOfWork.SaviorRepository.GetAllPaginatedFastAsync(page, size),
                CurrentPage = page,
                AllPageCount = await _unitOfWork.SaviorRepository.GetPageCountFast(size)
            };
            return paginateFast;
            // // return await _unitOfWork.SaviorRepository.GetAllAsync(p => p.IsDeleted == false);
            // List<Savior> saviors = await _unitOfWork
            //     .SaviorRepository
            //     .GetAllPaginatedAsync(page, size, p => p.IsDeleted == false, "Reports");
            // Paginate<Savior> paginate = new Paginate<Savior>();
            // paginate.Items = saviors;
            // paginate.CurrentPage = page;
            // paginate.AllPageCount = await getPageCount(size);
            // return paginate;
        }

    

        // public async Task<List<Savior>> GetAllAsync(string search)
        // {
        //     return await _unitOfWork
        //         .SaviorRepository
        //         .GetAllAsync(p
        //             => p.IsDeleted == false &&
        //                p.FullName.ToLower().Trim().Contains(search.ToLower().Trim()) ==
        //                true, "Reports");
        // }
//search zamani istifade olunur
        public async Task<PaginateFast<Savior>> GetAllPaginatedSAsync(string search, int page, int size)
        {
            // HashSet<Savior> dbSaviors = _context
            //     .Saviors
            //     .AsNoTracking()
            //     .Where(p => p.IsDeleted == false &&
            //                 p.FullName.ToLower().Trim().Contains(search.ToLower().Trim()) == true)
            //     .Skip((page - 1) * size)
            //     .Take(size)
            //     .ToHashSet();
            // //      return exp is null
            // //         ? await query.Skip((page - 1) * size).Take(size).ToListAsync()
            // //         : await query.Where(exp).Skip((page - 1) * size).Take(size).ToListAsync();
            // // }
            // PaginateFast<Savior> paginateFast = new PaginateFast<Savior>()
            // {
            //     Items = dbSaviors,
            //     CurrentPage = page,
            //     AllPageCount = await getPageCountFastAsync(size, search)
            // };

            PaginateFast<Savior> paginateFast = new PaginateFast<Savior>()
            {
                Items = await _unitOfWork.SaviorRepository.GetAllPaginatedSearchAsync(search, page, size),
                CurrentPage = page,
                AllPageCount = await _unitOfWork.SaviorRepository.GetPageCountSearchAsync(size, search)
            };
            return paginateFast;
        }

        // private IQueryable<T> GetQuery(params string[] includes)
        // {
        //     var query = _context.Set<T>().AsQueryable();
        //     if (includes != null)
        //     {
        //         foreach (var item in includes)
        //         {
        //             query = query.Include(item);
        //         }
        //     }
        //
        //     return query;
        // }
        // public async Task<Paginate<Savior>> GetAllAsync(string search, int page, int size)
        // {
        //     List<Savior> saviors = await _unitOfWork
        //         .SaviorRepository
        //         .GetAllPaginatedAsync(page, size, p => p.IsDeleted == false &&
        //                                                p.FullName.ToLower().Trim().Contains(search.ToLower().Trim()) ==
        //                                                true, "Reports");
        //     Paginate<Savior> paginate = new Paginate<Savior>();
        //     paginate.Items = saviors;
        //     paginate.CurrentPage = page;
        //     paginate.AllPageCount = await getFilteredPageCount(search,size);
        //     return paginate;
        // }

        // public async Task<int> getPageCountFastAsync(int take, string search)
        // {
        //     var count = await _context
        //         .Saviors
        //         .AsNoTracking()
        //         .Where(p => p.IsDeleted == false &&
        //                     p.FullName.ToLower().Trim().Contains(search.ToLower().Trim()) ==
        //                     true).CountAsync();
        //     // var saviors = await _unitOfWork
        //     //     .SaviorRepository
        //     //     .GetAllAsync(p => p.IsDeleted == false,
        //     //         "Reports");
        //     // var count = saviors.Count;
        //     return (int) Math.Ceiling(((decimal) count / take));
        // }

        // public async Task<int> getPageCount(int take)
        // {
        //     int count = await _context
        //         .Saviors
        //         .AsNoTracking()
        //         .Where(p => p.IsDeleted == false)
        //         .CountAsync();
        //     return (int) Math.Ceiling(((decimal) count / take));
        // }

        // public async Task<int> getFilteredPageCount(string search, int take)
        // {
        //     var saviors = await _unitOfWork
        //         .SaviorRepository
        //         .GetAllAsync(p => p.IsDeleted == false &&
        //                           p.FullName.ToLower().Trim().Contains(search.ToLower().Trim()) ==
        //                           true,
        //             "Reports");
        //     var count = saviors.Count;
        //     return (int) Math.Ceiling(((decimal) count / take));
        // }
    }
}