using System.Threading.Tasks;
using Leykoz.Business.ViewModels;

namespace Leykoz.Business.Service.Interfaces
{
    public interface IDashBoardService
    {
        Task<DashBoardVM> GetAllCountAsync();
    }
}