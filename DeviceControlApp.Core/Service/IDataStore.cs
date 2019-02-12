using System;
namespace DeviceControlApp.Core.Service
{
    public interface IDataStore
    {
        void Put<T>(string key, T t);
        T Get<T>(string key);
        bool IsContainsKey();
    }
}
