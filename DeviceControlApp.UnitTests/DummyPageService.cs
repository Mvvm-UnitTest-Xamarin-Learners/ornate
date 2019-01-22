using System;
using System.Threading.Tasks;
using DeviceControlApp.ViewModel;

namespace DeviceControlApp.UnitTests
{
    public class DummyPageService:IPageService
    {
        private object _viewModel;

        public Type GetViewModelPageType()
        {
            return _viewModel.GetType();
        }

        public async Task GoNext(Type viewModelType)
        {
            throw new NotImplementedException();
        }

        public async Task GoNext(object viewModel)
        {
            _viewModel = viewModel;
        }

    }
}
