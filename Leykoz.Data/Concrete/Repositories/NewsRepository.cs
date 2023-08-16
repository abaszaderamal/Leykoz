using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leykoz.Core.Abstract.Repositories;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Leykoz.Data.Concrete.Repositories
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        readonly private AppDbContext _context;

        public NewsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<News>> GetAllPaginatedAsync(int page)
        {
            return await _context
                .News
                .Where(p=>p.IsDeleted==false)
                .OrderByDescending(p => p.Id)
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Skip((page - 1) * 9)
                .Take(9)
                .ToListAsync();
        }

        public async Task<int> GetPageCountAsync(int take)
        {
            int count = await _context
                .News
                .AsNoTracking()
                .Where(p => p.IsDeleted == false).CountAsync();
            return (int) Math.Ceiling(((decimal) count / take));
        }

        public async Task<List<News>> GetLastNews(int count)
        {
            return await _context
                .News
                .OrderByDescending(p => p.Id)
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<News>> GetPaginatedByDesending(int page, int size, Expression<Func<News, bool>> exp = null)
        {
            return exp is null
                ? await _context
                    .News
                    .OrderByDescending(p => p.Id)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync()
                : await _context
                    .News
                    .OrderByDescending(p => p.Id)
                    .Where(exp)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync();
        }
    }
}