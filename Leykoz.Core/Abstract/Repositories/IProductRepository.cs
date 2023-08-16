using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leykoz.Core.Entities;

namespace Leykoz.Core.Abstract.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllByDesendingAsync();

        Task<List<Product>> GetAllPaginatedDesendingAsync(int page, int size,
            Expression<Func<Product, bool>> exp = null);
    }
}