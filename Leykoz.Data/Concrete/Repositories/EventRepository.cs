using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leykoz.Core.Abstract.Repositories;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Leykoz.Data.Concrete.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        readonly private AppDbContext _context;

        public EventRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllByDesendingAsync()
        {
            return await _context
                .Events
                .Where(p => p.IsDeleted == false)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }
    }
}