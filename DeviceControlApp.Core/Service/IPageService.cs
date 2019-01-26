using System.Threading.Tasks;

namespace DeviceControlApp.Core.Service
{
    public interface IPageService
    {
        Task GoNext(object viewModel);
    }
}