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
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        readonly private AppDbContext _context;

        public ReportRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<Report>> GetAllPaginatedAsync(int page)
        {
            return await _context
                .Reports
                .OrderByDescending(p => p.Id)
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Skip((page - 1) * 9)
                .Take(9)
                .Include(p => p.ReportAmounts)
                .ToListAsync();
        }

        public async Task<int> GetPageCountAsync(int take)
        {
            int count = await _context
                .Reports
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                //         .Include(p => p.Savior)
                .CountAsync();
            return (int)Math.Ceiling(((decimal)count / take));
        }

        public async Task<List<Report>> GetAllByDateAsync(DateTime dateTime)
        {
            return await _context
                .Reports
                .AsNoTracking()
                .Where(p => p.CreatedAt.Year == dateTime.Year)
                .ToListAsync();
        }

        public async Task<Report> GetById(int id)
        {
            return await _context.Reports.Where(p => p.Id == id)
                .Include(p => p.ReportAmounts)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetCountByDateAsync(DateTime dateTime)
        {
            int count = 0;
            // List<Report> 
            var reports =  _context.Reports
                .Where(p => p.IsDeleted == false)
                .Include(p => p.ReportAmounts);
                
            foreach (var report in reports)
            {
                count += report.ReportAmounts.Where(p => p.IsDeleted == false).Count();
            }

            return count;

            return await _context
                .ReportAmounts
                .AsNoTracking()
                .Where(p => p.CreatedAt.Year == dateTime.Year && p.IsDeleted == false)
                .CountAsync();
        }

        public async Task<int> GetLastId()
        {
            Report lastReport = await _context.Reports.LastOrDefaultAsync(p => p.Name != String.Empty);
            return lastReport == null ? 0 : lastReport.Id;
        }
    }
}