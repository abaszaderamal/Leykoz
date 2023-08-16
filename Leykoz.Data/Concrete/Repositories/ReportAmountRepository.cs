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
    public class ReportAmountRepository : Repository<ReportAmount>, IReportAmountRepository
    {
        readonly private AppDbContext _context;

        public ReportAmountRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<ReportAmount>> GetAllPaginatedAsync(int page)
        {
            var amounts = await _context
                .ReportAmounts
                .OrderByDescending(p => p.Id)
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Skip((page - 1) * 9)
                .Take(9)
                .Include(p => p.Report)
                .Where(p => p.Report.IsDeleted == false)
                .ToListAsync();
            return amounts;
        }

        public async Task<List<ReportAmount>> GetAllExcelAsync()
        {
            return await _context
                .ReportAmounts
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Report).ToListAsync();
        }

        public async Task<int> GetPageCountAsync(int take)
        {
            int count = await _context
                .ReportAmounts
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Report)
                .Where(p => p.Report.IsDeleted == false)
                .CountAsync();
            return (int)Math.Ceiling(((decimal)count / take));
        }

        public async Task<List<ReportAmount>> GetAllByDateAsync(DateTime dateTime)
        {
            var amounts=await _context
                .ReportAmounts
                .Where(p => p.IsDeleted == false && p.CreatedAt.Year == dateTime.Year)
                .Include(p => p.Report).ToListAsync();
            return await _context
                .ReportAmounts
                .Where(p => p.IsDeleted == false && p.CreatedAt.Year == dateTime.Year)
                .Include(p => p.Report).ToListAsync();
        }
    }
}