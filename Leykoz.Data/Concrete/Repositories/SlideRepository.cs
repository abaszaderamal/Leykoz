using Leykoz.Core.Abstract.Repositories;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;

namespace Leykoz.Data.Concrete.Repositories
{
    public class SlideRepository : Repository<Slide>, ISilideRepository
    {
        public SlideRepository(AppDbContext context) : base(context)
        {
        }
    }
}