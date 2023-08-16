using Leykoz.Core.Abstract.Repositories;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;

namespace Leykoz.Data.Concrete.Repositories
{
    public class ReportYearRepository:Repository<ReportYear>,IReportYearRepository
    {
        public ReportYearRepository(AppDbContext context) : base(context)
        {
        }
    }
}