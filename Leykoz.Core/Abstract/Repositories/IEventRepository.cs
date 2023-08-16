using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leykoz.Core.Entities;

namespace Leykoz.Core.Abstract.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<List<Event>> GetAllByDesendingAsync();

    }
}