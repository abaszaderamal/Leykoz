using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leykoz.Core.Entities;

namespace Leykoz.Core.Abstract.Repositories
{
    public interface INewsRepository:IRepository<News>
    {
        Task<List<News>> GetAllPaginatedAsync(int page);
        Task<int> GetPageCountAsync(int take);
        Task<List<News>> GetLastNews(int count);
        Task<List<News>> GetPaginatedByDesending(int page, int size,
            Expression<Func<News, bool>> exp = null);
    }
}