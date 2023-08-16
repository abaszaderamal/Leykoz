using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leykoz.Business.Service.Interfaces
{
    public interface ISiteSettingService
    {
        // Task<string> GetAsync(string key);
        Task<Dictionary<string, string>> GetAllAsync();
        Task<string> GetValueByKeyAsync(string key);
        Task SetValueByKeyAsync(string key, string value);
        Task SetValueytvideo( string value);
    }
}