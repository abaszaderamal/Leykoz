using Leykoz.Core.Abstract.Repositories;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;

namespace Leykoz.Data.Concrete.Repositories
{
    public class SiteSettingRepository : Repository<SiteSetting>, ISiteSettingRepository
    {
        public SiteSettingRepository(AppDbContext context) : base(context)
        {
        }
    }
}