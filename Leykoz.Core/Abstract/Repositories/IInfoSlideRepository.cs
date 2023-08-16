using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leykoz.Core.Entities;

namespace Leykoz.Core.Abstract.Repositories
{
    public interface IInfoSlideRepository : IRepository<InfoSlide>
    {
        Task<List<InfoSlide>> GetPaginatedByDesending(int page, int size,
            Expression<Func<InfoSlide, bool>> exp = null);
    }
}