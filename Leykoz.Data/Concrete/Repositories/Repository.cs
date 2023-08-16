using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leykoz.Core.Abstract.Repositories;
using Leykoz.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Leykoz.Data.Concrete.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;


        public Repository(AppDbContext context)
        {
            _context = context;
        }


        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> GetAsync(Expression<Func<T, bool>> exp = null, params string[] includes)
        {
            var query = GetQuery(includes);
            return exp is null
                ? await query.FirstOrDefaultAsync()
                : await query.Where(exp).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp = null, params string[] includes)
        {
            var query = GetQuery(includes);
            return exp is null
                ? await query.ToListAsync()
                : await query.Where(exp).ToListAsync();
        }

        public async Task<List<T>> GetAllPaginatedAsync(int page, int size,
            Expression<Func<T, bool>> exp = null, params string[] includes)
        {
            var query = GetQuery(includes);
            return exp is null
                ? await query.Skip((page - 1) * size).Take(size).ToListAsync()
                : await query.Where(exp).Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public async Task<int> GetTotalCountAsync(Expression<Func<T, bool>> exp = null)
        {
            return exp is null
                ? await Table.CountAsync()
                : await Table.Where(exp).CountAsync();
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> exp)
        {
            return await Table.AnyAsync(exp);
            // return await _context.Set<T>().AnyAsync(exp);
        }

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            // await _context.Set<T>().AddAsync(entity);
        }

        public void Remove(T entity)
        {
            Table.Remove(entity);
            // _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            Table.Update(entity);
            // _context.Set<T>().Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IQueryable<T> GetQuery(params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }
        
        
        
        
        // private IQueryable<T> GetQuery(params string[] includes)
        // {
        //     var query = Table.AsQueryable();
        //     if (includes != null)
        //     {
        //         foreach (var item in includes)
        //         {
        //             query = query.Include(item);
        //         }
        //     }
        //
        //     return query;
        // }
    }
}