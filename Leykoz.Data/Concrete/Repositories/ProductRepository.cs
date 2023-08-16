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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllPaginatedDesendingAsync(int page, int size,
            Expression<Func<Product, bool>> exp = null)
        {
            return exp is null
                ? await
                    _context.Products.OrderByDescending(p=>p.Id).Skip((page - 1) * size).Take(size).ToListAsync()
                : await _context.Products.OrderByDescending(p=>p.Id).Where(exp).Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public async Task<List<Product>> GetAllByDesendingAsync()
        {
            return await _context
                .Products
                .Where(p => p.IsDeleted == false)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }
    }
}