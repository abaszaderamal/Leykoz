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
    public class InfoSlideRepository : Repository<InfoSlide>, IInfoSlideRepository
    {
        private readonly AppDbContext _context;

        public InfoSlideRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<InfoSlide>> GetPaginatedByDesending(int page, int size,
            Expression<Func<InfoSlide, bool>> exp = null)
        {
            return exp is null
                ? await _context
                    .InfoSlides
                    .OrderByDescending(p => p.Id)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync()
                : await _context
                    .InfoSlides
                    .OrderByDescending(p => p.Id)
                    .Where(exp)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync();
        }
    }
}