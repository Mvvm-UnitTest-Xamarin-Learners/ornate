using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ViewModel;
using DeviceControlApp.View;
using Xamarin.Forms;

namespace DeviceControlApp.ViewMap
{
    public class PageService:IPageService
    {
        private Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public PageService()
        {
            MapViewToViewModel();
        }

        private void MapViewToViewModel()
        {
            _map.Add(typeof(HomePageViewModel), typeof(HomePage));
            _map.Add(typeof(LocationViewModel), typeof(ProductPage));
            _map.Add(typeof(LocationStatusViewModel), typeof(LocationStatusPage));

        }

        public async Task GoNext(object viewModel)
        {
            var viewmodeltype = viewModel.GetType();
            if (_map.ContainsKey(viewmodeltype))
            {
                var viewtype = _map[viewmodeltype];
                var page = (Page)Activator.CreateInstance(viewtype);
                page.BindingContext = viewModel;
                await Application.Current.MainPage.Navigation.PushModalAsync(page);

            }
            else
            {
                throw new Exception("Navigating to unmapped type");
            }
        }
    }
}
