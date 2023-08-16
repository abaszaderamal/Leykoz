using Leykoz.Core.Abstract.Repositories;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;

namespace Leykoz.Data.Concrete.Repositories
{
    public class TargetRepository:Repository<Target>,ITargetRepository
    {
        public TargetRepository(AppDbContext context) : base(context)
        {
        }
    }
}