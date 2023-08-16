using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Implementations
{
    public class SiteSettingService : ISiteSettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SiteSettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            var dbdata = await _unitOfWork.SiteSettingRepository.GetAllAsync();
            var result = dbdata.ToDictionary(p => p.Key, p => p.Value);
            return result;
        }

        public async Task<string> GetValueByKeyAsync(string key)
        {
            return (await _unitOfWork.SiteSettingRepository.GetAsync(p => p.Key == key)).Value;
        }

        public async Task SetValueByKeyAsync(string key, string value)
        {
            SiteSetting dbSiteSetting = await _unitOfWork.SiteSettingRepository.GetAsync(p => p.Key == key);
            dbSiteSetting.Value = value;
            _unitOfWork.SiteSettingRepository.Update(dbSiteSetting);
            await _unitOfWork.SaveAsync();
        }

        public async Task SetValueytvideo(string value)
        {
            string result = value;
            string key = "youtublelink";
            if (!value.Contains("embed"))
            {
                string rvalue = value.Substring(32);
                result = "https://www.youtube.com/embed/" + rvalue;
            }
       
            SiteSetting dbSiteSetting = await _unitOfWork.SiteSettingRepository.GetAsync(p => p.Key == key);
            dbSiteSetting.Value = result;
            _unitOfWork.SiteSettingRepository.Update(dbSiteSetting);
            await _unitOfWork.SaveAsync();
        }
    }
}