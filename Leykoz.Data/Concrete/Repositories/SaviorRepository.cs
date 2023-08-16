using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leykoz.Core.Abstract.Repositories;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Leykoz.Data.Concrete.Repositories
{
    public class SaviorRepository : Repository<Savior>, ISaviorRepository
    {
        readonly private AppDbContext _context;

        public SaviorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Savior>> GetAllPaginatedFastAsync(int page, int size)
        {
            return await _context
                .Saviors
                .Where(p=>p.IsDeleted==false)
                .OrderByDescending(p => p.Id)
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
        }

        public async Task<int> GetPageCountFast(int take)
        {
            int count = await _context
                .Saviors
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .CountAsync();
            return (int) Math.Ceiling(((decimal) count / take));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns>search result nu pagination formada result uchun</returns>
        public async Task<List<Savior>> GetAllPaginatedSearchAsync(string search, int page, int size)
        {
            List<Savior> dbSaviors = await _context
                .Saviors
                .AsNoTracking()
                .Where(p => p.IsDeleted == false &&
                            p.FullName.ToLower().Trim().Contains(search.ToLower().Trim()) == true)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            return dbSaviors;
        }

      

        public async Task<int> GetPageCountSearchAsync(int take, string search)
        {
            int count = await _context
                .Saviors
                .AsNoTracking()
                .Where(p => p.IsDeleted == false &&
                            p.FullName.ToLower().Trim().Contains(search.ToLower().Trim()) ==
                            true).CountAsync();
            return (int) Math.Ceiling(((decimal) count / take));
        }
    }
}