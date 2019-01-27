using System;
using System.Threading.Tasks;
using DeviceControlApp.Core.Service;

namespace DeviceControlApp.NunitTests
{
    public class DummyPageService:IPageService
    {
        private object _viewModel;

        public Type GetViewModelPageType()
        {
            return _viewModel.GetType();
        }

        public async Task GoNext(object viewModel)
        {
            _viewModel = viewModel;
        }

    }
}
