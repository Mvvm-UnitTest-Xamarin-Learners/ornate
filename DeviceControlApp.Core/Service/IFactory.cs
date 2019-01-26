namespace DeviceControlApp.Core.Service
{
    public interface IFactory
    {
        void Initialize();
        T Get<T>();
    }
}