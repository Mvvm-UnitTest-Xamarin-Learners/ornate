using System;
using System.Collections.Generic;
using DeviceControlApp.Core.Service;

namespace DeviceControlApp.Core.ServiceImpln
{
    public class DataStore : IDataStore
    {
       
        private Dictionary<string, object> _map = new Dictionary<string, object>();

        public T Get<T>(string key)
        {

            if (_map.ContainsKey(key))
            {
                return (T)_map[key];
            }
            else
            {
                throw new Exception("obj not found");
            }
        }

        public bool IsDataAvailable(string key)
        {
            if (_map.ContainsKey(key))
                return true;
            return false;
        }

        public void Put<T>(string key, T t)
        {
            if (_map.ContainsKey(key))
            {
                _map[key] = t;
                return;
            }
            _map.Add(key, t);
        }


    }
}
